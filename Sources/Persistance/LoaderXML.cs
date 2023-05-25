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
using System.Runtime.CompilerServices;
using System.Dynamic;
using System.Xml.Linq;

namespace Persistance
{/// <summary>
///  Le problème vient du GetCurrentDirectory, le prof à dit que c'était le sujet du prochain cour donc je mets ça en pose.
///  Chelou que ça marchait avant et je suis pas le seul à qui sa fait ça
///  Avant il me mettait dans les fichiers du projet mais plus maintenant
///  EN POSE
/// </summary>
    public class LoaderXml : IUserDataManager, IMonsterDataManager 
    {
        static string path = "../../../../Persistance/saves/";
        static string fichierUserXML = "users.xml";
        static string fichierMonstreXML = "monsters.xml";
        
        void IMonsterDataManager.saveMonsters(List<Monstre> monstres)
        {
            //Chargement();
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), path)); // Setup le chemin d'accès
            var serialiserXML = new DataContractSerializer(typeof(List<Monstre>));
            XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true }; // Pour avoir le format xml dans le fichier ( indentation etc... )
            using (TextWriter tw = File.CreateText(Path.Combine(fichierMonstreXML)))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, xmlSettings))
                {
                    serialiserXML.WriteObject(writer, monstres);
                }
            }
        }
        public List<Monstre> loadMonsters()
        {
            //Chargement();
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), path));
            var serialiserXML = new DataContractSerializer(typeof(List<Monstre>));
            List<Monstre>? monsters;
            try
            {
                using (Stream s = File.OpenRead(fichierMonstreXML))
                {
                    monsters = serialiserXML.ReadObject(s) as List<Monstre>;
                }
            }
            catch (FileNotFoundException e) {
                throw new FileNotFoundException("The XML file used to load a list of monsters is missing.", e);
            }
            if (monsters != null) return monsters; // ça va faire un code smells
            return new List<Monstre> { };
        }
        // Serialisation / Deserialisation de Users
        void IUserDataManager.saveUsers(List<User> users)// Serialise correctement juste voir comment l'appelé en fonction de IUserDataManager
        {
            //Chargement();

            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), path)); // Setup le chemin d'accès
            var serialiserXML = new DataContractSerializer(typeof(List<User>));

            XmlWriterSettings xmlSettings = new XmlWriterSettings() { Indent = true }; // Pour avoir le format xml dans le fichier ( indentation etc... )
            using (TextWriter tw = File.CreateText(fichierUserXML))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, xmlSettings))
                {
                    serialiserXML.WriteObject(writer, users);
                }
            }
        }
        public List<User> loadUsers()
        {
            //Chargement();
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), path));
            var serialiserXML = new DataContractSerializer(typeof(List<User>));
            List<User>? users;
            using (Stream s = File.OpenRead(fichierUserXML))
            {
                users = serialiserXML.ReadObject(s) as List<User>;
            }
            if (users == null)
            {
                return null; // Surement que ça va faire un code smells, mais j'ai pas trop cherché pour le moment
            }
            return users;
        }
    }
}