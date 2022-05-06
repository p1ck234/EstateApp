using EstateApp.ModelBD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for WindowRed.xaml
    /// </summary>
    public partial class WindowRed : Window
    {
        public WindowRed()
        {
            InitializeComponent();
            List<string> a = new List<string>() { "1-комн. квартира", "2-комн. квартира", "3-комн. квартира" };
            cmbActual.ItemsSource = a;
            tbName.Text = Catalog.selectEntites.Title.ToString();
            tbPrice.Text = Catalog.selectEntites.Cost.ToString();
            tbArea.Text = Catalog.selectEntites.Area.ToString();
            tbFloor.Text = Catalog.selectEntites.Floor.ToString();
            tbDescript.Text = Catalog.selectEntites.Description.ToString();
            if (Catalog.selectEntites.Category == "1-комн. квартира")
            {
                cmbActual.SelectedIndex = 0;
            }    
            else if (Catalog.selectEntites.Category == "2-комн. квартира")
            {
                cmbActual.SelectedIndex = 1;
            }
            else if (Catalog.selectEntites.Category == "3-комн. квартира")
            {
                cmbActual.SelectedIndex = 2;
            }
        }

        private void tbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[а-яА-Я]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9/./,]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }

        }

        private void tbArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9/./,]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbFloor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbDescript_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.States.Load();
            State currentProduct = new State();
            currentProduct.Title = tbName.Text;
            currentProduct.Cost = decimal.Parse(tbPrice.Text);
            currentProduct.Area = double.Parse(tbArea.Text);
            currentProduct.Floor = int.Parse(tbFloor.Text);
            currentProduct.Description = tbDescript.Text;
            currentProduct.CostArea = Catalog.selectEntites.CostArea;
            currentProduct.MainImagePage = Catalog.selectEntites.MainImagePage;

            if (cmbActual.SelectedIndex == 0)
            {
                currentProduct.Category = "1-комн. квартира";
            }
            else if (cmbActual.SelectedIndex == 1)
            {
                currentProduct.Category = "2-комн. квартира";
            }
            else if (cmbActual.SelectedIndex == 1)
            {
                currentProduct.Category = "3-комн. квартира";
            }
            try
            {
                AvtorizationWindow.bd.States.Remove(Catalog.selectEntites);
                AvtorizationWindow.bd.States.Add(currentProduct);
                AvtorizationWindow.bd.SaveChanges();
                AvtorizationWindow.Inf("Информация сохранена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
