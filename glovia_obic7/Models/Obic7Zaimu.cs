using CsvHelper.Configuration;
using System;
using System.ComponentModel;

namespace glovia_obic7.Models
{
    public class Obic7ZaimuMap : CsvClassMap<Obic7Zaimu>
    {
        public Obic7ZaimuMap()
        {
            Map(m => m.CompanyCode).Name("会社コード");
            Map(m => m.DenpyoNo).Name("伝票№");
            Map(m => m.DenpyoDate).Name("発生日");
            Map(m => m.SystemCategory).Name("ｼｽﾃﾑ分類");
            Map(m => m.Site).Name("サイト");
            Map(m => m.SiwakeKbn).Name("仕訳区分");
            Map(m => m.DenpyoKbn).Name("伝票区分");
            Map(m => m.JigyoshoCode).Name("事業所コード");
            Map(m => m.Rows).Name("行№");
            Map(m => m.KariKamokuCode).Name("借方勘定科目コード");
            Map(m => m.KariHojoCode).Name("借方補助科目コード");
            Map(m => m.KariHojoUchiwakeCode).Name("借方補助内訳科目コード");
            Map(m => m.KariBumonCode).Name("借方部門コード");
            Map(m => m.KariTorihikisakiCode).Name("借方取引先コード");
            Map(m => m.KariTaxKbn).Name("借方税区分");
            Map(m => m.KariTaxationKbn).Name("借方税込区分");
            Map(m => m.KariAmount).Name("借方金額");
            Map(m => m.KariTaxAmount).Name("借方消費税額");
            Map(m => m.KariTaxKamokuCode).Name("借方消費税本体科目コード");
            Map(m => m.KariBunsekiCode1).Name("借方分析コード１");
            Map(m => m.KariBunsekiCode2).Name("借方分析コード２");
            Map(m => m.KariBunsekiCode3).Name("借方分析コード３");
            Map(m => m.KariBunsekiCode4).Name("借方分析コード４");
            Map(m => m.KariBunsekiCode5).Name("借方分析コード５");
            Map(m => m.KariFundCode).Name("借方資金コード");
            Map(m => m.KariProjectCode).Name("借方プロジェクトコード");
            Map(m => m.KashiKamokuCode).Name("貸方勘定科目コード");
            Map(m => m.KashiHojoCode).Name("貸方補助科目コード");
            Map(m => m.KashiHojoUchiwakeCode).Name("貸方補助内訳科目コード");
            Map(m => m.KashiBumonCode).Name("貸方部門コード");
            Map(m => m.KashiTorihikisakiCode).Name("貸方取引先コード");
            Map(m => m.KashiTaxKbn).Name("貸方税区分");
            Map(m => m.KashiTaxationKbn).Name("貸方税込区分");
            Map(m => m.KashiAmount).Name("貸方金額");
            Map(m => m.KashiTaxAmount).Name("貸方消費税額");
            Map(m => m.KashiTaxKamokuCode).Name("貸方消費税本体科目コード");
            Map(m => m.KashiBunsekiCode1).Name("貸方分析コード１");
            Map(m => m.KashiBunsekiCode2).Name("貸方分析コード２");
            Map(m => m.KashiBunsekiCode3).Name("貸方分析コード３");
            Map(m => m.KashiBunsekiCode4).Name("貸方分析コード４");
            Map(m => m.KashiBunsekiCode5).Name("貸方分析コード５");
            Map(m => m.KashiFundCode).Name("貸方資金コード");
            Map(m => m.KashiProjectCode).Name("貸方プロジェクトコード");
            Map(m => m.MeisaiComment).Name("明細摘要");
            Map(m => m.DenpyoComment).Name("伝票摘要");
            Map(m => m.UserId).Name("UserID");
            Map(m => m.KariJigyoshoCode).Name("借方事業所コード");
            Map(m => m.KashiiJigyoshoCode).Name("貸方事業所コード");
        }
    }

    public class Obic7Zaimu : BaseModel
    {
        public int CompanyCode { get; set; }

        public string DenpyoNo { get; set; }

        public DateTime DenpyoDate { get; set; }

        [DefaultValue(0)]   // 50
        public int SystemCategory { get; set; }
        [DefaultValue(null)]
        public int? Site { get; set; }
        public int SiwakeKbn { get; set; }
        [DefaultValue(10)]
        public string DenpyoKbn { get; set; }
        [DefaultValue("1")]
        public string JigyoshoCode { get; set; }
        public int Rows { get; set; }

        public string KariKamokuCode { get; set; }
        public string KariHojoCode { get; set; }
        [DefaultValue(null)]
        public string KariHojoUchiwakeCode { get; set; }
        public string KariBumonCode { get; set; }
        public string KariTorihikisakiCode { get; set; }
        public string KariTaxKbn { get; set; }
        public int KariTaxationKbn { get; set; }
        public decimal? KariAmount { get; set; }
        [DefaultValue(null)]
        public decimal? KariTaxAmount { get; set; }
        public string KariTaxKamokuCode { get; set; }
        public string KariBunsekiCode1 { get; set; }
        public string KariBunsekiCode2 { get; set; }
        public string KariBunsekiCode3 { get; set; }
        [DefaultValue(null)]
        public string KariBunsekiCode4 { get; set; }
        [DefaultValue(null)]
        public string KariBunsekiCode5 { get; set; }
        [DefaultValue(null)]
        public string KariFundCode { get; set; }
        [DefaultValue(null)]
        public string KariProjectCode { get; set; }

        public string KashiKamokuCode { get; set; }
        public string KashiHojoCode { get; set; }
        [DefaultValue(null)]
        public string KashiHojoUchiwakeCode { get; set; }
        public string KashiBumonCode { get; set; }
        public string KashiTorihikisakiCode { get; set; }
        public string KashiTaxKbn { get; set; }
        public int KashiTaxationKbn { get; set; }
        public decimal? KashiAmount { get; set; }
        [DefaultValue(null)]
        public decimal? KashiTaxAmount { get; set; }
        public string KashiTaxKamokuCode { get; set; }
        public string KashiBunsekiCode1 { get; set; }
        public string KashiBunsekiCode2 { get; set; }
        public string KashiBunsekiCode3 { get; set; }
        [DefaultValue(null)]
        public string KashiBunsekiCode4 { get; set; }
        [DefaultValue(null)]
        public string KashiBunsekiCode5 { get; set; }
        [DefaultValue(null)]
        public string KashiFundCode { get; set; }
        [DefaultValue(null)]
        public string KashiProjectCode { get; set; }

        public string MeisaiComment { get; set; }
        [DefaultValue(null)]
        public string DenpyoComment { get; set; }

        [DefaultValue(null)]
        public string UserId { get; set; }
        [DefaultValue(null)]
        public string KashiiJigyoshoCode { get; set; }
        [DefaultValue(null)]
        public string KariJigyoshoCode { get; set; }
    }
}
