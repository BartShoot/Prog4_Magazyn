using CommunityToolkit.Mvvm.Input;
using Magazyn.Models;
using Magazyn.Services;
using Magazyn.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Magazyn.ViewModels
{
    public partial class ZawiasyViewModel : ViewModelBase
    {
        public GenericDataService<Zawiasy> _genericDataService =
            new GenericDataService<Zawiasy>(new DbContextFactory());
        public ZawiasyViewModel()
        {
            _zawias = new();
            DeleteZawiasCommand = new RelayCommand<Zawiasy>((param) => DeleteZawias(param));
            AddZawiasCommand = new RelayCommand(AddZawias);
            UpdateZawiasCommand = new RelayCommand<Zawiasy>((param) => UpdateZawias(param));
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            OpenEditWindowCommand = new RelayCommand<Zawiasy>((param) => OpenEditWindow(param));

            ListaZawiasow = new();
            var result = Task.Run(() => GetAllZawiasAsync()).Result.ToList();
            foreach (var item in result)
            {
                ListaZawiasow.Add(item);
            }
        }

        public ZawiasyViewModel(Zawiasy zawias) : this()
        {
            _zawias = new Zawiasy
            {
                Id = zawias.Id,
                Firma = zawias.Firma,
                Model = zawias.Model,
                Cena = zawias.Cena,
                Ilosc = zawias.Ilosc,
                KatOtwarcia = zawias.KatOtwarcia,
                Hamulec = zawias.Hamulec,
                Sprezyna = zawias.Sprezyna
            };
            _firma = zawias.Firma;
            _model = zawias.Model;
            _cena = zawias.Cena;
            _ilosc = zawias.Ilosc;
            _katOtwarcia = zawias.KatOtwarcia;
            _hamulec = zawias.Hamulec;
            _sprezyna = zawias.Sprezyna;
        }

        private Zawiasy _zawias;
        public Zawiasy Zawias
        {
            get => _zawias;
            set
            {
                _zawias = value;
                OnPropertyChanged(nameof(Zawias));
            }
        }
        
        private ObservableCollection<Zawiasy> _listaZawiasow;
        public ObservableCollection<Zawiasy> ListaZawiasow
        {
            get => _listaZawiasow;
            set
            {
                _listaZawiasow = value;
                OnListChanged(ListaZawiasow);
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
        private int _katOtwarcia = 90;
        public int KatOtwarcia
        {
            get => _katOtwarcia;
            set
            {
                _katOtwarcia = value;
                OnPropertyChanged(nameof(KatOtwarcia));
            }
        }
        private bool _hamulec;
        public bool Hamulec
        {
            get => _hamulec;
            set
            {
                _hamulec = value;
                OnPropertyChanged(nameof(Hamulec));
            }
        }
        private bool _sprezyna;
        public bool Sprezyna
        {
            get => _sprezyna;
            set
            {
                _sprezyna = value;
                OnPropertyChanged(nameof(Sprezyna));
            }
        }

        public ICommand AddZawiasCommand { get; }
        public async void AddZawias()
        {
            _zawias.Firma = Firma;
            _zawias.Model = Model;
            _zawias.Cena = Cena;
            _zawias.Ilosc = Ilosc;
            _zawias.KatOtwarcia = KatOtwarcia;
            _zawias.Hamulec = Hamulec;
            _zawias.Sprezyna = Sprezyna;
            await _genericDataService.Create(_zawias);
            
        }
        public ICommand GetAllZawiasCommand { get; }
        public async Task<IEnumerable<Zawiasy>> GetAllZawiasAsync()
        {
            return await _genericDataService.GetAllAsync();
        }
        public ICommand UpdateZawiasCommand { get; set; }
        public void UpdateZawias(Zawiasy param)
        {
            param.Firma = Firma;
            param.Model = Model;
            param.Cena = Cena;
            param.Ilosc = Ilosc;
            param.KatOtwarcia = KatOtwarcia;
            param.Hamulec = Hamulec;
            param.Sprezyna = Sprezyna;
            _ = _genericDataService.Update(param.Id, param);
        }
        public ICommand DeleteZawiasCommand { get; set; }
        public void DeleteZawias(Zawiasy param)
        {
            _ = _genericDataService.Delete(param.Id);
        }

        public ICommand OpenAddWindowCommand { get; }
        public void OpenAddWindow()
        {
            var window = new Window
            {
                Name = "AddWindow",
                Title = "Dodaj zawias",
                Content = new ZawiasyAdd()
            };

            window.Show();
        }
        public ICommand OpenEditWindowCommand { get; set; }
        public void OpenEditWindow(Zawiasy param)
        {
            var window = new Window
            {
                Name = "EditWindow",
                Title = "Edytuj zawias",
                Content = new ZawiasyEdit()
            };
            window.DataContext = new ZawiasyViewModel(param);
            window.Show();
        }
    }
}