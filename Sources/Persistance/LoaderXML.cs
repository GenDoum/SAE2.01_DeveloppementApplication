using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace Persistance
{

    public class LoaderXML : IUserDataManager, IMonsterDataManager
    {
        static string fichierXML = "users.xml";
        static string monstreXML = "monsters.xml";
        /*
        #region SauvegardeUser
        public static void sauvegardeUserXML(List<User>) //Fonction de sauvegarde fonctionnelle si on enlève loadUsers car conflit en les deux
        {
            User test = new User("DedeDu42", "dede", "dodo", "mdp", new List<Monstre> { });


            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Persistance/saves/")); // Setup le chemin d'accès

            var serialiserXML = new DataContractSerializer(typeof(User));

            #region Serialisation

            XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true }; // Pour avoir le format xml dans le fichier ( indentation etc... )

            using (TextWriter tw = File.CreateText(fichierXML))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, xmlSettings))
                {
                    serialiserXML.WriteObject(writer, test);
                }
            }

            #endregion


            #region Deserialisation

            User user2;
            using (Stream s = File.OpenRead(fichierXML))
            {
                user2 = serialiserXML.ReadObject(s) as User;
            }

            #endregion

            #region AffichageTest

            Console.WriteLine(user2.Prenom);
            Console.WriteLine(user2.Nom);
            Console.WriteLine(user2.Pseudo);
            Console.WriteLine(user2.monstresDejaVu);


            #endregion
            #endregion
        }
        */


        public static void sauvegarderListUsers()
        {

        }
        List<Monstre> IMonsterDataManager.loadMonsters()
        {
            #region Deserialisation
            var serialiserXML = new DataContractSerializer(typeof(List<Monstre>));
            List<Monstre> monsters;
            using (Stream s = File.OpenRead(monstreXML))
            {
                monsters = serialiserXML.ReadObject(s) as List<Monstre>;
            }
            #endregion
            return monsters;
        }

        /// <summary>
        /// Enregistre les données dans un fichier XML 
        /// CORECTION: à adapter en fonction de IUserDataManager mais sinon fonctionnelle
        /// </summary>


        void IMonsterDataManager.saveMonsters(List<Monstre> monstres)
        {
            #region Serialisation

            
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Persistance/saves/")); // Setup le chemin d'accès
            var serialiserXML = new DataContractSerializer(typeof(List<Monstre>));

            #region Serialisation

            XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true }; // Pour avoir le format xml dans le fichier ( indentation etc... )
            using (TextWriter tw = File.CreateText(monstreXML))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, xmlSettings))
                {
                    serialiserXML.WriteObject(writer, monstres);
                }
            }
            #endregion
        }

        void IUserDataManager.saveUsers(List<User> users)// Serialise correctement juste voir comment l'appelé en fonction de IUserDataManager
        {
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Persistance/saves/")); // Setup le chemin d'accès
            var serialiserXML = new DataContractSerializer(typeof(List<User>));

            #region Serialisation

            XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true }; // Pour avoir le format xml dans le fichier ( indentation etc... )
            using (TextWriter tw = File.CreateText(fichierXML))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, xmlSettings))
                {
                    serialiserXML.WriteObject(writer, users);
                }
            }

            #endregion
            //throw new NotImplementedException();
        }

        public List<User> loadUsers()
        {
            #region Deserialisation
            var serialiserXML = new DataContractSerializer(typeof(List<User>));
            List<User> users;
            using (Stream s = File.OpenRead(fichierXML))
            {
                users = serialiserXML.ReadObject(s) as List<User>;
            }

            #endregion
            #region AffichageTest

            foreach (User u in users)
            {
                Console.WriteLine(u.Pseudo);
                Console.WriteLine(u.Prenom);
            }
            return users;
            #endregion
        }
    }
}

#endregion