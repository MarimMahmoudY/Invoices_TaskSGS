using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.BL.Dtos;

public class ItemReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Qty { get; set; }
    public int Price { get; set; }
}
