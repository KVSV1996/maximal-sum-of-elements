namespace MaximalSumOfElements
{
    public class ConsoleComunication : ICommunication
    {
        public void WriteLine(object message)
        {
            Console.WriteLine(message);            
        }        
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
