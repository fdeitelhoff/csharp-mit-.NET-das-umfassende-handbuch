using Android.Content;
using Android.OS;
using MauiBeispiele.Platforms.Android;
using Application = Android.App.Application;

[assembly: Dependency(typeof(DeviceVibrator))]
namespace MauiBeispiele.Platforms.Android
{
    public class DeviceVibrator : IDeviceVibrator
    {
        public void Vibrate(int milliseconds)
        {
            var vibrator = Application.Context.GetSystemService(Context.VibratorService) as Vibrator;
            vibrator?.Vibrate(VibrationEffect.CreateOneShot(500, VibrationEffect.DefaultAmplitude));
        }
    }
}
