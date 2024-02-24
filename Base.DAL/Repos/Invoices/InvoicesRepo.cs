using Base.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DAL;

public class InvoicesRepo : IInvoicesRepo
{
    private readonly SystemContext _context;

    public InvoicesRepo(SystemContext context) 
    {
        _context = context;
    }

    public IEnumerable<InvoiceHDR> GetAll()
    {
        return _context.Set<InvoiceHDR>().Include(i => i.Items);
    }

    public InvoiceHDR GetById(int id)
    {
        return _context.Set<InvoiceHDR>()
            .Include(i=>i.Items)
            .FirstOrDefault(i => i.InvoiceID == id);
    }
    public void Add(InvoiceHDR invoice)
    {
        _context.Set<InvoiceHDR>().Add(invoice);
    }

    public void Delete(InvoiceHDR invoice)
    {
        _context.Set<InvoiceHDR>().Remove(invoice);
    }
    public void Update(InvoiceHDR invoice)
    {
        //tracking
    }
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
