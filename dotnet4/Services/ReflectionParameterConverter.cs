using System;
using System.Globalization;

namespace dotnet2.Services
{
    /// <summary>
    /// Преобразует строковые значения с формы в аргументы методов и конструкторов.
    /// </summary>
    public static class ReflectionParameterConverter
    {
        public static object ParseValue(string value, Type targetType)
        {
            if (targetType == null)
            {
                throw new ArgumentNullException(nameof(targetType));
            }

            Type underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (underlyingType == typeof(string))
            {
                return value ?? string.Empty;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                if (underlyingType.IsValueType)
                {
                    return Activator.CreateInstance(underlyingType);
                }

                return null;
            }

            if (underlyingType.IsEnum)
            {
                return Enum.Parse(underlyingType, value, true);
            }

            if (underlyingType == typeof(bool))
            {
                string normalized = value.Trim();
                if (string.Equals(normalized, "истина", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(normalized, "да", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(normalized, "true", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (string.Equals(normalized, "ложь", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(normalized, "нет", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(normalized, "false", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                return bool.Parse(value);
            }

            if (underlyingType == typeof(int))
            {
                return int.Parse(value, CultureInfo.InvariantCulture);
            }

            if (underlyingType == typeof(long))
            {
                return long.Parse(value, CultureInfo.InvariantCulture);
            }

            if (underlyingType == typeof(double))
            {
                return double.Parse(value, CultureInfo.InvariantCulture);
            }

            if (underlyingType == typeof(float))
            {
                return float.Parse(value, CultureInfo.InvariantCulture);
            }

            if (underlyingType == typeof(decimal))
            {
                return decimal.Parse(value, CultureInfo.InvariantCulture);
            }

            return Convert.ChangeType(value, underlyingType, CultureInfo.InvariantCulture);
        }
    }
}
