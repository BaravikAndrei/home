﻿using System.Windows;
using System;
 
namespace MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
 
            DataContext = new CarViewModel();
        }
    }
}