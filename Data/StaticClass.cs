using Labb2.Databas.Ebooks.Models;

namespace Labb2.Databas.Ebooks.Data
{
    static class StaticClass
    {
        public static Author? currentAuthor = new Author();
        public static Book? currentBook = new Book();

        private static StoreDBContext? storeDBContext;
        public static StoreDBContext _DBContext
        {
            get
            {
                if (storeDBContext == null)
                {
                    storeDBContext = new StoreDBContext();
                }
                return storeDBContext;
            }
        }


    }

}
