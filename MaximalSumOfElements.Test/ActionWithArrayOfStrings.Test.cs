using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MaximalSumOfElements.Test
{
    [TestClass]
    public class ActionWithArrayOfStringsTest
    {
        [TestMethod]
        public void ActionWithArrayOfStrings_EmptyArray_Exseption()
        {
            string[] array = new string[] { };

            ActionWithArrayOfStrings actions = new ActionWithArrayOfStrings(array);

            Assert.ThrowsException<InvalidOperationException>(() => new ActionWithArrayOfStrings(array));
        }

        [TestMethod]
        public void ActionWithArrayOfStrings_Null_Exseption()
        {
            string[] array = null;

            ActionWithArrayOfStrings actions = new ActionWithArrayOfStrings(array);

            Assert.ThrowsException<NullReferenceException>(() => new ActionWithArrayOfStrings(array));
        }

        [TestMethod]
        [DataRow(new string[] { "15.72,71.33,59.78,18.65,15.49", "85.03,41.27,88.24,62.21,83.02,85.76,27.99,36.31", "jfbh,fng", "-12, -12, -99999" },2)]
        [DataRow(new string[] { "-5,-20,1", "-300,-10", "jfbh,fng", "-12,-12,-99999" }, 1)]        
        [DataRow(new string[] { "0", "0", "jfbh,fng", "-12, -12, -99999" }, 1)]
        [DataRow(new string[] { "025 wr", "jfbh,fng", "-12, -12, -99999" }, Constants.NoLines)]
        public void ActionWithArrayOfStrings_ValidData_Answer(string[] array,object value)
        {
            ActionWithArrayOfStrings actions = new ActionWithArrayOfStrings(array);

            object result = actions.FindingLineWithMaximumSum();

            Assert.AreEqual(value, result);
        }
    }
}
