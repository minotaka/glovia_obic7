using glovia_obic7.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace glovia_obic7.Repositories
{
    class LocalTableRepository : BaseRepository, ILocalTableRepository
    {
        private DataContext context = null;

        public LocalTableRepository()
        {
            if (context == null) context = DataContext.Create();
        }

        public SQLiteDataReader GetCompany()
        {
            try
            {
                return context.ExecuteQuery(SqliteResource.SqlGetCompanyList);
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                throw ex;
            }
        }

        public DataTable GetCompanyForDatatable()
        {
            try
            {
                return context.ExecuteQueryForDataTable(SqliteResource.SqlGetCompanyList);
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                throw ex;
            }
        }

        public int GetCompanyCode(int baseCode)
        {
            try
            {
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetCompanyCodeByBase, baseCode);
                if (result.Rows.Count == 0)
                {
                    return -1;
                }
                else
                {
                    var str = result.Rows[0][0].ToString();
                    int ret;
                    if (int.TryParse(str, out ret))
                    {
                        return ret;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return -1;
            }
        }

        public string GetCompanyKbn(int baseCode)
        {
            try
            {
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetCompanyKbnByBase, baseCode);
                if (result.Rows.Count == 0)
                {
                    return string.Empty;
                }
                else
                {
                    return result.Rows[0][0].ToString();
                }
           }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return string.Empty;
            }
        }

        public bool IsCompanyCode(string code)
        {
            int companyCode = 0;
            if (int.TryParse(code, out companyCode))
            {
                if (GetCompanyCode(companyCode) >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public SQLiteDataReader GetConvertCode()
        {
            try
            {
                return context.ExecuteQuery(SqliteResource.SqlGetConvertList);
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                throw ex;
            }
        }

        public DataTable GetConvertCodeForDatatable()
        {
            try
            {
                return context.ExecuteQueryForDataTable(SqliteResource.SqlGetConvertList);
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                throw ex;
            }
        }

        public string GetConvertCodeCode(string key)
        {
            try
            {
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetConvertCodeCodeByKey, key);
                if (result.Rows.Count == 0)
                {
                    return string.Empty;
                }
                else
                {
                    return result.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return string.Empty;
            }
        }

        public SQLiteDataReader GetConvertType()
        {
            try
            {
                return context.ExecuteQuery(SqliteResource.SqlGetConvertTypeList);
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                throw ex;
            }
        }

        public DataTable GetConvertTypeForDatatable()
        {
            try
            {
                return context.ExecuteQueryForDataTable(SqliteResource.SqlGetConvertTypeList);
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                throw ex;
            }
        }

        public int GetConvertTypeCode(string key, int mode)
        {
            try
            {
                if (mode <= 0 || mode > 4)
                {
                    throw new ArgumentOutOfRangeException("mode");
                }
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetConvertTypeByKey, key);
                if (result.Rows.Count == 0)
                {
                    return -1;
                }
                else
                {
                    var str = result.Rows[0][mode].ToString();
                    int ret;
                    if (int.TryParse(str, out ret))
                    {
                        return ret;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return -1;
            }
        }

        public int GetSystemCodeCode(string key)
        {
            try
            {
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetSystemCodeByKey, key);
                if (result.Rows.Count == 0)
                {
                    return -1;
                }
                else
                {
                    var str = result.Rows[0][0].ToString();
                    int ret;
                    if (int.TryParse(str, out ret))
                    {
                        return ret;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return -1;
            }
        }

        public bool IsTorihikiByCode(string key)
        {
            try
            {
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlIsTorihikiByCode, key);
                if (result.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return false;
            }
        }

        public int IsHojoByCode(string key)
        {
            try
            {
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlIsHojoByCode, key);
                if (result.Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    int ret;
                    if (int.TryParse(result.Rows[0][0].ToString(), out ret))
                    {
                        return ret;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return 0;
            }
        }

        public int GetDenpyoKindCodeByAccount(string payable)
        {
            try
            {
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetDenpyoKindCodeByAccount, payable);
                if (result.Rows.Count == 0)
                {
                    result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetDenpyoKindCodeDefault);
                }
                int ret;
                if (int.TryParse(result.Rows[0][0].ToString(), out ret))
                {
                    return ret;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return 0;
            }
        }

        public int GetSaimuTorihikiKbnCode(string expence, string payable)
        {
            try
            {
                var result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetSaimuTorihikiKbnCode, expence, payable);
                if (result.Rows.Count == 0)
                {
                    result = context.ExecuteQueryForDataTable(SqliteResource.SqlGetSaimuTorihikiKbnCodeDefault);
                }
                int ret;
                if (int.TryParse(result.Rows[0][0].ToString(), out ret))
                {
                    return ret;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return 0;
            }
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Disconnect();
                context = null;
            }
        }
    }
}
