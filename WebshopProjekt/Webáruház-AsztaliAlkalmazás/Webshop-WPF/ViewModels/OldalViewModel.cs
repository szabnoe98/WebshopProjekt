using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Webshop_WPF.ViewModels
{
    public abstract class OldalViewModel : ObservableObject
    {
        private string _searchKey;
        public string SearchKey
        {
            get { return _searchKey; }
            
            set { SetProperty(ref _searchKey, value); page = 1; }
        }

        private string _sortBy;
        public string SortBy
        {
            get { return _sortBy; }
            set
            {
                SetProperty(ref _sortBy, value);
                if (value == _sortBy)
                {
                    ascending = !ascending;
                }
                LoadData();
            }
        }
        protected bool ascending;

        // Oldaltördelés
        private string _currentPage;
        public string CurrentPage
        {
            get { return _currentPage; }
            set { SetProperty(ref _currentPage, value); }
        }

        public ObservableCollection<int> IPOList { get; set; }

        private int itemsPerOldal = 30;
        public int ItemsPerOldal
        {
            get { return itemsPerOldal; }
            set { SetProperty(ref itemsPerOldal, value); LoadData(); }
        }
        protected int page = 1;
        private int pageCount;

        private int _totalItems;
        public int TotalItems
        {
            get { return _totalItems; }
            set
            {
                pageCount = (value - 1) / itemsPerOldal + 1;
                CurrentPage = page + "/" + pageCount;
                SetProperty(ref _totalItems, value);
                if (page > pageCount)
                {
                    page = pageCount;
                }
            }
        }

        public RelayCommand LoadDataCmd { get; set; } 
        public RelayCommand FirstPageCmd { get; set; }
        public RelayCommand PreviousPageCmd { get; set; }
        public RelayCommand NextPageCmd { get; set; }
        public RelayCommand LastPageCmd { get; set; }
        
        public OldalViewModel()
        {
            
            LoadDataCmd = new RelayCommand(() => LoadData());
            FirstPageCmd = new RelayCommand(() => FirstPage());
            PreviousPageCmd = new RelayCommand(() => PrevPage());
            NextPageCmd = new RelayCommand(() => NextPage());
            LastPageCmd = new RelayCommand(() => LastPage());
            IPOList = new ObservableCollection<int>(new List<int>() { 10, 20, 30 });
        }

        
        protected abstract void LoadData();

        protected void FirstPage()
        {
            page = 1;
            LoadData();
        }

        protected void PrevPage()
        {
            if (page != 1)
            {
                page--;
                LoadData();
            }
        }

        protected void NextPage()
        {
            if (page != pageCount)
            {
                page++;
                LoadData();
            }
        }

        protected void LastPage()
        {
            page = pageCount;
            LoadData();
        }

        
    }
}
