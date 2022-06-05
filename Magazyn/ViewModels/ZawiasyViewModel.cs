using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Magazyn.Models;

namespace Magazyn.ViewModels
{
    [INotifyPropertyChanged]
    public partial class ZawiasyViewModel
    {
        public Zawiasy _zawias = new Zawiasy();
        [ObservableProperty]
        string firma;
        [ObservableProperty]
        string model;
        [ObservableProperty]
        decimal cena;
        [ObservableProperty]
        int ilosc;
        [ObservableProperty]
        int katOtwarcia;
        [ObservableProperty]
        bool hamulec;
        [ObservableProperty]
        bool sprezyna;

        [ICommand]
        void AddZawias()
        {
            /*
            using (MagazynDBContext context = _contextFactory.Create())
            {
                _zawias.Firma = firma;
                _zawias.Model = model;
                _zawias.Cena = cena;
                _zawias.Ilosc = ilosc;
                _zawias.Kat_Otwarcia = katOtwarcia;
                _zawias.Hamulec = hamulec;
                _zawias.Sprezyna = sprezyna;
                context.Zawiasy.Add(_zawias);
                context.SaveChanges();
            }
            */
        }
    }
}
