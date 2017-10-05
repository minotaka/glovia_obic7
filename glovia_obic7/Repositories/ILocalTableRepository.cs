using System;
using System.Data;
using System.Data.SQLite;

namespace glovia_obic7.Repositories
{
    public interface ILocalTableRepository : IDisposable
    {
        SQLiteDataReader GetCompany();
        DataTable GetCompanyForDatatable();
        int GetCompanyCode(int baseCode);
        string GetCompanyKbn(int baseCode);
        bool IsCompanyCode(string code);

        SQLiteDataReader GetConvertCode();
        DataTable GetConvertCodeForDatatable();
        string GetConvertCodeCode(string key);

        SQLiteDataReader GetConvertType();
        DataTable GetConvertTypeForDatatable();
        int GetConvertTypeCode(string key, int mode);
        int GetSystemCodeCode(string key);

        bool IsTorihikiByCode(string key);
        int IsHojoByCode(string key);

        int GetDenpyoKindCodeByAccount(string payable);
        int GetSaimuTorihikiKbnCode(string expence, string payable);
    }
}
