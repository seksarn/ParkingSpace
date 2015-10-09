using ParkingSpace.Web.Controllers;
using Xunit;
using System.Web.Mvc;
using ParkingSpace.Web.Printing;
using ParkingSpace.Models;
using System.Data.Entity;
using ParkingSpace.Services;

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
      class FakePrinter : IParkingTicketPrinter {
        public bool HasPrinted = false;

        public void Print(ParkingTicket ticket, object args = null) {
          // throw new NotImplementedException();
          HasPrinted = true;
        }
      }

      [Fact]
      public void ShouldCreatePDFFile() {
        using (var app = new App(testing: true)) {
          var printer = new FakePrinter();
          var ctrl = new GateInController(printer, app);
          var result = ctrl.CreateTicket("1234");

          Assert.Equal(true, printer.HasPrinted);
        }

      }

    }

  }
}
