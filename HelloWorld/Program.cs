using System;
using System.Threading;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using System.Device.Spi;
using GHIElectronics.Endpoint.Core;
          
var count = 0;
var pin = EPM815.Gpio.Pin.PC0;
var portId = pin / 16;
var pinId = pin % 16;

var gpioController = new GpioController(PinNumberingScheme.Logical, new LibGpiodDriver(portId));

gpioController.OpenPin(pinId);
gpioController.SetPinMode(pinId, PinMode.Output);

Console.WriteLine("Embedded .NET template"); 

while (true)
{
    Console.WriteLine("Counter increases every one second: " + count++);

    gpioController.Write(pinId, PinValue.High);
    Thread.Sleep(500);

    gpioController.Write(pinId, PinValue.Low);
    Thread.Sleep(500);
                
}