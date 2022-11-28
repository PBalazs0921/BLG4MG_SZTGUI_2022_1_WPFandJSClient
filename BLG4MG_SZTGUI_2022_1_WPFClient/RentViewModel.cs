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
    public class RentViewModel:ObservableRecipient
    {
        public RestCollection<Rent> Rents { get; set; }

        public ICommand DeleteRent { get; set; }

        public ICommand CreateRent { get; set; }
        public ICommand UpdateRent { get; set; }

        private Rent selectedRent;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;

            }
        }

        public Rent SelectedRent
        {
            get { return selectedRent; }
            set
            {
                if (value != null)
                {
                    selectedRent = new Rent()
                    {
                        id = value.id,
                        CarId=value.CarId,
                        CustomerId=value.CustomerId,
                        begin=value.begin,
                        end=value.end
                        
                    };
                    OnPropertyChanged();
                    (DeleteRent as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public RentViewModel()
        {
            if (!IsInDesignMode)
            {


                Rents = new RestCollection<Rent>("http://localhost:61417/", "Car", "hub");

                CreateRent = new RelayCommand(() =>
                {
                    Rents.Add(new Rent()
                    {
                        CustomerId = SelectedRent.CustomerId
                    });
                }
                );

                UpdateRent = new RelayCommand(() =>
                {
                    Rents.Update(SelectedRent);

                });
                DeleteRent = new RelayCommand(() =>
                {
                    Rents.Delete(SelectedRent.id);
                },
                () =>
                {
                    return SelectedRent != null;
                });

                selectedRent = new Rent();
            }
        }
    }
}
