using Model;
using Persistance;

namespace Vues
{
    public partial class App : Application
    {
        public MonsterManager monsterManager { get; private set; } = new MonsterManager(new LoaderStub());

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}