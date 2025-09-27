using MVVM_Sample.Command;
using MVVM_Sample.Model;
using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;

namespace MVVM_Sample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region "Private Felder"
        private ObservableCollection<Person> _personsList;
        private string _actualPosition;
        private ListCollectionView _personsView;
        private CommandBinding _newCommandBinding;
        private CommandBinding _deleteCommandBinding;
        private CommandBinding _saveCommandBinding;
        private CommandBinding _undoCommandBinding;
        #endregion

        #region "Öffentliche Eigenschaften"
        public ListCollectionView PersonsView
        {
            get { return _personsView; }
        }

        public string ActualPosition
        {
            get { return _actualPosition; }
            private set
            {
                SetProperty<string>(ref _actualPosition, value);
            }
        }

        public ICommand FirstCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        public ICommand PreviousCommand { get; private set; }
        public ICommand LastCommand { get; private set; }

        public CommandBinding NewCommandBinding
        {
            get { return _newCommandBinding; }
        }

        public CommandBinding SaveCommandBinding
        {
            get { return _saveCommandBinding; }
        }

        public CommandBinding DeleteCommandBinding
        {
            get { return _deleteCommandBinding; }
        }

        public CommandBinding UndoCommandBinding
        {
            get { return _undoCommandBinding; }
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
           _personsView.CurrentChanged += _persons_CurrentChanged;

           // Commands initialisieren
           FirstCommand = new RelayCommand(FirstExecute, BackCanExecute);
           PreviousCommand = new RelayCommand(PreviousExecute, BackCanExecute);
           NextCommand = new RelayCommand(NextExecute, ForwardCanExecute);
           LastCommand = new RelayCommand(LastExecute, ForwardCanExecute);

           // CommandBindings erzeugen
           _newCommandBinding = new CommandBinding(ApplicationCommands.New, NewExecuted, NewCanExecute);
           _deleteCommandBinding = new CommandBinding(ApplicationCommands.Delete, DeleteExecuted, DeleteCanExecute);
           _saveCommandBinding = new CommandBinding(ApplicationCommands.Save, SaveExecuted, SaveCanExecute);
           _undoCommandBinding = new CommandBinding(ApplicationCommands.Undo, UndoExecuted, UndoCanExecute);
        }
        #endregion

        #region "Methoden der CommandBindings"
        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // To do
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // To do
        }

        private void DeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = PersonsView.Count > 0;
        }

        private void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Person persDelete = PersonsView.CurrentItem as Person;
            if (persDelete != null)
                _personsList.Remove(persDelete);
            _personsView.MoveCurrentToFirst();
        }

        private void NewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Person person = new Person();
            _personsList.Add(person);
            _personsView.MoveCurrentTo(person);
        }

        private void UndoCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // To do
        }

        private void UndoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // To do
        }
        #endregion

        #region "Methoden für Commands"
        private bool BackCanExecute(object obj)
        {
            return _personsView.CurrentPosition > 0;
        }

        private bool ForwardCanExecute(object obj)
        {
            return _personsView.CurrentPosition < _personsView.Count - 1;
        }

        private void FirstExecute(object obj)
        {
            _personsView.MoveCurrentToFirst();
        }
      
        private void PreviousExecute(object obj)
        {
            _personsView.MoveCurrentToPrevious();
        }       
      
        private void NextExecute(object obj)
        {
            _personsView.MoveCurrentToNext();
        }

        private void LastExecute(object obj)
        {
            _personsView.MoveCurrentToLast();
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

        private void _persons_CurrentChanged(object sender, EventArgs e)
        {
            ActualPosition = "Datensatz " + (_personsView.CurrentPosition + 1) +
                             " von " + _personsView.Count;
        }

        #endregion
    }
}
