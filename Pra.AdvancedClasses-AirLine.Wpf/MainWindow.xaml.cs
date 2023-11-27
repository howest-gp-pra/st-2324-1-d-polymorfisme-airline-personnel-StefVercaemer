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
using Pra.Airlines.Core.Services;
using Pra.Airlines.Core.Entities;
using System.Diagnostics;

namespace Pra.AdvancedClasses_AirLine.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AirLineService airLine;

        public MainWindow()
        {
            InitializeComponent();
            CabinCrew nathalie = new CabinCrew("Nathalie", null, 120);
            Debug.WriteLine(nathalie.Experience);


            Pilot youri = new Pilot("Youri", null);

            Personnel boxedYouri = youri;
            Personnel boxedNathalie = nathalie;

            Debug.WriteLine(boxedNathalie.Experience);
            Debug.WriteLine(boxedYouri.Experience);


            airLine = new AirLineService();
        }

        void ShowPersonnel()
        {
            lstAvailableCrew.ItemsSource = airLine.PersonnelMembers;
            lstAvailableCrew.Items.Refresh();
        }

        void SeedLstFilter()
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowPersonnel();
            tbkFeedback.Visibility = Visibility.Hidden;
        }

        private void LstAvailableCrew_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnTakeOff_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LstFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
