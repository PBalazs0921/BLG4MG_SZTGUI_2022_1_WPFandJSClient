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
    public class CarViewModel:ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }

        public ICommand DeleteCar { get; set; }

        public ICommand CreateCar { get; set; }
        public ICommand UpdateCar { get; set; }

        private Car selectedCar;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;

            }
        }

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Model = value.Model,
                        id = value.id
                    };
                    OnPropertyChanged();
                    (DeleteCar as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public CarViewModel()
        {
            if (!IsInDesignMode)
            {


                Cars = new RestCollection<Car>("http://localhost:61417/", "Car", "hub");

                CreateCar = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {
                        Model = SelectedCar.Model
                    });
                }
                );

                UpdateCar = new RelayCommand(() =>
                {
                    Cars.Update(SelectedCar);

                });
                DeleteCar = new RelayCommand(() =>
                {
                    Cars.Delete(SelectedCar.id);
                },
                () =>
                {
                    return SelectedCar != null;
                });

                selectedCar = new Car();
            }
        }
    }
}
