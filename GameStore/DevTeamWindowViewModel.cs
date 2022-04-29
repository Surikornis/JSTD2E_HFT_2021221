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
    class DevTeamWindowViewModel : ObservableRecipient
    {
        public RestCollection<DeveloperTeam> DeveloperTeams { get; set; }

        private DeveloperTeam selectedDevTeam;

        public DeveloperTeam SelectedDevTeam
        {
            get { return selectedDevTeam; }
            set 
            {
                if (value != null)
                {
                    selectedDevTeam = new DeveloperTeam()
                    {
                        Id = value.Id,
                        DevTeam = value.DevTeam,
                        DateofFoundation = value.DateofFoundation,
                        HQ = value.HQ
                    };
                }
                OnPropertyChanged();
                (DeleteDevTeamCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public ICommand CreateDevTeamCommand { get; set; }
        public ICommand UpdateDevTeamCommand { get; set; }
        public ICommand DeleteDevTeamCommand { get; set; }

        public DevTeamWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                DeveloperTeams = new RestCollection<DeveloperTeam>("http://localhost:62282/", "developerteam", "hub");
                CreateDevTeamCommand = new RelayCommand(() =>
                {
                    DeveloperTeams.Add(new DeveloperTeam()
                    {
                        DevTeam = SelectedDevTeam.DevTeam
                    });
                });

                UpdateDevTeamCommand = new RelayCommand(() =>
                {
                    DeveloperTeams.Update(SelectedDevTeam);
                });

                DeleteDevTeamCommand = new RelayCommand(() =>
                {
                    DeveloperTeams.Delete(SelectedDevTeam.Id);
                },
                () =>
                {
                    return SelectedDevTeam != null;
                });
                SelectedDevTeam = new DeveloperTeam();
            }
        }
    }
}
