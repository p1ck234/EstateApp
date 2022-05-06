using EstateApp.ModelBD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace EstateApp
{
    /// <summary>
    /// Interaction logic for BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        public BuyWindow()
        {
            InitializeComponent();
            dpDate.DisplayDateStart = DateTime.Now;
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.States.Load();
            Order currentBuy = new Order();
            try
            {
                currentBuy.ID = AvtorizationWindow.bd.States.Local.Count + 1;
                currentBuy.Date = dpDate.SelectedDate;
                currentBuy.StateID = Catalog.selectEntites.ID;
                AvtorizationWindow.bd.Orders.Add(currentBuy);
                AvtorizationWindow.bd.SaveChanges();
                AvtorizationWindow.Inf("Спасибо за запись\nВам перезвонит менеджер");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
