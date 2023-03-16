using Microsoft.Maui.LifecycleEvents;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureLifecycleEvents(events =>
			{
#if ANDROID
			     events.AddAndroid(android => android
				 .OnActivityResult((activity, requestCode, resultCode, data) => LogEvent(nameof(AndroidLifecycle.OnActivityResult), requestCode.ToString()))
                 .OnStart((activity) => LogEvent(nameof(AndroidLifecycle.OnStart)))
                 .OnCreate((activity, bundle) => LogEvent(nameof(AndroidLifecycle.OnCreate)))
                 .OnBackPressed((activity) => LogEvent(nameof(AndroidLifecycle.OnBackPressed)) && false)
                 .OnStop((activity) => LogEvent(nameof(AndroidLifecycle.OnStop)))
				 .OnResume((activity)=> 
				 {
					 LogEvent(nameof(AndroidLifecycle.OnResume));
				 })
				 .OnDestroy((activity)=>LogEvent(nameof(AndroidLifecycle.OnDestroy)))
				 .OnPause((activity) => LogEvent(nameof (AndroidLifecycle.OnPause)))
				 .OnRestart((activity) => LogEvent(nameof(AndroidLifecycle.OnRestart)))
				 .OnPostResume((activity) => LogEvent(nameof(AndroidLifecycle.OnPostResume)))
				 .OnSaveInstanceState((activity, hoge) => { LogEvent(nameof(AndroidLifecycle.OnSaveInstanceState)); })
				 );
#endif
                static bool LogEvent(string eventName, string type = null)
                {
                    System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
                    return true;
                }
            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialFontFamily");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
            });

		return builder.Build();
	}
}
