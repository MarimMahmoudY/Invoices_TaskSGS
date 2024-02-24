using Base.DAL;
using Base.DAL.Data;
using Mid.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.BL;

public class InvoiceManager : IInvoiceManager
{
    private readonly IInvoicesRepo _invoicesRepo;

    public InvoiceManager(IInvoicesRepo invoicesRepo)
    {
        _invoicesRepo = invoicesRepo;
    }
    public IEnumerable<InvoiceReadDto> GetAll()
    {
        IEnumerable<InvoiceHDR> invoicesFromDb = _invoicesRepo.GetAll();
        return invoicesFromDb.Select(x => new InvoiceReadDto 
        {
            InvoiceID = x.InvoiceID,
            InvoiceDate = x.InvoiceDate,
            PaymentMethod= x.PaymentMethod,
            Customer = x.Customer,
            Description = x.Description,
        }).ToList();
    }
    public InvoiceUpdateDto GetById(int id)
    {
        InvoiceHDR invoiceFromDb = _invoicesRepo.GetById(id);
        if (invoiceFromDb == null)
        {
            return null;
        }
        return new InvoiceUpdateDto
        {
            InvoiceID = invoiceFromDb.InvoiceID,
            InvoiceDate = invoiceFromDb.InvoiceDate,
            PaymentMethod = invoiceFromDb.PaymentMethod,
            Customer = invoiceFromDb.Customer,
            Description = invoiceFromDb.Description,
            Items= invoiceFromDb.Items
        };
    }
    public int Add(InvoiceAddDto invoiceFromRequest)
    {
        InvoiceHDR invoice=new InvoiceHDR
        {
            InvoiceDate = invoiceFromRequest.InvoiceDate,
            PaymentMethod = invoiceFromRequest.PaymentMethod,
            Customer = invoiceFromRequest.Customer,
            Description = invoiceFromRequest.Description,
            Items = invoiceFromRequest.Items,
        };
        _invoicesRepo.Add(invoice);
        _invoicesRepo.SaveChanges();
        return invoice.InvoiceID;
    }
    public bool Update(InvoiceUpdateDto invoiceFromRequest)
    {
        InvoiceHDR invoiceFromDb=_invoicesRepo.GetById(invoiceFromRequest.InvoiceID);
        if(invoiceFromDb == null) 
        {
           return false; 
        }
        invoiceFromDb.InvoiceDate = invoiceFromRequest.InvoiceDate;
        invoiceFromDb.PaymentMethod = invoiceFromRequest.PaymentMethod;
        invoiceFromDb.Customer = invoiceFromRequest.Customer;
        invoiceFromDb.Description = invoiceFromRequest.Description;
        //--future handling//nvoiceFromDb.Items = invoiceFromRequest.Items;
        invoiceFromDb.Items = invoiceFromDb.Items;

        _invoicesRepo.Update(invoiceFromDb);
        _invoicesRepo.SaveChanges();
        return true;
    }
    public bool Delete(int id)
    {
        InvoiceHDR invoiceFromDb = _invoicesRepo.GetById(id);
        if (invoiceFromDb == null)
        {
            return false;
        }
        _invoicesRepo.Delete(invoiceFromDb); 
        _invoicesRepo.SaveChanges();
        return true;
    }

    
}
