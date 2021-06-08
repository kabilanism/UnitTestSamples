using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            //Setup resources for specific tests within this class.
            //Add database tables ..
            //Initialize data in tables ..
            //Set text in files ..
            tc.WriteLine("In ClassInitialize() method");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //TODO: Clean up after all tests in class
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In TestInitialize() method");
            WriteDescription(this.GetType());
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(GOOD_FILE_NAME))
                {
                    TestContext.WriteLine("Creating file: " + GOOD_FILE_NAME);
                    File.AppendAllText(GOOD_FILE_NAME, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("In TestCleanup() method");
            
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (File.Exists(GOOD_FILE_NAME))
                {
                    TestContext.WriteLine($"Deleting file: {GOOD_FILE_NAME}");
                    File.Delete(GOOD_FILE_NAME);
                }
            }
        }

        [TestMethod]
        [Description("Check to see if a file exists.")]
        public void FileNameDoesExist()
        {
            //Arrange: Get all your variables set up to be used in the action step.
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Checking File {GOOD_FILE_NAME} ...");

            //Act: Execute the function using the previous arrangement and store the result.
            fromCall = fp.FileExists(GOOD_FILE_NAME);

            //Assert: Confirm whether the result returned by the action is as expected.
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file does not exist.")]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Checking File {BAD_FILE_NAME} ...");

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] //For this test, we're expecting an exception of ArgumentNull.
        [Description("Check for a thrown ArgumentNullException using ExpectedException.")]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            TestContext.WriteLine("Checking null or empty file ...");

            fp.FileExists("");
        }

        [TestMethod]
        [Description("Check for a thrown ArgumentNullExcpetion using a try catch.")]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                TestContext.WriteLine("Checking null or empty file using try catch ...");
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //Test was a success
                return;
            }

            //Fail the test
            Assert.Fail("Call to FileExists() did NOT throw an ArgumentNullException.");
        }

        
    }
}
