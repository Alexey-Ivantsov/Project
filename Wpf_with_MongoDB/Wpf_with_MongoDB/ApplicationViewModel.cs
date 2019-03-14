using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_with_MongoDB
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Person selectedPerson;

        public ObservableCollection<Person> Persons { get; set; }
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }
        public ApplicationViewModel(IQueryable<Person> ps)
        {
            var myObservableCollection = new ObservableCollection<Person>(ps);
            Persons = myObservableCollection;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
