using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.XPath;

namespace Command.Extension
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/27/2021 12:09:11 PM
    /// @source : 
    /// @des : 读取xml内容扩展
    /// </summary>
    public static class ReadXmlExt
    {

        private static readonly IDictionary<Type, string> _remarkDic = new Dictionary<Type, string>();
        private static readonly IDictionary<MethodInfo, string> _methodRemarkDic = new Dictionary<MethodInfo, string>();
        private static readonly Lazy<XPathNavigator> _xPathNavigator = new Lazy<XPathNavigator>(() =>
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            return new XPathDocument(Path.Combine(AppContext.BaseDirectory, assembly.GetName().Name + ".xml")).CreateNavigator();
        });

        public static string GetXmlSummary(this Type type)
        {
            if (type == null) return _remarkDic[type] = null;
            if (_remarkDic.ContainsKey(type)) return _remarkDic[type];

            return _remarkDic[type] = _xPathNavigator.Value.SelectSingleNode(type.FullName.GetXmlSummaryPath(false))?.Value.AutoTrim();
        }

        public static string GetXmlSummary(this MethodInfo method)
        {
            if (method == null) return _methodRemarkDic[method] = null;
            if (_methodRemarkDic.ContainsKey(method)) return _methodRemarkDic[method];

            return _methodRemarkDic[method] = _xPathNavigator.Value.SelectSingleNode(method.GetXmlFullName().GetXmlSummaryPath())?.Value.AutoTrim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method">用于缓存的key</param>
        /// <param name="findMethodFunc">具体查找的方法</param>
        /// <returns></returns>
        public static string GetXmlSummary(this MethodInfo method, Func<MethodInfo> findMethodFunc)
        {
            if (method == null) return _methodRemarkDic[method] = null;
            if (_methodRemarkDic.ContainsKey(method)) return _methodRemarkDic[method];

            MethodInfo methodInfo = findMethodFunc();

            if (methodInfo == null) return _methodRemarkDic[method] = null;

            return _methodRemarkDic[method] = _xPathNavigator.Value.SelectSingleNode(methodInfo.GetXmlFullName().GetXmlSummaryPath())?.Value.AutoTrim();
        }

        /// <summary>
        /// 获取方法对应的全路径[文档注释]
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetXmlFullName(this MethodInfo method)
        {

            var paramStr = string.Join(",", method.GetParameters().Select(u =>
            {

                if (u.ParameterType.IsGenericType)
                {
                    return $"{u.ParameterType.FullName.Substring(0, u.ParameterType.FullName.IndexOf('`'))}{{{string.Join(",", u.ParameterType.GetGenericArguments().Select(x => x.FullName))}}}";
                }

                return u.ParameterType.FullName;
            }));

            return $"{method.DeclaringType.FullName}.{method.Name}({paramStr})";
        }

        /// <summary>
        /// 获取xml文档的查找路径
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="isMethod"></param>
        /// <returns></returns>
        public static string GetXmlSummaryPath(this string fullName, bool isMethod = true)
        {
            return $"doc/members/member[@name='{(isMethod ? 'M' : 'T')}:{fullName}']/summary";
        }

        public static string AutoTrim(this string str)
        {
            if (str == null) return null;
            return str.Replace("\r\n", string.Empty).Trim();
        }
    }
}
