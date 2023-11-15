using System.Text.RegularExpressions;
using System.Globalization;

namespace MaximalSumOfElements
{
    public class ActionWithArrayOfStrings
    {
        
        private double[] Sum;
        public List<int> DefectiveLines = new List<int>();  
        public ActionWithArrayOfStrings(string[] array)
        {
            if(array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            if(array.Length == 0)
            {
                throw new InvalidOperationException(nameof(array));
            }
            FindingSumOfElement(array);            
        }       

        public object FindingLineWithMaximumSum()
        {            
            double maxValue = Sum.Max();
            int maxIndex = Sum.ToList().IndexOf(maxValue);

            if (maxValue == double.MinValue)
            {
                return Constants.NoLines;
            }
            return maxIndex + 1;
        }        

        private void FindingSumOfElement(string[] array)
        {
            CultureInfo culture = new CultureInfo("en-US");            
            Sum = new double[array.Length];
            string[] elementsInLines;

            string patern = @"\.\.|\,\,|[a-z]|\s|^\,|^\.|^\s*$";
            Regex r = new Regex(patern, RegexOptions.IgnoreCase);

            for (int i = 0; i < array.Length; i++ )
            {
                Match m = r.Match(array[i]);
                if (m.Success)
                {
                    DefectiveLines.Add(i+1);
                    Sum[i] = double.MinValue;
                    continue;
                }

                elementsInLines = array[i].Split(',');

                foreach (string elements in elementsInLines)
                {                    
                    Sum[i] += double.Parse(elements, culture.NumberFormat);                    
                }                
            }
        }        
    }
}
