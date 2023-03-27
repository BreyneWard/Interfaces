

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
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
using static System.Net.Mime.MediaTypeNames;

namespace _30._2_
{

    public partial class MainWindow : Window
    {
        
        public string typeOfEmployee = "";
        //List<Werknemer> werknemerList = new List<Werknemer>();
        //List<Werknemer> sortedList = new List<Werknemer>();
        List<Werknemer> werknemerList;
        List<Werknemer> sortedList;

        public MainWindow()
        {

            InitializeComponent();

        }


        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            
            CheckTypeOfWerknemer();
            if (typeOfEmployee == "commission")
            {
                CommissieWerker a = new CommissieWerker(tbAchternaam.Text, tbVoornaam.Text, decimal.Parse(tbVerdiensten.Text, CultureInfo.InvariantCulture), int.Parse(tbAantal.Text), int.Parse(tbCommissie.Text));
                werknemerList.Add(a);
                
            }else if (typeOfEmployee== "uur")
            {
                UurWerker a = new UurWerker(tbAchternaam.Text, tbVoornaam.Text, decimal.Parse(tbVerdiensten.Text, CultureInfo.InvariantCulture), int.Parse(tbAantal.Text), int.Parse(tbCommissie.Text));
                werknemerList.Add(a);
            }
            else if (typeOfEmployee == "stuk")
            {
                StukWerker a = new StukWerker(tbAchternaam.Text, tbVoornaam.Text, decimal.Parse(tbVerdiensten.Text, CultureInfo.InvariantCulture), int.Parse(tbAantal.Text), int.Parse(tbCommissie.Text));
                werknemerList.Add(a);
            }
            
            sortedList = werknemerList;
            if(rbtnSortByNaam.IsChecked == true)
            {
                sortedList.Sort(new NameComparer());
            }
            if(rbtnSortByVerdiensten.IsChecked== true)
            {
                sortedList.Sort(new VerdienstenComparer());
            }
            
            lvDisplayWerknemer.Items.Clear(); // clear listview before outputting the new data
            foreach(Werknemer w in sortedList)
            {
                lvDisplayWerknemer.Items.Add(w.GetDisplayText("\t\t"));
            }
            
            // Clear input fields after display data to listview
            ClearInputFields();
        }


        private void CheckTypeOfWerknemer()
        {
            if (rbtnCommissiewerker.IsChecked == true)
            { typeOfEmployee = "commission"; }
            else if(rbtnStukwerker.IsChecked == true)
            {
                typeOfEmployee = "stuk";
            }
            else if(rbtnUurwerker.IsChecked == true)
            {
                typeOfEmployee = "uur";
            }
            else { typeOfEmployee = ""; }
        }

        public void ClearInputFields()
        {
            tbAchternaam.Text = string.Empty;
            tbVoornaam.Text = string.Empty;
            tbVerdiensten.Text = string.Empty;
            tbAantal.Text = string.Empty;
            tbCommissie.Text = string.Empty;
            tbAchternaam.Focus();
            
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {

            object item = lvDisplayWerknemer.SelectedItem;



            var result = MessageBox.Show($"Are you sure you want to delete: {item}?", "warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // remove werknemer record from wpf form
                lvDisplayWerknemer.Items.Remove(item);

                // also remove werknemer from internal list werknemerList
                string[] fields = item.ToString().Split('\t');
                
                var itemToRemove = werknemerList.SingleOrDefault(r => r.Achternaam == fields[0] && r.Voornaam == fields[2] ); 

                if (itemToRemove != null)
                {
                    werknemerList.Remove(itemToRemove);
                    MessageBox.Show("User deleted");
                }
                else
                {
                    MessageBox.Show("no items were removed from internal list");
                }

            }

        }

        private void rbtnCommissiewerker_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("commisiewerker");
        }

        private void rbtnStukwerker_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("stukwerker");

        }

        private void rbtnUurwerker_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("uurwerker");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) 
        {
            werknemerList = new List<Werknemer>();
            sortedList = new List<Werknemer>();
            rbtnCommissiewerker.IsChecked= true;
            rbtnSortByNaam.IsChecked= true;


        }

        private void rbtnSortByNaam_Checked(object sender, RoutedEventArgs e)
        {
            sortedList = werknemerList;
            sortedList.Sort(new NameComparer());
            lvDisplayWerknemer.Items.Clear();
            foreach (Werknemer w in sortedList)
            {
                lvDisplayWerknemer.Items.Add(w.GetDisplayText("\t\t"));
            }
        }

        private void rbtnSortByVerdiensten_Checked(object sender, RoutedEventArgs e)
        {
            sortedList = werknemerList;
            sortedList.Sort(new VerdienstenComparer());
            lvDisplayWerknemer.Items.Clear();
            foreach (Werknemer w in sortedList)
            {
                lvDisplayWerknemer.Items.Add(w.GetDisplayText("\t\t"));
            }
        }
    }
}
