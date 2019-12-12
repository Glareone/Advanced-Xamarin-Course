﻿using System;
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ExpensesApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            var dbName = "expenses_db.db3";
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..",
                "Library");
            var fullPath = Path.Combine(folderPath, dbName);

            // Another approach to use DI registration. Other one - is use [assembly: Dependency attribute]
            //DependencyService.Register<IShare, Share>();
            // OR
            //DependencyService.Register<Share>();

            LoadApplication(new App(fullPath));

            return base.FinishedLaunching(app, options);
        }
    }
}