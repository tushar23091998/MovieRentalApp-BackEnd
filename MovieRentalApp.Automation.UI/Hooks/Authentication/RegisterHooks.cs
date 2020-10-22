//using MovieRentalApp.Automation.UI.Config;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechTalk.SpecFlow;

//namespace MovieRentalApp.Automation.UI.Hooks.Authentication
//{
//    [Binding]
//    public class RegisterHooks 
//    {
//                // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

//        [BeforeScenario]
//        public void BeforeScenario()
//        {
//            TestInitializeHook testInitializeHook = new TestInitializeHook(BrowserType.Chrome);
//            testInitializeHook.InitializeSettings();
//        }

//        [AfterScenario]
//        public void AfterScenario()
//        {
//            DriverContext.Driver.Quit();
//        }
//    }
//}
