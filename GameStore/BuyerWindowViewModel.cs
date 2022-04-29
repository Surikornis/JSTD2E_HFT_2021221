using JSTD2E_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JSTD2E_HFT_2021221.WPFClient
{
    class BuyerWindowViewModel : ObservableRecipient
    {
        public RestCollection<Buyer> Buyers { get; set; }

        private Buyer selectedBuyer;

        public Buyer SelectedBuyer
        {
            get { return selectedBuyer; }
            set
            {
                if (value != null)
                {
                    selectedBuyer = new Buyer()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Age = value.Age,
                        DateofPurchase = value.DateofPurchase
                    };
                }
                OnPropertyChanged();
                (DeleteBuyerCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand CreateBuyerCommand { get; set; }
        public ICommand UpdateBuyerCommand { get; set; }
        public ICommand DeleteBuyerCommand { get; set; }

        public BuyerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Buyers = new RestCollection<Buyer>("http://localhost:62282/", "buyer", "hub");
                CreateBuyerCommand = new RelayCommand(() =>
                {
                    Buyers.Add(new Buyer()
                    {
                        Name = SelectedBuyer.Name,
                        Age = SelectedBuyer.Age,
                        DateofPurchase = SelectedBuyer.DateofPurchase
                    });
                });

                UpdateBuyerCommand = new RelayCommand(() =>
                {
                    Buyers.Update(SelectedBuyer);
                });

                DeleteBuyerCommand = new RelayCommand(() =>
                {
                    Buyers.Delete(SelectedBuyer.Id);
                },
                () =>
                {
                    return SelectedBuyer != null;
                });
                SelectedBuyer = new Buyer();
            }
        }
    }
}
