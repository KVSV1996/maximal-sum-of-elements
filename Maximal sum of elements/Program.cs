namespace MaximalSumOfElements
{
    class Program
    {
        public static void Main(string[] args)
        {            
            ICommunication comunication = new ConsoleComunication();
            IReading read = new ReadFromFile();
            ProgramManager programManager = new ProgramManager(comunication, read);            
            programManager.Start(args);
        }        
    }
}

