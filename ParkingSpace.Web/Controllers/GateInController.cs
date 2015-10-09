using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingSpace.Models;
using ParkingSpace.Services;
using System;
using ParkingSpace.Web.Printing;
using Rotativa;

namespace ParkingSpace.Web.Controllers {

  [RoutePrefix("gate-in")]
  public class GateInController : Controller {
    private static ParkingTicketService service;

    static GateInController() {
      service = new ParkingTicketService();
    }

    private readonly IParkingTicketPrinter printer;

    public GateInController()  {
      // this.printer = new PDFParkingTicketPrinter(this.ControllerContext);
      this.printer = new PDFParkingTicketPrinter();
    }
    public GateInController(IParkingTicketPrinter printer) {
      this.printer = printer;
    }

    // GET: GateIn
    [Route]
    public ActionResult Index() {
      return View();
    }

    [HttpPost]
    [Route("CreateTicket")]
    public ActionResult CreateTicket(string plateno) {
      var ticket = service.CreateParkingTicket(plateno);
    
      this.printer.Print(ticket, this.ControllerContext);

      TempData["NewTicket"] = ticket;

      
      return RedirectToAction("Index");
    }

    public ActionResult OpenBarrier() {
      throw new NotImplementedException();
    }

    private void printParkingTicket(ParkingTicket t) {
      
    }

   
  }
}