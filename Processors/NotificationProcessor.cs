using Microsoft.Toolkit.Uwp.Notifications;

namespace BatteryExtensions.Processors;
public class NotificationProcessor
{
    string test = "";
    ToastContentBuilder notificationInstance = new ToastContentBuilder();
    public void Build(string type)
    {
        switch (type)
        {
            case "":
                break;
            default:
                notificationInstance.AddText("Battery 90% charged, unplug to preserve battery health.");
                break;
        }
        
    }

    public void Show()
    {
        notificationInstance.Show();
    }
}