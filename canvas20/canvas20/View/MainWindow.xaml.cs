using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace canvas20
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //bool OnDrag = false;
        //static DependencyObject element;
        //static double curMousePosInElementY;
        //static double curMousePosInElementX;
        //private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    OnDrag = true;
        //    var canvas = sender as Canvas;
        //    if (canvas == null)
        //        return;

        //    HitTestResult hitTestResult = VisualTreeHelper.HitTest(canvas, e.GetPosition(canvas));
        //    element = hitTestResult.VisualHit;

        //    curMousePosInElementY =  (double)Mouse.GetPosition(null).Y - (double)element.GetValue(Canvas.TopProperty);
        //    curMousePosInElementX =  (double)Mouse.GetPosition(null).X - (double)element.GetValue(Canvas.LeftProperty);
        //}

        //private void Canvas_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (OnDrag == true && element.GetValue(Canvas.DataContextProperty).ToString() != "canvas20.Conector")
        //    {
               
        //        var parent = Application.Current.MainWindow;
                 
               
        //        if (element is Canvas)
        //        {
                    
        //            element.SetValue(Canvas.LeftProperty, Mouse.GetPosition(parent).X - curMousePosInElementX);
        //            element.SetValue(Canvas.TopProperty, Mouse.GetPosition(parent).Y - curMousePosInElementY);
        //        }
        //    }
        //}
        //private void Canvas_MouseUp(object sender, MouseEventArgs e)
        //{
        //    OnDrag = false;
        //}
    }
}
