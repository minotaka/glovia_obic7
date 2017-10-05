using CsvHelper.Configuration;
using System;
using System.ComponentModel;

namespace glovia_obic7.Models
{
    public class Obic7SaimuMap : CsvClassMap<Obic7Saimu>
    {
        public Obic7SaimuMap()
        {
            Map(m => m.CompanyCode).Name("会社NO");
            Map(m => m.SystemCategory).Name("システム分類");
            Map(m => m.UkeireDataKbn).Name("受入データ区分");
            Map(m => m.HeadInputJigyoshoCode).Name("HEAD入力事業所コード");
            Map(m => m.HeadDenpyoCode).Name("HEAD伝票種別コード");
            Map(m => m.HeadDate).Name("HEAD発生日");
            Map(m => m.SubsystemDenpyoNo).Name("サブシステム伝票番号");
            Map(m => m.HeadManageJigyoshoCode).Name("HEAD債務管理事業所コード");
            Map(m => m.HeadManageBumonCode).Name("HEAD債務管理部門コード");
            Map(m => m.HeadPaymentJigyoshoCode).Name("HEAD支払事業所コード");
            Map(m => m.HeadPaymentBumonCode).Name("HEAD支払部門コード");
            Map(m => m.HeadSupplierCode).Name("HEAD仕入先コード");
            Map(m => m.HeadSupplierSpotKbn).Name("HEAD仕入先スポット区分");
            Map(m => m.HeadTantoCode).Name("HEAD担当者コード");
            Map(m => m.HeadNohinDate).Name("HEAD納品書日付");
            Map(m => m.HeadNohinNo).Name("HEAD納品書番号");
            Map(m => m.HeadSimeKbn).Name("HEAD都度締区分");
            Map(m => m.HeadPaymentTermCode).Name("HEAD決済条件コード");
            Map(m => m.HeadSimeDate).Name("HEAD締日");
            Map(m => m.HeadPaymentDate).Name("HEAD支払予定日");
            Map(m => m.HeadComment).Name("HEAD摘要");
            Map(m => m.HeadPaymentAccountCode).Name("HEAD支払決済口座コード");
            Map(m => m.HeadAccoutSelectKbn).Name("HEAD振込口座選択区分");
            Map(m => m.HeadHojoKamokuCode).Name("HEAD補助科目コード");
            Map(m => m.HeadHojoUchiwakeCode).Name("HEAD補助内訳科目コード");
            Map(m => m.HeadBunsekiCode1).Name("HEAD分析コード1");
            Map(m => m.HeadBunsekiCode2).Name("HEAD分析コード2");
            Map(m => m.HeadBunsekiCode3).Name("HEAD分析コード3");
            Map(m => m.HeadBunsekiCode4).Name("HEAD分析コード4");
            Map(m => m.HeadBunsekiCode5).Name("HEAD分析コード5");
            Map(m => m.HeadFundCode).Name("HEAD資金コード");
            Map(m => m.HeadProjectCode).Name("HEADプロジェクトコード");
            Map(m => m.HeadWithholdingKbn).Name("HEAD源泉税預り金計算対象区分");
            Map(m => m.HeadWithholdingCode).Name("HEAD源泉税コード");
            Map(m => m.HeadWithholdingAmount).Name("HEAD源泉税預り金");
            Map(m => m.HeadWithholdingBunsekiCode1).Name("HEAD源泉税分析コード1");
            Map(m => m.HeadWithholdingBunsekiCode2).Name("HEAD源泉税分析コード2");
            Map(m => m.HeadWithholdingBunsekiCode3).Name("HEAD源泉税分析コード3");
            Map(m => m.HeadWithholdingBunsekiCode4).Name("HEAD源泉税分析コード4");
            Map(m => m.HeadWithholdingBunsekiCode5).Name("HEAD源泉税分析コード5");
            Map(m => m.HeadWithholdingFundCode).Name("HEAD源泉税資金コード");
            Map(m => m.HeadWithholdingProjectCode).Name("HEAD源泉税プロジェクトコード");
            Map(m => m.Rows).Name("行番号");
            Map(m => m.DataKbnCode).Name("明細債務データ取引区分コード");
            Map(m => m.JigyoshoCode).Name("明細事業所コード");
            Map(m => m.BumonCode).Name("明細部門コード");
            Map(m => m.HojoKamokuCode).Name("明細補助科目コード");
            Map(m => m.HojoUchiwakeCode).Name("明細補助内訳科目コード");
            Map(m => m.TaxKbn).Name("明細税区分");
            Map(m => m.TaxationKbn).Name("明細税込区分");
            Map(m => m.BunsekiCode1).Name("明細分析コード1");
            Map(m => m.BunsekiCode2).Name("明細分析コード2");
            Map(m => m.BunsekiCode3).Name("明細分析コード3");
            Map(m => m.BunsekiCode4).Name("明細分析コード4");
            Map(m => m.BunsekiCode5).Name("明細分析コード5");
            Map(m => m.FundCode).Name("明細資金コード");
            Map(m => m.ProjectCode).Name("明細プロジェクトコード");
            Map(m => m.TaxKamokuCode).Name("明細消費税本体科目コード");
            Map(m => m.ProductCode).Name("明細品コード");
            Map(m => m.ProductName).Name("明細品名");
            Map(m => m.ProductStandard).Name("明細規格");
            Map(m => m.ProductTaniCode).Name("明細単位コード");
            Map(m => m.ProductTaniName).Name("明細単位名");
            Map(m => m.ProductSu).Name("明細数量");
            Map(m => m.ProductTanka).Name("明細単価");
            Map(m => m.LotNo).Name("明細ロットNO");
            Map(m => m.Comment).Name("明細摘要");
            Map(m => m.Amount).Name("明細金額");
            Map(m => m.ExclusiveTaxAmount).Name("明細外税消費税");
            Map(m => m.TaxAmount).Name("明細うち消費税");
            Map(m => m.TorihikiName1).Name("取引先正式名1");
            Map(m => m.TorihikiName2).Name("取引先正式名2");
            Map(m => m.TorihikiBushoName).Name("取引先部署名");
            Map(m => m.TorihikiNickName).Name("社内用取引先名");
            Map(m => m.TorihikiShortName).Name("取引先略名");
            Map(m => m.TorihikiFurigana).Name("取引先フリガナ");
            Map(m => m.TorihikiZipCode1).Name("取引先郵便番号1（上3桁）");
            Map(m => m.TorihikiZipCode2).Name("取引先郵便番号2（下4桁）");
            Map(m => m.TorihikiAddress1).Name("取引先住所1");
            Map(m => m.TorihikiAddress2).Name("取引先住所2");
            Map(m => m.TorihikiAddress3).Name("取引先住所3");
            Map(m => m.TorihikiTel1AreaCode).Name("取引先電話番号1市外局番");
            Map(m => m.TorihikiTel1LocalNumber).Name("取引先電話番号1市内局番");
            Map(m => m.TorihikiTel1).Name("取引先電話番号1");
            Map(m => m.TorihikiTel1ExtensionNumber).Name("取引先内線番号1");
            Map(m => m.TorihikiTel2AreaCode).Name("取引先電話番号2市外局番");
            Map(m => m.TorihikiTel2LocalNumber).Name("取引先電話番号2市内局番");
            Map(m => m.TorihikiTel2).Name("取引先電話番号2");
            Map(m => m.TorihikiTel2ExtensionNumber).Name("取引先内線番号2");
            Map(m => m.TorihikiFaxAreaCode).Name("取引先FAX番号市外局番");
            Map(m => m.TorihikiFaxLocalNumber).Name("取引先FAX番号市内局番");
            Map(m => m.TorihikiFax).Name("取引先FAX番号");
            Map(m => m.TorihikiTantoBushoName).Name("取引先担当部署名");
            Map(m => m.TorihikiTantoPositionName).Name("取引先担当役職名");
            Map(m => m.TorihikiTantoName).Name("取引先担当者名");
            Map(m => m.Email).Name("メールアドレス");
            Map(m => m.AddressKbn).Name("郵送先住所区分");
            Map(m => m.Name1).Name("郵送先正式名1");
            Map(m => m.Name2).Name("郵送先正式名2");
            Map(m => m.ZipCode1).Name("郵便番号1（上3桁）");
            Map(m => m.ZipCode2).Name("郵便番号2（下4桁）");
            Map(m => m.Address1).Name("郵送先住所1");
            Map(m => m.Address2).Name("郵送先住所2");
            Map(m => m.Address3).Name("郵送先住所3");
            Map(m => m.TelAreaCode).Name("郵送先電話番号市外局番");
            Map(m => m.TelLocalNumber).Name("郵送先電話番号市内局番");
            Map(m => m.Tel).Name("郵送先電話番号");
            Map(m => m.TelExtensionNumber).Name("郵送先内線番号");
            Map(m => m.FaxAreaCode).Name("郵送先FAX番号市外局番");
            Map(m => m.FaxlocalNumber).Name("郵送先FAX番号市内局番");
            Map(m => m.Fax).Name("郵送先FAX電話番号");
            Map(m => m.TantoBushoName).Name("郵送先担当部署名");
            Map(m => m.TantoName).Name("郵送先担当者名");
            Map(m => m.BankCode).Name("振込先銀行コード");
            Map(m => m.BankBranchCode).Name("振込先銀行支店コード");
            Map(m => m.BankAccountKbn).Name("預金種別区分");
            Map(m => m.BankAccountNumber).Name("口座番号");
            Map(m => m.BankAccountName).Name("口座名義人カナ");
            Map(m => m.BankChargeKbn).Name("手数料負担区分");
            Map(m => m.BankHolidayKbn).Name("休日処理区分");
            Map(m => m.SiteCalcKbn).Name("サイト計算区分");
            Map(m => m.Site).Name("サイト");
            Map(m => m.SiteMonth).Name("サイト月数");
            Map(m => m.SiteDays).Name("サイト日数");
        }
    }

