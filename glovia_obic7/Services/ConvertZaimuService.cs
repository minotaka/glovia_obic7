using glovia_obic7.Models;
using glovia_obic7.Repositories;
using glovia_obic7.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace glovia_obic7.Services
{
    public class ConvertZaimuService : BaseConvertService, IBaseConvertService
    {
        private List<Obic7Zaimu> resultlist = null;
        private string denpyoNoBase = null;
        private int companyCode = 0;

        public ConvertZaimuService(ILocalTableRepository repository, ISupportRepository support) : base(repository, support)
        {
            mode = ServiceResource.ZAIMU;
        }

        private bool ConvertProcess(List<GloviaIppanModel> gloviadata, out List<Obic7Zaimu> list, InputSystem system)
        {
            try
            {
                int systemCode = repository.GetSystemCodeCode(gloviadata[0].InpputSystem);
                if (systemCode < 0)
                {
                    list = null;
                    return false;
                }

                int counter = 0;
                int currentInputNo = -1;
                string currentVoucherComment = string.Empty;
                int currentSiwakeMode = 0;
                string currentDenpyoNo = string.Empty;

                list = new List<Obic7Zaimu>();
                CConvertLogger.Info("会社コード={0} 伝票番号基準={1}", companyCode, denpyoNoBase);
                foreach (var item in gloviadata)
                {
                    if (currentInputNo != item.InpputNo)
                    {
                        counter++;
                        currentInputNo = item.InpputNo;
                        currentVoucherComment = item.VoucherComment;
                        // ToDo : 仕訳モードで勘定科目スキップの考慮を設ける
                        currentSiwakeMode = GetSiwakeMode(gloviadata, currentInputNo, currentVoucherComment);
                        // currentDenpyoNo = denpyoNoBase + counter.ToString("X4");
                        currentDenpyoNo = item.InpputNo.ToString();
                        CConvertLogger.Trace("入力番号={0} 伝票備考={1}", currentInputNo, currentVoucherComment);
                        CConvertLogger.Debug("仕訳区分={0} 伝票番号={1}", currentSiwakeMode, currentDenpyoNo);
                    }

                    int cRow = support.StringToInteger(item.Rows);

                    // URI(418100:仮受消費税)＋複合仕訳の場合、スキップ
                    // if (system == InputSystem.URI && item.AccountTitleCode == "418100" && currentSiwakeMode==1)
                    // URI(418100:仮受消費税)＋２行目以降のの場合、スキップ
                    if (system == InputSystem.URI && item.AccountTitleCode == "418100" && cRow>1)
                        continue;

                    // NYU(142100:仮払消費税)＋２行目以降のの場合、スキップ
                    if (system == InputSystem.NYUU && item.AccountTitleCode == "142100" && cRow > 1)
                        continue;

                    Obic7Zaimu result;
                    RecordMode recordMode = RecordMode.APPEND;
                    result = list.Where(x => x.DenpyoNo == currentDenpyoNo).Where(x => x.Rows == cRow).SingleOrDefault();
                    if (result == null)
                    {
                        result = new Obic7Zaimu();
                        recordMode = RecordMode.NEW;
                    }

                    if (recordMode == RecordMode.NEW)
                    {
                        // 1.会社コード
                        result.CompanyCode = companyCode;
                        // 2.伝票ＮＯ
                        result.DenpyoNo = item.InpputNo.ToString();
                        // 3.発生日
                        result.DenpyoDate = DateTime.ParseExact(item.VoucherDate, "yyyyMMdd", null);
                        // 4.システム分類
                        result.SystemCategory = systemCode;
                        // 5.サイト
                        result.Site = null;
                        // 6.仕訳区分
                        result.SiwakeKbn = currentSiwakeMode;
                        // 7.伝票区分
                        result.DenpyoKbn = "10";
                        // 8.事業所コード
                        result.JigyoshoCode = "1";
                        // 9.行ＮＯ
                        result.Rows = support.StringToInteger(item.Rows);
                        // 44.明細摘要
                        result.MeisaiComment = support.StringToString(item.Remarks1, 60);
                        // 45.伝票摘要
                        result.DenpyoComment = support.StringToString(item.VoucherComment, 60);
                        // 46.UserId
                        result.UserId = null;
                        // 47.借方事業所コード
                        result.KariJigyoshoCode = null;
                        // 48.貸方事業所コード
                        result.KashiiJigyoshoCode = null;
                    }
                    if (item.DebitCredit == "0")
                    {
                        // 10.借方勘定科目コード
                        result.KariKamokuCode = item.AccountTitleCode;
                        // 11.借方補助科目コード
                        result.KariHojoCode = "";
                        if (repository.IsHojoByCode(item.AccountTitleCode) > 0)
                        {
                            // USE(従業員コード)
                            if (repository.IsHojoByCode(item.AccountTitleCode) == 4)
                            {
                                if (item.ExtensionIdentify5 == "0005")
                                    result.KariHojoCode = item.ExtensionCode5;
                            }
                            else if (!string.IsNullOrEmpty(item.ParticularsIdentify))
                            {
                                result.KariHojoCode = item.ParticularsCode;
                            }
                        }
                        // 12.借方補助内訳科目コード
                        result.KariHojoUchiwakeCode = null;
                        // 13.借方部門コード
                        result.KariBumonCode = item.AccountDepartmentCode;
                        // 418100:仮受消費税か142100:仮払消費税の場合、部門コードをブランク
                        if (item.AccountTitleCode == "418100" || item.AccountTitleCode == "142100")
                            result.KariBumonCode = string.Empty;
                        // 14.借方取引先コード
                        if (repository.IsTorihikiByCode(item.AccountTitleCode))
                        {
                            if (system == InputSystem.CMS)
                            {
                                if (item.ParticularsIdentify == "0501")
                                    result.KariTorihikisakiCode = item.ParticularsCode;
                            }
                            else
                            {
                                result.KariTorihikisakiCode = item.CustomerCode;
                            }
                        }
                        // 15.借方税区分
                        if (system == InputSystem.CMS)
                        {
                            // CMS
                            result.KariTaxKbn = "0";
                            if (item.AccountTitleCode == "861070")
                                result.KariTaxKbn = "41";
                        }
                        else if (system == InputSystem.USE || system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // USE/NYU/KEI
                            // result.KariTaxKbn = item.TaxCategory;
                            // if (string.IsNullOrEmpty(item.TaxCategory))
                            //    result.KashiTaxKbn = "0";
                            result.KashiTaxKbn = "0";
                            if (item.TaxCategory == "50")
                                result.KariTaxKbn = "71";
                        }
                        else if (system == InputSystem.URI)
                        {
                            // URI
                            if (string.IsNullOrEmpty(item.TaxCategory))
                                result.KashiTaxKbn = "0";
                            if (item.TaxCategory == "10")
                                result.KariTaxKbn = "11";
                        }
                        // TEST
                        if (string.IsNullOrEmpty(result.KariTaxKbn))
                        {
                            result.KariTaxKbn = "0";
                        }

                        // 16.借方税込区分
                        if (system == InputSystem.CMS || system == InputSystem.USE)
                        {
                            // CMS/USE
                            result.KariTaxationKbn = support.StringToIntegerOrDefault(item.TaxationCategory);
                        }
                        else if (system == InputSystem.URI)
                        {
                            // URI(elseがないのでそのまま？？)
                            if (item.TaxCategory == "10")
                                result.KariTaxationKbn = 3;
                        }
                        else if (system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // NYU/KEI(elseがないのでそのまま？？)
                            if (item.TaxCategory == "50")
                                result.KariTaxationKbn = 3;
                        }
                        // 17.借方金額
                        result.KariAmount = support.GamountToDecimal(item.BaseAmount);
                        // 18.借方消費税額
                        result.KariTaxAmount = support.GamountToDecimal(item.ReferenceTaxAmount);
                        // 19.借方消費税本体科目コード
                        result.KariTaxKamokuCode = null;
                        // 20.借方分析コード１
                        if(system == InputSystem.CMS || system == InputSystem.USE)
                        {
                            // CMS/USE
                            result.KariBunsekiCode1 = null;
                        }
                        else if(system == InputSystem.URI || system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // URI/NYU/KEI(入金予定日)
                            if (item.ExtensionIdentify4 == "0004" && !string.IsNullOrEmpty(item.ExtensionCode4))
                                result.KariBunsekiCode1 = DateTime.ParseExact(item.ExtensionCode4, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        }
                        // 21.借方分析コード２
                        result.KariBunsekiCode2 = null;
                        // 22.借方分析コード３
                        result.KariBunsekiCode3 = null;
                        // 23.借方分析コード４
                        // CMS/USE
                        result.KariBunsekiCode4 = null;
                        // URI/NYU/KEI(生産拠点)
                        if (item.ExtensionIdentify1 == "0010")
                        {
                            result.KariBunsekiCode4 = item.ExtensionCode1;
                        }
                        // 24.借方分析コード５
                        if (system == InputSystem.CMS || system == InputSystem.USE)
                        {
                            // CMS/USE
                            result.KariBunsekiCode5 = null;
                        }
                        else if (system == InputSystem.URI || system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // URI/NYU/KEI(種別)
                            if (item.ExtensionIdentify2 == "0011")
                            {
                                result.KariBunsekiCode5 = item.ExtensionCode2;
                            }
                        }
                        // 25.借方資金コード
                        result.KariFundCode = null;
                        // 26.借方プロジェクトコード
                        result.KariProjectCode = null;
                    }
                    else if (item.DebitCredit == "1")
                    {
                        // 27.貸方勘定科目コード
                        result.KashiKamokuCode = item.AccountTitleCode;
                        // 28.貸方補助科目コード
                        result.KashiHojoCode = "";
                        if (repository.IsHojoByCode(item.AccountTitleCode) > 0)
                        {
                            // USE(従業員コード)
                            if (repository.IsHojoByCode(item.AccountTitleCode) == 4)
                            {
                                if (item.ExtensionIdentify5 == "0005")
                                    result.KashiHojoCode = item.ExtensionCode5;
                            }
                            else if (!string.IsNullOrEmpty(item.ParticularsIdentify))
                            {
                                result.KashiHojoCode = item.ParticularsCode;
                            }
                        }
                        // 29.貸方補助内訳科目コード
                        result.KashiHojoUchiwakeCode = null;
                        // 30.貸方部門コード
                        result.KashiBumonCode = item.AccountDepartmentCode;
                        // 418100:仮受消費税か142100:仮払消費税の場合、部門コードをブランク
                        if (item.AccountTitleCode == "418100" || item.AccountTitleCode == "142100")
                            result.KashiBumonCode = string.Empty;
                        // 31.貸方取引先コード
                        if (repository.IsTorihikiByCode(item.AccountTitleCode))
                        {
                            if (system == InputSystem.CMS)
                            {
                                if (item.ParticularsIdentify == "0501")
                                    result.KashiTorihikisakiCode = item.ParticularsCode;
                            }
                            else
                            {
                                result.KashiTorihikisakiCode = item.CustomerCode;
                            }
                        }
                        // 32.貸方税区分
                        if(system == InputSystem.CMS)
                        {
                            // CMS
                            result.KashiTaxKbn = item.TaxCategory;
                            if (item.AccountTitleCode == "861070")
                                result.KashiTaxKbn = "41";
                        }
                        else if(system == InputSystem.USE)
                        {
                            // USE
                            result.KashiTaxKbn = item.TaxCategory;
                            if (string.IsNullOrEmpty(item.TaxCategory))
                                result.KashiTaxKbn = "0";
                            if (item.TaxCategory == "50")
                                result.KashiTaxKbn = "71";
                        }
                        else if (system == InputSystem.URI)
                        {
                            // URI
                            if (string.IsNullOrEmpty(item.TaxCategory))
                                result.KashiTaxKbn = "0";
                            if (item.TaxCategory == "10")
                                result.KashiTaxKbn = "11";
                        }
                        else if (system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // NYU/KEI
                            // if (string.IsNullOrEmpty(item.TaxCategory))
                            //    result.KashiTaxKbn = "0";
                            result.KashiTaxKbn = "0";
                            if (item.TaxCategory == "10")
                                result.KashiTaxKbn = "71";
                        }
                        // TEST
                        if (string.IsNullOrEmpty(result.KashiTaxKbn))
                        {
                            result.KashiTaxKbn = "0";
                        }
                        // 33.貸方税込区分
                        if(system == InputSystem.CMS || system == InputSystem.USE)
                        {
                            // CMS/USE
                            result.KashiTaxationKbn = support.StringToIntegerOrDefault(item.TaxationCategory);
                        }
                        else if(system == InputSystem.URI || system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // URI/NYU/KEI(elseがないのでそのまま？？)
                            if (item.TaxCategory == "10")
                                result.KashiTaxationKbn = 3;
                        }
                        // 34.貸方金額
                        result.KashiAmount = support.GamountToDecimal(item.BaseAmount);
                        // 35.貸方消費税額
                        result.KashiTaxAmount = support.GamountToDecimal(item.ReferenceTaxAmount);
                        // 36.貸方消費税本体科目コード
                        result.KashiTaxKamokuCode = null;
                        // 37.貸方分析コード１
                        if(system == InputSystem.CMS || system == InputSystem.USE)
                        {
                            // CMS/USE
                            result.KashiBunsekiCode1 = null;
                        }
                        else if(system == InputSystem.URI || system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // URI/NYU/KEI(入金予定日)
                            if (item.ExtensionIdentify4 == "0004" && !string.IsNullOrEmpty(item.ExtensionCode4))
                                result.KashiBunsekiCode1 = DateTime.ParseExact(item.ExtensionCode4, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        }
                        // 38.貸方分析コード２
                        result.KashiBunsekiCode2 = null;
                        // 39.貸方分析コード３
                        result.KashiBunsekiCode3 = null;
                        // 40.貸方分析コード４
                        if(system == InputSystem.CMS || system == InputSystem.USE)
                        {
                            // CMS/USE
                            result.KashiBunsekiCode4 = null;
                        }
                        else if(system == InputSystem.URI || system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // URI/NYU/KEI(生産拠点)
                            if (item.ExtensionIdentify1 == "0010")
                            {
                                result.KashiBunsekiCode4 = item.ExtensionCode1;
                            }
                        }
                        // 41.貸方分析コード５
                        if (system == InputSystem.CMS || system == InputSystem.USE)
                        {
                            // CMS/USE
                            result.KashiBunsekiCode5 = null;
                        }
                        else if (system == InputSystem.URI || system == InputSystem.NYUU || system == InputSystem.KEI)
                        {
                            // URI/NYU/KEI(種別)
                            if (item.ExtensionIdentify2 == "0011")
                            {
                                result.KashiBunsekiCode5 = item.ExtensionCode2;
                            }
                        }
                        // 42.貸方資金コード
                        result.KashiFundCode = null;
                        // 43.貸方プロジェクトコード
                        result.KashiProjectCode = null;
                    }

                    if (recordMode == RecordMode.NEW)
                    {
                        list.Add(result);
                    }
                }
                // 丸め誤差処理
                var denpyoList = list.Select(x => x.DenpyoNo).Distinct().ToList();
                foreach(var item in denpyoList)
                {
                    var kariAmount = list.Where(x => x.DenpyoNo == item).Select(x => x.KariAmount).Sum();
                    var kariTaxAmount = list.Where(x => x.DenpyoNo == item).Select(x => x.KariTaxAmount).Sum();
                    var kashiAmount = list.Where(x => x.DenpyoNo == item).Select(x => x.KashiAmount).Sum();
                    var kashiTaxAmount = list.Where(x => x.DenpyoNo == item).Select(x => x.KashiTaxAmount).Sum();
                    decimal baseAmount = 0;
                    if (kariAmount.HasValue) baseAmount += kariAmount.Value;
                    if (kariTaxAmount.HasValue) baseAmount += kariTaxAmount.Value;
                    decimal checkAmount = 0;
                    if (kashiAmount.HasValue) checkAmount += kashiAmount.Value;
                    if (kashiTaxAmount.HasValue) checkAmount += kashiTaxAmount.Value;
                    if(baseAmount != checkAmount)
                    {
                        var addAmount = baseAmount - checkAmount;
                        var result = list.Where(x => x.DenpyoNo == item).Where(x => x.Rows == 1).SingleOrDefault();
                        result.KashiTaxAmount += addAmount;
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
            return WriteFile<Obic7ZaimuMap>(output_path, keyname, resultlist, false, hasHeader);
        }
    }
}
