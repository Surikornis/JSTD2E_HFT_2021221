using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSTD2E_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            DevTeamWindow dwt = new DevTeamWindow();
            this.Close();
            dwt.Show();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gw = new GameWindow();
            this.Close();
            gw.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            BuyerWindow bw = new BuyerWindow();
            this.Close();
            bw.Show();
        }
    }
}
