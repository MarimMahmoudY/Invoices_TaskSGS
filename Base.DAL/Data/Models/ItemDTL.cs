using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DAL;
public class ItemDTL
{
    [Key]
    public int ItemId { get; set; }
    [ForeignKey("InvoiceHDR")]
    public int InvoiceHDRId { get; set; }
    public string ItemName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
}
