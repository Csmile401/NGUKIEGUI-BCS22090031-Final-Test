using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace NGU_KIE_GUI_BCS22090031_FinalTest_Question_3
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
