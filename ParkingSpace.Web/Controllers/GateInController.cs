using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ParkingSpace.Services;
using ParkingSpace.Models;
namespace ParkingSpace.Web.Controllers {
  public class GateInController : Controller {
    // GET: GateIn
    public ActionResult Index() {
      return View();
    }

    public ActionResult CreateTicket(string plateno) {
      throw new NotImplementedException();
    }

    public ActionResult OpenBarrier() {
      throw new NotImplementedException();
    }

    private void printParkingTicket(ParkingTicket t) {

    }
  }
}