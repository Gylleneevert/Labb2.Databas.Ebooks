using System;
using System.Collections.Generic;

namespace Labb2.Databas.Ebooks.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? CustomerId { get; set; }

    public int? StoreId { get; set; }

    public int? PublisherId { get; set; }

    public string? Isbn13 { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Book? Isbn13Navigation { get; set; }

    public virtual Publisher? Publisher { get; set; }

    public virtual Store? Store { get; set; }
}
