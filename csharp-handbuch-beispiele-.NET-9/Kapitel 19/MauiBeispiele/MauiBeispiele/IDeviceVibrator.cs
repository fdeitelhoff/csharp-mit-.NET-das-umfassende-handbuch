using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeispiele.Platforms.Android
{
    public interface IDeviceVibrator
    {
        void Vibrate(int milliseconds);
    }
}
