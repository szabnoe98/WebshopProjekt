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

    public partial class TermekekView : Window
    {

        public TermekekView()
        {
            InitializeComponent();
            termekekD.Sorting += TermekekD_Sorting;
        }



        private void TermekekD_Sorting(object sender, DataGridSortingEventArgs e)
        {
            DataGridColumn column = e.Column;
            Vm.SortBy = column.SortMemberPath;
            e.Handled = true;
            ListSortDirection direction = (column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            
            column.SortDirection = direction;
        }

        private TermekekViewModel Vm => this.DataContext as TermekekViewModel;

    }
}