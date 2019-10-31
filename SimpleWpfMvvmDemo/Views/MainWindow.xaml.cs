using System;
using System.Windows.Input;
using SimpleWpfMvvmDemo.Models;
using SimpleWpfMvvmDemo.ViewModels;

namespace SimpleWpfMvvmDemo.Views
{
    public partial class MainWindow
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = Resources["ViewModel"] as MainWindowViewModel;

            if (_viewModel == null)
            {
                throw new Exception("ViewModel cannot be null");
            }
        }

        private void CanExecuteAddCommand(object sender, CanExecuteRoutedEventArgs args)
        {
            if (_viewModel != null)
            {
                UserModel userDetails = _viewModel.NewUserDetails;
                args.CanExecute = !string.IsNullOrWhiteSpace(userDetails.Firstname) &&
                                  !string.IsNullOrWhiteSpace(userDetails.Lastname);
            }
        }

        private void ExecuteAddCommand(object sender, ExecutedRoutedEventArgs args)
        {
            _viewModel.UserCollection.Add(_viewModel.NewUserDetails);
            _viewModel.SelectedUser = _viewModel.NewUserDetails;
            _viewModel.NewUserDetails = new UserModel();
        }
    }
}
