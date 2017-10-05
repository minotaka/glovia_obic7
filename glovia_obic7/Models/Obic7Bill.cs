using CsvHelper.Configuration;
using System;
using System.ComponentModel;

namespace glovia_obic7.Models
{
    public class Obic7BillMap : CsvClassMap<Obic7Bill>
    {
        public Obic7BillMap()
        {
            Map(m => m.ManageNumber).Name("管理番号");
            Map(m => m.BranchNumber).Name("枝番");
            Map(m => m.BillNumber).Name("手形番号");
            Map(m => m.BillKbn).Name("手形区分");
            Map(m => m.TemporalyReceivedKbn).Name("仮収納区分");
            Map(m => m.BillKindCode).Name("手形種別コード");
            Map(m => m.BillTypeCode).Name("手形分類コード");
            Map(m => m.FuridashiKbn).Name("振出区分");
            Map(m => m.IssueKbn).Name("発行区分");
            Map(m => m.ReciveName).Name("受取人名");
            Map(m => m.TorihikiCode).Name("取引先コード");
            Map(m => m.TorihikiName).Name("取引先名");
            Map(m => m.FuridashiName).Name("振出人名");
            Map(m => m.FuridashiAddress1).Name("振出人住所1");
            Map(m => m.FuridashiAddress2).Name("振出人住所2");
            Map(m => m.FuridashiTantoPosition).Name("振出人代表者役職");
            Map(m => m.FuridashiTantoName).Name("振出人代表者氏名");
            Map(m => m.BankCode).Name("取扱銀行コード");
            Map(m => m.PaymentOther).Name("支払地");
            Map(m => m.PaymentBankCode).Name("支払銀行コード");
            Map(m => m.PaymentBankBranchCode).Name("支払銀行支店コード");
            Map(m => m.PaymentBankOther).Name("支払銀行支払地");
            Map(m => m.BillAmount).Name("手形金額");
            Map(m => m.PaymentDate).Name("支払日");
            Map(m => m.RecivedDate).Name("受取日");
            Map(m => m.FuridashiDate).Name("振出日");
            Map(m => m.MankiDate).Name("満期日");
            Map(m => m.KessaiDate).Name("決済日");
            Map(m => m.HolidayKbn).Name("休日区分");
            Map(m => m.UragakiKbn).Name("手形裏書区分");
            Map(m => m.KisaiJikou).Name("記載事項");
            Map(m => m.UragakiDisabled).Name("裏書禁止フラグ");
            Map(m => m.BillComment).Name("手形摘要");
            Map(m => m.BillSiwakeKbn).Name("手形仕訳区分");
            Map(m => m.JigyoshoCode).Name("管理事業所コード");
            Map(m => m.BumonCode).Name("管理部門コード");
            Map(m => m.Filler37).Name("借方決済分析コード1");
            Map(m => m.Filler38).Name("借方決済分析コード2");
            Map(m => m.Filler39).Name("借方決済分析コード3");
            Map(m => m.Filler40).Name("借方決済分析コード4");
            Map(m => m.Filler41).Name("借方決済分析コード5");
            Map(m => m.Filler42).Name("借方決済資金コード");
            Map(m => m.Filler43).Name("借方決済プロジェクトコード");
            Map(m => m.Filler44).Name("貸方決済分析コード1");
            Map(m => m.Filler45).Name("貸方決済分析コード2");
            Map(m => m.Filler46).Name("貸方決済分析コード3");
            Map(m => m.Filler47).Name("貸方決済分析コード4");
            Map(m => m.Filler48).Name("貸方決済分析コード5");
            Map(m => m.Filler49).Name("貸方決済資金コード");
            Map(m => m.Filler50).Name("貸方決済プロジェクトコード");
            Map(m => m.Filler51).Name("借方計上事業所コード");
            Map(m => m.Filler52).Name("借方計上部門コード");
            Map(m => m.Filler53).Name("借方総勘定科目コード");
            Map(m => m.Filler54).Name("借方補助科目コード");
            Map(m => m.Filler55).Name("借方補助内訳科目コード");
            Map(m => m.Filler56).Name("借方分析コード1");
            Map(m => m.Filler57).Name("借方分析コード2");
            Map(m => m.Filler58).Name("借方分析コード3");
            Map(m => m.Filler59).Name("借方分析コード4");
            Map(m => m.Filler60).Name("借方分析コード5");
            Map(m => m.Filler61).Name("借方資金コード");
            Map(m => m.Filler62).Name("借方プロジェクトコード");
            Map(m => m.Filler63).Name("借方取引先コード");
            Map(m => m.Filler64).Name("借方税区分");
            Map(m => m.Filler65).Name("借方税込区分");
            Map(m => m.Filler66).Name("借方金額");
            Map(m => m.Filler67).Name("借方消費税額");
            Map(m => m.Filler68).Name("借方消費税本体科目コード");
            Map(m => m.Filler69).Name("貸方計上事業所コード");
            Map(m => m.Filler70).Name("貸方計上部門コード");
            Map(m => m.Filler71).Name("貸方総勘定科目コード");
            Map(m => m.Filler72).Name("貸方補助科目コード");
            Map(m => m.Filler73).Name("貸方補助内訳科目コード");
            Map(m => m.Filler74).Name("貸方分析コード1");
            Map(m => m.Filler75).Name("貸方分析コード2");
            Map(m => m.Filler76).Name("貸方分析コード3");
            Map(m => m.Filler77).Name("貸方分析コード4");
            Map(m => m.Filler78).Name("貸方分析コード5");
            Map(m => m.Filler79).Name("貸方資金コード");
            Map(m => m.Filler80).Name("貸方プロジェクトコード");
            Map(m => m.Filler81).Name("貸方取引先コード");
            Map(m => m.Filler82).Name("貸方税区分");
            Map(m => m.Filler83).Name("貸方税込区分");
            Map(m => m.Filler84).Name("貸方金額");
            Map(m => m.Filler85).Name("貸方消費税額");
            Map(m => m.Filler86).Name("貸方消費税本体科目コード");
            Map(m => m.Filler87).Name("控除区分");
            Map(m => m.Filler88).Name("引受人コード");
            Map(m => m.Filler89).Name("引受人名");
            Map(m => m.Filler90).Name("引受人住所1");
            Map(m => m.Filler91).Name("引受人住所2");
            Map(m => m.Filler92).Name("引受人代表者役職");
            Map(m => m.Filler93).Name("引受人代表者氏名");
            Map(m => m.Filler94).Name("記録機関");
            Map(m => m.Filler95).Name("口座情報コード");
            Map(m => m.Filler96).Name("支払預金種目");
            Map(m => m.Filler97).Name("支払預金口座");
        }
    }

