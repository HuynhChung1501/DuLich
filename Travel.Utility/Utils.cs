using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Travel.Utility
{
    public static class Utils
    {
        //ckeck danh sách null hay không
        public static bool IsNotEmpty<T>(IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
        public static bool IsNotEmpty<T>(IList<T> data)
        {
            return data != null && data.Count() != 0;
        }
        public static bool IsNotEmpty<T>(this object data)
        {
            if (data == null) return false;
            if (data.GetType() == typeof(string))
            {
                return !string.IsNullOrEmpty(data.ToString());
            }
            else if (data.GetType() == typeof(DateTime?))
            {
                return data.HasValue();
            }
            else if (data.GetType() == typeof(IList))
            {
                var list = (IList)data;
                if (list.Count == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsNullOrEmpty([NotNullWhen(false)] string? value)
        {
            return value == null || value.Length == 0;
        }

        public static bool HasValue<T>(this T obj)
        {
            // Ensure the object is not null
            if (obj == null)
                return false;

            // Iterate through all properties of the object
            foreach (PropertyInfo info in obj.GetType().GetProperties())
            {
                try
                {
                    // Get the type of the property
                    Type propertyType = info.PropertyType;
                    var value = info.GetValue(obj);

                    // Check the value based on property type
                    if (propertyType == typeof(string))
                    {
                        if (!string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(string[]))
                    {
                        if (value is string[] array && array.Any())
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(long) || propertyType == typeof(long?))
                    {
                        if (value is long num && num > 0L)
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(long[]))
                    {
                        if (value is long[] array && array.Any())
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(int) || propertyType == typeof(int?))
                    {
                        if (value is int num && num > 0)
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(byte) || propertyType == typeof(byte?))
                    {
                        if (value is byte num && num > 0)
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(int[]))
                    {
                        if (value is int[] array && array.Any())
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(byte[]))
                    {
                        if (value is byte[] array && array.Any())
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                    {
                        if (value is bool boolValue && boolValue)
                        {
                            return true;
                        }
                    }
                    else if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
                    {
                        if (value is DateTime dateTimeValue && IsDate(dateTimeValue))
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    // Log or handle exceptions as needed
                }
            }

            return false;
        }
        public static T? Deserialize<T>(string json) where T : new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return new T();
            }
        }

        public static string Serialize<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Serialize(object obj)
        {
            return obj == null ? "" : JsonConvert.SerializeObject(obj);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64EncodedData);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Base64Encode(string plainText)
        {
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
            }
            catch
            {
                return string.Empty;
            }
        }
        public static bool IsDate(DateTime? dt)
        {
            if (!dt.HasValue)
            {
                return false;
            }
            DateTime? nullable = dt;
            DateTime minValue = DateTime.MinValue;
            if (nullable.HasValue)
            {
                return nullable.GetValueOrDefault() != minValue;
            }
            return true;
        }
        /// <summary>
        /// Lấy mô tả từ enum dựa trên giá trị int
        /// </summary>
        /// <typeparam name="TEnum">Loại enum</typeparam>
        /// <param name="intValue">Giá trị int</param>
        /// <returns>Mô tả hoặc null nếu không tìm thấy</returns>
        public static string GetEnumDescription<TEnum>(int intValue) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), intValue))
            {
                var enumValue = (TEnum)Enum.ToObject(typeof(TEnum), intValue);

                var field = typeof(TEnum).GetField(enumValue.ToString());
                var attribute = (DescriptionAttribute)field
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault();

                return attribute?.Description ?? enumValue.ToString();
            }

            return null; // Giá trị không hợp lệ
        }
        /// <summary>
        /// Lấy ra Description và truyền vào Enum Value đó 
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="value">EnumValue (Enum.value)</param>
        /// <returns></returns>
        public static string GetDescriptionByValue<T>(T value) where T : Enum
        {
            string result = string.Empty;
            Type typeFromHandle = typeof(T);
            Array enumValues = typeFromHandle.GetEnumValues();
            try
            {
                foreach (T item in enumValues)
                {
                    if (item.Equals(value))
                    {
                        MemberInfo element = typeFromHandle.GetMember(item.ToString()).First();
                        DescriptionAttribute customAttribute = element.GetCustomAttribute<DescriptionAttribute>();
                        if (customAttribute != null)
                        {
                            result = customAttribute.Description;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return result;
            }

            return result;
        }
        

    }
}
