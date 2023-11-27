using System;
using System.Collections.Generic;

namespace Labb2.Databas.Ebooks.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
}