    public class Obic7Bill : BaseModel
    {
        public int ManageNumber { get; set; }
        public int BranchNumber { get; set; }
        public string BillNumber { get; set; }
        [DefaultValue(1)]
        public int BillKbn { get; set; }
        [DefaultValue(1)]
        public int TemporalyReceivedKbn { get; set; }

        public string BillKindCode { get; set; }
        [DefaultValue(null)]
        public string BillTypeCode { get; set; }
        [DefaultValue(2)]
        public int FuridashiKbn { get; set; }
        [DefaultValue(0)]
        public int IssueKbn { get; set; }

        [DefaultValue(null)]
        public string ReciveName { get; set; }
        public string TorihikiCode { get; set; }
        [DefaultValue(null)]
        public string TorihikiName { get; set; }

        [DefaultValue(null)]
        public string FuridashiName { get; set; }
        [DefaultValue(null)]
        public string FuridashiAddress1 { get; set; }
        [DefaultValue(null)]
        public string FuridashiAddress2 { get; set; }
        [DefaultValue(null)]
        public string FuridashiTantoPosition { get; set; }
        [DefaultValue(null)]
        public string FuridashiTantoName { get; set; }

        [DefaultValue(null)]
        public int? BankCode { get; set; }
        [DefaultValue(null)]
        public string PaymentOther { get; set; }
        public string PaymentBankCode { get; set; }
        public string PaymentBankBranchCode { get; set; }
        [DefaultValue(null)]
        public string PaymentBankOther { get; set; }
        public decimal BillAmount { get; set; }

        [DefaultValue(null)]
        public DateTime? PaymentDate { get; set; }
        public DateTime RecivedDate { get; set; }
        [DefaultValue(null)]
        public DateTime? FuridashiDate { get; set; }
        public DateTime MankiDate { get; set; }
        [DefaultValue(null)]
        public DateTime? KessaiDate { get; set; }

        [DefaultValue(0)]
        public int HolidayKbn { get; set; }
        [DefaultValue(null)]
        public int? UragakiKbn { get; set; }
        [DefaultValue(null)]
        public string KisaiJikou { get; set; }
        [DefaultValue(null)]
        public int? UragakiDisabled { get; set; }
        [DefaultValue(null)]
        public string BillComment { get; set; }
        [DefaultValue(null)]
        public string BillSiwakeKbn { get; set; }

