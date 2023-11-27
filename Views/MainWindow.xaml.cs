using Labb2.Databas.Ebooks.Views;
using System.Windows;

namespace Labb2.Databas.Ebooks
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

        private void XtrmStoreBtn_Click(object sender, RoutedEventArgs e)
        {

            ExtremeStore extremeStore = new ExtremeStore();
            extremeStore.Show();
            this.Close();
        }


        private void SoftStoreBtn_Click(object sender, RoutedEventArgs e)
        {
            SoftStore softStore = new SoftStore();
            softStore.Show();
            this.Close();
        }

        private void SnshinStoreBtn_Click(object sender, RoutedEventArgs e)
        {
            SunshineStore sunshineStore = new SunshineStore();
            sunshineStore.Show();
            this.Close();
        }

        private void AddNewBook_Click(object sender, RoutedEventArgs e)
        {
            CreateNewBook newBook = new CreateNewBook();
            newBook.Show();
            this.Close();
        }
    }
}
