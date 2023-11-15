using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;


namespace MaximalSumOfElements.Test
{
    [TestClass]
    public class ProgramManagerTest
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
        public void ProgramManager_UserEnter_Answer()
        {
            TestInitialize();

            var mock = new Mock<ICommunication>();
            mock.Setup(p => p.ReadLine())
                .Returns("TestFile.txt");

            var read = new Mock<IReading>();
            read.Setup(r => r.ReadText("TestFile.txt"))
                .Returns(new string[] { "15.72,71.33,59.78,18.65,15.49", "85.03,41.27,88.24,62.21,83.02,85.76,27.99,36.31", "jfbh,fng", "-12, -12, -99999" });

            string[] array = new string[] {""};

            ProgramManager programManager = new ProgramManager(mock.Object, read.Object);

            programManager.Start(array);

            mock.Verify(p => p.WriteLine(Constants.EnterPath));

            mock.Verify(p => p.WriteLine(Constants.LineWithMaximumSum));

            TestCleanup();
        }

        [TestMethod]
        public void ProgramManager_ConsoleArgument_Answer()
        {
            TestInitialize();

            var mock = new Mock<ICommunication>();            

            string[] array = new string[] {"TestFile.txt" };

            ProgramManager programManager = new ProgramManager(mock.Object);

            programManager.Start(array);            

            mock.Verify(p => p.WriteLine(Constants.LineWithMaximumSum));

            TestCleanup();
        }
    }
}