        [DefaultValue("1")]
        public string JigyoshoCode { get; set; }
        public string BumonCode { get; set; }

        [DefaultValue(null)]
        public string Filler37 { get; set; }
        [DefaultValue(null)]
        public string Filler38 { get; set; }
        [DefaultValue(null)]
        public string Filler39 { get; set; }
        [DefaultValue(null)]
        public string Filler40 { get; set; }
        [DefaultValue(null)]
        public string Filler41 { get; set; }
        [DefaultValue(null)]
        public string Filler42 { get; set; }
        [DefaultValue(null)]
        public string Filler43 { get; set; }
        [DefaultValue(null)]
        public string Filler44 { get; set; }
        [DefaultValue(null)]
        public string Filler45 { get; set; }
        [DefaultValue(null)]
        public string Filler46 { get; set; }
        [DefaultValue(null)]
        public string Filler47 { get; set; }
        [DefaultValue(null)]
        public string Filler48 { get; set; }
        [DefaultValue(null)]
        public string Filler49 { get; set; }
        [DefaultValue(null)]
        public string Filler50 { get; set; }
        [DefaultValue(null)]
        public string Filler51 { get; set; }
        [DefaultValue(null)]
        public string Filler52 { get; set; }
        [DefaultValue(null)]
        public string Filler53 { get; set; }
        [DefaultValue(null)]
        public string Filler54 { get; set; }
        [DefaultValue(null)]
        public string Filler55 { get; set; }
        [DefaultValue(null)]
        public string Filler56 { get; set; }
        [DefaultValue(null)]
        public string Filler57 { get; set; }
        [DefaultValue(null)]
        public string Filler58 { get; set; }
        [DefaultValue(null)]
        public string Filler59 { get; set; }
        [DefaultValue(null)]
        public string Filler60 { get; set; }
        [DefaultValue(null)]
        public string Filler61 { get; set; }
        [DefaultValue(null)]
        public string Filler62 { get; set; }
        [DefaultValue(null)]
        public string Filler63 { get; set; }
        [DefaultValue(null)]
        public string Filler64 { get; set; }
        [DefaultValue(null)]
        public string Filler65 { get; set; }
        [DefaultValue(null)]
        public string Filler66 { get; set; }
        [DefaultValue(null)]
        public string Filler67 { get; set; }
        [DefaultValue(null)]
        public string Filler68 { get; set; }
        [DefaultValue(null)]
        public string Filler69 { get; set; }
        [DefaultValue(null)]
        public string Filler70 { get; set; }
        [DefaultValue(null)]
        public string Filler71 { get; set; }
        [DefaultValue(null)]
        public string Filler72 { get; set; }
        [DefaultValue(null)]
        public string Filler73 { get; set; }
        [DefaultValue(null)]
        public string Filler74 { get; set; }
        [DefaultValue(null)]
        public string Filler75 { get; set; }
        [DefaultValue(null)]
        public string Filler76 { get; set; }
        [DefaultValue(null)]
        public string Filler77 { get; set; }
        [DefaultValue(null)]
        public string Filler78 { get; set; }
        [DefaultValue(null)]
        public string Filler79 { get; set; }
        [DefaultValue(null)]
        public string Filler80 { get; set; }
        [DefaultValue(null)]
        public string Filler81 { get; set; }
        [DefaultValue(null)]
        public string Filler82 { get; set; }
        [DefaultValue(null)]
        public string Filler83 { get; set; }
        [DefaultValue(null)]
        public string Filler84 { get; set; }
        [DefaultValue(null)]
        public string Filler85 { get; set; }
        [DefaultValue(null)]
        public string Filler86 { get; set; }
        [DefaultValue(null)]
        public string Filler87 { get; set; }
        [DefaultValue(null)]
        public string Filler88 { get; set; }
        [DefaultValue(null)]
        public string Filler89 { get; set; }
        [DefaultValue(null)]
        public string Filler90 { get; set; }
        [DefaultValue(null)]
        public string Filler91 { get; set; }
        [DefaultValue(null)]
        public string Filler92 { get; set; }
        [DefaultValue(null)]
        public string Filler93 { get; set; }
        [DefaultValue(null)]
        public string Filler94 { get; set; }
        [DefaultValue(null)]
        public string Filler95 { get; set; }
        [DefaultValue(null)]
        public string Filler96 { get; set; }
        [DefaultValue(null)]
        public string Filler97 { get; set; }
    }
}
