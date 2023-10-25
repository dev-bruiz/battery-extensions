// See https://aka.ms/new-console-template for more information
using Microsoft.Toolkit.Uwp.Notifications;
using BatteryExtensions.Processors;

Console.WriteLine("Hello, World!");

var batteryProcessor = new BatteryProcessor();
var notificationProcessor = new NotificationProcessor();
var batteryStatus = batteryProcessor.GetBatteryStatus();

while (batteryStatus.IsCharging)
{
    //TODO: convert his console app into a backround service
    //Check if battery is charging and level is >= 90%
    if (batteryStatus.IsCharging && batteryStatus.BatteryPercentage >= 90)
    {
        notificationProcessor.Build("");
        notificationProcessor.Show();

        System.Threading.Thread.Sleep(300000);
    }
}