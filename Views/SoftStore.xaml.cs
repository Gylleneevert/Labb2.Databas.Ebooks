using Labb2.Databas.Ebooks.Data;
using Labb2.Databas.Ebooks.Models;
using System.Linq;
using System.Windows;

namespace Labb2.Databas.Ebooks.Views
{
    /// <summary>
    /// Interaction logic for SoftStore.xaml
    /// </summary>
    public partial class SoftStore : Window
    {
        public StoreDBContext storeDBContext;
        public BookView bookView;
        public Store currentStore;

        public SoftStore()
        {
            InitializeComponent();
            storeDBContext = new StoreDBContext();
            bookView = new BookView();
            currentStore = storeDBContext.Stores.FirstOrDefault(s => s.StoreId == 2);
            LoadBooks();
        }
        public void LoadBooks()
        {
            var bookStock = storeDBContext.BookViews.Where(inv => inv.StoreId == 2).ToList();

            ListOfBooks.ItemsSource = bookStock;
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {


            var selectedBook = ListOfBooks.SelectedItem as BookView;
            if (selectedBook != null)
            {


                var invStock = storeDBContext.Inventories.FirstOrDefault(i => i.Isbn13 == selectedBook.Isbn13);


                if (invStock != null)
                {
                    invStock.StockBalance += 1;
                    MessageBox.Show("du La till en bok");

                }



                storeDBContext.SaveChanges();

                LoadBooks();
            }
            else
            {
                MessageBox.Show("You need to Choose a book from the list");
            }


        }




        private void RemoveBookBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = ListOfBooks.SelectedItem as BookView;
            if (selectedBook != null)
            {


                var invStock = storeDBContext.Inventories.FirstOrDefault(i => i.Isbn13 == selectedBook.Isbn13);


                if (invStock != null)
                {
                    invStock.StockBalance -= 1;
                    MessageBox.Show("du tog bort en bok");

                }

                storeDBContext.SaveChanges();

                LoadBooks();
            }
            else
            {
                MessageBox.Show("You need to Choose a book from the list");
            }



        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
