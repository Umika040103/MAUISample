using static Microsoft.Maui.ApplicationModel.Permissions;


namespace MauiApp1.Platforms.Android.Helper
{
    internal class MyBluetoothPermissionDroid : BasePlatformPermission
    {
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string permission, bool isRuntime)>
        {
                ("android.permission.BLUETOOTH_SCAN", true),
                ("android.permission.BLUETOOTH_CONNECT", true)
        }.ToArray();
    }
}
