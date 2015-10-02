using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSpace.Models
{
    public class ParkingTicket
    {
    public string ID { get; set; }
    public string PlateNo { get; set; }

    public int GateID { get; set; }
    
    public DateTime DateIn { get; set; }
    public DateTime? DateOut { get; set; }


  }
}
