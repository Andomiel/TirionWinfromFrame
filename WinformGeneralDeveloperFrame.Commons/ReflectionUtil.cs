using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace WinformGeneralDeveloperFrame.Commons
{
    public sealed class ReflectionUtil
    {
        public static BindingFlags bf = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        private ReflectionUtil()
        {
        }

        public static object InvokeMethod(object obj, string methodName, object[] args) => obj.GetType().InvokeMember(methodName, ReflectionUtil.bf | BindingFlags.InvokeMethod, (Binder)null, obj, args);

        public static void SetField(object obj, string name, object value) => obj.GetType().GetField(name, ReflectionUtil.bf).SetValue(obj, value);

        public static object GetField(object obj, string name) => obj.GetType().GetField(name, ReflectionUtil.bf).GetValue(obj);

        public static FieldInfo[] GetFields(object obj) => obj.GetType().GetFields(ReflectionUtil.bf);

        public static void SetProperty(object obj, string name, object value)
        {
            PropertyInfo property = obj.GetType().GetProperty(name, ReflectionUtil.bf);
            value = Convert.ChangeType(value, property.PropertyType);
            property.SetValue(obj, value, (object[])null);
        }

        public static object GetProperty(object obj, string name) => obj.GetType().GetProperty(name, ReflectionUtil.bf).GetValue(obj, (object[])null);

        public static PropertyInfo[] GetProperties(object obj) => obj.GetType().GetProperties(ReflectionUtil.bf);

        public static string ToNameValuePairs(object obj, bool includeEmptyProperties = true)
        {
            string str1 = "";
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                string str2 = property.GetValue(obj, (object[])null)?.ToString();
                if (string.IsNullOrEmpty(str2))
                {
                    if (includeEmptyProperties)
                    {
                        if (!string.IsNullOrEmpty(str1))
                            str1 += "&";
                        str1 += string.Format("{0}={1}", (object)property.Name, (object)str2);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(str1))
                        str1 += "&";
                    str1 += string.Format("{0}={1}", (object)property.Name, (object)str2);
                }
            }
            return str1;
        }

        public static string GetDescription(Enum value) => ReflectionUtil.GetDescription(value, (object[])null);

        public static string GetDescription(Enum value, params object[] args)
        {
            DescriptionAttribute[] descriptionAttributeArray = value != null ? (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false) : throw new ArgumentNullException(nameof(value));
            string format = descriptionAttributeArray.Length != 0 ? descriptionAttributeArray[0].Description : value.ToString();
            return args != null && (uint)args.Length > 0U ? string.Format((IFormatProvider)null, format, args) : format;
        }

        public static string GetDescription(MemberInfo member) => ReflectionUtil.GetDescription(member, (object[])null);

        public static string GetDescription(MemberInfo member, params object[] args)
        {
            if (member == (MemberInfo)null)
                throw new ArgumentNullException(nameof(member));
            if (!member.IsDefined(typeof(DescriptionAttribute), false))
                return string.Empty;
            string description = ((DescriptionAttribute[])member.GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
            return args != null && (uint)args.Length > 0U ? string.Format((IFormatProvider)null, description, args) : description;
        }

        public static object GetAttribute(Type attributeType, Assembly assembly)
        {
            if (attributeType == (Type)null)
                throw new ArgumentNullException(nameof(attributeType));
            if (assembly == (Assembly)null)
                throw new ArgumentNullException(nameof(assembly));
            return assembly.IsDefined(attributeType, false) ? assembly.GetCustomAttributes(attributeType, false)[0] : (object)null;
        }

        public static object GetAttribute(Type attributeType, MemberInfo type) => ReflectionUtil.GetAttribute(attributeType, type, false);

        public static object GetAttribute(Type attributeType, MemberInfo type, bool searchParent)
        {
            if (attributeType == (Type)null || type == (MemberInfo)null || (!attributeType.IsSubclassOf(typeof(Attribute)) || !type.IsDefined(attributeType, searchParent)))
                return (object)null;
            object[] customAttributes = type.GetCustomAttributes(attributeType, searchParent);
            return (uint)customAttributes.Length > 0U ? customAttributes[0] : (object)null;
        }

        public static object[] GetAttributes(Type attributeType, MemberInfo type) => ReflectionUtil.GetAttributes(attributeType, type, false);

        public static object[] GetAttributes(Type attributeType, MemberInfo type, bool searchParent) => type == (MemberInfo)null || attributeType == (Type)null || (!attributeType.IsSubclassOf(typeof(Attribute)) || !type.IsDefined(attributeType, false)) ? (object[])null : type.GetCustomAttributes(attributeType, searchParent);

        public static Stream GetImageResource(string ResourceName) => Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName);

        public static Bitmap LoadBitmap(
          Type assemblyType,
          string resourceHolder,
          string imageName)
        {
            Assembly assembly = Assembly.GetAssembly(assemblyType);
            return (Bitmap)new ResourceManager(resourceHolder, assembly).GetObject(imageName);
        }

        public static string GetStringRes(Type assemblyType, string resName, string resourceHolder)
        {
            Assembly assembly = Assembly.GetAssembly(assemblyType);
            return new ResourceManager(resourceHolder, assembly).GetString(resName);
        }

        public static string GetManifestString(Type assemblyType, string charset, string ResName)
        {
            Stream manifestResourceStream = Assembly.GetAssembly(assemblyType).GetManifestResourceStream(assemblyType.Namespace + "." + ResName.Replace("/", "."));
            if (manifestResourceStream == null)
                return "";
            int length = (int)manifestResourceStream.Length;
            byte[] numArray = new byte[length];
            manifestResourceStream.Read(numArray, 0, length);
            return numArray != null ? Encoding.GetEncoding(charset).GetString(numArray) : "";
        }

        public static object CreateInstance(string type)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int index = 0; index < assemblies.Length; ++index)
            {
                if (assemblies[index].GetType(type) != (Type)null)
                    return assemblies[index].CreateInstance(type);
            }
            return (object)null;
        }

        public static object CreateInstance(Type type) => ReflectionUtil.CreateInstance(type.FullName);
    }
}
