using CsvHelper.Configuration;
using System;
using System.ComponentModel;

namespace glovia_obic7.Models
{
    public class Obic7TorihikiMap : CsvClassMap<Obic7Torihiki>
    {
        public Obic7TorihikiMap()
        {
            Map(m => m.Code).Name("取引先コード");
            Map(m => m.ModifiedDate).Name("取引先コード改定日");
            Map(m => m.Name1).Name("取引先正式名1");
            Map(m => m.Name2).Name("取引先正式名2");
            Map(m => m.BushoName).Name("取引先部署名");
            Map(m => m.NickName).Name("社内用取引先名");
            Map(m => m.ShortName).Name("取引先略名");
            Map(m => m.Furigana).Name("取引先フリガナ");
            Map(m => m.ZipCode1).Name("取引先郵便番号1(上3桁)");
            Map(m => m.ZipCode2).Name("取引先郵便番号2(下4桁)");
            Map(m => m.Address1).Name("取引先住所1");
            Map(m => m.Address2).Name("取引先住所2");
            Map(m => m.Address3).Name("取引先住所3");
            Map(m => m.Tel1AreaCode).Name("取引先電話番号1市外局番");
            Map(m => m.Tel1LocalNumber).Name("取引先電話番号1市内局番");
            Map(m => m.Tel1).Name("取引先電話番号1");
            Map(m => m.Tel1ExtensionNumber).Name("取引先内線番号1");
            Map(m => m.Tel2AreaCode).Name("取引先電話番号2市外局番");
            Map(m => m.Tel2LocalNumber).Name("取引先電話番号2市内局番");
            Map(m => m.Tel2).Name("取引先電話番号2");
            Map(m => m.Tel2ExtensionNumber).Name("取引先内線番号2");
            Map(m => m.FaxAreaCode).Name("取引先FAX番号市外局番");
            Map(m => m.FaxLocalNumber).Name("取引先FAX番号市内局番");
            Map(m => m.Fax).Name("取引先FAX電話番号");
            Map(m => m.TantoBushoName).Name("取引先担当部署名");
            Map(m => m.TantoPositionName).Name("取引先担当役職名");
            Map(m => m.TantoName).Name("取引先担当者名");
            Map(m => m.EMail).Name("メールアドレス");
            Map(m => m.LeaseKbn).Name("リース会社区分");
            Map(m => m.TaxOfficeKbn).Name("税務署区分");
            Map(m => m.SpotKbn).Name("スポット区分");
            Map(m => m.InterfaceKbn).Name("インターフェイス区分");
            Map(m => m.EnabledKbn).Name("取引有効区分");
            Map(m => m.SearchString).Name("検索用取引分類");
            Map(m => m.SupplierKbn).Name("仕入先区分");
            Map(m => m.PaymentKbn).Name("支払先区分");
            Map(m => m.TokuisakiKbn).Name("得意先区分");
            Map(m => m.KaisyuKbn).Name("回収先区分");
            Map(m => m.Kbn1).Name("取引先区分1");
            Map(m => m.Kbn2).Name("取引先区分2");
            Map(m => m.Kbn3).Name("取引先区分3");
            Map(m => m.Kbn4).Name("取引先区分4");
            Map(m => m.SitaukeKbn).Name("下請事業者区分");
            Map(m => m.CorporationKbn).Name("法人区分");
            Map(m => m.CorporationNumber).Name("法人番号");
            Map(m => m.JigyoshoCode).Name("事業所コード");
        }
    }

    public class Obic7Torihiki : BaseModel
    {
        public string Code { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name1 { get; set; }
        [DefaultValue(null)]
        public string Name2 { get; set; }
        [DefaultValue(null)]
        public string BushoName { get; set; }
        public string NickName { get; set; }
        public string ShortName { get; set; }
        [DefaultValue(null)]
        public string Furigana { get; set; }

        public string ZipCode1 { get; set; }
        public string ZipCode2 { get; set; }
        [DefaultValue(null)]
        public string Address1 { get; set; }
        [DefaultValue(null)]
        public string Address2 { get; set; }
        [DefaultValue(null)]
        public string Address3 { get; set; }

        [DefaultValue(null)]
        public string Tel1AreaCode { get; set; }
        [DefaultValue(null)]
        public string Tel1LocalNumber { get; set; }
        [DefaultValue(null)]
        public string Tel1 { get; set; }
        [DefaultValue(null)]
        public string Tel1ExtensionNumber { get; set; }

        [DefaultValue(null)]
        public string Tel2AreaCode { get; set; }
        [DefaultValue(null)]
        public string Tel2LocalNumber { get; set; }
        [DefaultValue(null)]
        public string Tel2 { get; set; }
        [DefaultValue(null)]
        public string Tel2ExtensionNumber { get; set; }

        [DefaultValue(null)]
        public string FaxAreaCode { get; set; }
        [DefaultValue(null)]
        public string FaxLocalNumber { get; set; }
        [DefaultValue(null)]
        public string Fax { get; set; }

        [DefaultValue(null)]
        public string TantoBushoName { get; set; }
        [DefaultValue(null)]
        public string TantoPositionName { get; set; }
        [DefaultValue(null)]
        public string TantoName { get; set; }
        [DefaultValue(null)]
        public string EMail { get; set; }

        [DefaultValue(0)]
        public int LeaseKbn { get; set; }
        [DefaultValue(0)]
        public int TaxOfficeKbn { get; set; }
        [DefaultValue(0)]
        public int SpotKbn { get; set; }
        [DefaultValue(0)]
        public int InterfaceKbn { get; set; }
        [DefaultValue(0)]
        public int EnabledKbn { get; set; }
        [DefaultValue(0)]
        public string SearchString { get; set; }
        [DefaultValue(0)]
        public int SupplierKbn { get; set; }
        [DefaultValue(0)]
        public int PaymentKbn { get; set; }
        [DefaultValue(0)]
        public int TokuisakiKbn { get; set; }
        [DefaultValue(0)]
        public int KaisyuKbn { get; set; }
        [DefaultValue(0)]
        public int Kbn1 { get; set; }
        [DefaultValue(0)]
        public int Kbn2 { get; set; }
        [DefaultValue(0)]
        public int Kbn3 { get; set; }
        [DefaultValue(0)]
        public int Kbn4 { get; set; }
        [DefaultValue(0)]
        public int SitaukeKbn { get; set; }
        [DefaultValue(0)]
        public int CorporationKbn { get; set; }
        [DefaultValue(null)]
        public int? CorporationNumber { get; set; }
        [DefaultValue(null)]
        public int? JigyoshoCode { get; set; }
    }
}
