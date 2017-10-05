using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace glovia_obic7.Services
{
    public class FileListup : BaseService
    {
        public FileListup() { }

        public List<string> GetTargetFiles(string path)
        {
            var files = Directory.EnumerateFiles(path, ServiceResource.ListupSearchPattern, SearchOption.AllDirectories);
            List<string> result = new List<string>();
            foreach (var file in files)
            {
                if (Regex.IsMatch(file, ServiceResource.ListupMatchPattern, RegexOptions.IgnoreCase))
                {
                    result.Add(file);
                }
                if (Regex.IsMatch(file, ServiceResource.ListupMatchOtherPattern, RegexOptions.IgnoreCase))
                {
                    result.Add(file);
                }
            }
            return result;
        }
    }
}
