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
    public class ConvertSaimuService : BaseConvertService, IBaseConvertService
    {
        private List<Obic7Saimu> resultlist = null;
        private string denpyoNoBase = null;
        private int companyCode = 0;

        public ConvertSaimuService(ILocalTableRepository repository, ISupportRepository support) : base(repository, support)
        {
            mode = ServiceResource.SAIMU;
        }

        private void HeadCopy(Obic7Saimu result, Obic7Saimu predata)
        {
            result.CompanyCode = predata.CompanyCode;
            result.SystemCategory = predata.SystemCategory;
            result.UkeireDataKbn = predata.UkeireDataKbn;
            result.HeadInputJigyoshoCode = predata.HeadInputJigyoshoCode;
            result.HeadDenpyoCode = predata.HeadDenpyoCode;
            result.HeadDate = predata.HeadDate;
            result.SubsystemDenpyoNo = predata.SubsystemDenpyoNo;
            result.HeadManageJigyoshoCode = predata.HeadManageJigyoshoCode;
            result.HeadManageBumonCode = predata.HeadManageBumonCode;
            result.HeadPaymentJigyoshoCode = predata.HeadPaymentJigyoshoCode;
            result.HeadPaymentBumonCode = predata.HeadPaymentBumonCode;
            result.HeadSupplierCode = predata.HeadSupplierCode;
            result.HeadSupplierSpotKbn = predata.HeadSupplierSpotKbn;
            result.HeadTantoCode = predata.HeadTantoCode;
            result.HeadNohinDate = predata.HeadNohinDate;
            result.HeadNohinNo = predata.HeadNohinNo;
            result.HeadSimeKbn = predata.HeadSimeKbn;
            result.HeadPaymentTermCode = predata.HeadPaymentTermCode;
            result.HeadSimeDate = predata.HeadSimeDate;
            result.HeadPaymentDate = predata.HeadPaymentDate;
            result.HeadComment = predata.HeadComment;
            result.HeadPaymentAccountCode = predata.HeadPaymentAccountCode;
            result.HeadAccoutSelectKbn = predata.HeadAccoutSelectKbn;
            result.HeadHojoKamokuCode = predata.HeadHojoKamokuCode;
            result.HeadHojoUchiwakeCode = predata.HeadHojoUchiwakeCode;
        }

        private bool ConvertProcess(List<GloviaIppanModel> gloviadata, out List<Obic7Saimu> list, InputSystem system)
        {
            try
            {
                int systemCode = repository.GetSystemCodeCode(gloviadata[0].InpputSystem);
                if (systemCode < 0)
                {
                    list = null;
                    return false;
                }
                // ToDo:算出外部化
                // システム分類を２１とする
                systemCode = 21;

                int counter = 0;
                int currentInputNo = -1;
                string currentVoucherComment = string.Empty;
                string currentDenpyoNo = string.Empty;
                string baseAccountCode = string.Empty;

                list = new List<Obic7Saimu>();
                CConvertLogger.Info("会社コード={0} 伝票番号基準={1}", companyCode, denpyoNoBase);
                foreach (var item in gloviadata)
                {
                    if (currentInputNo != item.InpputNo)
                    {
                        counter++;
                        currentInputNo = item.InpputNo;
                        currentVoucherComment = item.VoucherComment;
                        // currentDenpyoNo = denpyoNoBase + counter.ToString("X4");
                        currentDenpyoNo = item.InpputNo.ToString();
                        CConvertLogger.Trace("入力番号={0} 伝票備考={1}", currentInputNo, currentVoucherComment);
                        CConvertLogger.Debug("伝票番号={0}", currentDenpyoNo);
                    }

                    // 更新サブシステムが２以外は一律スキップ
                    if (item.UpdateSubsystem != "2")
                        continue;

                    int cRow = support.StringToInteger(item.Rows);

                    // 142100(仮払消費税)＋２行目以降のの場合、スキップ
                    if (item.AccountTitleCode == "142100" && cRow > 1)
                        continue;

                    Obic7Saimu result;
                    RecordMode recordMode = RecordMode.APPEND;
                    result = list.Where(x => x.SubsystemDenpyoNo == currentDenpyoNo).Where(x => x.Rows == cRow).SingleOrDefault();
                    if (result == null)
                    {
                        result = new Obic7Saimu();
                        recordMode = RecordMode.NEW;
                    }
                    if(item.DebitCredit == "1")
                    {
                        // 基準の勘定科目を保管
                        baseAccountCode = item.AccountTitleCode;

                        // 1.会社コード
                        result.CompanyCode = companyCode;
                        // 2.システム分類
                        result.SystemCategory = systemCode;
                        // 3.受入データ区分
                        result.UkeireDataKbn = 1;
                        // 4.HEAD入力事業所コード
                        result.HeadInputJigyoshoCode = "1";
                        // 5.HEAD伝票種別コード(仕様不明)
                        result.HeadDenpyoCode = repository.GetDenpyoKindCodeByAccount(item.AccountTitleCode);
                        // 6.HEAD発生日(仕様不明)
                        result.HeadDate = DateTime.ParseExact(item.VoucherDate, "yyyyMMdd", null);
                        // 7.サブシステム伝票番号(仕様不明)
                        result.SubsystemDenpyoNo = currentInputNo.ToString();
                        // 8.HEAD債務管理事業所コード
                        result.HeadManageJigyoshoCode = "1";
                        // 9.HEAD債務管理部門コード(仕様不明)
                        result.HeadManageBumonCode = item.InputDepartmentCode;
                        // 10.HEAD支払事業所コード
                        result.HeadPaymentJigyoshoCode = "1";
                        // 11.HEAD支払部門コード(仕様不明)
                        result.HeadPaymentBumonCode = item.AccountDepartmentCode;
                        // 12.HEAD仕入先コード(仕様不明)
                        result.HeadSupplierCode = item.CustomerCode;
                        // 13.HEAD仕入先スポット区分
                        result.HeadSupplierSpotKbn = 0;
                        // 14.HEAD担当者コード
                        result.HeadTantoCode = null;
                        // 15.HEAD納品書日付
                        result.HeadNohinDate = null;
                        // 16.HEAD納品書番号
                        result.HeadNohinNo = null;
                        // 17.HEAD都度締区分
                        result.HeadSimeKbn = 0;
                        // 18.HEAD決済条件コード
                        result.HeadPaymentTermCode = null;
                        // 19.HEAD締日
                        result.HeadSimeDate = null;
                        // 20.HEAD支払予定日
                        result.HeadPaymentDate = null;
                        // 21.HEAD摘要
                        result.HeadComment = null;
                        // 22.HEAD支払決済口座コード
                        result.HeadPaymentAccountCode = 1;
                        // 23.HEAD振込口座選択区分
                        result.HeadAccoutSelectKbn = null;
                        // 24.HEAD補助科目コード(仕様不明)
                        result.HeadHojoKamokuCode = "";
                        // 25.HEAD補助内訳科目コード(仕様不明)
                        result.HeadHojoUchiwakeCode = "";
                        // xx.HEAD分析コード1
                        // xx.HEAD分析コード2
                        // xx.HEAD分析コード3
                        // xx.HEAD分析コード4
                        // xx.HEAD分析コード5
                        // xx.HEAD資金コード
                        // xx.HEADプロジェクトコード
                        // xx.HEAD源泉税預り金計算対象区分
                        // xx.HEAD源泉税コード
                        // xx.HEAD源泉税預り金
                        // xx.HEAD源泉税分析コード1
                        // xx.HEAD源泉税分析コード2
                        // xx.HEAD源泉税分析コード3
                        // xx.HEAD源泉税分析コード4
                        // xx.HEAD源泉税分析コード5
                        // xx.HEAD源泉税資金コード
                        // xx.HEAD源泉税プロジェクトコード
                        // 43.行番号(仕様不明)
                        result.Rows = cRow;
                    }
                    else if (item.DebitCredit == "0")
                    {
                        if (cRow > 1)
                        {
                            var predata = list.Where(x => x.SubsystemDenpyoNo == currentDenpyoNo).Where(x => x.Rows == (cRow-1)).SingleOrDefault();
                            if (predata != null)
                                HeadCopy(result, predata);
                        }
                        // 43.行番号(仕様不明)
                        result.Rows = cRow;
                        // 44.明細債務データ取引区分コード(仕様不明)
                        result.DataKbnCode = repository.GetSaimuTorihikiKbnCode(item.AccountTitleCode, baseAccountCode);
                        // 45.明細事業所コード
                        result.JigyoshoCode = "1";
                        // 46.明細部門コード(仕様不明)
                        result.BumonCode = item.AccountDepartmentCode;
                        // 47.明細補助科目コード(仕様不明)
                        result.HojoKamokuCode = "";
                        // 48.明細補助内訳科目コード(仕様不明)
                        result.HojoUchiwakeCode = "";
                        // 49.明細税区分(仕様不明)
                        result.TaxKbn = "71";
                        // 50.明細税込区分(仕様不明)
                        result.TaxationKbn = 3;
                        // xx.明細分析コード1
                        // xx.明細分析コード2
                        // xx.明細分析コード3
                        // xx.明細分析コード4
                        // xx.明細分析コード5
                        // xx.明細資金コード
                        // xx.明細プロジェクトコード
                        // xx.明細消費税本体科目コード
                        // xx.明細品コード
                        // xx.明細品名
                        // xx.明細規格
                        // xx.明細単位コード
                        // xx.明細単位名
                        // xx.明細数量
                        // xx.明細単価
                        // xx.明細ロットNO
                        // 67.明細摘要(仕様不明)
                        result.Comment = item.Remarks1;
                        // 68.明細金額(仕様不明)
                        result.Amount = support.GamountToDecimal(item.BaseAmount);
                        // 69.明細外税消費税(仕様不明)
                        result.ExclusiveTaxAmount = support.GamountToDecimal(item.ReferenceTaxAmount);
                        // xx.明細うち消費税
                        // xx.取引先正式名1
                        // xx.取引先正式名2
                        // xx.取引先部署名
                        // xx.社内用取引先名
                        // xx.取引先略名
                        // xx.取引先フリガナ
                        // xx.取引先郵便番号1（上3桁）
                        // xx.取引先郵便番号2（下4桁）
                        // xx.取引先住所1
                        // xx.取引先住所2
                        // xx.取引先住所3
                        // xx.取引先電話番号1市外局番
                        // xx.取引先電話番号1市内局番
                        // xx.取引先電話番号1
                        // xx.取引先内線番号1
                        // xx.取引先電話番号2市外局番
                        // xx.取引先電話番号2市内局番
                        // xx.取引先電話番号2
                        // xx.取引先内線番号2
                        // xx.取引先FAX番号市外局番
                        // xx.取引先FAX番号市内局番
                        // xx.取引先FAX番号
                        // xx.取引先担当部署名
                        // xx.取引先担当役職名
                        // xx.取引先担当者名
                        // xx.メールアドレス
                        // xx.郵送先住所区分
                        // xx.郵送先正式名1
                        // xx.郵送先正式名2
                        // xx.郵便番号1（上3桁）
                        // xx.郵便番号2（下4桁）
                        // xx.郵送先住所1
                        // xx.郵送先住所2
                        // xx.郵送先住所3
                        // xx.郵送先電話番号市外局番
                        // xx.郵送先電話番号市内局番
                        // xx.郵送先電話番号
                        // xx.郵送先内線番号
                        // xx.郵送先FAX番号市外局番
                        // xx.郵送先FAX番号市内局番
                        // xx.郵送先FAX電話番号
                        // xx.郵送先担当部署名
                        // xx.郵送先担当者名
                        // xx.振込先銀行コード
                        // xx.振込先銀行支店コード
                        // xx.預金種別区分
                        // xx.口座番号
                        // xx.口座名義人カナ
                        // xx.手数料負担区分
                        // xx.休日処理区分
                        // xx.サイト計算区分
                        // xx.サイト
                        // xx.サイト月数
                        // xx.サイト日数
                    }
                    if (recordMode == RecordMode.NEW)
                    {
                        list.Add(result);
                    }
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

                gloviadata = gloviadata.OrderBy(gd => gd.InpputNo).ThenByDescending(gd => gd.DebitCredit).ThenBy(gd => gd.Rows).ToList();
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
            return WriteFile<Obic7SaimuMap>(output_path, keyname, resultlist, false, hasHeader);
        }
    }
}
