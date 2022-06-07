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
    public class ProwadniceViewModel : ViewModelBase
    {
        public GenericDataService<Prowadnice> _genericDataService =
            new GenericDataService<Prowadnice>(new DbContextFactory());
        public ProwadniceViewModel()
        {
            _prowadnica = new();
            AddProwadniceCommand = new RelayCommand(AddProwadnice);
            UpdateProwadniceCommand = new RelayCommand<Prowadnice>((param) => UpdateProwadnice(param));
            DeleteProwadniceCommand = new RelayCommand<Prowadnice>((param) => DeleteProwadnice(param));
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            OpenEditWindowCommand = new RelayCommand<Prowadnice>((param) => OpenEditWindow(param));

            ListaProwadnic = new();
            var result = Task.Run(() => GetAllProwadniceAsync()).Result.ToList();
            foreach (var item in result)
            {
                ListaProwadnic.Add(item);
            }
        }
        public ProwadniceViewModel(Prowadnice prowadnica) : this()
        {
            _prowadnica = new Prowadnice
            {
                Id = prowadnica.Id,
                Firma = prowadnica.Firma,
                Model = prowadnica.Model,
                Cena = prowadnica.Cena,
                Ilosc = prowadnica.Ilosc,
                Dlugosc = prowadnica.Dlugosc,
                Samodomyk = prowadnica.Samodomyk
            };
            _firma = prowadnica.Firma;
            _model = prowadnica.Model;
            _cena = prowadnica.Cena;
            _ilosc = prowadnica.Ilosc;
            _dlugosc = prowadnica.Dlugosc;
            _samodomyk = prowadnica.Samodomyk;
        }
        private Prowadnice _prowadnica;
        public Prowadnice Prowadnica
        {
            get => _prowadnica;
            set
            {
                _prowadnica = value;
                OnPropertyChanged(nameof(Prowadnica));
            }
        }

        private ObservableCollection<Prowadnice> _listaProwadnic;
        public ObservableCollection<Prowadnice> ListaProwadnic
        {
            get => _listaProwadnic;
            set
            {
                _listaProwadnic = value;
                OnListChanged(ListaProwadnic);
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
        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        private decimal _cena;
        public decimal Cena
        {
            get => _cena;
            set
            {
                _cena = value;
                OnPropertyChanged(nameof(Cena));
            }
        }
        private int _ilosc = 1;
        public int Ilosc
        {
            get => _ilosc;
            set
            {
                _ilosc = value;
                OnPropertyChanged(nameof(Ilosc));
            }
        }
        private int _dlugosc = 12;
        public int Dlugosc
        {
            get => _dlugosc;
            set
            {
                _dlugosc = value;
                OnPropertyChanged(nameof(Dlugosc));
            }
        }
        private bool _samodomyk;
        public bool Samodomyk
        {
            get => _samodomyk;
            set
            {
                _samodomyk = value;
                OnPropertyChanged(nameof(Samodomyk));
            }
        }

        public ICommand AddProwadniceCommand { get; }
        public async void AddProwadnice()
        {
            _prowadnica.Firma = Firma;
            _prowadnica.Model = Model;
            _prowadnica.Cena = Cena;
            _prowadnica.Ilosc = Ilosc;
            _prowadnica.Dlugosc = Dlugosc;
            _prowadnica.Samodomyk = Samodomyk;
            await _genericDataService.Create(_prowadnica);
        }
        public ICommand GetAllProwadniceCommand { get; }
        public async Task<IEnumerable<Prowadnice>> GetAllProwadniceAsync()
        {
            return await _genericDataService.GetAllAsync();
        }
        public ICommand UpdateProwadniceCommand { get; set; }
        public void UpdateProwadnice(Prowadnice param)
        {
            param.Firma = Firma;
            param.Model = Model;
            param.Cena = Cena;
            param.Ilosc = Ilosc;
            param.Dlugosc = Dlugosc;
            param.Samodomyk = Samodomyk;
            _ = _genericDataService.Update(param.Id, param);
        }
        public ICommand DeleteProwadniceCommand { get; set; }
        public void DeleteProwadnice(Prowadnice param)
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
                Content = new ProwadniceAdd()
            };
            window.Show();
        }
        public ICommand OpenEditWindowCommand { get; set; }
        public void OpenEditWindow(Prowadnice param)
        {
            var window = new Window
            {
                Name = "EditWindow",
                Title = "Edytuj uchwyt",
                Content = new ProwadniceEdit()
            };
            window.DataContext = new ProwadniceViewModel(param);
            window.Show();
        }
    }
}
