using System.Data.Entity;
using ParkingSpace.Models;
namespace ParkingSpace.DataAccess.Context {
  public class ParkingSpaceDb : DbContext {
    /// <summary>
    /// Table for save ParkingTicket's data
    /// </summary>
    public DbSet<ParkingTicket> parkingTicket { get; set; }

    /// <summary>
    /// Table far save Setting's data
    /// </summary>
    public DbSet<Setting> Setting { get; set; }
  }
}
