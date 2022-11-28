using BLG4MG_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BLG4MG_SZTGUI_2022_1_WPFClient
{
    public class CustomerViewModel:ObservableRecipient
    {
        public RestCollection<Customer> Customers { get; set; }

        public ICommand DeleteCustomer { get; set; }

        public ICommand CreateCustomer { get; set; }
        public ICommand UpdateCustomer { get; set; }

        private Customer selectedCustomer;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;

            }
        }

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        Name = value.Name,
                        id = value.id
                    };
                    OnPropertyChanged();
                    (DeleteCustomer as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public CustomerViewModel()
        {
            if (!IsInDesignMode)
            {


                Customers = new RestCollection<Customer>("http://localhost:61417/", "Car", "hub");

                CreateCustomer = new RelayCommand(() =>
                {
                    Customers.Add(new Customer()
                    {
                        Name = SelectedCustomer.Name
                    });
                }
                );

                UpdateCustomer = new RelayCommand(() =>
                {
                    Customers.Update(SelectedCustomer);

                });
                DeleteCustomer = new RelayCommand(() =>
                {
                    Customers.Delete(SelectedCustomer.id);
                },
                () =>
                {
                    return SelectedCustomer != null;
                });

                selectedCustomer = new Customer();
            }
        }
    }
}
