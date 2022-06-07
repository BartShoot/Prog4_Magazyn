using CommunityToolkit.Mvvm.Input;
using Magazyn.Models;
using Magazyn.Services;
using Magazyn.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Magazyn.ViewModels
{
    public class PlytyViewModel : ViewModelBase
    {
        public GenericDataService<Plyty> _genericDataService =
            new GenericDataService<Plyty>(new DbContextFactory());
        public PlytyViewModel()
        {
            _plyty = new();
            AddPlytaCommand = new RelayCommand(AddPlyta);
            UpdatePlytaCommand = new RelayCommand<Plyty>((param) => UpdatePlyta(param));
            DeletePlytaCommand = new RelayCommand<Plyty>((param) => DeletePlyta(param));
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            OpenEditWindowCommand = new RelayCommand<Plyty>((param) => OpenEditWindow(param));

            ListaPlyt = new();
            var result = Task.Run(() => GetAllPlytyAsync()).Result.ToList();
            foreach (var item in result)
            {
                ListaPlyt.Add(item);
            }
        }
        public PlytyViewModel(Plyty plyty) : this()
        {
            _plyty = new Plyty
            {
                Id = plyty.Id,
                Firma = plyty.Firma,
                Kolor = plyty.Kolor,
            };
            _firma = plyty.Firma;
            _kolor = plyty.Kolor;
            _typ = plyty.Typ;

        }
        private Plyty _plyty;
        public Plyty Plyty
        {
            get => _plyty;
            set
            {
                _plyty = value;
                OnPropertyChanged(nameof(Plyty));
            }
        }

        private ObservableCollection<Plyty> _listaPlyt;
        public ObservableCollection<Plyty> ListaPlyt
        {
            get => _listaPlyt;
            set
            {
                _listaPlyt = value;
                OnListChanged(ListaPlyt);
            }
        }

        private string _firma;
        public string Firma
        {
            get => _firma;
            set
            {
                _firma = value;
                OnPropertyChanged(nameof(Firma));
            }
        }
        private string _kolor;
        public string Kolor
        {
            get => _kolor;
            set
            {
                _kolor = value;
                OnPropertyChanged(nameof(Kolor));
            }
        }
        private string _typ;
        public string Typ
        {
            get => _typ;
            set
            {
                _typ = value;
                OnPropertyChanged(nameof(Typ));
            }
        }
        private int _ilosc;
        public int Ilosc
        {
            get => _ilosc;
            set
            {
                _ilosc = value;
                OnPropertyChanged(nameof(Ilosc));
            }
        }

        public ICommand AddPlytaCommand { get; }
        public async void AddPlyta()
        {
            _plyty.Firma = Firma;
            _plyty.Kolor = Kolor;
            _plyty.Typ = Typ;
            await _genericDataService.Create(_plyty);
        }
        public ICommand GetAllPlytyCommand { get; }
        public async Task<IEnumerable<Plyty>> GetAllPlytyAsync()
        {
            return await _genericDataService.GetAllAsync();
        }
        public ICommand UpdatePlytaCommand { get; set; }
        public void UpdatePlyta(Plyty param)
        {
            param.Firma = Firma;
            param.Kolor = Kolor;
            param.Typ = Typ;
            _ = _genericDataService.Update(param.Id, param);
        }
        public ICommand DeletePlytaCommand { get; set; }
        public void DeletePlyta(Plyty param)
        {
            _ = _genericDataService.Delete(param.Id);
        }
        public ICommand OpenAddWindowCommand { get; }
        public void OpenAddWindow()
        {
            var window = new Window
            {
                Name = "AddWindow",
                Title = "Dodaj uchwyt",
                Content = new PlytyAdd()
            };
            window.Show();
        }
        public ICommand OpenEditWindowCommand { get; set; }
        public void OpenEditWindow(Plyty param)
        {
            var window = new Window
            {
                Name = "EditWindow",
                Title = "Edytuj płyte",
                Content = new PlytyEdit()
            };
            window.DataContext = new PlytyViewModel(param);
            window.Show();
        }
    }
}
