using glovia_obic7.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovia_obic7.Services
{
    public class DirectoryFilesService : BaseService, IDirectoryFilesService
    {
        public bool ClearDirectory(string targetDirectoryPath, bool deleteBaseDirectory = false)
        {
            return ClearDirectory(targetDirectoryPath, 0, deleteBaseDirectory, 0);
        }

        public bool ClearDirectory(string targetDirectoryPath, int clearLevel, bool deleteBaseDirectory = false)
        {
            return ClearDirectory(targetDirectoryPath, clearLevel, deleteBaseDirectory, 0);
        }

        private bool ClearDirectory(string targetDirectoryPath, int clearLevel, bool deleteBaseDirectory, int nowLevel)
        {
            try
            {
                if (!Directory.Exists(targetDirectoryPath))
                {
                    return false;
                }
                string[] filePaths = Directory.GetFiles(targetDirectoryPath);
                foreach (string filePath in filePaths)
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }

                // 
                if (clearLevel == 0 || clearLevel > nowLevel)
                {
                    string[] directoryPaths = Directory.GetDirectories(targetDirectoryPath);
                    foreach (string directoryPath in directoryPaths)
                    {
                        ClearDirectory(directoryPath, clearLevel, true, nowLevel + 1);
                    }
                }
                if (deleteBaseDirectory)
                {
                    Directory.Delete(targetDirectoryPath, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex, LogMessage.SYS_CLEAR_EXCEPTION);
                return false;
            }
        }

        public bool CopyAndReplace(string sourcePath, string copyPath, bool preClear = false, bool copySubDirectory = true)
        {
            if (preClear)
            {
                ClearDirectory(copyPath, 0, true);
                CreateDirectory(copyPath);
            }
            return CopyAndReplace(sourcePath, copyPath, copySubDirectory);
        }

        private bool CopyAndReplace(string sourcePath, string copyPath, bool copySubDirectory)
        {
            try
            {
                foreach (var file in Directory.GetFiles(sourcePath))
                {
                    File.Copy(file, Path.Combine(copyPath, Path.GetFileName(file)));
                }
                if (copySubDirectory)
                {
                    foreach (var dir in Directory.GetDirectories(sourcePath))
                    {
                        CopyAndReplace(dir, Path.Combine(copyPath, Path.GetFileName(dir)), copySubDirectory);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex, LogMessage.SYS_CLEAR_EXCEPTION);
                return false;
            }
        }

        public bool MoveDirectoryFiles(string sourcePath, string copyPath, bool moveSubDirectory = true)
        {
            try
            {
                ClearDirectory(copyPath, true);
                CreateDirectory(copyPath);

                foreach (var file in Directory.GetFiles(sourcePath))
                {
                    File.Move(file, Path.Combine(copyPath, Path.GetFileName(file)));
                }
                if (moveSubDirectory)
                {
                    foreach (var dir in Directory.GetDirectories(sourcePath))
                    {
                        MoveDirectoryFiles(dir, Path.Combine(copyPath, Path.GetFileName(dir)), moveSubDirectory);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex, LogMessage.SYS_CLEAR_EXCEPTION);
                return false;
            }
        }

        public bool CreateDirectory(string targetPath)
        {
            try
            {
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex, LogMessage.SYS_CLEAR_EXCEPTION);
                return false;
            }
        }
    }
}
