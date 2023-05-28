using CarShop_RoxanaLungu.Data;
using CarShop_RoxanaLungu.Views;
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

namespace CarShop_RoxanaLungu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CarShopDbContext dbContext;
        public MainWindow()
        {
            InitializeComponent();
             //MainFrame.Navigate(new HomeView());

        }
        public MainWindow(CarShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
    }
}
