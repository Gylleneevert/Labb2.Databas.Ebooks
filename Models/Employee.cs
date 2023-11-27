using System;
using System.Collections.Generic;

namespace Labb2.Databas.Ebooks.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public int? StoreId { get; set; }
}
