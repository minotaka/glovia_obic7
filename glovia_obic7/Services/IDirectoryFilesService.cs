using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovia_obic7.Services
{
    public interface IDirectoryFilesService
    {
        bool ClearDirectory(string targetDirectoryPath, bool deleteBaseDirectory = false);
        bool ClearDirectory(string targetDirectoryPath, int clearLevel, bool deleteBaseDirectory = false);
        bool CopyAndReplace(string sourcePath, string copyPath, bool preClear = false, bool copySubDirectory = true);
        bool MoveDirectoryFiles(string sourcePath, string copyPath, bool moveSubDirectory = true);
        bool CreateDirectory(string targetPath);
    }
}
