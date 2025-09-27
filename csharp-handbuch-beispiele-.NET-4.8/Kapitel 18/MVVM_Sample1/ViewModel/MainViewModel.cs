using MVVM_Sample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml.Serialization;

namespace MVVM_Sample.ViewModel
{
    public class MainViewModel
    {
        #region "Private Felder"
        private ObservableCollection<Person> _personsList;
        private ListCollectionView _personsView;
        #endregion

        #region "Öffentliche Eigenschaften"
        public ListCollectionView PersonsView
        {
            get { return _personsView; }
        }
        #endregion

        #region "Konstruktor"
        public MainViewModel()
        {
            // Personenliste füllen
            _personsList = new ObservableCollection<Person>();
             LoadPersons(ref _personsList);
            // ListCollectionView initialisieren
           _personsView = new ListCollectionView(_personsList);
        }
        #endregion

        #region "Private Methoden"
        private void LoadPersons(ref ObservableCollection<Person> liste)
        {
            // XML-Datei deserialisieren
            if (File.Exists("Persons.xml"))
            {
                FileStream fs = new FileStream("Persons.xml", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
                liste = (ObservableCollection<Person>)serializer.Deserialize(fs);
                fs.Close();
            }
        }
        #endregion
    }
}
