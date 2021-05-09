using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string GOOD_FILE_NAME;
        protected const string BAD_FILE_NAME = @"C:\Windows\Fake.exe";
        protected void SetGoodFileName()
        {
            GOOD_FILE_NAME = TestContext.Properties["GoodFileName"].ToString();
            if (GOOD_FILE_NAME.Contains("[AppPath]"))
            {
                GOOD_FILE_NAME = GOOD_FILE_NAME.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