    public class Obic7Saimu : BaseModel
    {
        public int CompanyCode { get; set; }

        [DefaultValue(21)]
        public int SystemCategory { get; set; }
        [DefaultValue(1)]
        public int UkeireDataKbn { get; set; }

        [DefaultValue("1")]
        public string HeadInputJigyoshoCode { get; set; }
        public int HeadDenpyoCode { get; set; }
        public DateTime HeadDate { get; set; }

        public string SubsystemDenpyoNo { get; set; }

        [DefaultValue("1")]
        public string HeadManageJigyoshoCode { get; set; }
        public string HeadManageBumonCode { get; set; }
        [DefaultValue("1")]
        public string HeadPaymentJigyoshoCode { get; set; }
        [DefaultValue("*")]
        public string HeadPaymentBumonCode { get; set; }

        public string HeadSupplierCode { get; set; }
        [DefaultValue(0)]
        public int HeadSupplierSpotKbn { get; set; }

        [DefaultValue(null)]
        public string HeadTantoCode { get; set; }
        [DefaultValue(null)]
        public DateTime? HeadNohinDate { get; set; }
        [DefaultValue(null)]
        public string HeadNohinNo { get; set; }
        [DefaultValue(0)]
        public int HeadSimeKbn { get; set; }
        [DefaultValue(null)]
        public int? HeadPaymentTermCode { get; set; }
        [DefaultValue(null)]
        public DateTime? HeadSimeDate { get; set; }
        [DefaultValue(null)]
        public DateTime? HeadPaymentDate { get; set; }
        [DefaultValue(null)]
        public string HeadComment { get; set; }
        [DefaultValue(1)]
        public int HeadPaymentAccountCode { get; set; }
        [DefaultValue(null)]
        public int? HeadAccoutSelectKbn { get; set; }

