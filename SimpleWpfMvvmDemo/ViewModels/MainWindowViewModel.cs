using System.Collections.ObjectModel;
using System.ComponentModel;
using SimpleWpfMvvmDemo.Models;

namespace SimpleWpfMvvmDemo.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private UserModel _selectedUser;
        private ObservableCollection<UserModel> _userCollection;

        public MainWindowViewModel()
        {
            UserCollection = new ObservableCollection<UserModel>
            {
                new UserModel {Firstname = "Firstname1", Lastname = "Lastname1"},
                new UserModel {Firstname = "Firstname2", Lastname = "Lastname2"},
                new UserModel {Firstname = "Firstname3", Lastname = "Lastname3"},
                new UserModel {Firstname = "Firstname4", Lastname = "Lastname4"}
            };

            NewUserDetails = new UserModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public ObservableCollection<UserModel> UserCollection
        {
            get => _userCollection;
            set
            {
                _userCollection = value;
                OnPropertyChanged("UserCollection");
            }
        }

        private UserModel _newUserDetails;

        public UserModel NewUserDetails
        {
            get => _newUserDetails;
            set
            {
                _newUserDetails = value;
                OnPropertyChanged("NewUserDetails");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventArgs propertyChangedEventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, propertyChangedEventArgs);
        }
    }
}
