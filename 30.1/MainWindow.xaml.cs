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

namespace _30._1_
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

        private void btnOppervlakte_Click(object sender, RoutedEventArgs e)
        {
            Figuur mijnFiguur = new Figuur(30.0, 10.0);
            Bereken(mijnFiguur);
        }

        private void btnIntrest_Click(object sender, RoutedEventArgs e)
        {
            Bankrekening mijnBankrekening= new Bankrekening(1000.0,2.3);
            Bereken(mijnBankrekening);
        }

        private void Bereken(InterfaceObject berekening)
        {

            MessageBox.Show(berekening.ToString(), "result",MessageBoxButton.OK, MessageBoxImage.Information); ;
        }


    }
}
