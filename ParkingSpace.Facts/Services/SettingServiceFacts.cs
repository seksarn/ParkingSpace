using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingSpace.Models;
using ParkingSpace.Services;
namespace ParkingSpace.Facts.Services {
  public class SettingServiceFacts {

    public class CurrentProperty {

      [Fact]
      public void FirstCallCreatenewSetting() {
        using(var app = new App(testing: true)) {
          Assert.Equal(0, app.Setting.All().Count());

          var s = app.Setting.Current;
          Assert.NotNull(s);
          Assert.Equal(1, app.Setting.All().Count());

        }
      }

      [Fact]
      public void SecondCallGetTheSameSetting() {
        using (var app = new App(testing: true)) {
          var s = app.Setting.Current;
          var s1 = app.Setting.Current;

          Assert.Same(s, s1);

        }
      }




    }

  }
}
