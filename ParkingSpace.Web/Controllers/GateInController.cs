using System.Web.Mvc;
using ParkingSpace.Models;
using ParkingSpace.Services;
using System;
using ParkingSpace.Web.Printing;

namespace ParkingSpace.Web.Controllers {

  [RoutePrefix("gate-in")]
  public class GateInController : Controller {
    private App app;
    private readonly IParkingTicketPrinter printer;

    public GateInController()  {
      // this.printer = new PDFParkingTicketPrinter(this.ControllerContext);
      this.printer = new PDFParkingTicketPrinter();
      app = new App();
    }
    public GateInController(IParkingTicketPrinter printer, App app) {
      this.printer = printer;
      this.app = app;
    }

    // GET: GateIn
    [Route]
    public ActionResult Index() {
      ViewBag.GateID = app.Setting.Current.GateID;
      return View();
    }

    [HttpPost]
    [Route("CreateTicket")]
    public ActionResult CreateTicket(string plateno) {
      
      var ticket = app.ParkingTickets.CreateParkingTicket(plateno);
    
      this.printer.Print(ticket,  this.ControllerContext);

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