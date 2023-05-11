using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class LoaderJson : IUserDataManager, IMonsterDataManager
    {
        List<Monstre> IMonsterDataManager.loadMonsters()
        {
            throw new NotImplementedException();
        }

        List<User> IUserDataManager.loadUsers()
        {
            throw new NotImplementedException();
        }

        void IMonsterDataManager.saveMonsters(List<Monstre> monstres)
        {
            throw new NotImplementedException();
        }

        void IUserDataManager.saveUsers(List<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
