namespace MaximalSumOfElements
{
    public class ReadFromFile : IReading
    {
        public string[] ReadText(string message)
        {           
                return File.ReadAllLines(message);
        }
    }
}
