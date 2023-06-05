using Model;
using Persistance;
namespace Vues;

public partial class Inscription : ContentPage
{
    string nom;
    string prenom;
    string id;
    string mdp;

	public Inscription()
	{
		InitializeComponent();
        BindingContext = (Application.Current as App).userManager;
    }
    private async void Valid_Clicked(object sender, EventArgs e)
    {
        id = Id.Text;
        mdp = Mdp.Text;
        nom = Nom.Text;
        prenom = Prenom.Text;
        if ((Application.Current as App).userManager.checkIfPseudoExists(id))
        {
            resultLabel.IsVisible = true;
            return;
            //await Navigation.PushAsync(new SearchMob());
        }
        try
        {
            User newUser = new User(id, nom, prenom, mdp);
        }
        catch (FormatException)
        {
            resultLabel.IsVisible = true;
            resultLabel.Text = "You must complete all entries!";
        }
        catch (ArgumentException)
        {
            resultLabel.IsVisible = true;
            resultLabel.Text = "You ";
        }

        (Application.Current as App).userManager.ListUsers.Add(newUser);
        (Application.Current as App).User = newUser;
        await Navigation.PopAsync();
        return;
    }

    private void Id_TextChanged(object sender, TextChangedEventArgs e)
    {
        resultLabel.IsVisible=false;
    }
}