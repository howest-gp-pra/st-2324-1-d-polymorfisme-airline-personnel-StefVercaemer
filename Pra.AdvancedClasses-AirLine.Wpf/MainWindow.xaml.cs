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
using System.CodeDom;

namespace Pra.AdvancedClasses_AirLine.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AirLineService airLineService;

        public MainWindow()
        {
            InitializeComponent();
            //CabinCrew nathalie = new CabinCrew("Nathalie", null, 120);
            //Debug.WriteLine(nathalie.Experience);


            //Pilot youri = new Pilot("Youri", null);

            //Personnel boxedYouri = youri;
            //Personnel boxedNathalie = nathalie;

            //Debug.WriteLine(boxedNathalie.Experience);
            //Debug.WriteLine(boxedYouri.Experience);


            airLineService = new AirLineService();
        }

        void ShowPersonnel()
        {
            lstAvailableCrew.ItemsSource = airLineService.PersonnelMembers;
            lstAvailableCrew.Items.Refresh();
        }

        void SeedLstFilter()
        {
            lstFilter.Items.Add("Alle personeelsleden");
            lstFilter.Items.Add(typeof(Pilot));
            lstFilter.Items.Add(typeof(CabinCrew));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowPersonnel();
            SeedLstFilter();
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
            object filter = lstFilter.SelectedItem;
            lstAvailableCrew.ItemsSource = null;
            if (filter != null)
            {
                if (filter is string)
                    lstAvailableCrew.ItemsSource = airLineService.PersonnelMembers;
                else
                {
                    Type type = filter as Type;
                    if (type == typeof(Pilot))
                        lstAvailableCrew.ItemsSource = airLineService.Pilots;
                    else
                        lstAvailableCrew.ItemsSource = airLineService.CabinCrewMembers;
                }
            }
        }
    }
}
