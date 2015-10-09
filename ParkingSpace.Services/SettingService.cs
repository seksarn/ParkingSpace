﻿using ParkingSpace.Models;
using ParkingSpace.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSpace.DataAccess.Core;

namespace ParkingSpace.Services {
  public class SettingService : ServiceBase<App, Setting> {
    public override IRepository<Setting> Repository { get; set; }

    public override Setting Find(params object[] keys) {
      var id = (int)keys[0];
      return Query(item => item.ID == id).SingleOrDefault();
    }
    public Setting Current {
      get {
        var setting = All().FirstOrDefault();
        if (setting == null) {
          setting = new Setting();  
          Add(setting);
          SaveChanges();
        }
        return setting;
      }
    }
  }
}
