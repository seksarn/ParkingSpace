using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingSpace.Models;
using Rotativa;
using System.Web.Mvc;

namespace ParkingSpace.Web.Printing {
  public class PDFParkingTicketPrinter : IParkingTicketPrinter {
   // private ControllerContext context;

    public ControllerContext Context { get; set; }

    public PDFParkingTicketPrinter() {
    }

    public void Print(ParkingTicket ticket, object args = null) {
      //throw new NotImplementedException();
     
      var r = new ViewAsPdf("RPT_01_PakingTicket_In", ticket);
      r.PageSize = Rotativa.Options.Size.A6;
      r.PageOrientation = Rotativa.Options.Orientation.Portrait;


      var fName = ticket.ID + ".PDF";
      var fPath = HttpContext.Current. Server.MapPath("~/App_Data/" + fName);


      var bytes = r.BuildPdf((ControllerContext) args);
      System.IO.File.WriteAllBytes(fPath, bytes);
    }
  }
}