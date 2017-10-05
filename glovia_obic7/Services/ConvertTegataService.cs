using glovia_obic7.Models;
using glovia_obic7.Repositories;
using glovia_obic7.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glovia_obic7.Services
{
    public class ConvertTegataService : BaseConvertService, IBaseConvertService
    {
        private List<Obic7Bill> resultlist = null;
        private string denpyoNoBase = null;
        private int companyCode = 0;

        public ConvertTegataService(ILocalTableRepository repository, ISupportRepository support) : base(repository, support)
        {
            mode = ServiceResource.TEGATA;
        }

        private bool ConvertProcess(List<GloviaIppanModel> gloviadata, out List<Obic7Bill> list, InputSystem system)
        {
            try
            {
                list = new List<Obic7Bill>();
                foreach (var item in gloviadata)
                {
                    // 暫定：手形番号が無い場合はスキップ
                    if (string.IsNullOrEmpty(item.NotesNo))
                    {
                        continue;
                    }

                    var result = new Obic7Bill();
                    // 1.管理番号(仕様不明)
                    result.ManageNumber = item.InpputNo;
                    // 2.枝番
                    result.BranchNumber = 0;
                    // 3.手形番号(仕様不明)
                    result.BillNumber = item.NotesNo;
                    // 4.手形区分
                    result.BillKbn = 1;
                    // 5.仮収納区分(仕様不明)
                    result.TemporalyReceivedKbn = 1;
                    // 6.手形種別コード(仕様不明)
                    if (string.IsNullOrEmpty(item.NotesCategory))
                    {
                        result.BillKindCode = "3";
                    }
                    else
                    {
                        result.BillKindCode = item.NotesCategory;
                    }
                    // 7.手形分類コード
                    result.BillTypeCode = "";
                    // 8.振出区分
                    result.FuridashiKbn = 2;
                    // 9.発行区分
                    result.IssueKbn = 0;
                    // 10.受取人名
                    result.ReciveName = null;
                    // 11.取引先コード
                    result.TorihikiCode = item.CustomerCode;
                    // 12.取引先名
                    // 13.振出人名
                    // 14.振出人住所1
                    // 15.振出人住所2
                    // 16.振出人代表者役職
                    // 17.振出人代表者氏名
                    // 18.取扱銀行コード
                    // 19.支払地
                    // 20.支払銀行コード(仕様不明)
                    if (item.PaymentBankCode.Length >= 4)
                    {
                        result.PaymentBankCode = item.PaymentBankCode.Substring(0, 4);
                    }
                    else
                    {
                        result.PaymentBankCode = "";
                    }
                    // 21.支払銀行支店コード
                    if (item.PaymentBankCode.Length >= 7)
                    {
                        result.PaymentBankBranchCode = item.PaymentBankCode.Substring(4, 3);
                    }
                    else
                    {
                        result.PaymentBankBranchCode = "";
                    }
                    // 22.支払銀行支払地
                    // 23.手形金額(仕様不明)
                    result.BillAmount = support.GamountToDecimal(item.BaseAmount);
                    // 24.支払日
                    // 25.受取日(仕様不明)
                    result.RecivedDate = DateTime.ParseExact(item.VoucherDate, "yyyyMMdd", null);
                    // 26.振出日(仕様不明)
                    result.FuridashiDate = DateTime.ParseExact(item.NotesClosingDate, "yyyyMMdd", null);
                    // 27.満期日(仕様不明)
                    result.MankiDate = DateTime.ParseExact(item.NotesClosingDate, "yyyyMMdd", null);
                    // 28.決済日
                    // 29.休日区分(仕様不明)
                    result.HolidayKbn = 0;
                    // 30.手形裏書区分
                    // 31.記載事項
                    // 32.裏書禁止フラグ
                    // 33.手形摘要
                    // 34.手形仕訳区分
                    // 35.管理事業所コード
                    // 36.管理部門コード(仕様不明)
                    result.BumonCode = item.AccountDepartmentCode;
                    // 37.借方決済分析コード1
                    // 38.借方決済分析コード2
                    // 39.借方決済分析コード3
                    // 40.借方決済分析コード4
                    // 41.借方決済分析コード5
                    // 42.借方決済資金コード
                    // 43.借方決済プロジェクトコード
                    // 44.貸方決済分析コード1
                    // 45.貸方決済分析コード2
                    // 46.貸方決済分析コード3
                    // 47.貸方決済分析コード4
                    // 48.貸方決済分析コード5
                    // 49.貸方決済資金コード
                    // 50.貸方決済プロジェクトコード
                    // 51.借方計上事業所コード
                    // 52.借方計上部門コード
                    // 53.借方総勘定科目コード
                    // 54.借方補助科目コード
                    // 55.借方補助内訳科目コード
                    // 56.借方分析コード1
                    // 57.借方分析コード2
                    // 58.借方分析コード3
                    // 59.借方分析コード4
                    // 60.借方分析コード5
                    // 61.借方資金コード
                    // 62.借方プロジェクトコード
                    // 63.借方取引先コード
                    // 64.借方税区分
                    // 65.借方税込区分
                    // 66.借方金額
                    // 67.借方消費税額
                    // 68.借方消費税本体科目コード
                    // 69.貸方計上事業所コード
                    // 70.貸方計上部門コード
                    // 71.貸方総勘定科目コード
                    // 72.貸方補助科目コード
                    // 73.貸方補助内訳科目コード
                    // 74.貸方分析コード1
                    // 75.貸方分析コード2
                    // 76.貸方分析コード3
                    // 77.貸方分析コード4
                    // 78.貸方分析コード5
                    // 79.貸方資金コード
                    // 80.貸方プロジェクトコード
                    // 81.貸方取引先コード
                    // 82.貸方税区分
                    // 83.貸方税込区分
                    // 84.貸方金額
                    // 85.貸方消費税額
                    // 86.貸方消費税本体科目コード
                    // 87.控除区分
                    // 88.引受人コード
                    // 89.引受人名
                    // 90.引受人住所1
                    // 91.引受人住所2
                    // 92.引受人代表者役職
                    // 93.引受人代表者氏名
                    // 94.記録機関
                    // 95.口座情報コード
                    // 96.支払預金種目
                    // 97.支払預金口座
                    list.Add(result);
                }
                return true;
            }
            catch (Exception ex)
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
                if (!PreProcess(filename, out List<GloviaIppanModel> gloviadata))
                {
                    CConvertLogger.Info(LogMessage.MODE_CONVERT_SKIP, filename);
                    return false;
                }

                int baseCompanyCode = support.StringToInteger(gloviadata[0].CompanyCode);
                companyCode = repository.GetCompanyCode(baseCompanyCode);
                denpyoNoBase = MakeBaseDenpyoNo(baseCompanyCode, filename);
                if (ConvertProcess(gloviadata, out resultlist, system) == false)
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
            return WriteFile<Obic7BillMap>(output_path, "TEGATA", resultlist, false, hasHeader);
        }
    }
}
