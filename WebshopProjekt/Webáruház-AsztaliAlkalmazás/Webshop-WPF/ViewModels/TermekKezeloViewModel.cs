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
    public class TermekKezeloViewModel : ObservableObject
    {
       
        public TermekekViewModel TermekekVM { get; set; }

       
        //Változáskezelés
        private termek _selectedtermek;

        public termek Selectedtermek
        {
            get { return _selectedtermek; }
            set { SetProperty(ref _selectedtermek, value); }
        }

        
        public RelayCommand SaveCmd { get; set; }

        public RelayCommand<Window> LogoutCommand { get; set; }


        //Új termék felvitele esetén
        public TermekKezeloViewModel()
        {
            _selectedtermek = new termek();
            SaveCmd = new RelayCommand(() => Save(Selectedtermek));
            LogoutCommand = new RelayCommand<Window>(e => Close(e));

        }

        //Meglévő termék módosítása

        public TermekKezeloViewModel(TermekekViewModel vm, int cikkszam)
        {
            _selectedtermek = vm.TermekRepo.GetById(cikkszam);
            TermekekVM = vm;
            SaveCmd = new RelayCommand(() => Save(Selectedtermek));
            LogoutCommand = new RelayCommand<Window>(e => Close(e));
           
        }


        private void Save(termek termek)
        {
            if (TermekekVM.TermekRepo.Exist(termek.Cikkszam))
            {
                // adatbázisból elkérjük az entitást, ha létezik
                termek t = TermekekVM.TermekRepo.GetById(termek.Cikkszam);
                // belemásoljuk a UI-on történt változásokat
                Selectedtermek.Copy(ref t);
                // frissítjük az adatbázisban
                TermekekVM.TermekRepo.Update(t);
            }
            else
            {
                TermekekVM.TermekRepo.Insert(termek);
               
            }
            TermekekVM.LoadDataCmd.Execute(null);
           

        }


        //Bezárás után a terméklistára
        public void Close(Window window)
        {
            window.Close();
            TermekekVM.LoadDataCmd.Execute(null);
        }
    }
}
