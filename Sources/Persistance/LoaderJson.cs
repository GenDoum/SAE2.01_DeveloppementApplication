using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance
{
    public class LoaderJson : IUserDataManager, IMonsterDataManager
    {
        DataContractJsonSerializer jsonUserSerializer = new DataContractJsonSerializer(typeof(List<User>));
        DataContractJsonSerializer jsonMonsterSerializer = new DataContractJsonSerializer(typeof(List<Monstre>));
        MemoryStream memoryStream = new MemoryStream();
        List<Monstre> IMonsterDataManager.loadMonsters()
        {
            List<Monstre>? monstre2;
            using (FileStream s2 = File.OpenRead("monsters.json"))
            {
                monstre2 = jsonMonsterSerializer.ReadObject(s2) as List<Monstre>;
            }
            return monstre2;
            //throw new NotImplementedException();
        }

        List<User> IUserDataManager.loadUsers()
        {
            List<User>? user2;
            using (FileStream s2 = File.OpenRead("monsters.json"))
            {
                user2 = jsonMonsterSerializer.ReadObject(s2) as List<User>;
            }
            return user2;
            //throw new NotImplementedException();
            throw new NotImplementedException();
        }

        void IMonsterDataManager.saveMonsters(List<Monstre> monstres)
        {
            jsonMonsterSerializer.WriteObject(memoryStream, monstres);
            using (FileStream s = File.Create("monsters.json"))
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                    memoryStream,
                    System.Text.Encoding.UTF8,
                    false,
                    true))
            {
                memoryStream.WriteTo(s);
            }
        }

        void IUserDataManager.saveUsers(List<User> users)
        {
            jsonMonsterSerializer.WriteObject(memoryStream, users);
            using (FileStream s = File.Create("monsters.json"))
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                    memoryStream,
                    System.Text.Encoding.UTF8,
                    false,
                    true))
            {
                memoryStream.WriteTo(s);
            }
            throw new NotImplementedException();
        }
    }
}
