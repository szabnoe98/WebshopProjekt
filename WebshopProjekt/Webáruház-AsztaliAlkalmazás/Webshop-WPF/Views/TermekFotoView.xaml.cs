using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Webshop_WPF.ViewModels;

namespace Webshop_WPF.Views
{
    
    public partial class TermekFotoView : Window
    {
        
        public TermekFotoView(TermekFotoViewModel p)
        {
            InitializeComponent();
            this.DataContext = p;

          

        }

        int i = 1;
        private void GoBack(object sender, RoutedEventArgs e)
        {
            i--;

            if (i < 1)
            {
                i = 6;
            }

            pictures.Source = new BitmapImage(new Uri(@"/Images/" + i + ".jpg", UriKind.Relative));

            

        }

        private void GoNext(object sender, RoutedEventArgs e)
        {
            i++;

            if (i > 6)
            {
                i = 6;
            }

           

            pictures.Source = new BitmapImage(new Uri(@"/Images/" + i + ".jpg", UriKind.Relative));
        }
    }
}
