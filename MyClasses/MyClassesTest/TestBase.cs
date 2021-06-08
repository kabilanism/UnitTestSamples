using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string GOOD_FILE_NAME;
        protected string BAD_FILE_NAME = @"C:\Windows\Fake.exe";
        protected void WriteDescription(Type typ)
        {
            string testName = TestContext.TestName;

            //Find the test method currently executing
            MemberInfo method = typ.GetMethod(testName);
            if (method != null)
            {
                //See if the [Description] attribute exists on this test
                Attribute attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if (attr != null)
                {
                    //Cast the attribute to a DescriptionAttribute
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;
                    //Display the test description
                    TestContext.WriteLine($"Test Description: {dattr.Description}");
                }
            }
        }
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
