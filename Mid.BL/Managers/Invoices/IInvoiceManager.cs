using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mid.BL.Dtos;

namespace Mid.BL;

public interface IInvoiceManager
{
    IEnumerable<InvoiceReadDto> GetAll();
    InvoiceUpdateDto GetById(int id);
    int Add(InvoiceAddDto invoice);
    bool Update(InvoiceUpdateDto invoice);
    bool Delete(int id);

}
