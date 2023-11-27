using System;
using System.Collections.Generic;

namespace Labb2.Databas.Ebooks.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Isbn13 { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
