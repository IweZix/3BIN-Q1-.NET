namespace Semaine_4.client
{
    // 4.	Créez une classe Logger
    class Logger
    {
        public delegate void Log(String s);

        public Log log;

        public void LogMessage(String s)
        {
            log?.Invoke(s);
        }
    }

    // 5.	Créez une classe ConsoleLogger qui implémente un logger qui écrit sur la Console
    class ConsoleLogger
    {
        public void LogMessage(String s)
        {
            Console.WriteLine(s);
        }
    }

    // 6.	Créez une classe FileLogger qui implémente un logger qui écrit dans un fichier
    class FileLogger
    {
        public void LogMessage(String s)
        {
            File.WriteAllText("log.txt", s);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.log += new ConsoleLogger().LogMessage;
            logger.log += new FileLogger().LogMessage;

            logger.LogMessage("test");

        }
    }
}
