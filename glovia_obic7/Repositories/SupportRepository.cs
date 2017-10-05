using glovia_obic7.Infrastructure;
using glovia_obic7.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace glovia_obic7.Repositories
{
    public class SupportRepository : BaseRepository, ISupportRepository, IDisposable
    {
        public SupportRepository() { }

        private int Digit(int num)
        {
            try
            {
                return (num == 0) ? 1 : ((int)Math.Log10(num) + 1);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int StringToInteger(string src, int size = 0)
        {
            try
            {
                if (src == null || string.IsNullOrEmpty(src))
                {
                    throw new ArgumentNullException(RepositoryResource.ParamaterName_src, RepositoryResource.NullExceptionMessage);
                }
                if (size < 0)
                {
                    throw new ArgumentOutOfRangeException(RepositoryResource.ParamaterName_size, RepositoryResource.MustPositiveNumber);
                }
                var result = int.Parse(src);
                if (size > 0 && Digit(result) > size)
                {
                    throw new ArithmeticException(RepositoryResource.OverflowMessage);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int StringToIntegerOrDefault(string src, int size = 0, int defaultValue = 0)
        {
            try
            {
                return StringToInteger(src, size);
            }
            catch
            {
                return defaultValue;
            }
        }

        public string StringToString(string src, int size)
        {
            if (src == null)
            {
                throw new ArgumentNullException(RepositoryResource.ParamaterName_src, RepositoryResource.NullExceptionMessage);
            }
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(RepositoryResource.ParamaterName_size, RepositoryResource.MustPositiveNumber);
            }

            Encoding e = Encoding.GetEncoding(RepositoryResource.ReadFileEncod);
            string result = new String(src.TakeWhile((c, i) => e.GetByteCount(src.Substring(0, i + 1)) <= size).ToArray());
            return result;
        }

        public decimal GamountToDecimal(string src)
        {
            if (src == null)
            {
                throw new ArgumentNullException(RepositoryResource.ParamaterName_src, RepositoryResource.NullExceptionMessage);
            }
            string sign = src.Substring(0, 1);
            string data = src.Substring(1, src.Length - 1);
            var result = decimal.Parse(data);
            if (sign == RepositoryResource.MinusSignString)
            {
                result *= -1;
            }
            return result;
        }

        public List<GloviaIppanModel> ReadGloviaIppan(string filename)
        {
            return ReadGloviaIppan<GloviaIppanModel>(filename);
        }

        private List<T> ReadGloviaIppan<T>(string filename) where T : IGloviaModel, new()
        {
            try
            {
                string[] lines = File.ReadAllLines(filename, Encoding.GetEncoding(RepositoryResource.ReadFileEncod));
                List<T> glovia = new List<T>();
                foreach (var line in lines)
                {
                    T addModel = new T();
                    var tmps = line.AsDynamic();
                    tmps(InpputNo: 8, InpputSystem: 3, CompanyCode: 12, InputUserCode: 12, InputDepartmentCode: 12,
                        ApprovalUserCode: 12, ApprovalDate: 8, ApprovalState: 1, JournalCategory: 2,
                        VoucherDate: 8, VoucherNo: 8, VoucherDisableState: 1, VoucherComment: 64,
                        Rows: 9, DebitCredit: 1, AccountTitleCode: 12, AccountDepartmentCode: 12, ParticularsIdentify: 4, ParticularsCode: 12, BreakdownIdentify: 4, BreakdownCode: 12, ExtensionIdentify1: 4, ExtensionCode1: 12, ExtensionIdentify2: 4, ExtensionCode2: 12, ExtensionIdentify3: 4, ExtensionCode3: 12, ExtensionIdentify4: 4, ExtensionCode4: 12, ExtensionIdentify5: 4, ExtensionCode5: 12,
                        CustomerCode: 12, SegmentCode: 12, CurrencyCode: 4, FundCode: 12, TaxCategory: 4, TaxRateCode: 2, BaseAmount: 20, CurrenyCodeAmount: 20, ReferenceTaxAmount: 20, TaxationCategory: 1, RecordPropertyCode: 12,
                        SystemReserved01: 12, SystemReserved02: 12, SystemReserved03: 4, SystemReserved04: 12, SystemReserved05: 4, SystemReserved06: 12, SystemReserved07: 4, SystemReserved08: 12, SystemReserved09: 4, SystemReserved10: 12, SystemReserved11: 4, SystemReserved12: 12, SystemReserved13: 4, SystemReserved14: 12, SystemReserved15: 4, SystemReserved16: 12, SystemReserved17: 12, SystemReserved18: 12, SystemReserved19: 4, SystemReserved20: 2, SystemReserved21: 4, SystemReserved22: 12,
                        Remarks1: 64, SeikyuSiharaisakiCode: 12, SystemReserved23: 4, ContractNo: 8, SystemReserved24: 4, SystemReserved25: 4, InvoiceNo: 12, SystemReserved26: 4, CollectDepertmentCode: 12, CollectPlanDate: 8, PaymentClosingDate: 8, UpdateSubsystem: 1, SystemReserved27: 4,
                        PropertyManagedNo: 12, NotesNo: 12, NotesCategory: 1, NotesType: 1, TransitionType: 2, NotesClosingDate: 8, SystemReserved28: 1, PaymentInfoDate: 8, CashBillDate: 8, NotesSite: 4, SystemReserved29: 4, SystemReserved30: 15, FuridashiName: 64, PaymentBankCode: 12, PaymentPlace: 32, NotesBankCode: 12, NotesChargeAmount: 13,
                        DenbunType: 1, ChargeType: 1, FbType: 1, MyBankType: 1, MyBankNo: 12, OtherBankType: 1, OtherBankNo: 12, SystemReserved31: 22, KeshikomiCategory: 4, KeshikomiKey: 12, SystemReserved32: 340);
                    var infoArray = addModel.GetType().GetMembers();
                    foreach (var info in infoArray)
                    {
                        if (info.MemberType == MemberTypes.Property)
                        {
                            var pr = addModel.GetType().GetProperty(info.Name);
                            string str = tmps[info.Name];
                            str = str.TrimEnd();
                            if (pr.PropertyType == str.GetType())
                            {
                                pr.SetValue(addModel, str);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(str))
                                {
                                    pr.SetValue(addModel, int.Parse(str));
                                }
                            }
                        }
                    }
                    glovia.Add(addModel);
                }
                return glovia;
                // return glovia.OrderBy(x => x.InpputNo).ThenBy(x => x.Rows).ThenBy(x => x.DebitCredit).ToList();
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return null;
            }
        }

        public List<GloviaTorihikisakiModel> ReadGloviaTorihiki(string filename)
        {
            return ReadGloviaTorihiki<GloviaTorihikisakiModel>(filename);
        }

        private List<T> ReadGloviaTorihiki<T>(string filename) where T : IGloviaModel, new()
        {
            try
            {
                string[] lines = File.ReadAllLines(filename, Encoding.GetEncoding(RepositoryResource.ReadFileEncod));
                List<T> glovia = new List<T>();
                foreach (var line in lines)
                {
                    T addModel = new T();
                    var tmps = line.AsDynamic();
                    tmps(CompanyCode: 12, Code: 12, IdentityKbn: 3, FromDate: 8, ToDate: 8, Name: 64, ShortName: 16, DispOrderName: 12,
                        SeikyusakiCode: 12, PaymentCode: 12, HolidayPatternCode: 5, BusinessDayKbn: 1, SpotKbn: 1,
                        ZipCode1: 3, ZipCode2: 4, Address1: 64, Address2: 64, Tel: 15, Fax: 15, Mobile: 15, Email: 64,
                        BushoName: 64, TantoName: 16, MyBushoName: 64, MyTantoName: 16, UserArea: 64);
                    var infoArray = addModel.GetType().GetMembers();
                    foreach (var info in infoArray)
                    {
                        if (info.MemberType == MemberTypes.Property)
                        {
                            var pr = addModel.GetType().GetProperty(info.Name);
                            string str = tmps[info.Name];
                            str = str.TrimEnd();
                            if (pr.PropertyType == str.GetType())
                            {
                                pr.SetValue(addModel, str);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(str))
                                {
                                    pr.SetValue(addModel, int.Parse(str));
                                }
                            }
                        }
                    }
                    glovia.Add(addModel);
                }
                return glovia;
            }
            catch (Exception ex)
            {
                SystemLogger.Error(ex);
                return null;
            }
        }

        public List<T> ReadGlovia<T>(string filename) where T : IGloviaModel, new()
        {
            if (typeof(T) == typeof(GloviaIppanModel))
            {
                return ReadGloviaIppan<T>(filename);
            }
            if (typeof(T) == typeof(GloviaTorihikisakiModel))
            {
                return ReadGloviaTorihiki<T>(filename);
            }
            return null;
        }

        public void Dispose() { }
    }
}
