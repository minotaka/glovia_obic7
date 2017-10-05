namespace glovia_obic7.Models
{
    public class GloviaTorihikisakiModel : IGloviaModel
    {
        /// <summary>
        /// 会社コード
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// 取引先コード
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 世代識別区分
        /// </summary>
        public int IdentityKbn { get; set; }

        /// <summary>
        /// 有効開始日付
        /// </summary>
        public string FromDate { get; set; }

        /// <summary>
        /// 有効終了日付
        /// </summary>
        public string ToDate { get; set; }

        /// <summary>
        /// 取引先長名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 取引先短名称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 名称表示順名称
        /// </summary>
        public string DispOrderName { get; set; }

        /// <summary>
        /// 請求先コード
        /// </summary>
        public string SeikyusakiCode { get; set; }

        /// <summary>
        /// 支払先コード
        /// </summary>
        public string PaymentCode { get; set; }

        /// <summary>
        /// 休日パターンコード
        /// </summary>
        public string HolidayPatternCode { get; set; }

        /// <summary>
        /// 営業日調整区分
        /// </summary>
        public string BusinessDayKbn { get; set; }

        /// <summary>
        /// スポット支払い区分
        /// </summary>
        public string SpotKbn { get; set; }

        /// <summary>
        /// 郵便番号前
        /// </summary>
        public string ZipCode1 { get; set; }

        /// <summary>
        /// 郵便番号後
        /// </summary>
        public string ZipCode2 { get; set; }

        /// <summary>
        /// 住所前
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// 住所後
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// ＦＡＸ番号
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 携帯番号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 担当部署名
        /// </summary>
        public string BushoName { get; set; }

        /// <summary>
        /// 担当者名
        /// </summary>
        public string TantoName { get; set; }

        /// <summary>
        /// 自社担当部署名
        /// </summary>
        public string MyBushoName { get; set; }

        /// <summary>
        /// 自社担当者名
        /// </summary>
        public string MyTantoName { get; set; }

        /// <summary>
        /// ユーザー開放域
        /// </summary>
        public string UserArea { get; set; }
    }
}
