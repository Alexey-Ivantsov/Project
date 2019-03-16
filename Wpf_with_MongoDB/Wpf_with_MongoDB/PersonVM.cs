using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_with_MongoDB
{
    public class PersonVM : BaseVM, INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(() => this.Id);
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(() => this.FirstName);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(() => this.LastName);
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged(() => this.Age);
            }
        }

    }
}
