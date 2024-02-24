using Base.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.BL.Dtos;

public class InvoiceReadDto
{
    public int InvoiceID { get; set; }
    public DateTime InvoiceDate { get; set; }
    public bool PaymentMethod { get; set; }
    public string Customer { get; set; }
    public string? Description { get; set; } = string.Empty;
    public List<ItemReadDto> Items { get; set; } = new List<ItemReadDto>();
}
