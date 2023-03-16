using Android.OS;

namespace MauiApp1
{
    public partial class AppExitService
    {
        public partial void Exit()
        {
            Console.WriteLine("AppExit Android");
            //Process.KillProcess(Process.MyPid());
            //System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
