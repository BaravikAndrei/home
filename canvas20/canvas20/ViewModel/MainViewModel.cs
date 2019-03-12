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
using System;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System.Threading;

namespace canvas20
{
    public class MainViewModel : Behavior<Panel>, INotifyPropertyChanged
    {
        public int SizeOfConnector = 5;
        public int SizeOfBox = 100;
        #region BoxItems definition  
        private ObservableCollection<Box> boxes = new ObservableCollection<Box>();
        private Box selectedBox = new Box();
        //public int SizeOfBox = 50;
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
        #region BlockType1 defenition
        private ObservableCollection<BlockType1> blockType1s = new ObservableCollection<BlockType1>();
        private BlockType1 selectedBlockType1 = new BlockType1();

        //public static int counter = 1;
        //public static int counterLine = 1;
        //private double _panelX;
        //private double _panelY;

        public ObservableCollection<BlockType1> BlockType1s
        {
            get { return blockType1s; }
            set
            {
                blockType1s = value;
            }
        }

        public BlockType1 SelectedBlockType1
        {
            get { return selectedBlockType1; }
            set
            {
                selectedBlockType1 = value;
                OnPropertyChanged();
            }
        }


        private ICommand addBlockType1;
        //create new Box with Connectors
        public ICommand AddBlockType1
        {
            get
            {
                return addBlockType1 ?? (addBlockType1 = new RelayCommand(() =>
                {                    
                    //Connectors.Add(new Conector { PosX = SelectedBox.PosOfBoxX, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, SizeOfConector = SelectedBox.Size / 10, IdOfBox = counter });
                    //Connectors.Add(new Conector { PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY, SizeOfConector = SelectedBox.Size / 10, IdOfBox = counter });
                    //Connectors.Add(new Conector { SizeOfConector = SelectedBox.Size / 10, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size - 5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, IdOfBox = counter });
                    //Connectors.Add(new Conector { SizeOfConector = SelectedBox.Size / 10, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size - 5, IdOfBox = counter });

                    SelectedBlockType1 = new BlockType1 { MultiVisibility = Visibility.Collapsed, Size = SizeOfBox, ID = counter, PosOfBoxX = 0, PosOfBoxY = 0, SomeField1 = 0, SomeField2 = 0, Title = "BlockType1"};
                    BlockType1s.Add(SelectedBlockType1);

                    //SelectetConnector = new Conector { PosX = SelectedBox.PosOfBoxX, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, SizeOfConector = SelectedBox.Size / 10, IdOfBox = counter };
                    //SelectedBox.LeftConector = SelectetConnector;
                    //SelectetConnector = new Conector { PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY, SizeOfConector = SelectedBox.Size / 10, IdOfBox = counter };
                    //SelectedBox.TopConector = SelectetConnector;
                    //SelectetConnector = new Conector { SizeOfConector = SelectedBox.Size / 10, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size - 5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, IdOfBox = counter };
                    //SelectedBox.RightConector = SelectetConnector;
                    //SelectetConnector = new Conector { SizeOfConector = SelectedBox.Size / 10, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size - 5, IdOfBox = counter };
                    //SelectedBox.BottomConector = SelectetConnector;

                    Connectors.Add(new Conector { PosX = SelectedBlockType1.PosOfBoxX, PosY = SelectedBlockType1.PosOfBoxY + SelectedBlockType1.Size / 2 - 2.5, SizeOfConector = SizeOfConnector, IdOfBox = counter, BoxOfConnector = SelectedBlockType1 });
                    Connectors.Add(new Conector { PosX = SelectedBlockType1.PosOfBoxX + SelectedBlockType1.Size / 2 - 2.5, PosY = SelectedBlockType1.PosOfBoxY, SizeOfConector = SizeOfConnector, IdOfBox = counter, BoxOfConnector = SelectedBlockType1 });
                    Connectors.Add(new Conector { SizeOfConector = SizeOfConnector, PosX = SelectedBlockType1.PosOfBoxX + SelectedBlockType1.Size - 5, PosY = SelectedBlockType1.PosOfBoxY + SelectedBlockType1.Size / 2 - 2.5, IdOfBox = counter, BoxOfConnector = SelectedBlockType1 });
                    Connectors.Add(new Conector { SizeOfConector = SizeOfConnector, PosX = SelectedBlockType1.PosOfBoxX + SelectedBlockType1.Size / 2 - 2.5, PosY = SelectedBlockType1.PosOfBoxY + SelectedBlockType1.Size - 5, IdOfBox = counter, BoxOfConnector = SelectedBlockType1 });
                    counter++;
                    for (int i = Connectors.Count - 1; i > Connectors.Count - 5; i--)
                    {
                        SelectedBlockType1.ListConector.Add(Connectors.ElementAt(i));
                    }
                }));
            }
        }
        #endregion
        #region Connectors defenition 
        private static ObservableCollection<Conector> connectors = new ObservableCollection<Conector>();
        private Conector selectedConnector = new Conector();

        //public int SizeOfConenector = 50;
        public static int counterConnector = 1;
        public static ObservableCollection<Conector> Connectors
        {
            get { return connectors; }
            set
            {
                connectors = value;
            }
        }

