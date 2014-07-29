using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace SimpleRgbLed {
  public class Program {
    public static void Main()
    {

      // msft classes
      var redLed = new Microsoft.SPOT.Hardware.PWM(Cpu.PWMChannel.PWM_7, 0.6f, 50, false);
      var greenLed = new Microsoft.SPOT.Hardware.PWM(Cpu.PWMChannel.PWM_5, 0.0f, 50, false);
      var blueLed = new Microsoft.SPOT.Hardware.PWM(Cpu.PWMChannel.PWM_4, 1.0f, 50, false);

      redLed.Start();
      greenLed.Start();
      blueLed.Start();

      // secret labs classes
      var redLed2 = new SecretLabs.NETMF.Hardware.PWM(Pins.GPIO_PIN_D11);
      redLed2.SetDutyCycle(40);
      var greenLed2 = new SecretLabs.NETMF.Hardware.PWM(Pins.GPIO_PIN_D9);
      greenLed2.SetDutyCycle(60);
      var blueLed2 = new SecretLabs.NETMF.Hardware.PWM(Pins.GPIO_PIN_D8);
      blueLed2.SetDutyCycle(10);

      Thread.Sleep(Timeout.Infinite);
    }

  }
}
