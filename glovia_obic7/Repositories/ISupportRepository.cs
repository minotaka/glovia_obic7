using glovia_obic7.Models;
using System.Collections.Generic;

namespace glovia_obic7.Repositories
{
    public interface ISupportRepository
    {
        int StringToInteger(string src, int size = 0);
        int StringToIntegerOrDefault(string src, int size = 0, int defaultValue = 0);
        string StringToString(string src, int size);
        decimal GamountToDecimal(string src);
        List<GloviaIppanModel> ReadGloviaIppan(string filename);
        List<GloviaTorihikisakiModel> ReadGloviaTorihiki(string filename);
        List<T> ReadGlovia<T>(string filename) where T : IGloviaModel, new();
    }
}
