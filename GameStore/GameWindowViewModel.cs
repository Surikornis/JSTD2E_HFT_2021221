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
    class GameWindowViewModel : ObservableRecipient
    {
        public RestCollection<Game> Games { get; set; }

        private Game selectedGame;

        public Game SelectedGame
        {
            get { return selectedGame; }
            set 
            {
                if (value != null)
                {
                    selectedGame = new Game()
                    {
                        Id = value.Id,
                        GameName = value.GameName,
                        Type = value.Type,
                        Price = value.Price,
                        BuyerId = value.BuyerId,
                        DevTeamId = value.DevTeamId
                    };
                }
                OnPropertyChanged();
                (DeleteGameCommand as RelayCommand).NotifyCanExecuteChanged();
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
        public ICommand CreateGameCommand { get; set; }
        public ICommand UpdateGameCommand { get; set; }
        public ICommand DeleteGameCommand { get; set; }

        public GameWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Games = new RestCollection<Game>("http://localhost:62282/", "game", "hub");
                CreateGameCommand = new RelayCommand(() =>
                {
                    Games.Add(new Game()
                    {
                        GameName = SelectedGame.GameName,
                        Type = SelectedGame.Type,
                        Price = SelectedGame.Price,
                        BuyerId = SelectedGame.BuyerId,
                        DevTeamId = SelectedGame.DevTeamId
                    });
                });

                UpdateGameCommand = new RelayCommand(() =>
                {
                    Games.Update(SelectedGame);
                }
                );

                DeleteGameCommand = new RelayCommand(() =>
                {
                    Games.Delete(SelectedGame.Id);
                },
                () =>
                {
                    return SelectedGame != null;
                });
                SelectedGame = new Game();
            }
        }
    }
}
