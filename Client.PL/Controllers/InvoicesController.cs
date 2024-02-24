using Microsoft.AspNetCore.Mvc;
using Mid.BL;
using Mid.BL.Dtos;
using System;

namespace Client.PL.Controllers;

public class InvoicesController : Controller
{
    private readonly IInvoiceManager _invoiceManager;
    public InvoicesController(IInvoiceManager invoiceManager)
    {
        _invoiceManager = invoiceManager;
    }
    [Route("/")]
    public IActionResult GetAll()
    {
        List<InvoiceReadDto> invoices= _invoiceManager.GetAll().ToList();
        return View(invoices);
    }
    [Route("/get/{id}")]
    public IActionResult Get(int id) 
    {
        InvoiceUpdateDto invoice = _invoiceManager.GetById(id);
        if(invoice == null) 
        {
            return View("Error");
        }
        return PartialView(invoice);
    }
    [Route("/add")]
    public IActionResult Add(InvoiceAddDto invoice) 
    {
        if(invoice == null) 
        {
            return View("Error");
        }

        _invoiceManager.Add(invoice);   
        return RedirectToAction("GetAll");
    }
    public IActionResult Update(InvoiceUpdateDto invoiceFromRequest)
    {
        if (invoiceFromRequest == null)
        {
            return View("Error");
        }

        _invoiceManager.Update(invoiceFromRequest);
        return RedirectToAction("GetAll");
    }
    public IActionResult Delete(int id) 
    {
        _invoiceManager.Delete(id);
        return RedirectToAction("GetAll");
    }
    public IActionResult AddNew() 
    {

        return View("Add");
    }
    public IActionResult Index()
    {
        return View();
    }
}
    
