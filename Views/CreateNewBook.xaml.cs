using Labb2.Databas.Ebooks.Data;
using Labb2.Databas.Ebooks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace Labb2.Databas.Ebooks.Views
{
    /// <summary>
    /// Interaction logic for CreateNewBook.xaml
    /// </summary>
    public partial class CreateNewBook : Window
    {


        public StoreDBContext storeDBContext;
        public Author author;
        public Book book;
        public Inventory inventory;
        public Store store;
        public CreateNewBook()
        {
            InitializeComponent();
            storeDBContext = new StoreDBContext();
            author = new Author();
            book = new Book();

            LoadAuthors();


        }

        //[C]rud
        private void AddAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            var firstNameInput = FirstName.Text;
            var lastNameInput = LastName.Text;

            if (firstNameInput != null && lastNameInput != null)
            {
                var newAuthor = new Author()
                {
                    FirstName = firstNameInput,
                    LastName = lastNameInput,
                    BirthDate = System.DateTime.Today

                };
                storeDBContext.Authors.Add(newAuthor);

                storeDBContext.SaveChanges();

            }
            LoadAuthors();
        }

        //C[r]ud
        public void LoadAuthors()
        {


            var loadAuthors = storeDBContext.Authors.ToList();
            ListOfAuthors.ItemsSource = loadAuthors;




        }


        private void LoadTitlesForAuthor(Author author)
        {


            var bookOfAuthor = storeDBContext.Authors
                .Where(a => a.AuthorId == author.AuthorId)
                .Include(b => b.Books)
                .FirstOrDefault();

            if (bookOfAuthor != null)
            {
                var titlesOfAuthor = bookOfAuthor.Books.ToList();


                ListOfTitles.ItemsSource = bookOfAuthor.Books;
            }
            else
            {
                MessageBox.Show("choose a title from list");
            }
            //----------------------------------------------------

            //var titlesOfAuthor = storeDBContext.Books
            //    .Where(b => b.AuthorId == author.AuthorId)
            //    .Select(b => new { Title = b.Title })
            //    .ToList();
        }





        private void ListOfAuthors_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            author = ListOfAuthors.SelectedItem as Author;

            if (author != null)
            {
                LoadTitlesForAuthor(author);
            }

            //var selectedAuthor = ListOfAtuhors.SelectedItem as Author;


            //if (selectedAuthor != null)
            //{


            //    var booksOfAuthor = storeDBContext.Authors
            //    .Where(a => a.AuthorId == selectedAuthor.AuthorId)
            //    .Include(a => a.Books)
            //    .FirstOrDefault();



            //    if (booksOfAuthor != null)
            //    {

            //        var titlesOfAuthor = selectedAuthor.Books
            //            .Select(b => new { Title = b.Title })
            //            .ToList();

            //        ListOfTitles.ItemsSource = titlesOfAuthor;
            //    }
            //    else
            //    {
            //        MessageBox.Show("No books found for the selected author.");
            //    }
            //}



        }

        private void AddNewBookToAuthor_Click(object sender, RoutedEventArgs e)
        {
            var selectedAuthor = ListOfAuthors.SelectedItem as Author;
            var inputTitle = TitleBox.Text;
            var inputIsbn = IsbnBox.Text;
            var inputCategory = CategoryBox.Text;
            var inputPrice = PriceBox.Text;
            var inputLanguege = LanguegeBox.Text;


            if (selectedAuthor != null)
            {
                if (inputTitle != null &&
                    inputIsbn != null &&
                    inputCategory != null &&
                    inputPrice != null &&
                    inputLanguege != null)
                {
                    var newBook = new Book()
                    {
                        Title = inputTitle,
                        Isbn13 = inputIsbn,
                        Category = inputCategory,
                        Price = Convert.ToInt32(inputPrice),
                        Languege = inputLanguege,
                        ReleaseDate = DateTime.Now,
                        AuthorId = selectedAuthor.AuthorId



                    };

                    storeDBContext.Books.Add(newBook);

                    storeDBContext.SaveChanges();


                    LoadAuthors();
                    LoadTitlesForAuthor(author);
                }


            }
            else
            {
                MessageBox.Show("You need to choose a Author");
            }
        }







        private void DeleteAuthorBtn_Click(object sender, RoutedEventArgs e)
        {

            var selectedAuthor = ListOfAuthors.SelectedItem as Author;


            if (selectedAuthor != null)
            {
                storeDBContext.Authors.Remove(selectedAuthor);

                storeDBContext.SaveChanges();
                LoadAuthors();
            }
            else
            {
                MessageBox.Show("You need to choose an author from the list");
            }
        }

        private void DeleteBookBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = ListOfTitles.SelectedItem as Book;

            if (selectedBook != null)
            {

                author.Books.Remove(selectedBook);
                storeDBContext.SaveChanges();
                CreateNewBook newBook = new CreateNewBook();
                newBook.Show();
                this.Close();
            }


            //foreach (var book in storeDBContext.Books)
            //{
            //    if (book.Title == selectedBook.Title)
            //    {
            //        selectedBook = book;
            //        storeDBContext.Books.Remove(selectedBook);




            //    }
            //}
            //storeDBContext.SaveChanges();
            //var selectedAuthor = ListOfAuthors.SelectedItem as Author;

            //if (selectedAuthor != null)
            //{
            //    LoadTitlesForAuthor(selectedAuthor);
            //}




            //if (selectedBook != null)
            //{

            //    storeDBContext.Books.Remove(selectedBook);
            //    storeDBContext.SaveChanges();


            //    MessageBox.Show("Book Deleted");

            //    var selectedAuthor = ListOfAuthors.SelectedItem as Author;
            //    if (selectedAuthor != null)
            //    {
            //        LoadTitlesForAuthor(selectedAuthor);
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Need to choose a book from the list");
            //}



        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