        public Conector SelectetConnector
        {
            get { return selectedConnector; }
            set
            {
                selectedConnector = value;
                OnPropertyChanged("SelectedConector");
            }
        }
        private ICommand addBox;
        //create new Box with Connectors
        public ICommand AddBox
        {
            get
            {
                return addBox ?? (addBox = new RelayCommand(() =>
                {                  
                    //Connectors.Add(new Conector { PosX = SelectedBox.PosOfBoxX, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, SizeOfConector = SelectedBox.Size / 10, IdOfBox = counter });
                    //Connectors.Add(new Conector { PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY, SizeOfConector = SelectedBox.Size / 10, IdOfBox = counter });
                    //Connectors.Add(new Conector { SizeOfConector = SelectedBox.Size / 10, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size - 5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, IdOfBox = counter });
                    //Connectors.Add(new Conector { SizeOfConector = SelectedBox.Size / 10, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size - 5, IdOfBox = counter });

                    SelectedBox = new Box { Size = SizeOfBox, ID = counter, PosOfBoxX = 0, PosOfBoxY = 0, Title = "Box" };
                    Boxes.Add(SelectedBox);

                    //SelectetConnector = new Conector { PosX = SelectedBox.PosOfBoxX, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, SizeOfConector = SelectedBox.Size / 10, IdOfBox = counter };
                    //SelectedBox.LeftConector = SelectetConnector;
                    //SelectetConnector = new Conector { PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY, SizeOfConector = SelectedBox.Size / 10, IdOfBox = counter };
                    //SelectedBox.TopConector = SelectetConnector;
                    //SelectetConnector = new Conector { SizeOfConector = SelectedBox.Size / 10, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size - 5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, IdOfBox = counter };
                    //SelectedBox.RightConector = SelectetConnector;
                    //SelectetConnector = new Conector { SizeOfConector = SelectedBox.Size / 10, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size - 5, IdOfBox = counter };
                    //SelectedBox.BottomConector = SelectetConnector;

                    Connectors.Add(new Conector { PosX = SelectedBox.PosOfBoxX, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, SizeOfConector = SizeOfConnector, IdOfBox = counter, BoxOfConnector = selectedBox });
                    Connectors.Add(new Conector { PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY, SizeOfConector = SizeOfConnector, IdOfBox = counter, BoxOfConnector = selectedBox });
                    Connectors.Add(new Conector { SizeOfConector = SizeOfConnector, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size - 5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size / 2 - 2.5, IdOfBox = counter, BoxOfConnector = selectedBox });
                    Connectors.Add(new Conector { SizeOfConector = SizeOfConnector, PosX = SelectedBox.PosOfBoxX + SelectedBox.Size / 2 - 2.5, PosY = SelectedBox.PosOfBoxY + SelectedBox.Size - 5, IdOfBox = counter, BoxOfConnector = selectedBox });
                    counter++;
                    for (int i = Connectors.Count - 1; i > Connectors.Count - 5; i--)
                    {
                        SelectedBox.ListConector.Add(Connectors.ElementAt(i));
                    }
                }));
            }
        }


        #endregion
        #region ConnectorLineItems definition
        public static readonly DependencyProperty MouseYProperty = DependencyProperty.Register(
          "MouseY", typeof(double), typeof(MainViewModel), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty MouseXProperty = DependencyProperty.Register(
           "MouseX", typeof(double), typeof(MainViewModel), new PropertyMetadata(default(double)));
        private static ObservableCollection<ConectorLine> lines = new ObservableCollection<ConectorLine>();
        public static ConectorLine selectedline = new ConectorLine();

        public static ConectorLine PrewiewConnectorLine = new ConectorLine();

        public static ObservableCollection<ConectorLine> previewConnectorLineDisp = new ObservableCollection<ConectorLine>();
        public static ObservableCollection<ConectorLine> PreviewConnectorLineDisp
        {
            get { return previewConnectorLineDisp; }
            set
            {
                previewConnectorLineDisp = value;
            }
        }
        public ObservableCollection<ConectorLine> Lines
        {
            get { return lines; }
            set
            {
                lines = value;
            }
        }
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
        private void StartPosOfConnectorLine(object sender, MouseEventArgs mouseEventArgs)
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
            if (element.GetValue(Rectangle.DataContextProperty) is Conector)
            {
                selectedline.Start = (Conector)element.GetValue(Rectangle.DataContextProperty);
                //selectedline.Start.PosX += selectedline.Start.SizeOfConector / 2;
                //selectedline.Start.PosY += selectedline.Start.SizeOfConector / 2;


                x = Mouse.GetPosition((IInputElement)element).X - 2.5;//////////////////////////////////
                y = Mouse.GetPosition((IInputElement)element).Y - 2.5;//////////////////////////////////
                PrewiewConnectorLine.Start.PosX = pos.X - x;
                PrewiewConnectorLine.Start.PosY = pos.Y - y;

                PreviewConnectorLineDisp.Add(PrewiewConnectorLine);
            }
        }
        private void FinishPosOfConnectorLine(object sender, MouseEventArgs mouseEventArgs)
        {
            var pos = mouseEventArgs.GetPosition(AssociatedObject);
            var convas = sender as Canvas;
            PreviewConnectorLineDisp.Clear();
            if (convas == null)
                return;
            var parent = Application.Current.MainWindow;
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(convas, mouseEventArgs.GetPosition(convas));
            var element = hitTestResult.VisualHit;

            selectedline.FinishedId = element.GetValue(Canvas.UidProperty).ToString();
            if (selectedline.StartedId != selectedline.FinishedId && selectedline.StartedId != "" && element.GetValue(Rectangle.DataContextProperty) is Conector)
            {

                selectedline.Finish = (Conector)element.GetValue(Rectangle.DataContextProperty);
                //selectedline.Finish.PosX += selectedline.Start.SizeOfConector / 2;
                //selectedline.Finish.PosY += selectedline.Start.SizeOfConector / 2;
                selectedline.LineId = counterLine++;

                Lines.Add(selectedline);
            }
        }
        private void GetPosNewPoint(object sender, MouseEventArgs mouseEventArgs)
        {
            var canvas = sender as Canvas;
            if (canvas == null)
                return;
            var parent = Application.Current.MainWindow;
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, mouseEventArgs.GetPosition(canvas));
            var element = hitTestResult.VisualHit;
            if (element is Line)
            {

                var line = element.GetValue(Line.DataContextProperty) as ConectorLine;
                Conector SelectetCon = new Conector { IdOfBox = counterConnector++, PosX = Mouse.GetPosition(parent).X / zoom - differenceX / zoom, PosY = Mouse.GetPosition(parent).Y / zoom - differenceY / zoom, IsDrag = true, SizeOfConector = 10 };
                ConectorLine newLine = new ConectorLine();
                newLine.Start = SelectetCon;
                newLine.Finish = line.Finish;
                line.Finish = SelectetCon;

                Connectors.Add(SelectetCon);
                Lines.Add(newLine);

            }

        }
        protected override void OnDetaching()
        {
            //connector line
            AssociatedObject.MouseLeftButtonDown -= StartPosOfConnectorLine;
            AssociatedObject.MouseLeftButtonUp -= FinishPosOfConnectorLine;
            // drag
            AssociatedObject.MouseLeftButtonDown -= OnDraggable;
            AssociatedObject.MouseLeftButtonUp -= OffDraggable;
            AssociatedObject.MouseMove -= Drag;
            //delete line
            AssociatedObject.MouseLeftButtonDown -= DeliteLine;
            //zoom
            AssociatedObject.MouseWheel -= CanvasMouseWheelZoom;
            //drag connector by box
            AssociatedObject.MouseRightButtonDown -= DragConectorsOn;
            AssociatedObject.MouseMove -= DragConectorsMove;
            AssociatedObject.MouseRightButtonUp -= DragConectorsOff;
            //resize
            AssociatedObject.MouseLeftButtonDown -= BoxResizeOn;
            AssociatedObject.MouseMove -= BoxResize;
            AssociatedObject.MouseLeftButtonUp -= BoxResizeOff;
        }
        #endregion
        #region Drag defenition

