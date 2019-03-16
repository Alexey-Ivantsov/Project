using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_with_MongoDB
{
    public class BaseVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged<T>(Expression<Func<T>> raiser)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(raiser.Name));
        }
    }
}
