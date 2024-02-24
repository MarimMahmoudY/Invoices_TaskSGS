using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DAL.Data;
public class InvoiceHDR
{
    [Key]
    public int InvoiceID { get; set; }
    public DateTime InvoiceDate { get; set; }
    public bool PaymentMethod { get; set; }
    public string Customer { get; set; }
    public string? Description { get; set; } = string.Empty;
    public List<ItemDTL> Items { get; set; } = new List<ItemDTL>();

}
