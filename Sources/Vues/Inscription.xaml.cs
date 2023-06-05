using Model;
using Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        User newUser = new User { };
        if ((Application.Current as App).userManager.checkIfPseudoExists(id))
        {
            resultLabel.Text = "Error, this username is already taken!";
            resultLabel.IsVisible = true;
            return;
            //await Navigation.PushAsync(new SearchMob());
        }
        try
        {
            newUser = new User(id, nom, prenom, mdp);
            (Application.Current as App).userManager.ListUsers.Add(newUser);
            (Application.Current as App).User = newUser;
            await Navigation.PopAsync();
        }
        catch (ArgumentException)
        {
            resultLabel.IsVisible = true;
            resultLabel.Text = "Vous devez compléter tous les champs.";
        }
        catch (FormatException)
        {
            resultLabel.IsVisible = true;
            resultLabel.Text = "Votre identifiant / mot de passe ne peut contenir seulement des nombres !";
        }
        //resultLabel.IsVisible = true;
        //resultLabel.Text = "You must complete all entries!";
        //resultLabel.IsVisible = true;
        return;
    }

    private void Id_TextChanged(object sender, TextChangedEventArgs e)
    {
        resultLabel.IsVisible=false;
    }
}