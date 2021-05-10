using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class MyClassesTestInitialization
    {
        [AssemblyInitialize()] //You would include all the setup (database, files, etc. ..) for each class in this assembly to be done prior to any tests being run.
        public static void AssemblyInitialize(TestContext tc)
        {
            //Create DB ..
            //Create tables in the DB ..
            //Add test data to the DB ..
            //Create text files ..

            tc.WriteLine("In AssemblyInitialize() method");
        }

        [AssemblyCleanup()] //This is where you remove anything you set up in the initialization once the tests are completed running.
        public static void AssemblyCleanup()
        {
            //Remove DB ..
            //Remove tables in DB ..
            //Remove test data ..
            //Remove text files ..
        }
    }
}
