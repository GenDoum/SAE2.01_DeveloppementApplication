using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public interface IUserDataManager
    {
        //A CHANGER VISIBILITEE -> pour pas que tout le monde puisse load et save :)
        public void saveUsers(List<User> users);
        public List<User> loadUsers();
    }
}
