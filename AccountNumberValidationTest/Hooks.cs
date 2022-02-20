using Gherkin.Ast;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AccountNumberValidationTest
{
    [Binding]
    public class Hooks
    {
        static String test = null;
        static int total = 0;
        static int pass = 0;
        static int fail = 0;

        [BeforeTestRun]
        public static void BeforeTest()
        {
            Logger.InitializeLog();
            Logger.AddLog("-----------------------------------------");
            Logger.AddLog("");
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            test = ScenarioContext.Current.ScenarioInfo.Title;
            total++;
            Logger.AddLog("Scenario : " + test);

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            string status = ScenarioContext.Current.ScenarioExecutionStatus.ToString();
            if (status == "OK")
            {
                Logger.AddLog("Scenario : " + test + " : PASS");
                pass++;
            }
            else if(status == "TestError")
            {
                Logger.AddLog("Scenario : " + test + " : FAILED");
                fail++;
            }
            Logger.AddLog("-----------------------------------------");
            Logger.AddLog("");
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            Logger.AddLog($"Total Test\t:\t"+total.ToString());
            Logger.AddLog($"Total Passed\t:\t" + pass.ToString());
            Logger.AddLog($"Total Failed\t:\t" + fail.ToString());
            Logger.AddLog("-----------------------------------------");
        }
    }
}
