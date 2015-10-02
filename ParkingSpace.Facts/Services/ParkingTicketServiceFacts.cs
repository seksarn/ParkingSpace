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
        Assert.Equal(1, s.NextID);
      }

     
    }
    
        
    public class CreateParkingTicketMethod {


      private readonly ITestOutputHelper output;

      public CreateParkingTicketMethod(ITestOutputHelper output) {
        this.output = output;
      }

      [Fact]
      public void ReturnParingTicket() {
        var s = new ParkingTicketService();

        var t = s.CreateParkingTicket("1122");

        Assert.NotNull(t);
        Assert.Equal("1122", t.PlateNo);
      }

      [Fact]
      public void NewTicket_hasNoDateOut() {
        var s = new ParkingTicketService();

        var t = s.CreateParkingTicket("1122");

        var dt = DateTime.Now;
        SystemTime.SetNow(dt);

        Assert.NotEqual(default(DateTime), t.DateIn);
        Assert.Equal(dt, t.DateIn);
        Assert.Null(t.DateOut);
      }

      [Fact]
      public void NewTicket_hasAutoRunningId() {
        var s = new ParkingTicketService();

        int nextId1 = s.NextID;
        int gateId = s.GateID;

        var t = s.CreateParkingTicket("23");
        var id1 = $"{gateId:00}-{nextId1:00000}";


        displayTicket(t);
        Assert.Equal(id1, t.ID);

         //////////////////////////////////////////////
        int nextId2 = s.NextID;
        var t2 = s.CreateParkingTicket("555");
        var id2 = $"{gateId:00}-{nextId2:00000}";

        displayTicket(t2);

        Assert.Equal(nextId1 + 1, nextId2);
        Assert.Equal(id2, t2.ID);
      }

      [Fact]
      public void NewTicket_UseGateIdFromService() {
        var s = new ParkingTicketService();

        var t = s.CreateParkingTicket("23");

        Assert.Equal(s.GateID, t.GateID);
      }


      private void displayTicket(ParkingTicket t) {
        output.WriteLine("TICKET");

        output.WriteLine($"ID   :   {t.ID}");
        output.WriteLine($"Gate :   {t.GateID}");
        output.WriteLine($"Plate:   {t.PlateNo}");
        output.WriteLine($"Date In: {t.DateIn}");
      }


    }
  }
}
