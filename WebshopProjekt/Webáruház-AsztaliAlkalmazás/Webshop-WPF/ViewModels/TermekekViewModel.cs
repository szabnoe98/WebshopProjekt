using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Webshop_WPF.Models;
using Webshop_WPF.Repositories;
using Webshop_WPF.Views;

namespace Webshop_WPF.ViewModels
{
    public class TermekekViewModel : OldalViewModel
    {
       

        public TermekRepository TermekRepo { get; private set; }

        //Dinamikus adatgyűjtemény, amely értesítést küld, ha elemeket adnak hozzá vagy távolítanak el, vagy ha a teljes lista frissül.
        private ObservableCollection<termek> _termekek;
        
        public ObservableCollection<termek> Termekek
        {
            get { return _termekek; }
            set { SetProperty(ref _termekek, value); }
        }

        private termek _selectedtermek = new termek();

        //Változásértesítési események
        public termek Selectedtermek
        {
            get { return _selectedtermek; }
            set { SetProperty(ref _selectedtermek, value); }
        }

        private ObservableObject _selectedViewModel;
        public ObservableObject SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }


        //Parancsok

        public RelayCommand InventoryCmd { get; set; }
        public RelayCommand DeleteCmd { get; set; }
        public RelayCommand UpdateCmd { get; set; }

        public RelayCommand ProductPhoto { get; set; }

        public RelayCommand<Window> LogoutCommand { get; set; }


        public TermekekViewModel()
        {
            var context = new webaruhazContext();
            TermekRepo = new TermekRepository(context);
            DeleteCmd = new RelayCommand(() => Delete(Selectedtermek));
            ProductPhoto = new RelayCommand(ProductDetail);
            LogoutCommand = new RelayCommand<Window>(Close);
            InventoryCmd = new RelayCommand(ShowDetail);
            UpdateCmd = new RelayCommand(() => UpdateExisting(Selectedtermek.Cikkszam));
        

            LoadData();
        }

        




        //Betöltés
        protected override void LoadData()
        {
            var query = TermekRepo.GetAll(page, ItemsPerOldal, SearchKey, SortBy, ascending);
            TotalItems = TermekRepo.TotalItems;
            Termekek = new ObservableCollection<termek>(query); 

        }

        public void Delete(termek termek)
        {
            if (termek != null)
            {
                TermekRepo.Delete(termek.Cikkszam);
                LoadData();
            }
        }

        private void ShowDetail()
        {
            var vm = new TermekKezeloViewModel();
            vm.TermekekVM = this;
            TermekKezeloView detailView = new TermekKezeloView(vm);
            detailView.ShowDialog();
        }

        private void UpdateExisting(int cikkszam) //létező termék frissítése
        {
            var vm = new TermekKezeloViewModel(this, cikkszam);
            TermekKezeloView detailView = new TermekKezeloView(vm);
            detailView.ShowDialog();
        }

        private void ProductDetail()
        {
            var p = new TermekFotoViewModel();
            TermekFotoView dView = new TermekFotoView(p);
            dView.ShowDialog();
        }

        private void Close(Window window)
        {
            var loginView = new LoginView();
            loginView.Show();
            window.Close();
        }



    }
}
