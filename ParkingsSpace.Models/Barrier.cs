using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSpace.Models {
  public class Barrier {
    /// <summary>
    /// ID of barrier
    /// </summary>
    public string ID { get; set; }
    
    /// <summary>
    /// Status of barrier
    /// </summary>
    public BarrierStatus  Status { get; private set; }
  }
}
