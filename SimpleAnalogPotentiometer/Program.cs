using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace SimpleAnalogPotentiometer {
  public class Program {
    public static void Main() {
      OutputPort led = new OutputPort(Pins.GPIO_PIN_D0, false);

      AnalogInput pot = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);

      double potValueInVolts = 0; // goes from ~0.0V > ~3.3V
      int potValueInAdc = 0;      // goes from ~0 > 4095 on Netduino Plus 2 b/c it has a 12bit ADC


      while (true) {

        potValueInVolts = pot.Read() * 3.3f;
        potValueInAdc = pot.ReadRaw();

        Debug.Print("Read analog value (0.0 - 3.3v):  " + potValueInVolts + "v");
        Debug.Print("ReadRaw analog value (0 - 4095): " + potValueInAdc);

        int delay = (int)potValueInVolts * 100;
        Debug.Print("LED delay: " + delay +"ms");

        led.Write(true);
        Thread.Sleep(delay);
        led.Write(false);
        Thread.Sleep(delay);
      }

    }

  }
}
