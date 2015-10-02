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
    // GET: GateIn
    [Route]
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