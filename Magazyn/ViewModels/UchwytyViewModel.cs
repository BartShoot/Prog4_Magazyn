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
    public partial class UchwytyViewModel : ViewModelBase
    {
        public GenericDataService<Uchwyty> _genericDataService =
            new GenericDataService<Uchwyty>(new DbContextFactory());
        public UchwytyViewModel()
        {
            _uchwyt = new();
            AddUchwytCommand = new RelayCommand(AddUchwyt);
            UpdateUchwytCommand = new RelayCommand<Uchwyty>((param) => UpdateUchwyt(param));
            DeleteUchwytCommand = new RelayCommand<Uchwyty>((param) => DeleteUchwyt(param));
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            OpenEditWindowCommand = new RelayCommand<Uchwyty>((param) => OpenEditWindow(param));

            ListaUchwytow = new();
            var result = Task.Run(() => GetAllUchwytAsync()).Result.ToList();
            foreach (var item in result)
            {
                ListaUchwytow.Add(item);
            }
        }
        public UchwytyViewModel(Uchwyty uchwyt) : this()
        {
            _uchwyt = new Uchwyty
            {
                Id = uchwyt.Id,
                Firma = uchwyt.Firma,
                Model = uchwyt.Model,
                Cena = uchwyt.Cena,
                Ilosc = uchwyt.Ilosc,
                Rozstaw = uchwyt.Rozstaw,
                Kolor = uchwyt.Kolor
            };
            _firma = uchwyt.Firma;
            _model = uchwyt.Model;
            _cena = uchwyt.Cena;
            _ilosc = uchwyt.Ilosc;
            _rozstaw = uchwyt.Rozstaw;
            _kolor = uchwyt.Kolor;
        }
        private Uchwyty _uchwyt;
        public Uchwyty Uchwyt 
        { 
            get => _uchwyt; 
            set
            {
                _uchwyt = value;
                OnPropertyChanged(nameof(Uchwyt));
            }
        }

        private ObservableCollection<Uchwyty> _listaUchwytow;
        public ObservableCollection<Uchwyty> ListaUchwytow
        {
            get => _listaUchwytow;
            set
            {
                _listaUchwytow = value;
                OnListChanged(ListaUchwytow);
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
        private int _rozstaw = 12;
        public int Rozstaw
        {
            get => _rozstaw;
            set
            {
                _rozstaw = value;
                OnPropertyChanged(nameof(Rozstaw));
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

        public ICommand AddUchwytCommand { get; }
        public async void AddUchwyt()
        {
            _uchwyt.Firma = Firma;
            _uchwyt.Model = Model;
            _uchwyt.Cena = Cena;
            _uchwyt.Ilosc = Ilosc;
            _uchwyt.Rozstaw = Rozstaw;
            _uchwyt.Kolor = Kolor;
            await _genericDataService.Create(_uchwyt);
        }
        public ICommand GetAllUchwytCommand { get; }
        public async Task<IEnumerable<Uchwyty>> GetAllUchwytAsync()
        {
            return await _genericDataService.GetAllAsync();
        }
        public ICommand UpdateUchwytCommand { get; set; }
        public void UpdateUchwyt(Uchwyty param)
        {
            param.Firma = Firma;
            param.Model = Model;
            param.Cena = Cena;
            param.Ilosc = Ilosc;
            param.Rozstaw = Rozstaw;
            param.Kolor = Kolor;
            _ = _genericDataService.Update(param.Id, param);
        }
        public ICommand DeleteUchwytCommand { get; set; }
        public void DeleteUchwyt(Uchwyty param)
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
                Content = new UchwytyAdd()
            };
            window.Show();
        }
        public ICommand OpenEditWindowCommand { get; set; }
        public void OpenEditWindow(Uchwyty param)
        {
            var window = new Window
            {
                Name = "EditWindow",
                Title = "Edytuj uchwyt",
                Content = new UchwytyEdit()
            };
            window.DataContext = new UchwytyViewModel(param);
            window.Show();
        }
    }
}
