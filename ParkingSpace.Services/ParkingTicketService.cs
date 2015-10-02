using ParkingSpace.Models;
using ParkingSpace.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSpace.Services {

  public class ParkingTicketService {

    public int NextID { get; set; }
    public int GateID { get; set; }

    public ParkingTicketService() {
      NextID = 1;
      GateID = 0;
    }

    public ParkingTicket CreateParkingTicket(string plateno) {
      ParkingTicket t = new ParkingTicket();

      t.PlateNo = plateno;
      t.DateIn = SystemTime.Now();
      t.DateOut = null;
      t.GateID = this.GateID;

      t.ID = generateID();

      return t;
    }

    private string generateID() {
      var id = $"{this.GateID:00}-{this.NextID:00000}";

      this.NextID++;

      return id;
    }
  }
}
