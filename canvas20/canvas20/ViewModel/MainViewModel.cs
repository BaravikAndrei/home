using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Linq;
using System.Windows.Shapes;
using System.Collections.Generic;
using System;

namespace canvas20
{
    public class MainViewModel : Behavior<Panel>, INotifyPropertyChanged
    {
        #region BoxItems definition  
        private ObservableCollection<Box> boxes = new ObservableCollection<Box>();

        private Box selectedBox = new Box();
        private Conector selectedConector = new Conector();
        public int SizeOfBox = 50;
        public static int counter = 1;
        public static int counterLine = 1;
        private double _panelX;
        private double _panelY;

        public double PanelX
        {
            get { return _panelX; }
            set
            {
                if (value.Equals(_panelX)) return;
                _panelX = value;
                OnPropertyChanged();
            }
        }
        public double PanelY
        {
            get { return _panelY; }
            set
            {
                if (value.Equals(_panelY)) return;
                _panelY = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Box> Boxes
        {
            get { return boxes; }
            set
            {
                boxes = value;
            }
        }

        public Box SelectedBox
        {
            get { return selectedBox; }
            set
            {
                selectedBox = value;
                OnPropertyChanged("SelectedBox");
            }
        }

        public Conector SelectetConector
        {
            get { return selectedConector; }
            set
            {
                selectedConector = value;
                OnPropertyChanged("SelectedConector");
            }
        }
        private ICommand addBox;
        public ICommand AddBox
        {
            get
            {
                return addBox ?? (addBox = new RelayCommand(() =>
                {
                    SelectetConector = new Conector { PosX = SizeOfBox / 2 - 2, PosY = SizeOfBox / 2 - 2, SizeOfConector = SizeOfBox / 10, IdOfBox = counter };
                    SelectedBox = new Box { Size = SizeOfBox, ID = counter++, AllConector = SelectetConector };
                    Boxes.Add(SelectedBox);

                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
        #region ConnectorLineItems definition
        public static readonly DependencyProperty MouseYProperty = DependencyProperty.Register(
          "MouseY", typeof(double), typeof(MainViewModel), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty MouseXProperty = DependencyProperty.Register(
           "MouseX", typeof(double), typeof(MainViewModel), new PropertyMetadata(default(double)));
        private static ObservableCollection<ConectorLine> lines = new ObservableCollection<ConectorLine>();
        public static ConectorLine selectedline = new ConectorLine();
        public ObservableCollection<ConectorLine> Lines
        {
            get { return lines; }
            set
            {
                lines = value;
            }
        }

        public static ConectorLine PrewiewConnectorLine = new ConectorLine();////////////////////////////////////////////////////////////////////////

        public static ObservableCollection<ConectorLine> previewConnectorLineDisp = new ObservableCollection<ConectorLine>();//////////////////////////////////////////////////////////////////////////////////
        public static ObservableCollection<ConectorLine> PreviewConnectorLineDisp
        {
            get { return previewConnectorLineDisp; }
            set
            {
                previewConnectorLineDisp = value;
            }
        }////////////////////////////////////////////////////////////////////////////////////////////////////////
        public double MouseY
        {
            get { return (double)GetValue(MouseYProperty); }
            set { SetValue(MouseYProperty, value); }
        }
        public double MouseX
        {
            get { return (double)GetValue(MouseXProperty); }
            set { SetValue(MouseXProperty, value); }
        }


        double x;
        double y;
        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var pos = mouseEventArgs.GetPosition(AssociatedObject);

            var convas = sender as Canvas;
            selectedline = new ConectorLine();
            if (convas == null)
                return;
            var parent = Application.Current.MainWindow;
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(convas, mouseEventArgs.GetPosition(convas));
            var element = hitTestResult.VisualHit;
            selectedline = new ConectorLine();
            selectedline.StartedId = element.GetValue(Canvas.UidProperty).ToString();
            if (element.GetType().ToString() == "System.Windows.Shapes.Rectangle")
            {
                x = Mouse.GetPosition((IInputElement)element).X - 2.5;//////////////////////////////////
                y = Mouse.GetPosition((IInputElement)element).Y - 2.5;//////////////////////////////////
                selectedline.Start.X = pos.X - x;
                selectedline.Start.Y = pos.Y - y;
                selectedline.Finish.X = pos.X - x;
                selectedline.Finish.Y = pos.Y - y;

                PrewiewConnectorLine.Start.X = pos.X - x;
                PrewiewConnectorLine.Start.Y = pos.Y - y;

                PreviewConnectorLineDisp.Add(PrewiewConnectorLine);
            }
        }
        private void AssociatedObjectOnMouseMove1(object sender, MouseEventArgs mouseEventArgs)
        {
            var pos = mouseEventArgs.GetPosition(AssociatedObject);
            var convas = sender as Canvas;

            if (convas == null)
                return;
            var parent = Application.Current.MainWindow;
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(convas, mouseEventArgs.GetPosition(convas));
            var element = hitTestResult.VisualHit;

            selectedline.FinishedId = element.GetValue(Canvas.UidProperty).ToString();
            if (selectedline.StartedId != selectedline.FinishedId && element.GetValue(Canvas.DataContextProperty).ToString() == "canvas20.Conector" && element is System.Windows.Shapes.Rectangle)
            {
                x = Mouse.GetPosition((IInputElement)element).X - 2.5;//////////////////////////////////
                y = Mouse.GetPosition((IInputElement)element).Y - 2.5;//////////////////////////////////
                selectedline.Finish.X = pos.X - x;
                selectedline.Finish.Y = pos.Y - y;
                selectedline.LineId = counterLine++;
                if (selectedline.Start.X > 0)
                {
                    Lines.Add(selectedline);
                }

            }
        }
        private void LineOnMouseMuve(object sender, MouseEventArgs mouseEventArgs)
        {
            var pos = mouseEventArgs.GetPosition(AssociatedObject);
            selectedline.Finish.X = pos.X;
            selectedline.Finish.Y = pos.Y;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= AssociatedObjectOnMouseMove;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObjectOnMouseMove1;
            AssociatedObject.MouseLeftButtonDown -= DeliteLine;
        }


        #endregion
        #region Drag defenition
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseMove;
            AssociatedObject.MouseLeftButtonUp += AssociatedObjectOnMouseMove1;

            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnDraggable;
            AssociatedObject.MouseLeftButtonUp += AssociatedObjectOffDraggable;
            AssociatedObject.PreviewMouseMove += AssociatedObjectOnMoove;

            AssociatedObject.MouseLeftButtonDown += AssociatedObjectConnectorsOnMoove;
            AssociatedObject.MouseLeftButtonUp += AssociatedObjectConnectorsOffMoove;
            AssociatedObject.MouseLeftButtonDown += DeliteLine;
        }
        static bool OnDrag;
        static DependencyObject element;
        static DependencyObject elementLine;
        static double curMousePosInElementY;
        static double curMousePosInElementX;

        private void AssociatedObjectOnDraggable(object sender, MouseEventArgs mouseEventArgs)
        {
            OnDrag = true;
            var canvas = sender as Canvas;
            if (canvas == null)
                return;

            HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, mouseEventArgs.GetPosition(canvas));
            element = hitTestResult.VisualHit;

            curMousePosInElementY = (double)Mouse.GetPosition(null).Y - (double)element.GetValue(Canvas.TopProperty);
            curMousePosInElementX = (double)Mouse.GetPosition(null).X - (double)element.GetValue(Canvas.LeftProperty);

        }
        private void AssociatedObjectOnMoove(object sender, MouseEventArgs mouseEventArgs)
        {
            PrewiewConnectorLine.Finish.X = Mouse.GetPosition(null).X - 3;
            PrewiewConnectorLine.Finish.Y = Mouse.GetPosition(null).Y + 3;
            if (OnDrag == true)
            {

                var parent = Application.Current.MainWindow;
                //int tickX = (int)((Mouse.GetPosition(parent).X - curMousePosInElementX));
                //int tickY = (int)((Mouse.GetPosition(parent).Y - curMousePosInElementY));

                if (element is Canvas)
                {
                    element.SetValue(Canvas.LeftProperty, (Mouse.GetPosition(parent).X - curMousePosInElementX));
                    element.SetValue(Canvas.TopProperty, (Mouse.GetPosition(parent).Y - curMousePosInElementY));
                }
                

            }
        }
        private void DeliteLine(object sender, MouseEventArgs mouseEventArgs)
        {
            var line = sender as Canvas;
            if (line == null)
            {
                return;
            }
            HitTestResult hitTestResultLine = VisualTreeHelper.HitTest(line, mouseEventArgs.GetPosition(line));
            elementLine = hitTestResultLine.VisualHit;
            if (elementLine is System.Windows.Shapes.Line)
            {
                Lines.Remove(Lines.Single(i => i.LineId == Convert.ToInt32(elementLine.GetValue(Line.UidProperty))));
            }
        }
        private void AssociatedObjectOffDraggable(object sender, MouseEventArgs mouseEventArgs)
        {
            OnDrag = false;
            PreviewConnectorLineDisp.Clear();
            AssociatedObject.MouseDown -= AssociatedObjectConnectorsMoove;
        }
        static bool OnMove;
        public DependencyObject elementt;
        public static List<ConectorLine> ConnectedLines;

        private void AssociatedObjectConnectorsOnMoove(object sender, MouseEventArgs mouseEventArgs)
        {
            OnMove = true;
            var canvas = sender as Canvas;
            if (canvas == null)
                return;
            elementt = new DependencyObject();
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, mouseEventArgs.GetPosition(canvas));
            elementt = hitTestResult.VisualHit;
            ConnectedLines = new List<ConectorLine>();
            if (elementt is Canvas)
            {
                foreach (ConectorLine cl in Lines)
                {
                    if ((cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 2.4 > 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.4) > 0) &&
                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 2.6 < 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.6) < 0) ||
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 2.4 > 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.4) > 0) &&
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 2.6 < 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.6) < 0) ||

                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 47.4 > 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.4) > 0) &&
                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 47.6 < 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.6) < 0) ||
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 47.4 > 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.4) > 0) &&
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 47.6 < 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.6) < 0) ||

                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.4 > 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (2.4) > 0) &&
                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.6 < 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (2.6) < 0) ||
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.4 > 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (2.4) > 0) &&
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.6 < 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (2.6) < 0) ||

                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.4 > 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (47.4) > 0) &&
                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.6 < 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (47.6) < 0) ||
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.4 > 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (47.4) > 0) &&
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.6 < 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (47.6) < 0)

                        )
                    {
                        ConnectedLines.Add(cl);
                        //if (ConnectedLines.Count == 4)
                        //{
                        //    MessageBox.Show(ConnectedLines.Count.ToString());
                        //}
                        }

                }
                AssociatedObject.PreviewMouseMove += AssociatedObjectConnectorsMoove;
            }

        }
        private void AssociatedObjectConnectorsMoove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (OnMove == true /*&& elementt is Canvas*/)
            {
                foreach (ConectorLine cl in ConnectedLines)
                {
                    if ((cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 2.4 > 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.4) > 0) &&
                       (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 2.6 < 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.6) < 0))
                    {
                        cl.Start.X += ((double)Mouse.GetPosition(null).X - (double)elementt.GetValue(Canvas.LeftProperty) - curMousePosInElementX);
                        cl.Start.Y += ((double)Mouse.GetPosition(null).Y - (double)elementt.GetValue(Canvas.TopProperty) - curMousePosInElementY);
                    }
                    else if ((cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 2.4 > 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.4) > 0) &&
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 2.6 < 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.6) < 0))
                    {
                        cl.Finish.X += ((double)Mouse.GetPosition(null).X - (double)elementt.GetValue(Canvas.LeftProperty) - curMousePosInElementX);
                        cl.Finish.Y += ((double)Mouse.GetPosition(null).Y - (double)elementt.GetValue(Canvas.TopProperty) - curMousePosInElementY);
                    }
                    else if ((cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 47.4 > 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.4) > 0) &&
                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 47.6 < 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.6) < 0))
                    {
                        cl.Start.X += ((double)Mouse.GetPosition(null).X - (double)elementt.GetValue(Canvas.LeftProperty) - curMousePosInElementX);
                        cl.Start.Y += ((double)Mouse.GetPosition(null).Y - (double)elementt.GetValue(Canvas.TopProperty) - curMousePosInElementY);
                    }
                    else if ((cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 47.4 > 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.4) > 0) &&
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 47.6 < 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (25.6) < 0))
                    {
                        cl.Finish.X += ((double)Mouse.GetPosition(null).X - (double)elementt.GetValue(Canvas.LeftProperty) - curMousePosInElementX);
                        cl.Finish.Y += ((double)Mouse.GetPosition(null).Y - (double)elementt.GetValue(Canvas.TopProperty) - curMousePosInElementY);
                    }
                    else if ((cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.4 > 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (2.4) > 0) &&
                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.6 < 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (2.6) < 0))
                    {
                        cl.Start.X += ((double)Mouse.GetPosition(null).X - (double)elementt.GetValue(Canvas.LeftProperty) - curMousePosInElementX);
                        cl.Start.Y += ((double)Mouse.GetPosition(null).Y - (double)elementt.GetValue(Canvas.TopProperty) - curMousePosInElementY);
                    }
                    else if ((cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.4 > 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (2.4) > 0) &&
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.6 < 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (2.6) < 0))
                    {
                        cl.Finish.X += ((double)Mouse.GetPosition(null).X - (double)elementt.GetValue(Canvas.LeftProperty) - curMousePosInElementX);
                        cl.Finish.Y += ((double)Mouse.GetPosition(null).Y - (double)elementt.GetValue(Canvas.TopProperty) - curMousePosInElementY);
                    }
                    else if ((cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.4 > 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (47.4) > 0) &&
                        (cl.Start.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.6 < 0) && (cl.Start.Y - (double)elementt.GetValue(Canvas.TopProperty) - (47.6) < 0))
                    {
                        cl.Start.X += ((double)Mouse.GetPosition(null).X - (double)elementt.GetValue(Canvas.LeftProperty) - curMousePosInElementX);
                        cl.Start.Y += ((double)Mouse.GetPosition(null).Y - (double)elementt.GetValue(Canvas.TopProperty) - curMousePosInElementY);
                    }
                    else if ((cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.4 > 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (47.4) > 0) &&
                        (cl.Finish.X - (double)elementt.GetValue(Canvas.LeftProperty) - 25.6 < 0) && (cl.Finish.Y - (double)elementt.GetValue(Canvas.TopProperty) - (47.6) < 0))
                    {
                        cl.Finish.X += ((double)Mouse.GetPosition(null).X - (double)elementt.GetValue(Canvas.LeftProperty) - curMousePosInElementX);
                        cl.Finish.Y += ((double)Mouse.GetPosition(null).Y - (double)elementt.GetValue(Canvas.TopProperty) - curMousePosInElementY);
                    }
                }
            }

        }
        private void AssociatedObjectConnectorsOffMoove(object sender, MouseEventArgs mouseEventArgs)
        {
            OnMove = false;
            ConnectedLines = new List<ConectorLine>();
            AssociatedObject.PreviewMouseMove -= AssociatedObjectConnectorsMoove;
        }
        #endregion

    }
}