        public string HeadHojoKamokuCode { get; set; }
        public string HeadHojoUchiwakeCode { get; set; }
        public string HeadBunsekiCode1 { get; set; }
        public string HeadBunsekiCode2 { get; set; }
        public string HeadBunsekiCode3 { get; set; }
        [DefaultValue(null)]
        public string HeadBunsekiCode4 { get; set; }
        [DefaultValue(null)]
        public string HeadBunsekiCode5 { get; set; }
        [DefaultValue(null)]
        public string HeadFundCode { get; set; }
        [DefaultValue(null)]
        public string HeadProjectCode { get; set; }

        [DefaultValue(null)]
        public int? HeadWithholdingKbn { get; set; }
        [DefaultValue(null)]
        public int? HeadWithholdingCode { get; set; }
        [DefaultValue(null)]
        public int? HeadWithholdingAmount { get; set; }
        [DefaultValue(null)]
        public string HeadWithholdingBunsekiCode1 { get; set; }
        [DefaultValue(null)]
        public string HeadWithholdingBunsekiCode2 { get; set; }
        [DefaultValue(null)]
        public string HeadWithholdingBunsekiCode3 { get; set; }
        [DefaultValue(null)]
        public string HeadWithholdingBunsekiCode4 { get; set; }
        [DefaultValue(null)]
        public string HeadWithholdingBunsekiCode5 { get; set; }
        [DefaultValue(null)]
        public string HeadWithholdingFundCode { get; set; }
        [DefaultValue(null)]
        public string HeadWithholdingProjectCode { get; set; }

