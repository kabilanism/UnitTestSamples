using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\Windows\Fake.exe";
        private const string GOOD_FILE_NAME = @"C:\Windows\Regedit.exe";
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange: Get all your variables set up to be used in the action step.
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act: Execute the function using the previous arrangement and store the result.
            fromCall = fp.FileExists(GOOD_FILE_NAME);

            //Assert: Confirm whether the result returned by the action is as expected.
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] //For this test, we're expecting an exception of ArgumentNull.
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
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
