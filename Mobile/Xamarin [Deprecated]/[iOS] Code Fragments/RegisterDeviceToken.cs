public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
    // ..
    
    //to receive notification when app is on foreground
    UNUserNotificationCenter.Current.Delegate = new ForegroundNotificationDelegate();

    UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound, async (approved, err) =>
    {
        var settings = await UNUserNotificationCenter.Current.GetNotificationSettingsAsync();
        var alertSettingEnabled = (settings.AlertSetting == UNNotificationSetting.Enabled) && (settings.LockScreenSetting == UNNotificationSetting.Enabled) && (settings.NotificationCenterSetting == UNNotificationSetting.Enabled);
        var soundSettingEnabled = settings.SoundSetting == UNNotificationSetting.Enabled;
        var badgeSettingEnabled = settings.BadgeSetting == UNNotificationSetting.Enabled;

        if (approved && alertSettingEnabled && soundSettingEnabled && badgeSettingEnabled)
        {
            UIApplication.SharedApplication.RegisterForRemoteNotifications();
        }
        else
        {
            var alertController = UIAlertController.Create("Permission", "Allow settings to receive notifications", UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));
            alertController.AddAction(UIAlertAction.Create("Enable", UIAlertActionStyle.Default, action => UIApplication.SharedApplication.OpenUrl(new NSUrl("app-settings:"))));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);
        }
    });

    // ..
}

public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
{
    string myDeviceToken = deviceToken.DebugDescription.Replace(" ", "").Trim('<').Trim('>');
    //send device token to server..
}

public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
{
    if (Runtime.Arch == Arch.DEVICE)
    {
        //notify user
    }

    //iphone simulator cannot register for remote notification
}

public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
{
    //action for push notification click
}
