using Model;
using Persistance;

namespace Vues
{
    public partial class App : Application
    {
        MonsterManager mnstrMngr = new MonsterManager(new LoaderXml());

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}