        public int Rows { get; set; }

        public int DataKbnCode { get; set; }
        [DefaultValue("1")]
        public string JigyoshoCode { get; set; }
        public string BumonCode { get; set; }
        public string HojoKamokuCode { get; set; }
        public string HojoUchiwakeCode { get; set; }
        public string TaxKbn { get; set; }
        public int TaxationKbn { get; set; }

        public string BunsekiCode1 { get; set; }
        public string BunsekiCode2 { get; set; }
        public string BunsekiCode3 { get; set; }
        [DefaultValue(null)]
        public string BunsekiCode4 { get; set; }
        [DefaultValue(null)]
        public string BunsekiCode5 { get; set; }
        [DefaultValue(null)]
        public string FundCode { get; set; }
        [DefaultValue(null)]
        public string ProjectCode { get; set; }
        [DefaultValue(null)]
        public string TaxKamokuCode { get; set; }

        [DefaultValue(null)]
        public string ProductCode { get; set; }
        [DefaultValue(null)]
        public string ProductName { get; set; }
        [DefaultValue(null)]
        public string ProductStandard { get; set; }
        [DefaultValue(null)]
        public string ProductTaniCode { get; set; }
        [DefaultValue(null)]
        public string ProductTaniName { get; set; }
        [DefaultValue(null)]
        public decimal? ProductSu { get; set; }
        [DefaultValue(null)]
        public decimal? ProductTanka { get; set; }
        [DefaultValue(null)]
        public string LotNo { get; set; }
        public string Comment { get; set; }
        public decimal Amount { get; set; }
        [DefaultValue(0)]
        public decimal? ExclusiveTaxAmount { get; set; }
        [DefaultValue(null)]
        public decimal? TaxAmount { get; set; }

        [DefaultValue(null)]
        public string TorihikiName1 { get; set; }
        [DefaultValue(null)]
        public string TorihikiName2 { get; set; }
        [DefaultValue(null)]
        public string TorihikiBushoName { get; set; }
        [DefaultValue(null)]
        public string TorihikiNickName { get; set; }
        [DefaultValue(null)]
        public string TorihikiShortName { get; set; }
        [DefaultValue(null)]
        public string TorihikiFurigana { get; set; }

