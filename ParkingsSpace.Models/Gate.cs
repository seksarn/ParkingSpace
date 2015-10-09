using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ParkingSpace.Models {
  public enum GateStatus {
    Active = 1,
    InActive = 2
  }

  public enum BarrierStatus {
    Opened = 1,
    Closed = 2,
    OutOfService = 3
  }

  public  class Gate {
    public int ID { get; set; }
    public string Name { get; set; }
    public GateStatus Status { get; set; }

  }
}
