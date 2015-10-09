using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParkingSpace.Web.Controllers;
using Xunit;
using System.Web.Mvc;
using ParkingSpace.Web.Printing;
using ParkingSpace.Models;

namespace ParkingSpace.Facts.Controller {
 public class GateInControllerFacts {

    public class IndexAction {
      [Fact]
      public void ShouldReturnView() {
        var ctrl = new GateInController();
        var result = ctrl.Index();

        Assert.NotNull(result);
        Assert.IsType<ViewResult>(result);
      }
    }

    public class CreateTicketAction {
      class FackPrinter : IParkingTicketPrinter {
        public bool HasPrinted = false;

        public void Print(ParkingTicket ticket, object args = null) {
          // throw new NotImplementedException();
          HasPrinted = true;
        }
      }

      [Fact]
      public void ShouldCreatePDFFile() {
        var printer = new FackPrinter();
        var ctrl = new GateInController(printer);
        var result = ctrl.CreateTicket("1234");

        Assert.Equal(true, printer.HasPrinted);
      }
    }

  }
}
