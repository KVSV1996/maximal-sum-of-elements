using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MaximalSumOfElements.Test
{
    [TestClass]
    public class ReadFromFileTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            File.WriteAllText("TestFile.txt", "87.85,56.16\njfbh\nfngomrmnjt");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            File.Delete("TestFile.txt");
        }

        [TestMethod]
        public void ReadFromFile_Path_StringArray()
        {
            TestInitialize();

            string[] array = new string[] { "87.85,56.16", "jfbh,fng", "omrmnjt" };

            IReading read = new ReadFromFile();

            string[] result = read.ReadText("TestFile.txt");

            Assert.AreEqual(array.Length, result.Length);

            TestCleanup();
        }
    }
}
