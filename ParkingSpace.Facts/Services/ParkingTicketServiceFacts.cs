using ParkingSpace.Models;
using ParkingSpace.Services;
using ParkingSpace.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ParkingSpace.Facts.Services {
  public class ParkingTicketServiceFacts {

    public class GeneralUsage {

      [Fact]
      public void HasDefaultValues() {
        var s = new ParkingTicketService();
        Assert.Equal(0, s.GateID);
        // Assert.Equal(1, s.NextID);
      }


    }


    public class CreateParkingTicketMethod {


      private readonly ITestOutputHelper output;

      public CreateParkingTicketMethod(ITestOutputHelper output) {
        this.output = output;
      }

      [Fact]
      public void ReturnParingTicket() {
        using (var app = new App(testing: true)) {
          var s = app.ParkingTickets;

          var t = s.CreateParkingTicket("1122");

          Assert.NotNull(t);
          Assert.Equal("1122", t.PlateNo);
        }
      }

      [Fact]
      public void NewTicket_hasNoDateOut() {
        using (var app = new App(testing: true)) {
          var s = app.ParkingTickets;

          var t = s.CreateParkingTicket("1122");

          var dt = DateTime.Now;
          SystemTime.SetNow(dt);

          Assert.NotEqual(default(DateTime), t.DateIn);
          Assert.Equal(dt, t.DateIn);
          Assert.Null(t.DateOut);
        }
      }

      [Fact]
      public void NewTicket_hasAutoRunningId() {
        using (var app = new App(testing: true)) {
          var s = app.ParkingTickets;

          var ticket1 = s.CreateParkingTicket("23");
          var ticketId1 = string.Format("00-{0:00000}", 1);

          displayTicket(ticket1);

          Assert.Equal(ticketId1, ticket1.ID);

          var ticket2 = s.CreateParkingTicket("555");
          var ticketId2 = string.Format("00-{0:00000}", 2);

          displayTicket(ticket2);

          Assert.Equal(ticketId2, ticket2.ID);

        }

      }

      [Fact]
      public void NewTicket_UseGateIdFromService() {
        using (var app = new App(testing: true)) {
          var s = app.ParkingTickets;

          var t = s.CreateParkingTicket("23");

          Assert.Equal(s.GateID, t.GateID);
        }
      }

      private void displayTicket(ParkingTicket t) {
        output.WriteLine("TICKET");

        output.WriteLine($"ID   :   {t.ID}");
        output.WriteLine($"Gate :   {t.GateID}");
        output.WriteLine($"Plate:   {t.PlateNo}");
        output.WriteLine($"Date In: {t.DateIn}");
      }

      [Fact]
      public void NewTicketHas_InsertedToDatabase() {
        using (var app = new App(testing: true)) {
          var t = app.ParkingTickets.CreateParkingTicket("3AC-1111");
          var count = app.ParkingTickets.All().Count();

          Assert.Equal(1, count);

          var firstTicket = app.ParkingTickets.All().FirstOrDefault();
          Assert.Equal("3AC-1111", firstTicket.PlateNo);
        }
      }

    }
  }
}
