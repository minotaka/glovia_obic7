namespace glovia_obic7
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!System.IO.Directory.Exists(baseDirectory + @"\logs"))
                System.IO.Directory.CreateDirectory(baseDirectory + @"\logs");
            NLog.LogManager.GetLogger("systemLogger").Trace(Resources.LogMessage.PROGRAM_START);
            new Controllers.Converter().Conversion();
            NLog.LogManager.GetLogger("systemLogger").Trace(Resources.LogMessage.PROGRAM_END);
#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
