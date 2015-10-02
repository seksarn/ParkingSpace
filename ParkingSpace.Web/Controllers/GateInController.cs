using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ParkingSpace.Services;
using ParkingSpace.Models;
namespace ParkingSpace.Web.Controllers {

  [RoutePrefix("gate-in")]
  public class GateInController : Controller {
    private ParkingTicketService service;


    public GateInController() {
      service = new ParkingTicketService();
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
      printParkingTicket(ticket);
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