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
    public class AkcesoriaViewModel : ViewModelBase
    {
        public GenericDataService<Akcesoria> _genericDataService =
            new GenericDataService<Akcesoria>(new DbContextFactory());
        public AkcesoriaViewModel()
        {
            _akcesoria = new();
            AddAkcesoriaCommand = new RelayCommand(AddAkcesoria);
            UpdateAkcesoriaCommand = new RelayCommand<Akcesoria>((param) => UpdateAkcesoria(param));
            DeleteAkcesoriaCommand = new RelayCommand<Akcesoria>((param) => DeleteAkcesoria(param));
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            OpenEditWindowCommand = new RelayCommand<Akcesoria>((param) => OpenEditWindow(param));

            ListaAkcesoriow = new();
            var result = Task.Run(() => GetAllAkcesoriaAsync()).Result.ToList();
            foreach (var item in result)
            {
                ListaAkcesoriow.Add(item);
            }
        }
        public AkcesoriaViewModel(Akcesoria akcesoria) : this()
        {
            _akcesoria = new Akcesoria
            {
                Id = akcesoria.Id,
                Firma = akcesoria.Firma,
                Nazwa = akcesoria.Nazwa,
                Cena = akcesoria.Cena,
                Ilosc = akcesoria.Ilosc
            };
            _firma = akcesoria.Firma;
            _nazwa = akcesoria.Nazwa;
            _cena = akcesoria.Cena;
            _ilosc = akcesoria.Ilosc;
        }
        private Akcesoria _akcesoria;
        public Akcesoria Akcesoria
        {
            get => _akcesoria;
            set
            {
                _akcesoria = value;
                OnPropertyChanged(nameof(Akcesoria));
            }
        }

        private ObservableCollection<Akcesoria> _listaAkcesoriow;
        public ObservableCollection<Akcesoria> ListaAkcesoriow
        {
            get => _listaAkcesoriow;
            set
            {
                _listaAkcesoriow = value;
                OnListChanged(ListaAkcesoriow);
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
        private string _nazwa;
        public string Nazwa
        {
            get => _nazwa;
            set
            {
                _nazwa = value;
                OnPropertyChanged(nameof(Nazwa));
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

        public ICommand AddAkcesoriaCommand { get; }
        public async void AddAkcesoria()
        {
            _akcesoria.Firma = Firma;
            _akcesoria.Nazwa = Nazwa;
            _akcesoria.Cena = Cena;
            _akcesoria.Ilosc = Ilosc;
            await _genericDataService.Create(_akcesoria);
        }
        public ICommand GetAllAkcesoriaCommand { get; }
        public async Task<IEnumerable<Akcesoria>> GetAllAkcesoriaAsync()
        {
            return await _genericDataService.GetAllAsync();
        }
        public ICommand UpdateAkcesoriaCommand { get; set; }
        public void UpdateAkcesoria(Akcesoria param)
        {
            param.Firma = Firma;
            param.Nazwa = Nazwa;
            param.Cena = Cena;
            param.Ilosc = Ilosc;
            _ = _genericDataService.Update(param.Id, param);
        }
        public ICommand DeleteAkcesoriaCommand { get; set; }
        public void DeleteAkcesoria(Akcesoria param)
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
                Content = new AkcesoriaAdd()
            };
            window.Show();
        }
        public ICommand OpenEditWindowCommand { get; set; }
        public void OpenEditWindow(Akcesoria param)
        {
            var window = new Window
            {
                Name = "EditWindow",
                Title = "Edytuj uchwyt",
                Content = new AkcesoriaEdit()
            };
            window.DataContext = new AkcesoriaViewModel(param);
            window.Show();
        }
    }
}
