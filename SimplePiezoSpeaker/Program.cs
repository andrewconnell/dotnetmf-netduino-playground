using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace SimplePiezoSpeaker {
  public class Program {
    public static void Main() {
      // store notes on the music scale & associated pulse lengths
      var scale = new Hashtable();

      // low octave
      scale.Add("c", 1915u);
      scale.Add("d", 1700u);
      scale.Add("e", 1519u);
      scale.Add("f", 1432u);
      scale.Add("g", 1275u);
      scale.Add("a", 1136u);
      scale.Add("b", 1014u);

      // high octave
      scale.Add("C", 956u);
      scale.Add("D", 851u);
      scale.Add("E", 758u);

      // silence ('hold note')
      scale.Add("h", 0u);

      // set speed of 'song'
      const int beatsPerMinute = 90;
      const int beatTimeInMilliseconds = 60000 / beatsPerMinute;
      const int pauseTimeInMilliseconds = (int)(beatTimeInMilliseconds * 0.1);

      // define the song (letter of note followed by length of note)
      string song = "C1C1C1g1a1a1g2E1E1D1D1C2";

      // define speaker
      var speaker = new SecretLabs.NETMF.Hardware.PWM(Pins.GPIO_PIN_D5);

      // play the song
      for (int i = 0; i < song.Length; i += 2) {
        // extract each note & length in beats
        string note = song.Substring(i, 1);
        int beatCount = int.Parse(song.Substring(i + 1, 1));

        // lookup the note duration
        uint noteDuration = (uint)scale[note];

        // play the note for the desired number of beats
        speaker.SetPulse(noteDuration * 2, noteDuration);
        Thread.Sleep(beatTimeInMilliseconds * beatCount - pauseTimeInMilliseconds);

        // pause fo 1/10th of a beat between each note
        speaker.SetDutyCycle(0);
        Thread.Sleep(pauseTimeInMilliseconds);
      }

      Thread.Sleep(Timeout.Infinite);
    }

  }
}
