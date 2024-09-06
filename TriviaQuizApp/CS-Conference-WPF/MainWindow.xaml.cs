using System;
using System.Collections;
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
using CS_Conference_WPF.Repos;
using CS_Conference_WPF.Models;
using CS_Conference_WPF.Views;
using System.IO;

namespace CS_Conference_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Organizer> organizers = new List<Organizer>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClick_AddOrganizer(object sender, RoutedEventArgs e)
        {
            //Caputure Name
            if(string.IsNullOrEmpty(txbName.Text))
            {
                MessageBox.Show("Please enter the name", "Name Missing",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Capture Availability 
            List<CheckBox> availableTimes = stkCheckBoxesContainer.Children.OfType<CheckBox>().ToList();
            StringBuilder availableValues = new StringBuilder();

            foreach(CheckBox checkBox in availableTimes) 
            { 
                if(checkBox.IsChecked == true) 
                {
                    availableValues.Append(checkBox.Content.ToString()+",");
                }
            }

            if (string.IsNullOrEmpty(availableValues.ToString()))
            {
                MessageBox.Show("Please check an availability time", "Missing Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Country & City (optional)

            string selectedCountry = (cmbCounties.SelectedItem as ComboBoxItem).Content.ToString();
            string selectedCity = cmbCities.SelectedItem.ToString();

            Organizer organizer = new Organizer()
            {
                Name = txbName.Text,
                Availability = availableValues.ToString(),
                Country = string.IsNullOrEmpty(selectedCountry) ? "NA" : selectedCountry,
                City = string.IsNullOrEmpty(selectedCity) ? "NA" : selectedCity
            };

            organizers.Add(organizer);
            SaveOrganizerData(organizer);
        }


        private void SaveOrganizerData(Organizer organizer)
        {
            //Save data file.
            try
            {
                //DO NOT USE MAGIC
                File.AppendAllText("Organizer.cvs", organizer.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void cmbCounties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCountry = (cmbCounties.SelectedItem as ComboBoxItem).Content.ToString();

            switch (selectedCountry)
            {
                case "Canada":
                    cmbCities.ItemsSource = Data.GetCanadianCities();
                    break;
                case "United States":
                    cmbCities.ItemsSource = Data.GetUSCities();
                    break;
                default:
                    cmbCities.ItemsSource = Data.GetOtherCities();
                    break;
            }



        }

        private void Btn_GotoVisitorWindow(object sender, RoutedEventArgs e)
        {
            VisitorsWindow visitors = new VisitorsWindow();
            //visitors.ShowDialog();
            visitors.Show();

            this.Close();


        }
    }
}
