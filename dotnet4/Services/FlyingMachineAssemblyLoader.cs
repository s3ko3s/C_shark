using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FlyingMachine.Contracts;

namespace dotnet2.Services
{
    /// <summary>
    /// Загрузка внешней библиотеки и поиск типов, реализующих <see cref="IFlyingMachine"/>.
    /// </summary>
    public sealed class FlyingMachineAssemblyLoader
    {
        private Assembly _loadedAssembly;

        public IReadOnlyList<Type> ImplementingTypes { get; private set; } = Array.Empty<Type>();

        public string Load(string assemblyPath)
        {
            if (string.IsNullOrWhiteSpace(assemblyPath))
            {
                throw new ArgumentException("Укажите путь к библиотеке классов.", nameof(assemblyPath));
            }

            if (!System.IO.File.Exists(assemblyPath))
            {
                throw new System.IO.FileNotFoundException("Файл библиотеки не найден.", assemblyPath);
            }

            _loadedAssembly = Assembly.LoadFrom(assemblyPath);

            ImplementingTypes = _loadedAssembly
                .GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract)
                .Where(type => typeof(IFlyingMachine).IsAssignableFrom(type))
                .OrderBy(type => type.FullName)
                .ToList();

            if (ImplementingTypes.Count == 0)
            {
                return "Библиотека загружена. Классы, реализующие IFlyingMachine, не найдены.";
            }

            return $"Библиотека загружена. Найдено классов: {ImplementingTypes.Count}.";
        }

        public Type GetTypeByName(string typeName)
        {
            return ImplementingTypes.FirstOrDefault(type => type.Name == typeName);
        }

        public static IReadOnlyList<ConstructorInfo> GetConstructors(Type type)
        {
            return type
                .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(constructor => constructor.GetParameters().Length)
                .ToList();
        }

        public static IReadOnlyList<MethodInfo> GetCallableMethods(Type type)
        {
            return type
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(method => !method.IsSpecialName)
                .Where(method => method.DeclaringType != typeof(object))
                .OrderBy(method => method.Name)
                .ToList();
        }

        public static IReadOnlyList<PropertyInfo> GetWritableProperties(Type type)
        {
            return type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(property => property.CanWrite && property.GetIndexParameters().Length == 0)
                .OrderBy(property => property.Name)
                .ToList();
        }

        public static string BuildMethodSignature(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length == 0)
            {
                return method.Name + "()";
            }

            string parameterList = string.Join(
                ", ",
                parameters.Select(parameter => parameter.ParameterType.Name + " " + parameter.Name));

            return method.Name + "(" + parameterList + ")";
        }

        public static string ExtractMethodName(string methodSignature)
        {
            if (string.IsNullOrEmpty(methodSignature))
            {
                return string.Empty;
            }

            int bracketIndex = methodSignature.IndexOf('(');
            return bracketIndex < 0 ? methodSignature : methodSignature.Substring(0, bracketIndex);
        }
    }
}
