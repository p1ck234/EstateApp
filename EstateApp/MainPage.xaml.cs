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

namespace EstateApp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            if (Manager.Admin == true)
            {
                btnAdmin.Visibility = Visibility.Visible;
                btnClient.Visibility = Visibility.Visible;
            }
            else
            {
                btnAdmin.Visibility = Visibility.Hidden;
            }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TableOrder());
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Catalog());
        }
    }
}
