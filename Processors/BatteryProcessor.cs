using System.Management;
using BatteryExtensions.Models;

namespace BatteryExtensions.Processors;
public class BatteryProcessor
{
    public BatteryStatus GetBatteryStatus()
    {
        var batteryQuery = new ObjectQuery("SELECT * FROM Win32_Battery");
        using (var searcher = new ManagementObjectSearcher(batteryQuery))
        {
            var battery = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            if (battery != null)
            {
                return new BatteryStatus
                {
                    IsCharging = Convert.ToInt32(battery["BatteryStatus"]) == 2,
                    BatteryPercentage = Convert.ToInt32(battery["EstimatedChargeRemaining"])
                };
            }
        }
        return new BatteryStatus();
    }
}