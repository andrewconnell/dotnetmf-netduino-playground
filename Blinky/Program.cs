using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Blinky {
  public class Program {
    public static void Main() {
      // get reference to the onboard LED
      OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

      while (true)
      {
        // turn LED on
        led.Write(true);
        Thread.Sleep(250);
        // turn LED off
        led.Write(false);
        Thread.Sleep(250);
      }
    }

  }
}
