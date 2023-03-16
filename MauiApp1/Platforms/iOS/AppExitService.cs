using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class AppExitService
    {
        public partial void Exit()
        {
            Console.WriteLine("AppExit iOS");
            //System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
