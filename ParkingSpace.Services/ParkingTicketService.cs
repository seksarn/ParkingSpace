using ParkingSpace.Models;
using ParkingSpace.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSpace.DataAccess.Core;

namespace ParkingSpace.Services {

  public class ParkingTicketService : ServiceBase<App, ParkingTicket> {

    // public int NextID { get; set; }
    public int GateID { get; set; }

    public override IRepository<ParkingTicket> Repository { get; set; }
    public override ParkingTicket Find(params object[] keys) {
      string key = (string)keys[0];
      return Query(t => t.ID == key).SingleOrDefault();
    }

    public ParkingTicketService() {
      // NextID = 1;
      GateID = 0;
    }

    public ParkingTicket CreateParkingTicket(string plateno) {
      ParkingTicket t = new ParkingTicket();

      t.PlateNo = plateno;
      t.DateIn = SystemTime.Now();
      t.DateOut = null;
      t.GateID = this.GateID;
      t.ID = generateID();


      this.App.ParkingTickets.Add(t);
      this.App.ParkingTickets.SaveChanges();
      
      return t;
    }

    private string generateID() {
      var maxID = App.ParkingTickets.All().Max(t => t.ID);
      var nextID = 1;
      if (maxID != null) {
        nextID = int.Parse(maxID.Substring(maxID.Length - 5)) + 1;
      }

      var id = $"{this.GateID:00}-{nextID:00000}";

      // this.NextID++;

      return id;
    }


  }
}
