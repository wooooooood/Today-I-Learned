//https://forums.xamarin.com/discussion/128350/xamarin-ios-notifications-how-to-turn-shouldalwaysalertwhileappisforeground-to-yes
using System;
using UserNotifications;

namespace wooooooood.iOS
{
    public class ForegroundNotificationDelegate : UNUserNotificationCenterDelegate
    {
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            //multiple options
            completionHandler(UNNotificationPresentationOptions.Alert | UNNotificationPresentationOptions.Sound | UNNotificationPresentationOptions.Badge);
        }
    }
}

/*
[Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, 
Action<UNNotificationPresentationOptions> completionHandler)
{
    //multiple options
    completionHandler(UNNotificationPresentationOptions.Sound | UNNotificationPresentationOptions.Alert);
    
    //single option
    //completionHandler(UNNotificationPresentationOptions.Alert);
}
*/
