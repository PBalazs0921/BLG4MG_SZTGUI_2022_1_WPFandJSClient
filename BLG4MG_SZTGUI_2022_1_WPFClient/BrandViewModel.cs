using System;
using BLG4MG_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Windows;

namespace BLG4MG_SZTGUI_2022_1_WPFClient
{
    public class BrandViewModel:ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }

        public ICommand DeleteBrand { get; set; }

        public ICommand CreateBrand { get; set; }
        public ICommand UpdateBrand { get; set; }

        private Brand selectedBrand;
        
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;

            }
        }

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        BrandName = value.BrandName,
                        BrandId = value.BrandId
                    };
                    OnPropertyChanged();
                    (DeleteBrand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public BrandViewModel()
        {
            if (!IsInDesignMode)
            {


                Brands = new RestCollection<Brand>("http://localhost:61417/", "brand");

                CreateBrand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        BrandId = 69,
                        BrandName = "sajt"
                    });
                }
                );

                UpdateBrand = new RelayCommand(() => 
                {
                    Brands.Update(SelectedBrand);
                
                });
                DeleteBrand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.BrandId);
                },
                () =>
                {
                    return SelectedBrand != null;
                });


            }
        }

    }
}
