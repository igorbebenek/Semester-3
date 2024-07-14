using System;
using System.Collections.Generic;

namespace InvoiceManager.Models;

public partial class InvoicePo
{
    public decimal InvoicePosId { get; set; }

    public decimal InvoiceId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Value { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
}
