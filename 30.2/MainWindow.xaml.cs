

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
        // Test gedaan met creatie van een list van Werknemers met de bedoeling dat ik de toegevoegde werknemer records die in de view
        // Toegevoegd worden in een interne list collection bijgehouden worden om deze bijvoorbeeld dan weg te schrijven naar een file en/of
        // database
        public string typeOfEmployee = "";
        List<Werknemer> werknemerList = new List<Werknemer>();
        public MainWindow()
        {

            InitializeComponent();

        }


        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            //Creer werknemer object en voeg toe aan werknemerList
            //Werknemer w = new Werknemer(tbAchternaam.Text, tbVoornaam.Text, decimal.Parse(tbVerdiensten.Text, CultureInfo.InvariantCulture),int.Parse(tbAantal.Text), "");
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
            //werknemerList.Add(w);
            //lvDisplayWerknemer.Items.Add(a.GetDisplayText("\t"));
            // Maak na toevoegen de invoervelden leeg
            lvDisplayWerknemer.Items.Add(werknemerList.Last().GetDisplayText("\t"));
            ClearInputFields();
        }




        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    // Get the selected radio button
        //    RadioButton selectedRadioButton = (RadioButton)sender;

        //    // Check which radio button is selected
        //    if (selectedRadioButton == CommissionWorkerRadioButton)
        //    {
        //        // Create a CommissionWorker object and set the "sort of employee" property to "Commission"
        //        CommissionWorker commissionWorker = new CommissionWorker();
        //        commissionWorker.SortOfEmployee = "Commission";

        //        // Do something with the commissionWorker object
        //    }
        //    else if (selectedRadioButton == WorkerByHoursRadioButton)
        //    {
        //        // Create a HourlyWorker object and set the "sort of employee" property to "Hourly"
        //        HourlyWorker hourlyWorker = new HourlyWorker();
        //        hourlyWorker.SortOfEmployee = "Hourly";

        //        // Do something with the hourlyWorker object
        //    }
        //}



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
                //split method not available on object item warning in VS Studio, oplossing gevonden je moet object
                //naar string brengen via de ToString method dan pas is de Split method available enkel beschikbaar op strings en niet op object.

                // quick check door te itereren over mijn array en resultaat te printen in een MessageBox -> Gaat rapper in debugger maar wou eens checken of je dit zo
                // kan testen werkt effectief
                //foreach(string field in fields)
                //{
                //    MessageBox.Show($"{field}");
                //}

                //Onderstaande commented code werkte niet omdat dit het object niet uit mijn list verwijderde vermoedelijk omdat hij
                // geen match vond??
                //Werknemer w = new Werknemer();
                //w.Achternaam = fields[0];
                //w.Voornaam = fields[1];
                //w.Verdiensten = decimal.Parse(fields[2]);

                //remove from list
                //werknemerList.Remove(w);

                // betere manier die werkt, dit retourneerd null als er geen object in list gevonden werd, throw error when duplicate values to remove
                // nog exception handling nodig in dit geval!
                var itemToRemove = werknemerList.SingleOrDefault(r => r.Achternaam == fields[0] && r.Voornaam == fields[1] && r.Verdiensten == decimal.Parse(fields[2]));

                if (itemToRemove != null)
                    werknemerList.Remove(itemToRemove);
                else
                {
                    MessageBox.Show("no items were removed from internal list");
                }

                // via show messagebox resultaat geprint kon makkelijker via debugger ook.
                //foreach (Werknemer x in werknemerList)
                //{
                //    MessageBox.Show($"{x.GetDisplayText(" ")}");

                //}


                // ik had hier een voorbeeld voor multiselect gemaakt
                // multiselect example -> change selectionmode multiple or extended
                //var items = lvDisplayWerknemer.SelectedItems;
                //var result = MessageBox.Show($"Are you sure you want to delete {items.count}","warning", MessageBoxButton.YesNo, MessageBoxImage.Question); 
                //if(result == MessageBoxResult.Yes)
                //{
                //    var itemsList = new ArrayList(items);
                //    foreach (var item in itemsList)
                //    {
                //        lvDisplayWerknemer.Items.Remove(item);
                //
                //    }

                //}

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

        private void Window_Loaded(object sender, RoutedEventArgs e) { }
    }
}
