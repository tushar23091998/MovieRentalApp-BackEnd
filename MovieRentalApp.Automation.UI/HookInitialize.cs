using MovieRentalApp.Automation.UI.Config;
using MovieRentalApp.Automation.UI.Hooks;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace MovieRentalApp.Automation.UI
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {

        public HookInitialize() : base(BrowserType.Chrome)
        {
            InitializeSettings();
            //NavigateSite();
        }

        [BeforeScenario]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }

        [AfterScenario]
        public static void TestEnd()
        {
            DriverContext.Driver.Close();
            DriverContext.Driver.Quit();
        }
    }
}
