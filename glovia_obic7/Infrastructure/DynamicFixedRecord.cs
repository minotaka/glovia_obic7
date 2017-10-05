using System;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace glovia_obic7.Infrastructure
{
    public static class StringExtensions
    {
        public static dynamic AsDynamic(this string fixedRecord)
        {
            return new DynamicFixedRecord(fixedRecord);
        }
    }

    public class DynamicFixedRecord : DynamicObject
    {
        private NameValueCollection source;
        private string fixedRecord;

        public DynamicFixedRecord(string fixedRecord)
        {
            this.source = new NameValueCollection();
            this.fixedRecord = fixedRecord;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var value = source[(string)indexes[0]];
            result = new StringMember(value);
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var value = source[binder.Name];
            result = new StringMember(value);
            return true;
        }

        private static string MidB(string stTarget, int iStart, int iByteSize)
        {
            Encoding hEncoding = Encoding.GetEncoding("Shift_JIS");
            byte[] btBytes = hEncoding.GetBytes(stTarget);

            return hEncoding.GetString(btBytes, iStart, iByteSize);
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            var startIndex = 0;
            source.Clear();
            foreach (var item in binder.CallInfo.ArgumentNames.Zip(args, (key, value) => new { key, value }))
            {
                var length = Int32.Parse(item.value.ToString());
                source.Add(item.key, MidB(fixedRecord, startIndex, length));
                startIndex += length;
            }

            result = this;
            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type != typeof(string))
            {
                result = null;
                return false;
            }
            else
            {
                result = this.ToString();
                return true;
            }
        }

        public override string ToString()
        {
            return string.Join(", ",
              source.Cast<string>().Select(key => key + ":" + source[key]));
        }
    }

    class StringMember : DynamicObject
    {
        readonly string value;

        public StringMember(string value)
        {
            this.value = value;
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            var defaultValue = args.First();

            try
            {
                result = (value == null)
                    ? defaultValue
                    : Convert.ChangeType(value, defaultValue.GetType());
            }
            catch (FormatException)
            {
                result = defaultValue;
            }

            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            try
            {
                var type = (binder.Type.IsGenericType
                  && binder.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    ? binder.Type.GetGenericArguments().First()
                    : binder.Type;

                result = (value == null)
                    ? null
                    : type == typeof(DateTime)
                      ? DateTime.ParseExact(value,
                        new[] { "yyyyMMdd", "yyyy/MM/dd", "yyMMdd", "yy/MM/dd" },
                        null,
                        System.Globalization.DateTimeStyles.None)
                      : Convert.ChangeType(value, binder.Type);
            }
            catch (FormatException)
            {
                result = null;
            }

            return true;
        }

        public override string ToString()
        {
            return value ?? "";
        }
    }
}
