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
        users.Add(user);
        userMngr.saveUsers(users);
        
    }
}