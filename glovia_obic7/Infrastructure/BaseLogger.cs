using glovia_obic7.Resources;
using NLog;

namespace glovia_obic7.Infrastructure
{
    public class CustomLogger : Logger
    {
        public void SetMode(ConvertMode mode)
        {
            MappedDiagnosticsContext.Clear();
            MappedDiagnosticsContext.Set("PropertyType", mode.ToString());
        }
        public void SetMode(string mode)
        {
            MappedDiagnosticsContext.Clear();
            MappedDiagnosticsContext.Set("PropertyType", mode);
        }
    }

    public class BaseLogger
    {
        private string SystemLog = "systemLogger";
        private string ConvertLog = "convertLogger";
        private string CConvertLog = "cconvertLogger";
        protected Logger SystemLogger
        {
            get
            {
                return LogManager.GetLogger(SystemLog);
            }
        }
        protected Logger ConvertLogger
        {
            get
            {
                return LogManager.GetLogger(ConvertLog);
            }
        }

        protected CustomLogger CConvertLogger
        {
            get
            {
                return (CustomLogger)LogManager.GetLogger(CConvertLog, typeof(CustomLogger));
            }
        }
    }
}
