using Base.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DAL;

public interface IInvoicesRepo
{
    IEnumerable<InvoiceHDR> GetAll();
    InvoiceHDR GetById(int id);
    void Add(InvoiceHDR invoice);
    void Update(InvoiceHDR invoice);    
    void Delete(InvoiceHDR invoice);
    int SaveChanges();
}
