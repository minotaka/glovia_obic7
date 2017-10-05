using glovia_obic7.Repositories;
using glovia_obic7.Resources;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace glovia_obic7.Services
{
    public class PatternService : BaseService
    {
        private ILocalTableRepository repository;

        public PatternService(ILocalTableRepository repository)
        {
            this.repository = repository;
        }

        public ConvertMode GetConvertMode(string filename)
        {
            try
            {
                filename = Path.GetFileName(filename);
                ConvertMode typeCode = ConvertMode.NONE;
                if (repository.GetConvertTypeCode(filename, 1) == 1)
                {
                    typeCode = typeCode | ConvertMode.ZAIMU;
                }
                if (repository.GetConvertTypeCode(filename, 2) == 1)
                {
                    typeCode = typeCode | ConvertMode.SAIMU;
                }
                if (repository.GetConvertTypeCode(filename, 3) == 1)
                {
                    typeCode = typeCode | ConvertMode.TEGATA;
                }
                if (repository.GetConvertTypeCode(filename, 4) == 1)
                {
                    typeCode = typeCode | ConvertMode.TORIHIKI;
                }
                return typeCode;
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return ConvertMode.NONE;
            }
        }

        public string GetOutputKeyname(string filename)
        {
            try
            {
                var keyname = Path.GetFileNameWithoutExtension(filename);
                keyname = keyname.Replace(ServiceResource.Prefix_ARCANE, ServiceResource.Prefix_REPLACE)
                    .Replace(ServiceResource.Prefix_JFLA, ServiceResource.Prefix_REPLACE);
                return keyname;
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return null;
            }
        }

        protected bool HasCompanyCode(string code)
        {
            try
            {
                int baseCode;
                if (int.TryParse(code, out baseCode))
                {
                    var result = repository.GetCompanyKbn(baseCode);
                    if (string.IsNullOrEmpty(result))
                    {
                        return false;
                    }
                    return true;
                }
                throw new ArgumentException(ServiceResource.ParamaterName_Code);
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return false;
            }
        }
    }
}
