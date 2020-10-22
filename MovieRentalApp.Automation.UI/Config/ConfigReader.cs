using MovieRentalApp.Automation.UI.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml.XPath;

namespace MovieRentalApp.Automation.UI
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            //XPathItem aut;
            //XPathItem testtype;
            ////XPathItem buildname;

            //string strFilename = Environment.CurrentDirectory.ToString() + @"\Config\AutomationConfig.xml";
            //FileStream stream = new FileStream(strFilename, FileMode.Open, FileAccess.Read);
            //XPathDocument document = new XPathDocument(stream);
            //XPathNavigator navigator = document.CreateNavigator();

            //aut = navigator.SelectSingleNode("MovieAutomationFramework/RunSettings/AUT");
            ////buildname = navigator.SelectSingleNode("MovieAutomationFramework/RunSettings/BuildName");
            //testtype = navigator.SelectSingleNode("MovieAutomationFramework/RunSettings/TestType");

            //Set XML Details in the property to be used accross framework
            //Settings.AUT = aut.Value.ToString();
            //Settings.BuildName = buildname.Value.ToString();
            //Settings.TestType = testtype.Value.ToString();

            Settings.AUT = "http://localhost:4200/home";
        }
    }
}
