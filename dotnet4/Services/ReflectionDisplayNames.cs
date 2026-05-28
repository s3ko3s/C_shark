using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace dotnet2.Services
{
    /// <summary>
    /// Русские подписи для имён типов, методов, свойств и параметров в интерфейсе.
    /// </summary>
    public static class ReflectionDisplayNames
    {
        private static readonly Dictionary<string, string> EnglishToRussian =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["Airplane"] = "Самолёт",
                ["Helicopter"] = "Вертолёт",
                ["FlyingMachine"] = "Летательный аппарат",
                ["TakeOff"] = "Взлететь",
                ["Land"] = "Приземлиться",
                ["GetInfo"] = "Получить сведения",
                ["requiredRunwayLength"] = "требуемая длина ВПП",
                ["initialAltitude"] = "начальная высота",
                ["AvailableRunwayLength"] = "доступная длина ВПП",
                ["RequiredRunwayLength"] = "требуемая длина ВПП",
                ["Altitude"] = "высота",
                ["IsFlying"] = "в полёте",
                ["Int32"] = "целое число",
                ["Int64"] = "целое число",
                ["Boolean"] = "логическое",
                ["String"] = "строка",
                ["Double"] = "вещественное",
                ["Single"] = "вещественное",
                ["Decimal"] = "десятичное",
                ["Void"] = "без значения"
            };

        public static string ToRussian(string englishName)
        {
            if (string.IsNullOrEmpty(englishName))
            {
                return englishName;
            }

            return EnglishToRussian.TryGetValue(englishName, out string russianName)
                ? russianName
                : englishName;
        }

        public static string ToEnglish(string displayName)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                return displayName;
            }

            foreach (KeyValuePair<string, string> pair in EnglishToRussian)
            {
                if (string.Equals(pair.Value, displayName, StringComparison.OrdinalIgnoreCase))
                {
                    return pair.Key;
                }
            }

            return displayName;
        }

        public static string ToRussianType(Type type)
        {
            if (type == null)
            {
                return string.Empty;
            }

            if (type == typeof(void))
            {
                return ToRussian("Void");
            }

            return ToRussian(Nullable.GetUnderlyingType(type)?.Name ?? type.Name);
        }

        public static string BuildRussianConstructorSignature(ConstructorInfo constructor)
        {
            string typeName = ToRussian(constructor.DeclaringType.Name);
            string parameters = string.Join(
                ", ",
                constructor.GetParameters().Select(
                    parameter => ToRussianType(parameter.ParameterType) + " " + ToRussian(parameter.Name)));

            return $"{typeName}({parameters})";
        }

        public static string BuildRussianMethodSignature(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            string methodName = ToRussian(method.Name);

            if (parameters.Length == 0)
            {
                return methodName + "()";
            }

            string parameterList = string.Join(
                ", ",
                parameters.Select(
                    parameter => ToRussianType(parameter.ParameterType) + " " + ToRussian(parameter.Name)));

            return methodName + "(" + parameterList + ")";
        }

        public static string ExtractMethodNameFromSignature(string methodSignature)
        {
            if (string.IsNullOrEmpty(methodSignature))
            {
                return string.Empty;
            }

            int bracketIndex = methodSignature.IndexOf('(');
            string displayName = bracketIndex < 0
                ? methodSignature
                : methodSignature.Substring(0, bracketIndex);

            return ToEnglish(displayName.Trim());
        }

        public static string TranslateResultText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            string translated = text;
            foreach (KeyValuePair<string, string> pair in EnglishToRussian.OrderByDescending(pair => pair.Key.Length))
            {
                translated = translated.Replace(pair.Key, pair.Value);
            }

            return translated
                .Replace("True", "Истина")
                .Replace("False", "Ложь")
                .Replace("true", "истина")
                .Replace("false", "ложь");
        }
    }
}
