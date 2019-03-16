using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Wpf_with_MongoDB
{
    public class ApplicationViewModel : BaseVM, INotifyPropertyChanged
    {

        private PersonVM selectedPerson;
        public ObservableCollection<PersonVM> Persons { get; set; }
        public PersonVM SelectedPerson
        {
            get => selectedPerson;
            set
            {
                if (selectedPerson == value)
                    return;

                selectedPerson = value;
                OnPropertyChanged(() => this.SelectedPerson);
            }
        }
        public ApplicationViewModel(IQueryable<PersonVM> ps)
        {
            var myObservableCollection = new ObservableCollection<PersonVM>(ps);
            Persons = myObservableCollection;
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        PersonVM pers = obj as PersonVM;
                        if (pers != null)
                        {
                            Persons.Remove(pers);
                        }
                    },
                    (obj) => Persons.Count > 0));
            }

        }

    }
}
