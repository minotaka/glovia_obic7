using glovia_obic7.Resources;

namespace glovia_obic7.Services
{
    public interface IBaseConvertService
    {
        bool ExecuteConvert(string filename, InputSystem system);
        bool WriteFile(string output_path, string keyname, bool hasHeader);
    }
}
