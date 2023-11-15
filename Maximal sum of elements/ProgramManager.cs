
namespace MaximalSumOfElements
{
    public class ProgramManager
    {
        private IReading read;
        private readonly ICommunication comunication;                        
        public ProgramManager(ICommunication comunication)
        {
            this.comunication = comunication ?? throw new FileNotFoundException(nameof(comunication));
        }
        public ProgramManager(ICommunication comunication, IReading read)
        {
            this.comunication = comunication ?? throw new ArgumentNullException(nameof(comunication));
            this.read = read ?? throw new FileNotFoundException(nameof(comunication));
        }
        public void Start(string[] args)
        {            
            
            ActionWithArrayOfStrings actions = new ActionWithArrayOfStrings(read.ReadText(TakePath(args)));

            comunication.WriteLine(Constants.LineWithMaximumSum);
            comunication.WriteLine(actions.FindingLineWithMaximumSum());            

            PrintDefectiveLines(actions.DefectiveLines);            
        }

        private void PrintDefectiveLines(List<int> defectiveLines)
        {
            comunication.WriteLine(Constants.DefectiveLines);
            comunication.WriteLine(String.Join(',', defectiveLines));            
        }
        private string TakePath(string[] args)
        {
            if (args.Length > 0)
            {                
                if (File.Exists(args[0]))
                {                    
                    return args[0];
                }
            }
           return GetConsoleEnter();
        }

        private string GetConsoleEnter()
        {            
            comunication.WriteLine(Constants.EnterPath);
            string path = comunication.ReadLine();

            if (File.Exists(path))
            {
                return path;
            }
            comunication.WriteLine(Constants.Error);
            return GetConsoleEnter();
        }              
    }
}
