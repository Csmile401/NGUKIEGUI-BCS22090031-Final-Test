using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace NGU_KIE_GUI_BCS22090031_FinalTest
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
