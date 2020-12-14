public bool IsInstalledByOfficialGooglePlay()
{
    //GetInstallerPackageName deprecated from API30, use GetInstallSourceInfo but not supported on Xamarin yet
    return PackageManager.GetInstallerPackageName(this.PackageName) == "com.android.vending";
}
