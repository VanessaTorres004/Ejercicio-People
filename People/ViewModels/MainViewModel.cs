using People.Services;
using People.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace People.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();

        public ICommand DeleteCommand { get; set; }

        public MainViewModel()
        {
            LoadPeople();
            DeleteCommand = new Command<Person>(DeletePerson);
        }

        private void LoadPeople()
        {
            var people = App.Database.GetPeopleAsync().Result;
            foreach (var person in people)
            {
                People.Add(person);
            }
        }

        private void DeletePerson(Person person)
        {
            if (person != null)
            {
                App.Database.DeletePersonAsync(person);
                People.Remove(person);
                Application.Current.MainPage.DisplayAlert(
                    "Registro Eliminado",
                    $"{person.FirstName} {person.LastName} acaba de eliminar un registro.",
                    "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

