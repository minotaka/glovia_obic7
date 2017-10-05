using glovia_obic7.Models;
using glovia_obic7.Repositories;
using glovia_obic7.Resources;
using System;
using System.Collections.Generic;

namespace glovia_obic7.Services
{
    public class ConvertTorihikiService : BaseConvertService, IBaseConvertService
    {
        private List<Obic7Torihiki> resultlist = null;

        public ConvertTorihikiService(ILocalTableRepository repository, ISupportRepository support) : base(repository, support)
        {
            mode = ServiceResource.TORIHIKI;
        }

        private bool ConvertProcess(List<GloviaTorihikisakiModel> gloviadata, out List<Obic7Torihiki> list)
        {
            try
            {
                list = new List<Obic7Torihiki>();
                foreach (var item in gloviadata)
                {
                    var result = new Obic7Torihiki();
                    // 1.取引先コード
                    result.Code = support.StringToString(item.Code, 10);
                    // 2.取引先コード改定日
                    result.ModifiedDate = DateTime.ParseExact(item.FromDate, ServiceResource.ConvertGloviaDateFormat, null);
                    // 3.取引先正式名１
                    result.Name1 = item.Name;
                    // 6.社内用取引先名
                    result.NickName = item.ShortName;
                    // 7.取引先略称
                    result.ShortName = item.ShortName;
                    // 9.10.取引先郵便番号
                    if (!string.IsNullOrWhiteSpace(item.ZipCode1) && string.IsNullOrWhiteSpace(item.ZipCode2))
                    {
                        result.ZipCode1 = item.ZipCode1;
                        result.ZipCode2 = item.ZipCode2;
                    }
                    else
                    {
                        result.ZipCode1 = null;
                        result.ZipCode2 = null;
                    }
                    list.Add(result);
                }
                return true;
            }
            catch(Exception ex)
            {
                list = null;
                SystemLogger.Error(ex, LogMessage.SYS_MODE_CONVERSION_EXCEPTION, mode);
                throw ex;
            }
        }

        public bool ExecuteConvert(string filename, InputSystem system)
        {
            CConvertLogger.SetMode(mode);
            try
            {
                CConvertLogger.Info(LogMessage.MODE_CONVERT_START, mode, filename);
                if (!PreProcess<GloviaTorihikisakiModel>(filename, out List<GloviaTorihikisakiModel> gloviadata))
                {
                    CConvertLogger.Info(LogMessage.MODE_CONVERT_SKIP, filename);
                    return false;
                }
                if (ConvertProcess(gloviadata, out resultlist) == false)
                {
                    return false;
                }

                CConvertLogger.Info(LogMessage.MODE_CONVERT_END, mode, filename);
                return true;
            }
            catch (Exception ex)
            {
                CConvertLogger.Error(LogMessage.MODE_CONVERT_EXCEPTION);
                SystemLogger.Error(ex, LogMessage.SYS_MODE_CONVERSION_EXCEPTION, mode);
                return false;
            }
        }

        public bool WriteFile(string output_path, string keyname, bool hasHeader)
        {
             return WriteFile<Obic7TorihikiMap>(output_path, keyname, resultlist, hasHeader);
        }
    }
}
