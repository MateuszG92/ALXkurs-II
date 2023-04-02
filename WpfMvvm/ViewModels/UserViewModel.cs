using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfMvvm.Models;

namespace WpfMvvm.ViewModels
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        private User user;
        public string FirstName
        {
            get { return user.FirstName; }
            set 
            {
                if (user.FirstName != value)
                {
                    user.FirstName = value;
                    OnPropertyChange(nameof(FirstName));
                }
            }
        }
        public string LastName
        {
            get { return user.LastName; }
            set
            {
                if (user.LastName != value)
                {
                    user.LastName = value;
                    OnPropertyChange(nameof(LastName));
                }
            }
        }

        public UserViewModel()
        {
            user = new User()
            {
                FirstName="Jan",
                LastName="Kowalski"
            };
            Task.Run(() =>
            {
                Thread.Sleep(10000);
                user.FirstName = "Zenon";
                OnPropertyChange(nameof(FirstName));
                user.LastName = "Jakiśtam";
                OnPropertyChange(nameof(LastName));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
