using System;
using System.Collections.Generic;

namespace Labb2.Databas.Ebooks.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }

    public string? PublisherName { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
