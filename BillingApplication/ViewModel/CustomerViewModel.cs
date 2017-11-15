using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BillingApplication.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace BillingApplication.ViewModel
{
    class CustomerViewModel : INotifyPropertyChanged
    {
        private Customer _Customer;

        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Customer> _Customers;

        public ObservableCollection<Customer> Customers
        {
            get { return _Customers; }
            set { _Customers = value; }
        }

        public void SaveCustomer()
        {
            var temp = Customer;
            string fff =  Customer.Name;
        }

        private ICommand _Add;

        public ICommand Add
        {
            get { return _Add; }
            set { _Add = value; }
        }

        public CustomerViewModel()
        {
            _Customer = new Customer();
            _Add = new Add() { obj = this };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string str = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }


    }

    class Add : ICommand
    {
        public CustomerViewModel obj;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // my code
            obj.SaveCustomer();
        }
    }
}
