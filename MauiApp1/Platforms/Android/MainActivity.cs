using Android.App;
using Android.Content.PM;
using Android.OS;
using MauiApp1.Platforms.Android.Helper;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);


    }

    private async Task RequestPermission()
    {
        if (DeviceInfo.Platform != DevicePlatform.Android)
            return;

        var status = PermissionStatus.Unknown;

        if (DeviceInfo.Version.Major >= 12)
        {
            status = await Permissions.CheckStatusAsync<MyBluetoothPermissionDroid>();

            if (status == PermissionStatus.Granted)
                return;

            if (Permissions.ShouldShowRationale<MyBluetoothPermissionDroid>())
            {
                await Shell.Current.DisplayAlert("Needs permissions", "BECAUSE!!!", "OK");
            }

            status = await Permissions.RequestAsync<MyBluetoothPermissionDroid>();


        }
        else
        {
            status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return;

            //過去にユーザがアクセス許可をすでに拒否している場合はメッセージを表示する
            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                await Shell.Current.DisplayAlert("Needs permissions", "BECAUSE!!!", "OK");
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();


            while (status == PermissionStatus.Denied)
            {
                await Shell.Current.DisplayAlert("Needs permissions", "REASON", "OK");
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

        }


        if (status != PermissionStatus.Granted)
            await Shell.Current.DisplayAlert("Permission required",
                "Location permission is required for bluetooth scanning. " +
                "We do not store or use your location at all.", "OK");
    }
}
