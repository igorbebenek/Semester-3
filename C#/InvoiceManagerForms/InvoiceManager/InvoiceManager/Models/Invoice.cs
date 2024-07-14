﻿using System;
using System.Collections.Generic;

namespace InvoiceManager.Models;

public partial class Invoice
{
    public decimal InvoiceId { get; set; }

    public string Number { get; set; } = null!;

    public decimal? Value { get; set; }

    public virtual ICollection<InvoicePo> InvoicePos { get; set; } = new List<InvoicePo>();
}
