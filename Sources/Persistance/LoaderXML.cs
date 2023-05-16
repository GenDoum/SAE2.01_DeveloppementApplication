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
        static string path = "../../../../Persistance/saves/";
        static string fichierXML = "users.xml";
        static string monstreXML = "monsters.xml";


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
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), path)); // Setup le chemin d'accès
            var serialiserXML = new DataContractSerializer(typeof(List<Monstre>));
            XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true }; // Pour avoir le format xml dans le fichier ( indentation etc... )
            using (TextWriter tw = File.CreateText(monstreXML))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, xmlSettings))
                {
                    serialiserXML.WriteObject(writer, monstres);
                }
            }
        }

        void IUserDataManager.saveUsers(List<User> users)// Serialise correctement juste voir comment l'appelé en fonction de IUserDataManager
        {
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), path)); // Setup le chemin d'accès
            var serialiserXML = new DataContractSerializer(typeof(List<User>));

            XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true }; // Pour avoir le format xml dans le fichier ( indentation etc... )
            using (TextWriter tw = File.CreateText(fichierXML))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, xmlSettings))
                {
                    serialiserXML.WriteObject(writer, users);
                }
            }
        }

        public List<User> loadUsers()
        {
            var serialiserXML = new DataContractSerializer(typeof(List<User>));
            List<User> users;
            using (Stream s = File.OpenRead(path + fichierXML))
            {
                users = serialiserXML.ReadObject(s) as List<User>;
            }

            Console.WriteLine();
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Pseudo} --> {u.Prenom} {u.Nom}");
            }
            return users;
        }
    }
}