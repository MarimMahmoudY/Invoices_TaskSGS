using Base.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.BL.Dtos;

public class InvoiceAddDto
{
    public DateTime InvoiceDate { get; set; }
    
    public bool PaymentMethod { get; set; }
    public string Customer { get; set; }
    public string? Description { get; set; } = string.Empty;
    public List<ItemDTL> Items { get; set; } = new List<ItemDTL>();
}
