using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace PushOnboardButton {
  public class Program {
    public static void Main()
    {
      OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

      // lets me read the voltage level of the pins, in this case the voltage coming from the button
      InputPort button = new InputPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled);

      bool buttonState = false;

      while (true)
      {
        buttonState = button.Read();
        led.Write(buttonState);
      }
    }

  }
}