        [DefaultValue(null)]
        public int? TorihikiZipCode1 { get; set; }
        [DefaultValue(null)]
        public int? TorihikiZipCode2 { get; set; }
        [DefaultValue(null)]
        public string TorihikiAddress1 { get; set; }
        [DefaultValue(null)]
        public string TorihikiAddress2 { get; set; }
        [DefaultValue(null)]
        public string TorihikiAddress3 { get; set; }

        [DefaultValue(null)]
        public int? TorihikiTel1AreaCode { get; set; }
        [DefaultValue(null)]
        public int? TorihikiTel1LocalNumber { get; set; }
        [DefaultValue(null)]
        public int? TorihikiTel1 { get; set; }
        [DefaultValue(null)]
        public string TorihikiTel1ExtensionNumber { get; set; }

        [DefaultValue(null)]
        public int? TorihikiTel2AreaCode { get; set; }
        [DefaultValue(null)]
        public int? TorihikiTel2LocalNumber { get; set; }
        [DefaultValue(null)]
        public int? TorihikiTel2 { get; set; }
        [DefaultValue(null)]
        public string TorihikiTel2ExtensionNumber { get; set; }

        [DefaultValue(null)]
        public int? TorihikiFaxAreaCode { get; set; }
        [DefaultValue(null)]
        public int? TorihikiFaxLocalNumber { get; set; }
        [DefaultValue(null)]
        public int? TorihikiFax { get; set; }

        [DefaultValue(null)]
        public string TorihikiTantoBushoName { get; set; }
        [DefaultValue(null)]
        public string TorihikiTantoPositionName { get; set; }
        [DefaultValue(null)]
        public string TorihikiTantoName { get; set; }
        [DefaultValue(null)]
        public string Email { get; set; }

        [DefaultValue(null)]
        public int? AddressKbn { get; set; }
        [DefaultValue(null)]
        public string Name1 { get; set; }
        [DefaultValue(null)]
        public string Name2 { get; set; }
        [DefaultValue(null)]
        public int? ZipCode1 { get; set; }
        [DefaultValue(null)]
        public int? ZipCode2 { get; set; }
        [DefaultValue(null)]
        public string Address1 { get; set; }
        [DefaultValue(null)]
        public string Address2 { get; set; }
        [DefaultValue(null)]
        public string Address3 { get; set; }

        [DefaultValue(null)]
        public int? TelAreaCode { get; set; }
        [DefaultValue(null)]
        public int? TelLocalNumber { get; set; }
        [DefaultValue(null)]
        public int? Tel { get; set; }
        [DefaultValue(null)]
        public string TelExtensionNumber { get; set; }

        [DefaultValue(null)]
        public int? FaxAreaCode { get; set; }
        [DefaultValue(null)]
        public int? FaxlocalNumber { get; set; }
        [DefaultValue(null)]
        public int? Fax { get; set; }

        [DefaultValue(null)]
        public string TantoBushoName { get; set; }
        [DefaultValue(null)]
        public string TantoName { get; set; }

        [DefaultValue(null)]
        public int? BankCode { get; set; }
        [DefaultValue(null)]
        public int? BankBranchCode { get; set; }
        [DefaultValue(null)]
        public int? BankAccountKbn { get; set; }
        [DefaultValue(null)]
        public int? BankAccountNumber { get; set; }
        [DefaultValue(null)]
        public string BankAccountName { get; set; }
        [DefaultValue(null)]
        public int? BankChargeKbn { get; set; }
        [DefaultValue(null)]
        public int? BankHolidayKbn { get; set; }

        [DefaultValue(null)]
        public int? SiteCalcKbn { get; set; }
        [DefaultValue(null)]
        public int? Site { get; set; }
        [DefaultValue(null)]
        public int? SiteMonth { get; set; }
        [DefaultValue(null)]
        public int? SiteDays { get; set; }
    }
}
