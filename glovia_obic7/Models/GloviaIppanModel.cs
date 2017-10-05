namespace glovia_obic7.Models
{
    public class GloviaIppanModel : IGloviaModel
    {
        /// <summary>
        /// 入力番号
        /// </summary>
        public int InpputNo { get; set; }

        /// <summary>
        /// 入力システム区分
        /// </summary>
        public string InpputSystem { get; set; }

        /// <summary>
        /// 会社コード
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// 起票社員コード
        /// </summary>
        public string InputUserCode { get; set; }

        /// <summary>
        /// 起票部門コード
        /// </summary>
        public string InputDepartmentCode { get; set; }

        /// <summary>
        /// 商品社員コード
        /// </summary>
        public string ApprovalUserCode { get; set; }

        /// <summary>
        /// 承認日付
        /// </summary>
        public string ApprovalDate { get; set; }

        /// <summary>
        /// 承認状態区分
        /// </summary>
        public string ApprovalState { get; set; }

        /// <summary>
        /// 仕訳伝票区分
        /// </summary>
        public string JournalCategory { get; set; }

        /// <summary>
        /// 伝票日付
        /// </summary>
        public string VoucherDate { get; set; }

        /// <summary>
        /// 伝票番号
        /// </summary>
        public int? VoucherNo { get; set; }

        /// <summary>
        /// 伝票操作禁止区分
        /// </summary>
        public string VoucherDisableState { get; set; }

        /// <summary>
        /// 伝票備考
        /// </summary>
        public string VoucherComment { get; set; }

        /// <summary>
        /// 行番号
        /// </summary>
        public string Rows { get; set; }

        /// <summary>
        /// 伝票明細貸借区分
        /// </summary>
        public string DebitCredit { get; set; }

        /// <summary>
        /// 勘定科目コード
        /// </summary>
        public string AccountTitleCode { get; set; }

        /// <summary>
        /// 会計部門コード
        /// </summary>
        public string AccountDepartmentCode { get; set; }

        /// <summary>
        /// 細目コード識別区分
        /// </summary>
        public string ParticularsIdentify { get; set; }

        /// <summary>
        /// 細目コード
        /// </summary>
        public string ParticularsCode { get; set; }

        /// <summary>
        /// 内訳コード識別区分
        /// </summary>
        public string BreakdownIdentify { get; set; }

        /// <summary>
        /// 内訳コード
        /// </summary>
        public string BreakdownCode { get; set; }

        /// <summary>
        /// 集計拡張コード識別区分
        /// </summary>
        public string ExtensionIdentify1 { get; set; }
        /// <summary>
        /// 集計拡張コード
        /// </summary>
        public string ExtensionCode1 { get; set; }
        /// <summary>
        /// 集計拡張コード識別区分
        /// </summary>
        public string ExtensionIdentify2 { get; set; }
        /// <summary>
        /// 集計拡張コード
        /// </summary>
        public string ExtensionCode2 { get; set; }
        /// <summary>
        /// 集計拡張コード識別区分
        /// </summary>
        public string ExtensionIdentify3 { get; set; }
        /// <summary>
        /// 集計拡張コード
        /// </summary>
        public string ExtensionCode3 { get; set; }
        /// <summary>
        /// 集計拡張コード識別区分
        /// </summary>
        public string ExtensionIdentify4 { get; set; }
        /// <summary>
        /// 集計拡張コード
        /// </summary>
        public string ExtensionCode4 { get; set; }
        /// <summary>
        /// 集計拡張コード識別区分
        /// </summary>
        public string ExtensionIdentify5 { get; set; }
        /// <summary>
        /// 集計拡張コード
        /// </summary>
        public string ExtensionCode5 { get; set; }

        /// <summary>
        /// 取引先コード
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// セグメントコード
        /// </summary>
        public string SegmentCode { get; set; }
        /// <summary>
        /// 取引通貨コード
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 資金コード
        /// </summary>
        public string FundCode { get; set; }

        /// <summary>
        /// 消費税区分コード
        /// </summary>
        public string TaxCategory { get; set; }
        /// <summary>
        /// 税率区分
        /// </summary>
        public string TaxRateCode { get; set; }
        /// <summary>
        /// 基本通貨発生金額
        /// </summary>
        public string BaseAmount { get; set; }
        /// <summary>
        /// 取引通貨発生金額
        /// </summary>
        public string CurrenyCodeAmount { get; set; }

        /// <summary>
        /// 参考消費税金額
        /// </summary>
        public string ReferenceTaxAmount { get; set; }
        /// <summary>
        /// 課税区分
        /// </summary>
        public string TaxationCategory { get; set; }
        /// <summary>
        /// 履歴物件コード
        /// </summary>
        public string RecordPropertyCode { get; set; }
        public string SystemReserved01 { get; set; }
        public string SystemReserved02 { get; set; }
        public string SystemReserved03 { get; set; }
        public string SystemReserved04 { get; set; }
        public string SystemReserved05 { get; set; }
        public string SystemReserved06 { get; set; }
        public string SystemReserved07 { get; set; }
        public string SystemReserved08 { get; set; }
        public string SystemReserved09 { get; set; }
        public string SystemReserved10 { get; set; }
        public string SystemReserved11 { get; set; }
        public string SystemReserved12 { get; set; }
        public string SystemReserved13 { get; set; }
        public string SystemReserved14 { get; set; }
        public string SystemReserved15 { get; set; }
        public string SystemReserved16 { get; set; }
        public string SystemReserved17 { get; set; }
        public string SystemReserved18 { get; set; }
        public string SystemReserved19 { get; set; }
        public string SystemReserved20 { get; set; }
        public string SystemReserved21 { get; set; }
        public string SystemReserved22 { get; set; }

        /// <summary>
        /// 文字摘要１
        /// </summary>
        public string Remarks1 { get; set; }
        /// <summary>
        /// 請求支払先コード
        /// </summary>
        public string SeikyuSiharaisakiCode { get; set; }
        public string SystemReserved23 { get; set; }
        /// <summary>
        /// 契約番号
        /// </summary>
        public string ContractNo { get; set; }
        public string SystemReserved24 { get; set; }
        public string SystemReserved25 { get; set; }
        /// <summary>
        /// インボイス番号
        /// </summary>
        public string InvoiceNo { get; set; }
        public string SystemReserved26 { get; set; }
        /// <summary>
        /// 回収支払部門コード
        /// </summary>
        public string CollectDepertmentCode { get; set; }
        /// <summary>
        /// 回収支払予定日付
        /// </summary>
        public string CollectPlanDate { get; set; }
        /// <summary>
        /// 請求支払締め日付
        /// </summary>
        public string PaymentClosingDate { get; set; }
        /// <summary>
        /// 更新サブシステム区分
        /// </summary>
        public string UpdateSubsystem { get; set; }
        public string SystemReserved27 { get; set; }
        /// <summary>
        /// 物件管理番号
        /// </summary>
        public string PropertyManagedNo { get; set; }
        /// <summary>
        /// 手形番号
        /// </summary>
        public string NotesNo { get; set; }
        /// <summary>
        /// 手形種別区分
        /// </summary>
        public string NotesCategory { get; set; }
        /// <summary>
        /// 手形区分
        /// </summary>
        public string NotesType { get; set; }
        /// <summary>
        /// 推移区分
        /// </summary>
        public string TransitionType { get; set; }
        /// <summary>
        /// 手形期日「期日現金決済日」
        /// </summary>
        public string NotesClosingDate { get; set; }
        public string SystemReserved28 { get; set; }
        /// <summary>
        /// 取組日付「支払通知日付」
        /// </summary>
        public string PaymentInfoDate { get; set; }
        /// <summary>
        /// 現金化予定日付
        /// </summary>
        public string CashBillDate { get; set; }
        /// <summary>
        /// 手形サイト
        /// </summary>
        public string NotesSite { get; set; }
        public string SystemReserved29 { get; set; }
        public string SystemReserved30 { get; set; }
        /// <summary>
        /// 振出人名称「自社銀行口座名義人」「相手銀行口座名義人」
        /// </summary>
        public string FuridashiName { get; set; }
        /// <summary>
        /// 支払場所銀行コード「相手銀行コード」
        /// </summary>
        public string PaymentBankCode { get; set; }
        /// <summary>
        /// 支払場所
        /// </summary>
        public string PaymentPlace { get; set; }
        /// <summary>
        /// 手形取組銀行コード「自社銀行コード」
        /// </summary>
        public string NotesBankCode { get; set; }
        /// <summary>
        /// 手形割引手数料
        /// </summary>
        public string NotesChargeAmount { get; set; }
        /// <summary>
        /// 電信文書振込区分
        /// </summary>
        public string DenbunType { get; set; }
        /// <summary>
        /// 手数料負担区分
        /// </summary>
        public string ChargeType { get; set; }
        /// <summary>
        /// FB振込処理区分
        /// </summary>
        public string FbType { get; set; }
        /// <summary>
        /// 自社銀行口座種別
        /// </summary>
        public string MyBankType { get; set; }
        /// <summary>
        /// 自社銀行口座番号
        /// </summary>
        public string MyBankNo { get; set; }
        /// <summary>
        /// 相手銀行口座種別
        /// </summary>
        public string OtherBankType { get; set; }
        /// <summary>
        /// 相手銀行口座番号
        /// </summary>
        public string OtherBankNo { get; set; }
        public string SystemReserved31 { get; set; }
        /// <summary>
        /// 個別消込キー識別区分
        /// </summary>
        public string KeshikomiCategory { get; set; }
        /// <summary>
        /// 個別消込キー
        /// </summary>
        public string KeshikomiKey { get; set; }
        public string SystemReserved32 { get; set; }
    }
}
