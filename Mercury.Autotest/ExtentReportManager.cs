using RelevantCodes.ExtentReports;
using System;
using System.IO;

namespace Mercury.Autotest
{
    public static class ExtentReportManager
    {
        private static ExtentTest extentTest;
        public static string path;

        public static ExtentTest ExtentTest
        {
            get
            {
                if (extentTest == null)
                {
                    throw new NullReferenceException("The ExtentReportManager instance was not initialized.");
                }
                return extentTest;
            }
            private set
            {
                extentTest = value;
            }
        }

        public static void StartManager(ExtentTest extentTest, string path)
        {
            ExtentReportManager.extentTest = extentTest;
            ExtentReportManager.path = path;
        }

    }
}
