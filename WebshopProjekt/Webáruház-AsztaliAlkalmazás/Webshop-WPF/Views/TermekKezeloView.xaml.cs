using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Webshop_WPF.Models;
using Webshop_WPF.ViewModels;

namespace Webshop_WPF.Views
{
    /// <summary>
    /// Interaction logic for TermekKezelo.xaml
    /// </summary>
    public partial class TermekKezeloView : Window
    {
        public TermekKezeloView(TermekKezeloViewModel vm)
        {
            //datacontex-en keresztül hivatkozik a viewmodelre
            InitializeComponent();
            this.DataContext = vm;
        }

    }

    

}
