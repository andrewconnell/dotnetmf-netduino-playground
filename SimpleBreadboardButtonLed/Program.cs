using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace SimpleBreadboardButtonLed {
  public class Program {
    public static void Main() {
      // GPIO that goes to 330ohm resistor connected to long arm of the LED
      var led = new OutputPort(Pins.GPIO_PIN_D0, false);

      // GPIO that goes to the button on the breadboard
      var button = new InputPort(Pins.GPIO_PIN_D1, false, Port.ResistorMode.PullUp);

      bool buttonState = false;

      while (true)
      {
        // when the button is pressed...
        buttonState = !button.Read();
        // ... turn the light on
        led.Write(buttonState);

        Debug.Print(buttonState.ToString());
        Thread.Sleep(100);
      }

    }

  }
}
