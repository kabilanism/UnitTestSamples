using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange: Get all your variables set up to be used in the action step.
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act: Execute the function using the previous arrangement and store the result.
            fromCall = fp.FileExists(@"C:\Windows\Regedit.exe");

            //Assert: Confirm whether the result returned by the action is as expected.
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Windows\Fake.exe");

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            Assert.Inconclusive();
        }
    }
}
