using glovia_obic7.Infrastructure;
using glovia_obic7.Repositories;
using glovia_obic7.Resources;
using glovia_obic7.Services;
using NLog;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace glovia_obic7.Controllers
{
    public class Converter : BaseLogger, IDisposable
    {
        private Container container = null;

        public Converter()
        {
            container = new Container();
            container.Register<ILocalTableRepository, LocalTableRepository>(Lifestyle.Singleton);
            container.Register<ISupportRepository, SupportRepository>();
        }

        private bool GetEnviroment(out string srcPath, out string outPath, out string backupPath, out bool hadHeader)
        {
            try
            {
                srcPath = null;
                outPath = null;
                backupPath = null;
                hadHeader = true;

                srcPath = ConfigurationManager.AppSettings[ServiceResource.ConfigSourcePath];
                if (srcPath == null)
                {
                    ConvertLogger.Error(LogMessage.CONFIG_NO_SEARCHPATH);
                    SystemLogger.Error(LogMessage.SYS_CONFIG_SYS_NO_GET, ServiceResource.ConfigSourcePath);
                    ConvertLogger.Error(LogMessage.CONVERT_STOP);
                    return false;
                }
                ConvertLogger.Trace(LogMessage.CONFIG_SHOW_SEARCHPATH, srcPath);

                // 変換後の出力先を取得
                outPath = ConfigurationManager.AppSettings[ServiceResource.ConfigOutputPath];
                if (outPath == null)
                {
                    ConvertLogger.Error(LogMessage.CONFIG_NO_OUTPUTPATH);
                    SystemLogger.Error(LogMessage.SYS_CONFIG_SYS_NO_GET, ServiceResource.ConfigOutputPath);
                    ConvertLogger.Error(LogMessage.CONVERT_STOP);
                    return false;
                }
                if (!Directory.Exists(outPath))
                {
                    ConvertLogger.Error(LogMessage.CONFIG_NOT_EXIST_OUTPUTPATH);
                    SystemLogger.Error(LogMessage.SYS_CONFIG_ERROR_VALUE, ServiceResource.ConfigOutputPath, outPath);
                    ConvertLogger.Error(LogMessage.CONVERT_STOP);
                    return false;
                }
                if (!outPath.EndsWith(ServiceResource.ConfigPathEndString))
                {
                    outPath += ServiceResource.ConfigPathEndString;
                }

                backupPath = ConfigurationManager.AppSettings[ServiceResource.ConfigBackupPath];
                if (backupPath == null)
                {
                    ConvertLogger.Error(LogMessage.CONFIG_NO_OUTPUTPATH);
                    SystemLogger.Error(LogMessage.SYS_CONFIG_SYS_NO_GET, ServiceResource.ConfigBackupPath);
                    ConvertLogger.Error(LogMessage.CONVERT_STOP);
                    return false;
                }
                if (!Directory.Exists(backupPath))
                {
                    ConvertLogger.Error(LogMessage.CONFIG_NOT_EXIST_BACKUPPATH);
                    SystemLogger.Error(LogMessage.SYS_CONFIG_ERROR_VALUE, ServiceResource.ConfigBackupPath, backupPath);
                    ConvertLogger.Error(LogMessage.CONVERT_STOP);
                    return false;
                }
                if (!backupPath.EndsWith(ServiceResource.ConfigPathEndString))
                {
                    backupPath += ServiceResource.ConfigPathEndString;
                }

                var tmp = ConfigurationManager.AppSettings["header"];
                if (tmp != null)
                {
                    if (tmp == "0") hadHeader = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex, LogMessage.SYS_CONFIG_EXCEPTION);
                srcPath = null;
                outPath = null;
                backupPath = null;
                hadHeader = true;
                return false;
            }
        }

        private bool ClearOutputDirectory(string targetDirectoryPath, bool deleteBaseDirectory = false)
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
                string[] directoryPaths = Directory.GetDirectories(targetDirectoryPath);
                foreach (string directoryPath in directoryPaths)
                {
                    ClearOutputDirectory(directoryPath, true);
                }
                if (deleteBaseDirectory)
                {
                    Directory.Delete(targetDirectoryPath, false);
                }
                return true;
            }
            catch(Exception ex)
            {
                SystemLogger.Error(ex, LogMessage.SYS_CLEAR_EXCEPTION);
                return false;
            }
        }

        private bool CopyAndReplace(string sourcePath, string copyPath, bool copySubDirectory = true)
        {
            try
            {
                // ClearOutputDirectory(copyPath, true);
                // Directory.CreateDirectory(copyPath);

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

        private bool OutputFileBackup(string sourcePath, string copyPath, bool copySubDirectory = true)
        {
            try
            {
                ClearOutputDirectory(copyPath, true);
                Directory.CreateDirectory(copyPath);

                foreach (var file in Directory.GetFiles(sourcePath))
                {
                    File.Move(file, Path.Combine(copyPath, Path.GetFileName(file)));
                }
                if (copySubDirectory)
                {
                    foreach (var dir in Directory.GetDirectories(sourcePath))
                    {
                        OutputFileBackup(dir, Path.Combine(copyPath, Path.GetFileName(dir)), copySubDirectory);
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

        public bool Conversion()
        {
            SystemLogger.Trace(LogMessage.SYS_CONVERSION_START);
            try
            {
                ConvertLogger.Info(LogMessage.CONVERT_START);
                // 変換対象のファイル格納先を取得
                string searchPath;
                string outputPath;
                string backupPath;
                bool hasHeader;
                if (!GetEnviroment(out searchPath, out outputPath, out backupPath, out hasHeader))
                {
                    return false;
                }

                backupPath += DateTime.Now.ToString(ServiceResource.ConfigBackupPathDateFormat) + ServiceResource.ConfigPathEndString;
                if (!Directory.Exists(backupPath))
                    Directory.CreateDirectory(backupPath);

                var file_list = new FileListup().GetTargetFiles(searchPath);
                if (file_list == null || file_list.Count == 0)
                {
                    ConvertLogger.Warn(LogMessage.NO_TARGET_FILES);
                    ConvertLogger.Info(LogMessage.CONVERT_END);
                    return false;
                }
                ConvertLogger.Info(LogMessage.SHOW_TARGET_FILE_COUNT, file_list.Count);

                // ToDo : 前回ファイルを削除する処理を記述
                ClearOutputDirectory(outputPath);

                var cnvPattern = container.GetInstance<PatternService>();
                foreach(var file in file_list)
                {
                    ConvertLogger.Info(LogMessage.FILE_CONVERSION_START, file);
                    var mode = cnvPattern.GetConvertMode(file);
                    if (mode != ConvertMode.NONE)
                    {
                        ConvertLogger.Info(LogMessage.SHOW_CONVERT_MODE, mode);
                        var keyname = cnvPattern.GetOutputKeyname(file);
                        InputSystem system = (InputSystem)Enum.Parse(typeof(InputSystem), keyname, true);
                        List<IBaseConvertService> cnvSrv = new List<IBaseConvertService>();
                        if (mode.HasFlag(ConvertMode.TORIHIKI))
                        {
                            cnvSrv.Add(container.GetInstance<ConvertTorihikiService>());
                        }
                        if (mode.HasFlag(ConvertMode.ZAIMU))
                        {
                            cnvSrv.Add(container.GetInstance<ConvertZaimuService>());
                        }
                        if (mode.HasFlag(ConvertMode.TEGATA))
                        {
                            cnvSrv.Add(container.GetInstance<ConvertTegataService>());
                        }
                        if (mode.HasFlag(ConvertMode.SAIMU))
                        {
                            cnvSrv.Add(container.GetInstance<ConvertSaimuService>());
                        }
                        if (cnvSrv.Count == 0)
                        {
                            ConvertLogger.Warn(LogMessage.FILE_CONVERSION_NO_PROCESS);
                            continue;
                        }
                        bool convert_end_flag = true;
                        foreach(var item in cnvSrv)
                        {
                            if((convert_end_flag = item.ExecuteConvert(file, system)) == false)
                            {
                                break;
                            }
                        }
                        if (convert_end_flag)
                        {
                            foreach (var item in cnvSrv)
                            {
                                item.WriteFile(backupPath, keyname, hasHeader);
                            }
                            ConvertLogger.Info(LogMessage.FILE_CONVERSION_END);
                        }
                        else
                        {
                            ConvertLogger.Info(LogMessage.FILE_CONVERSION_SAVE_SKIP);
                        }
                    }
                    else
                    {
                        ConvertLogger.Warn(LogMessage.CONVERT_MODE_UNKNOWN, file);
                    }
                }
                ConvertLogger.Info(LogMessage.CONVERT_END);

                // 出力先にファイルを送付
                ConvertLogger.Info(LogMessage.FILE_COPY_START);
                if (!CopyAndReplace(backupPath, outputPath, false))
                {
                    ConvertLogger.Error(LogMessage.FILE_COPY_ABORT);
                    return false;
                }
                ConvertLogger.Info(LogMessage.FILE_COPY_END);
                return true;
            }
            catch (Exception ex)
            {
                SystemLogger.Log(LogLevel.Fatal, ex, LogMessage.SYS_CONVERSION_EXCEPTION);
                ConvertLogger.Fatal(LogMessage.CONVERT_FATAL_ERROR);
                return false;
            }
        }

        public void Dispose()
        {
            container.Dispose();
            container = null;
        }
    }
}
