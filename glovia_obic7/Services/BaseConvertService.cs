using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using glovia_obic7.Models;
using glovia_obic7.Repositories;
using glovia_obic7.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovia_obic7.Services
{
    public class BaseConvertService : BaseService
    {
        protected ILocalTableRepository repository;
        protected ISupportRepository support;
        protected string mode = null;
        protected string companycode = null;

        public BaseConvertService() { }

        public BaseConvertService(ILocalTableRepository repository, ISupportRepository support)
        {
            this.repository = repository;
            this.support = support;
        }

        protected virtual bool PreProcess<T>(string filename, out List<T> gloviadata) where T : IGloviaModel, new()
        {
            try
            {
                gloviadata = support.ReadGlovia<T>(filename);
                if (gloviadata == null)
                {
                    CConvertLogger.Error(LogMessage.MODE_SOURCEFILE_UNREAD);
                    return false;
                }
                if (gloviadata.Count == 0)
                {
                    gloviadata.Clear();
                    CConvertLogger.Warn(LogMessage.MODE_SOURCEFILE_ENPTY);
                    return false;
                }

                if (!repository.IsCompanyCode(gloviadata[0].CompanyCode))
                {
                    CConvertLogger.Error(LogMessage.MODE_UNKNOWN_COMPANY_CODE, gloviadata[0].CompanyCode);
                    return false;
                }
                companycode = gloviadata[0].CompanyCode;
                return true;
            }
            catch (Exception ex)
            {
                gloviadata = null;
                SystemLogger.Error(ex, LogMessage.SYS_MODE_CONVERSION_EXCEPTION, mode);
                throw ex;
            }
        }

        protected bool WriteFile<T>(string output_path, string keyname, IList recoreds, bool forceOverride = false, bool hasHeader = true) where T : CsvClassMap
        {
            CConvertLogger.SetMode(mode);
            try
            {
                var csvname = String.Format(ServiceResource.OutputfileTemplate, output_path, companycode, keyname);
                var options = new TypeConverterOptions { Format = ServiceResource.OutputDateFormat, };
                TypeConverterOptionsFactory.AddOptions<DateTime>(options);
                bool append = false;

                if (recoreds.Count > 0)
                {
                    if (File.Exists(csvname) && !forceOverride)
                    {
                        append = true;
                    }

                    using (var writer = new StreamWriter(csvname, append, Encoding.GetEncoding(ServiceResource.OutputStreamEncod)))
                    using (var csv = new CsvWriter(writer))
                    {
                        csv.Configuration.Encoding = Encoding.GetEncoding(ServiceResource.OutputEncod);
                        if (append || !hasHeader)
                        {
                            csv.Configuration.HasHeaderRecord = false;
                        }
                        else
                        {
                            csv.Configuration.HasHeaderRecord = true;
                        }
                        csv.Configuration.RegisterClassMap<T>();
                        csv.WriteRecords(recoreds);
                    }
                    CConvertLogger.Info(LogMessage.MODE_WRITE_SUCCESS, csvname);
                }
                else
                {
                    CConvertLogger.Info(LogMessage.MODE_WRITE_EMPTY, csvname);
                }

                return true;
            }
            catch (Exception ex)
            {
                CConvertLogger.Error(LogMessage.MODE_WRITE_EXCEPTION);
                SystemLogger.Error(ex, LogMessage.SYS_MODE_WRITE_EXCEPTION, mode);
                return false;
            }
        }

        protected string MakeBaseDenpyoNo(int baseCompanyCode, string filename)
        {
            string companyKbn = repository.GetCompanyKbn(baseCompanyCode);
            filename = Path.GetFileName(filename);
            string kindKbn = repository.GetConvertCodeCode(filename);
            return companyKbn + DateTime.Now.ToString("yyMMdd") + kindKbn;
        }

        protected virtual int GetSiwakeMode(List<GloviaIppanModel> gloviadata, int inputNo, string voucherComment)
        {
            var lists = gloviadata.Where(x => x.InpputNo == inputNo).Where(x => x.VoucherComment == voucherComment).ToList();
            var leftCount = lists.Where(x => x.DebitCredit == "0").Count();
            var rightCount = lists.Where(x => x.DebitCredit == "1").Count();
            if (leftCount == 1 && rightCount == 1)
            {
                return 0;
            }
            return 1;
        }
    }
}
