namespace orm_laby_c_plotek;

public partial class InvoicePo
{
    public decimal InvoicePosId { get; set; }

    public decimal InvoiceId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Value { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
}
