using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;

namespace Wpf_with_MongoDB
{
    public class ApplicationViewModel : BaseVM, INotifyPropertyChanged
    {

        private PersonVM _selectedPerson;
        public ObservableCollection<PersonVM> Persons { get; set; }
        public PersonVM SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                if (_selectedPerson == value)
                    return;

                _selectedPerson = value;
                OnPropertyChanged(() => this.SelectedPerson);
            }
        }
        public ApplicationViewModel(IQueryable<PersonVM> ps)
        {
            var myObservableCollection = new ObservableCollection<PersonVM>(ps);
            Persons = myObservableCollection;
        }

        ICommand RemoveCommand { get; set; }

        public void ClickRemoveEvent()
        {
            MessageBox.Show("sa");
        }
    }
}
