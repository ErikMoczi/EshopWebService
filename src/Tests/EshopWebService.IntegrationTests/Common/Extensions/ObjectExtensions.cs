using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace EshopWebService.IntegrationTests.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void ToHttpQuery(this object data, StringBuilder stringBuilder)
        {
            if (data == null)
            {
                return;
            }

            stringBuilder.Append("?");

            foreach (var pair in JObject.FromObject(data))
            {
                if (pair.Value.Type == JTokenType.Array)
                {
                    stringBuilder.Append(pair.Key).Append("[]=");
                    foreach (var jToken in pair.Value)
                    {
                        stringBuilder.Append(Uri.EscapeDataString(ConvertToString(jToken, CultureInfo.InvariantCulture))).Append('&');
                    }
                }
                else
                {
                    stringBuilder.AppendFormat(
                        "{0}={1}&",
                        Uri.EscapeDataString(pair.Key),
                        Uri.EscapeDataString(ConvertToString(pair.Value, CultureInfo.InvariantCulture))
                    );
                }
            }

            stringBuilder.Length--;
        }

        public static string ConvertToString(object value, IFormatProvider cultureInfo)
        {
            switch (value)
            {
                case null:
                {
                    return string.Empty;
                }
                case Enum _:
                {
                    var name = Enum.GetName(value.GetType(), value);
                    if (name != null)
                    {
                        var field = value.GetType().GetTypeInfo().GetDeclaredField(name);
                        if (field != null)
                        {
                            if (field.GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                            {
                                return attribute.Value ?? name;
                            }
                        }

                        var converted = Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                        return converted;
                    }

                    break;
                }
                case bool b:
                {
                    return Convert.ToString(b, cultureInfo).ToLowerInvariant();
                }
                case byte[] bytes:
                {
                    return Convert.ToBase64String(bytes);
                }
                default:
                {
                    if (value.GetType().IsArray)
                    {
                        var array = ((Array)value).OfType<object>();
                        return string.Join(",", array.Select(o => ConvertToString(o, cultureInfo)));
                    }

                    break;
                }
            }

            var result = Convert.ToString(value, cultureInfo);
            return result ?? string.Empty;
        }
    }
}