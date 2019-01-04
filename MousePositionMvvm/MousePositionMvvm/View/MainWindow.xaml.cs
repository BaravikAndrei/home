using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MousePositionMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //bool activated = false;
        //Point point;
        //object ellipse ;


        //private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    activated = true;
        //    point = Mouse.GetPosition(ellipse);
        //    Mouse.Capture(ellipse);
        //}

        //private void ellipse_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (activated)
        //    {
        //        double top = Canvas.GetTop(ellipse) + Mouse.GetPosition(ellipse).Y;
        //        Canvas.SetTop(ellipse, top);

        //        double left = Canvas.GetLeft(ellipse) + Mouse.GetPosition(ellipse).X;

        //        Canvas.SetLeft(ellipse, left);

        //        point = Mouse.GetPosition(ellipse);
        //    }
        //}

        //private void ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    activated = false;
        //    Mouse.Capture(null);
        //}

        private void Canvas_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Получение фокуса");
        }
    }
}

