using Model;
using Persistance;
namespace Vues;

public partial class Inscription : ContentPage
{ 
    List<User> users = new List<User>();
    UserManager userMngr = new UserManager(new LoaderXml());
    public User user { get; set; } = new User();
	public Inscription()
	{
		InitializeComponent();
        BindingContext=user;
	}
    private async void Valid_Clicked(object sender, EventArgs e)
    {
        if (!(Application.Current as App).userManager.checkIfPseudoExists(user.Pseudo))
        {
            users.Add(user);
            userMngr.saveUsers(users);
            userMngr.loadUsers();
            await Navigation.PushAsync(new Accueil());
        }       
    }
}