        static bool OnDrag;
        private DependencyObject element = new DependencyObject();
        static DependencyObject elementLine;

        static Canvas canvas;
        private double curMousePosInElementY;
        private double curMousePosInElementX;
        private double curStaticMousePosInElementY;
        private double curStaticMousePosInElementX;
        private double xxx;

        double differenceX = 0;
        double differenceY = 0;
        private void OnDraggable(object sender, MouseEventArgs mouseEventArgs)
        {
            OnDrag = true;
            canvas = sender as Canvas;
            if (canvas == null)
                return;
            var parent = Application.Current.MainWindow;
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, mouseEventArgs.GetPosition(canvas));
            element = hitTestResult.VisualHit;

            //if (element.GetValue(Canvas.DataContextProperty) is Box)
            //{
            //    o = (Box)element.GetValue(Canvas.DataContextProperty);
            //    //foreach (Conector c in o.ListConector)
            //    //{
            //    //    //c.PosX = 200.0;
            //    //}

            //}



            curMousePosInElementY = (double)Mouse.GetPosition(parent).Y - (double)element.GetValue(Canvas.TopProperty);
            curMousePosInElementX = (double)Mouse.GetPosition(parent).X - (double)element.GetValue(Canvas.LeftProperty);
            curStaticMousePosInElementY = (double)Mouse.GetPosition(null).Y / zoom - (double)element.GetValue(Canvas.TopProperty) - differenceY / zoom;
            curStaticMousePosInElementX = (double)Mouse.GetPosition(null).X / zoom - (double)element.GetValue(Canvas.LeftProperty) - differenceX / zoom;
            xxx = (double)element.GetValue(Canvas.LeftProperty);
        }
        double xx;
        double yy;
        private void Drag(object sender, MouseEventArgs mouseEventArgs)
        {

            double y;
            var parent = Application.Current.MainWindow;
            //var mainCanvas = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(parent, 0), 0);
            PrewiewConnectorLine.Finish.PosX = (Mouse.GetPosition(parent).X / zoom - differenceX / zoom);
            PrewiewConnectorLine.Finish.PosY = Mouse.GetPosition(parent).Y / zoom - differenceY / zoom;
            if (OnDrag == true)
            {

                if (element is Canvas && (double)element.GetValue(Canvas.MaxHeightProperty) == 200)///////////////////////////////////////////////////////////////////////////////////////
                {
                    xx = (double)(element.GetValue(Canvas.LeftProperty));
                    yy = y = (double)(element.GetValue(Canvas.TopProperty));

                    element.SetValue(Canvas.LeftProperty, ((Math.Ceiling(Mouse.GetPosition(parent).X / zoom / 10) * 10) - differenceX / zoom - Math.Ceiling(curStaticMousePosInElementX / 10) * 10));
                    curMousePosInElementX = (double)Mouse.GetPosition(parent).X - (double)element.GetValue(Canvas.LeftProperty);
                    //o.IsChangedX += ChangeConnectorX;


                    element.SetValue(Canvas.TopProperty, ((Math.Ceiling(Mouse.GetPosition(parent).Y / zoom / 10) * 10) - differenceY / zoom - Math.Ceiling(curStaticMousePosInElementY / 10) * 10));
                    curMousePosInElementY = (double)Mouse.GetPosition(parent).Y - (double)element.GetValue(Canvas.TopProperty);
                    // o.IsChangedY += ChangeConnectorY;
                    ////////////////////////////////////////////////////////////////
                    ///////////////////////////////
                    ///////////////////////////////////
                    //////////////////////////////////
                    ////////////////////////////////////
                    //((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY = (double)Mouse.GetPosition(parent).Y - (double)element.GetValue(Canvas.TopProperty);
                    //startY2 = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY;
                    //startY3 = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosY;
                    //startY4 = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY;

                    ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX + (double)element.GetValue(Canvas.LeftProperty) - xx;
                    ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosX = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosX + (double)element.GetValue(Canvas.LeftProperty) - xx;
                    ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX + (double)element.GetValue(Canvas.LeftProperty) - xx;
                    ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosX = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosX + (double)element.GetValue(Canvas.LeftProperty) - xx;

                    ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY + (double)element.GetValue(Canvas.TopProperty) - yy;
                    ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY + (double)element.GetValue(Canvas.TopProperty) - yy;
                    ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosY = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosY + (double)element.GetValue(Canvas.TopProperty) - yy;
                    ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY = ((Box)element.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY + (double)element.GetValue(Canvas.TopProperty) - yy;
                }


                else if (element is Canvas)
                {
                    if ((Mouse.GetPosition(parent).X - curMousePosInElementX) <= 0 && (Mouse.GetPosition(parent).Y - curMousePosInElementY) >= 0)
                    {
                        element.SetValue(Canvas.LeftProperty, Math.Ceiling((Mouse.GetPosition(parent).X - curMousePosInElementX) / zoom / 10) * 10 * zoom);

                        differenceX = (double)element.GetValue(Canvas.LeftProperty);
                        differenceY = (double)element.GetValue(Canvas.TopProperty);
                        //CanvasHeight = (int)(Mouse.GetPosition(parent).X - curMousePosInElementX + 50);
                        //element.SetValue(Canvas.HeightProperty, curMousePosInElementY - Mouse.GetPosition(parent).Y + 400);
                    }

                    if ((Mouse.GetPosition(parent).X - curMousePosInElementX) >= 0 && (Mouse.GetPosition(parent).Y - curMousePosInElementY) <= 0)
                    {
                        //element.SetValue(Canvas.LeftProperty, Mouse.GetPosition(parent).X - curMousePosInElementX);
                        element.SetValue(Canvas.TopProperty, Math.Ceiling((Mouse.GetPosition(parent).Y - curMousePosInElementY) / zoom / 10) * 10 * zoom);
                        differenceX = (double)element.GetValue(Canvas.LeftProperty);
                        differenceY = (double)element.GetValue(Canvas.TopProperty);
                        //element.SetValue(Canvas.WidthProperty, curMousePosInElementX - Mouse.GetPosition(parent).X + 400);
                    }

                    else if ((Mouse.GetPosition(parent).X - curMousePosInElementX) <= 0 && (Mouse.GetPosition(parent).Y - curMousePosInElementY) <= 0)
                    {
                        element.SetValue(Canvas.LeftProperty, Math.Ceiling((Mouse.GetPosition(parent).X - curMousePosInElementX) / zoom / 10) * 10 * zoom);
                        element.SetValue(Canvas.TopProperty, Math.Ceiling((Mouse.GetPosition(parent).Y - curMousePosInElementY) / zoom / 10) * 10 * zoom);
                        differenceX = (double)element.GetValue(Canvas.LeftProperty);
                        differenceY = (double)element.GetValue(Canvas.TopProperty);
                        element.SetValue(Canvas.HeightProperty, curMousePosInElementY - Mouse.GetPosition(parent).Y / zoom + 1080 / zoom);
                        element.SetValue(Canvas.WidthProperty, curMousePosInElementX - Mouse.GetPosition(parent).X / zoom + 1920 / zoom);

                        //element.SetValue(Canvas.LeftProperty, ((double)((int)(Mouse.GetPosition(parent).X / zoom / 10) * 10) - differenceX / zoom/*- curMousePosInElementX*/));
                    }
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
                var e = elementLine.GetValue(Line.DataContextProperty) as ConectorLine;
                Connectors.Remove(e.Start);
                Lines.Remove(Lines.First(i => i.Finish == e.Start));
                Lines.Remove(Lines.First(i => i.LineId == Convert.ToInt32(elementLine.GetValue(Line.UidProperty))));
            }
        }
        private void OffDraggable(object sender, MouseEventArgs mouseEventArgs)
        {
            PreviewConnectorLineDisp.Clear();
            OnDrag = false;
        }
        #endregion
        #region Zoom Defenition
        private Double zoomMax = 5;
        private Double zoomMin = 0.5;
        private Double zoomSpeed = 0.001;
        private Double zoom = 1;

        private void CanvasMouseWheelZoom(object sender, MouseWheelEventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas == null)
                return;
            zoom += zoomSpeed * e.Delta;
            if (zoom < zoomMin) { zoom = zoomMin; }
            if (zoom > zoomMax) { zoom = zoomMax; }

            System.Windows.Point mousePos = e.GetPosition(canvas);

            if (zoom > 1)
            {
                canvas.RenderTransform = new MatrixTransform(zoom, 0, 0, zoom, 0, 0);
            }
            else
            {
                canvas.RenderTransform = new MatrixTransform(zoom, 0, 0, zoom, 0, 0);
            }
        }

        #endregion
        #region Connectors moove
        static bool OnDragConector;
        static DependencyObject elementConector;
        Conector conect = new Conector();
        private void DragConectorsOn(object sender, MouseEventArgs mouseEventArgs)
        {
            OnDragConector = true;
            canvas = sender as Canvas;
            if (canvas == null)
                return;

            HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, mouseEventArgs.GetPosition(canvas));
            elementConector = hitTestResult.VisualHit;

            if (elementConector.GetValue(Canvas.DataContextProperty) is Conector)
            {
                conect = (Conector)elementConector.GetValue(Rectangle.DataContextProperty);
                curMousePosInElementY = (double)Mouse.GetPosition(null).Y / zoom - (double)elementConector.GetValue(Canvas.TopProperty);
                curMousePosInElementX = (double)Mouse.GetPosition(null).X / zoom - (double)elementConector.GetValue(Canvas.LeftProperty);

            }
        }
        private void DragConectorsMove(object sender, MouseEventArgs e)
        {
            if (OnDragConector)
            {
                var box = VisualTreeHelper.HitTest(canvas, e.GetPosition(canvas)).VisualHit;//.GetValue(Canvas.DataContextProperty);

                var parent = Application.Current.MainWindow;
                if (elementConector is Rectangle && VisualTreeHelper.HitTest(canvas, e.GetPosition(canvas)).VisualHit.GetValue(Canvas.DataContextProperty) is Box)
                {
                    if (conect.PosX == conect.BoxOfConnector.PosOfBoxX || conect.PosX == conect.BoxOfConnector.PosOfBoxX + (double)box.GetValue(Canvas.WidthProperty) - conect.SizeOfConector)
                        conect.PosY = Mouse.GetPosition(parent).Y / zoom - curMousePosInElementY;
                    if (conect.PosY == conect.BoxOfConnector.PosOfBoxY || conect.PosY == conect.BoxOfConnector.PosOfBoxY + (double)box.GetValue(Canvas.HeightProperty) - conect.SizeOfConector)
                        conect.PosX = Mouse.GetPosition(parent).X / zoom - curMousePosInElementX;
                }
                else if (conect.IsDrag)
                {
                    conect.PosX = Mouse.GetPosition(parent).X / zoom - curMousePosInElementX;
                    conect.PosY = Mouse.GetPosition(parent).Y / zoom - curMousePosInElementY;
                }
            }
        }
        private void DragConectorsOff(object sender, MouseEventArgs e)
        {
            OnDragConector = false;
        }

        #endregion
        #region Resize Boxes
        DependencyObject boxBorder = new DependencyObject();
        bool resizableLeft = false;
        bool resizableTop = false;
        bool resizableRight = false;
        bool resizableBot = false;
        double currentMouseX = 0;
        double currentMouseY = 0;
        double startWidth;
        double startPosX;
        double startLeft;

        double startPosX1;

        double startHeight;
        double startPosY;
        double startTop;

        double startPosY1;
        DependencyObject UnderCursor = new DependencyObject();
        private void BoxResizeOn(object sender, MouseEventArgs mouseEventArgs)
        {
            canvas = sender as Canvas;
            if (canvas == null)
                return;

            HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, mouseEventArgs.GetPosition(canvas));
            boxBorder = hitTestResult.VisualHit;
            if (boxBorder is TextBlock)
            {
                boxBorder = (VisualTreeHelper.GetParent(boxBorder));
            }

            //////////////////////////
            //startWidth = (double)boxBorder.GetValue(Canvas.WidthProperty);
            //startPosX = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX;
            //startLeft = (double)boxBorder.GetValue(Canvas.LeftProperty);
            //startHeight = (double)boxBorder.GetValue(Canvas.HeightProperty);
            //startPosY = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY;
            //startTop = (double)boxBorder.GetValue(Canvas.TopProperty);
            /////////////////////////////
            if (boxBorder is Canvas && (double)boxBorder.GetValue(Canvas.MaxWidthProperty) == 200)
            {
                if ((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X < 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + 5 * zoom >= 0)
                {
                    OnDrag = false;
                    resizableLeft = true;
                    currentMouseX = Mouse.GetPosition(null).X;
                    //AssociatedObject.MouseMove -= AssociatedObjectOnMoove;
                    startWidth = (double)boxBorder.GetValue(Canvas.WidthProperty);
                    startPosX = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX;
                    startLeft = (double)boxBorder.GetValue(Canvas.LeftProperty);


                    startPosX1 = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX;


                    startPosX = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX;
                }
                if ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y < 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + 5 * zoom >= 0)
                {
                    OnDrag = false;
                    resizableTop = true;
                    currentMouseY = Mouse.GetPosition(null).Y;
                    //AssociatedObject.MouseMove -= AssociatedObjectOnMoove;
                    startHeight = (double)boxBorder.GetValue(Canvas.HeightProperty);
                    startPosY = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY;
                    startTop = (double)boxBorder.GetValue(Canvas.TopProperty);

                    startPosY1 = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY;
                }
                if ((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + (double)boxBorder.GetValue(Canvas.WidthProperty) * zoom >= 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + (double)boxBorder.GetValue(Canvas.WidthProperty) * zoom - 5 <= 0)
                {
                    resizableRight = true;
                    OnDrag = false;
                    currentMouseX = Mouse.GetPosition(null).X;

                    startWidth = (double)boxBorder.GetValue(Canvas.WidthProperty);
                    startPosX = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX;
                    startLeft = (double)boxBorder.GetValue(Canvas.LeftProperty);

                    startPosX1 = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX;
                    //AssociatedObject.MouseMove -= AssociatedObjectOnMoove;
                }
                if ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + (double)boxBorder.GetValue(Canvas.HeightProperty) * zoom >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + (double)boxBorder.GetValue(Canvas.HeightProperty) * zoom - 5 <= 0)
                {
                    resizableBot = true;
                    currentMouseY = Mouse.GetPosition(null).Y;
                    OnDrag = false;
                    //AssociatedObject.MouseMove -= AssociatedObjectOnMoove;

                    startHeight = (double)boxBorder.GetValue(Canvas.HeightProperty);
                    startPosY = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY;
                    startTop = (double)boxBorder.GetValue(Canvas.TopProperty);

                    startPosY1 = ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY;
                }
            }


        }
        private void BoxResize(object sender, MouseEventArgs mouseEventArgs)
        {
            #region resizeLeft
            //if (resizableLeft && Math.Ceiling(currentMouseX - Mouse.GetPosition(null).X) + (double)boxBorder.GetValue(Canvas.WidthProperty) / zoom >= 0)

            if (resizableLeft && (double)boxBorder.GetValue(Canvas.WidthProperty) >= 50 && (double)boxBorder.GetValue(Canvas.WidthProperty) <= 200 && Math.Ceiling((currentMouseX - Mouse.GetPosition(null).X) / 10 / zoom) * 10 + startWidth > 45 && Math.Ceiling((currentMouseX - Mouse.GetPosition(null).X) / 10 / zoom) * 10 + startWidth < 200)
            {
                boxBorder.SetValue(Canvas.WidthProperty, Math.Ceiling((currentMouseX - Mouse.GetPosition(null).X) / 10 / zoom) * 10 + startWidth);
                boxBorder.SetValue(Canvas.LeftProperty, ((double)((int)(Mouse.GetPosition(null).X) / 10 / zoom) * 10) - differenceX / zoom);
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosX = (double)boxBorder.GetValue(Canvas.LeftProperty);
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosX = (double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX - startLeft)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX1 - startLeft)));
                VisualTreeHelper.GetChild(boxBorder, 0).SetValue(TextBlock.WidthProperty, boxBorder.GetValue(Canvas.WidthProperty));

                // 5 is size of connector
            }
            else if (resizableLeft && (double)boxBorder.GetValue(Canvas.WidthProperty) <= 50)
            {
                boxBorder.SetValue(Canvas.WidthProperty, 50.0);
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosX = (double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX - startLeft)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX1 - startLeft)));
            }
            else if (resizableLeft && (double)boxBorder.GetValue(Canvas.WidthProperty) >= 200)
            {
                boxBorder.SetValue(Canvas.WidthProperty, 200.0);
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosX = (double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX - startLeft)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX1 - startLeft)));
            }
            //}
            #endregion
            #region resizeTop
            //if (resizableTop && Math.Ceiling(currentMouseY - Mouse.GetPosition(null).Y) + (double)boxBorder.GetValue(Canvas.HeightProperty) / zoom >= 0)
            //{
            if (resizableTop && (double)boxBorder.GetValue(Canvas.HeightProperty) >= 50 && (double)boxBorder.GetValue(Canvas.HeightProperty) <= 200 && Math.Ceiling((currentMouseY - Mouse.GetPosition(null).Y) / 10 / zoom) * 10 + startHeight > 45 && Math.Ceiling((currentMouseY - Mouse.GetPosition(null).Y) / 10 / zoom) * 10 + startHeight < 200)
            {
                boxBorder.SetValue(Canvas.TopProperty, (double)((int)(Mouse.GetPosition(null).Y) / 10 / zoom) * 10 - differenceY / zoom);
                boxBorder.SetValue(Canvas.HeightProperty, Math.Ceiling((currentMouseY - Mouse.GetPosition(null).Y) / 10 / zoom) * 10 + startHeight);

                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosY = (double)boxBorder.GetValue(Canvas.TopProperty);
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY = (double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY1 - startTop)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY - startTop)));
            }
            else if (resizableTop && (double)boxBorder.GetValue(Canvas.HeightProperty) <= 50)
            {
                boxBorder.SetValue(Canvas.HeightProperty, 50.0);
                //boxBorder.SetValue(Canvas.TopProperty, (double)((int)(Mouse.GetPosition(null).Y) / 10 / zoom) * 10 - differenceY / zoom);
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY = (double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY1 - startTop)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY - startTop)));
            }
            else if (resizableTop && (double)boxBorder.GetValue(Canvas.HeightProperty) >= 200)
            {
                boxBorder.SetValue(Canvas.HeightProperty, 200.0);
                //boxBorder.SetValue(Canvas.TopProperty, (double)((int)(Mouse.GetPosition(null).Y) / 10 / zoom) * 10 - differenceY / zoom);
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY = (double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY1 - startTop)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY - startTop)));
            }
            //}
            #endregion
            #region resizeBot
            //if (resizableBot && Math.Ceiling(Mouse.GetPosition(null).Y - currentMouseY) >= 0)
            //{
            if (resizableBot && (double)boxBorder.GetValue(Canvas.HeightProperty) >= 50 && (double)boxBorder.GetValue(Canvas.HeightProperty) <= 200 && Math.Ceiling((Mouse.GetPosition(null).Y - currentMouseY) / 10 / zoom) * 10 + startHeight > 0)
            {
                //boxBorder.SetValue(Canvas.TopProperty, ((double)((int)(Mouse.GetPosition(null).Y) / 10 / zoom) * 10) - differenceY / zoom);
                boxBorder.SetValue(Canvas.HeightProperty, Math.Ceiling((Mouse.GetPosition(null).Y - currentMouseY) / 10 / zoom) * 10 + startHeight);
                //MessageBox.Show(resizableBot.ToString());
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY = (double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY - startTop)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY1 - startTop)));
            }
            if (resizableBot && (double)boxBorder.GetValue(Canvas.HeightProperty) <= 50)
            {
                boxBorder.SetValue(Canvas.HeightProperty, 50.0);
                //MessageBox.Show(resizableBot.ToString());
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY = (double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY - startTop)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY1 - startTop)));
            }
            else if (resizableBot && (double)boxBorder.GetValue(Canvas.HeightProperty) >= 200)
            {
                boxBorder.SetValue(Canvas.HeightProperty, 200.0);
                //MessageBox.Show(resizableBot.ToString());
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosY = (double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY - startTop)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(3).PosY = ((double)boxBorder.GetValue(Canvas.TopProperty) + (double)boxBorder.GetValue(Canvas.HeightProperty) / (startHeight / (startPosY1 - startTop)));
            }
            //}
            #endregion
            #region resizeRight
            //if (resizableRight && Math.Ceiling(Mouse.GetPosition(null).X - currentMouseX) >= 0)
            //{
            //boxBorder.SetValue(Canvas.LeftProperty, (double)((int)(Mouse.GetPosition(null).Y) / 10 / zoom) * 10 - differenceY / zoom);
            if (resizableRight && (double)boxBorder.GetValue(Canvas.WidthProperty) >= 50 && (double)boxBorder.GetValue(Canvas.WidthProperty) <= 200 && Math.Ceiling((Mouse.GetPosition(null).X - currentMouseX) / 10 / zoom) * 10 + startWidth / zoom > 0)
            {
                boxBorder.SetValue(Canvas.WidthProperty, Math.Ceiling((Mouse.GetPosition(null).X - currentMouseX) / 10 / zoom) * 10 + startWidth);
                //MessageBox.Show(resizableRight.ToString());
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosX = (double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX - startLeft)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX1 - startLeft)));
                VisualTreeHelper.GetChild(boxBorder, 0).SetValue(TextBlock.WidthProperty, boxBorder.GetValue(Canvas.WidthProperty));
            }
            if (resizableRight && (double)boxBorder.GetValue(Canvas.WidthProperty) <= 50)
            {
                boxBorder.SetValue(Canvas.WidthProperty, 50.0);
                VisualTreeHelper.GetChild(boxBorder, 0).SetValue(TextBlock.WidthProperty, 50.0);
                //MessageBox.Show(resizableRight.ToString());
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosX = (double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX - startLeft)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX1 - startLeft)));
            }
            else if (resizableRight && (double)boxBorder.GetValue(Canvas.WidthProperty) >= 200)
            {
                boxBorder.SetValue(Canvas.WidthProperty, 200.0);
                VisualTreeHelper.GetChild(boxBorder, 0).SetValue(TextBlock.WidthProperty, 200.0);
                //MessageBox.Show(resizableRight.ToString());
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(1).PosX = (double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) - 5;
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(0).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX - startLeft)));
                ((Box)boxBorder.GetValue(Canvas.DataContextProperty)).ListConector.ElementAt(2).PosX = ((double)boxBorder.GetValue(Canvas.LeftProperty) + (double)boxBorder.GetValue(Canvas.WidthProperty) / (startWidth / (startPosX1 - startLeft)));
            }

            //}
            //element.SetValue(Canvas.LeftProperty, (double)((int)(Mouse.GetPosition(parent).X - curMousePosInElementX) / 10 / zoom) * 10 * zoom);
            #endregion
        }
        private void BoxResizeOff(object sender, MouseEventArgs mouseEventArgs)
        {
            resizableLeft = false;
            resizableTop = false;
            resizableBot = false;
            resizableRight = false;
            //AssociatedObject.MouseMove += AssociatedObjectOnMoove;
        }
        private void CursorChange(object sender, MouseEventArgs mouseEventArgs)
        {
            canvas = sender as Canvas;
            if (canvas == null)
                return;

            HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, mouseEventArgs.GetPosition(canvas));
            UnderCursor = hitTestResult.VisualHit;

            if (UnderCursor is Canvas && (double)boxBorder.GetValue(Canvas.MaxWidthProperty) == 200)
            {
                if ((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + 5 >= 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X <= 0 &&
                   ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + 5 >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y <= 0))
                {
                    Mouse.SetCursor(Cursors.SizeNWSE);
                }
                else if ((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + 5 >= 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X <= 0 &&
                 ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + (double)boxBorder.GetValue(Canvas.HeightProperty) * zoom >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + (double)boxBorder.GetValue(Canvas.HeightProperty) * zoom - 5 <= 0))
                {
                    Mouse.SetCursor(Cursors.SizeNESW);
                }
                else if ((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + (double)boxBorder.GetValue(Canvas.WidthProperty) * zoom >= 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + (double)boxBorder.GetValue(Canvas.WidthProperty) * zoom - 5 <= 0 &&
                 ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + (double)boxBorder.GetValue(Canvas.HeightProperty) * zoom >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + (double)boxBorder.GetValue(Canvas.HeightProperty) * zoom - 5 <= 0))
                {
                    Mouse.SetCursor(Cursors.SizeNWSE);
                }
                else if (((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + (double)boxBorder.GetValue(Canvas.WidthProperty) * zoom >= 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + (double)boxBorder.GetValue(Canvas.WidthProperty) * zoom - 5 <= 0 &&
                  ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + 5 >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y <= 0)))
                {
                    Mouse.SetCursor(Cursors.SizeNESW);
                }




                else if ((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + 5 >= 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X <= 0)
                {
                    Mouse.SetCursor(Cursors.SizeWE);
                }
                else if ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + 5 >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y <= 0)
                {
                    Mouse.SetCursor(Cursors.SizeNS);
                }
                else if ((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + (double)boxBorder.GetValue(Canvas.WidthProperty) * zoom >= 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + (double)boxBorder.GetValue(Canvas.WidthProperty) * zoom - 5 <= 0)
                {
                    Mouse.SetCursor(Cursors.SizeWE);
                }
                else if ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + (double)boxBorder.GetValue(Canvas.HeightProperty) * zoom >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + (double)boxBorder.GetValue(Canvas.HeightProperty) * zoom - 5 <= 0)
                {
                    Mouse.SetCursor(Cursors.SizeNS);
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //else if ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + 5 >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y <= 0)
                //{
                //    Mouse.SetCursor(Cursors.SizeNS);
                //}
                //else if ((double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + 50 * zoom >= 0 && (double)boxBorder.GetValue(Canvas.LeftProperty) * zoom + differenceX - Mouse.GetPosition(null).X + 45 <= 0)
                //{
                //    Mouse.SetCursor(Cursors.SizeWE);
                //}
                //else if ((double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + 50 * zoom >= 0 && (double)boxBorder.GetValue(Canvas.TopProperty) * zoom + differenceY - Mouse.GetPosition(null).Y + 45 <= 0)
                //{
                //    Mouse.SetCursor(Cursors.SizeNS);
                //}
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else
                {
                    //Mouse.SetCursor(Cursors.Arrow);
                }

            }

        }


        #endregion
        #region DoubleClick properties
        byte countClicks = 0;
        double firstClickTime;
        double seccondClickTime;
        private void DoubleClickElement(object sender, MouseEventArgs mouseEventArgs)
        {
            
            if (element is Canvas && (double)element.GetValue(Canvas.MaxHeightProperty) == 200)
            {
                countClicks++;
            }
            if (countClicks == 1)
            {
                firstClickTime = DateTime.Now.Subtract(new DateTime(2000, 1, 1)).TotalMilliseconds;
            }
            else if (countClicks == 2)
            {

                seccondClickTime = DateTime.Now.Subtract(new DateTime(2000, 1, 1)).TotalMilliseconds;
            }
            if (countClicks == 2 && seccondClickTime - firstClickTime > 250)
            {
                countClicks = 1;
                firstClickTime = seccondClickTime;
                seccondClickTime = 0;
            }
            if (countClicks == 2 && seccondClickTime - firstClickTime <= 250)
            {
                HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, mouseEventArgs.GetPosition(canvas));
                var block = hitTestResult.VisualHit;
                //if (block.GetValue(Canvas.DataContextProperty) is Box) return;
                SelectedBlockType1 = block.GetValue(Canvas.DataContextProperty) as BlockType1;              
                var parentpopup = VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(block)))))));
                var popup = VisualTreeHelper.GetChild(parentpopup, 3);
                popup.SetValue(Popup.IsOpenProperty, true);

                
            }
            if (countClicks == 2)
            {
                firstClickTime = 0;
                seccondClickTime = 0;
                countClicks = 0;
            }
        }
        #endregion
        #region Popup       
        private bool open = false;
        private ICommand cancelPopup;
        private ICommand okpopup;
      
        public ICommand OkPopup
        {
            get
            {
                return okpopup ?? (okpopup = new RelayCommand(() =>
                {
                    if (SelectedBlockType1.IsMultiplay)
                    {
                        SelectedBlockType1.MultiVisibility = Visibility.Visible;
                        SelectedBlockType1.Multiplying();
                        //MessageBox.Show(selectedBlockType1.MultiVisibility.ToString());
                    }
                    Open = false;
                }));
            }
        }
        public ICommand CancelPopup
        {
            get
            {
                return cancelPopup ?? (cancelPopup = new RelayCommand(() =>
                {
                    Open = false;
                }));
            }
        }
        public bool Open
        {
            get { return open; }
            set
            {
                if (open == value) return;
                open = value;
                OnPropertyChanged("Open");
            }
        }            
        #endregion
        protected override void OnAttached()
        {
            //connector line
            AssociatedObject.MouseLeftButtonDown += StartPosOfConnectorLine;
            AssociatedObject.MouseLeftButtonUp += FinishPosOfConnectorLine;
            AssociatedObject.MouseLeftButtonDown += GetPosNewPoint;
            // drag
            AssociatedObject.MouseLeftButtonDown += OnDraggable;
            AssociatedObject.MouseLeftButtonUp += OffDraggable;
            AssociatedObject.PreviewMouseMove += Drag;
            //delete line
            AssociatedObject.MouseRightButtonDown += DeliteLine;
            //zoom
            AssociatedObject.MouseWheel += CanvasMouseWheelZoom;
            //drag connector by box
            AssociatedObject.MouseRightButtonDown += DragConectorsOn;
            AssociatedObject.MouseMove += DragConectorsMove;
            AssociatedObject.MouseRightButtonUp += DragConectorsOff;
            //resize
            AssociatedObject.MouseLeftButtonDown += BoxResizeOn;
            AssociatedObject.MouseMove += BoxResize;
            AssociatedObject.MouseLeftButtonUp += BoxResizeOff;
            AssociatedObject.PreviewMouseMove += CursorChange;

            AssociatedObject.MouseLeftButtonDown += DoubleClickElement;         
           // AssociatedObject.KeyDown += BoxActions
        }
     
    }
}
