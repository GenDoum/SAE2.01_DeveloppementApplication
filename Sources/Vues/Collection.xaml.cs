using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Vues;

public partial class Collection : ContentPage, INotifyPropertyChanged
{
    public ObservableCollection<Monstre> MnstrTemp = (Application.Current as App).monsterManager.ListMonsters;
    public ObservableCollection<Monstre> MonstresDejaVu { get; set; }

    public Collection()
    {
        InitializeComponent();
        User toto = (Application.Current as App).User;
        MonstresDejaVu = new ObservableCollection<Monstre>(toto.monstresDejaVu);
        
        ListViewMonsters.BindingContext = this;
    }

    private void UpdateListMobs()
    {
        var monstresDejaVu = MnstrTemp.Where(monstre => (Application.Current as App).User.monstresDejaVu.Contains(monstre)).ToList();
        var monstresPasVu = MnstrTemp.Except((Application.Current as App).User.monstresDejaVu).ToList();
        var listMobs = new ObservableCollection<Monstre>();
        listMobs.Clear();
        

        if (CheckboxdejaVu.IsChecked && CheckboxpasVu.IsChecked)
        {
            var concatMonstres = monstresDejaVu.Concat(monstresPasVu);
            listMobs = new ObservableCollection<Monstre>(concatMonstres);
        }
        else if (CheckboxdejaVu.IsChecked)
        {
            listMobs = new ObservableCollection<Monstre>(monstresDejaVu);
        }
        else if (CheckboxpasVu.IsChecked)
        {
            listMobs = new ObservableCollection<Monstre>(monstresPasVu);
        }
        else
        {
            listMobs = new ObservableCollection<Monstre>();
        }
    }

    private void CheckedVu(object sender, CheckedChangedEventArgs e)
    {
        UpdateListMobs();
    }

    private void CheckedPasVu(object sender, CheckedChangedEventArgs e)
    {
        UpdateListMobs();
    }

    private string imageLinkConverter(string imageLink)
    {
        imageLink = String.Concat(imageLink.Where(c => !Char.IsWhiteSpace(c)));
        imageLink = "collection" + imageLink.ToLower() + ".png";
        return imageLink;
    }
}