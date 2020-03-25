using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientStudy.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/25/2020 5:04:41 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class HttpClientDemo
    {

        public static void Study()
        {

            // 经常使用httpClient 可曾想过HttpClient具体如何发出请求的？

            HttpClient client = new HttpClient();

            #region 简单示例


            {// 常见的使用方式

                //HttpResponseMessage res = await client.GetAsync("https://www.baidu.com/");

                // 验证res是否请求成功、读取返回内容...

            }

            { // 测试相对路径

                //client.BaseAddress = new Uri("https://www.baidu.com/");

                //var info = await client.GetAsync(string.Empty);

            }

            { // 反射查看其私有成员

                //Type type = client.GetType();

                //FieldInfo fieldInfo = type.GetField("_baseAddress", BindingFlags.NonPublic | BindingFlags.Instance);

                //object baseAddress = fieldInfo?.GetValue(client);

                // 由于_handler定义在父类中，需要通过BaseType来进行反射获取
                //FieldInfo fieldInfo = type.BaseType.GetField("_handler", BindingFlags.NonPublic | BindingFlags.Instance);

                // System.Net.Http.HttpClientHandler
                //HttpClientHandler handler = fieldInfo?.GetValue(client) as HttpClientHandler;

            }

            {// 直接通过handler发起调用

                //var handler = new HttpClientHandler();

                //Type type = handler.GetType();

                //MethodInfo methodInfo = type.GetMethod("SendAsync", BindingFlags.NonPublic | BindingFlags.Instance);

                //Task<HttpResponseMessage> res = methodInfo.Invoke(handler, new object[] { new HttpRequestMessage(HttpMethod.Get, "https://www.baidu.com/"), CancellationToken.None }) as Task<HttpResponseMessage>;

                //var msg = res.Result;

            }

            {

                //var type = typeof(HttpClient).Assembly.GetType("System.Net.Http.DiagnosticsHandler");// 注：需使用全路径名

                //MethodInfo methodInfo = type.GetMethod("IsEnabled", BindingFlags.NonPublic | BindingFlags.Static);

                //var IsEnabled = methodInfo.Invoke(null,null);// true

            }

            { // 具体执行原理

                var handler = new HttpClientHandler();

                Type type = handler.GetType();

                FieldInfo fieldInfo = type.GetField("_diagnosticsHandler", BindingFlags.NonPublic | BindingFlags.Instance);

                // System.Net.Http.DiagnosticsHandler
                var diagnosticsHandler = fieldInfo.GetValue(handler);

                FieldInfo _innerHandlerField = diagnosticsHandler.GetType().BaseType.GetField("_innerHandler", BindingFlags.NonPublic | BindingFlags.Instance);

                // System.Net.Http.SocketsHttpHandler 
                var innerHandler = _innerHandlerField.GetValue(diagnosticsHandler);

                FieldInfo fieldInfo2 = innerHandler.GetType().GetField("_handler", BindingFlags.NonPublic | BindingFlags.Instance);

                // null
                object handler2 = fieldInfo2.GetValue(innerHandler);

                MethodInfo setupHandlerChain = innerHandler.GetType().GetMethod("SetupHandlerChain", BindingFlags.NonPublic | BindingFlags.Instance);

                // System.Net.Http.RedirectHandler
                object redirectHandler = setupHandlerChain?.Invoke(innerHandler, new object[0]);

                // System.Net.Http.HttpConnectionHandler
                object httpConnectionHandler = redirectHandler.GetType().GetField("_initialInnerHandler", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(redirectHandler);

                // System.Net.Http.HttpConnectionPoolManager
                object httpConnectionPoolManager = httpConnectionHandler.GetType().GetField("_poolManager", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(httpConnectionHandler);

                MethodInfo getConnectionKey = httpConnectionPoolManager.GetType().GetMethod("GetConnectionKey", BindingFlags.NonPublic | BindingFlags.Static);

                var req = new HttpRequestMessage(HttpMethod.Get, "https://www.baidu.com/");

                // System.Net.Http.HttpConnectionPoolManager.HttpConnectionKey
                object httpConnectionKey = getConnectionKey.Invoke(null, new object[] { req, null, false });

                ConstructorInfo constructorInfo = typeof(HttpClient).Assembly.GetType("System.Net.Http.HttpConnectionPool").GetConstructors()[0];

                // new HttpConnectionPool(this, connectionKey.Kind, flag ? ("[" + connectionKey.Host + "]") : connectionKey.Host, connectionKey.Port, connectionKey.SslHostName, connectionKey.ProxyUri, _maxConnectionsPerServer);

                type = httpConnectionKey.GetType();

                var param = new object[] {
                    httpConnectionPoolManager,
                    type.GetField("Kind",BindingFlags.Public|BindingFlags.Instance).GetValue(httpConnectionKey),
                    "www.baidu.com",443, "www.baidu.com",
                    null,
                    httpConnectionPoolManager.GetType().GetField("_maxConnectionsPerServer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(httpConnectionPoolManager)
                };

                // System.Net.Http.HttpConnectionPool
                object httpConnectionPool = constructorInfo.Invoke(param);

                MethodInfo getConnectionAsync = httpConnectionPool.GetType().GetMethod("GetConnectionAsync", BindingFlags.NonPublic | BindingFlags.Instance);

                // (HttpConnection, HttpResponseMessage) valueTuple = await GetConnectionAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                object obj = getConnectionAsync.Invoke(httpConnectionPool, new object[] { req, CancellationToken.None });

                object result = obj.GetType().GetProperty("Result", BindingFlags.Public | BindingFlags.Instance).GetValue(obj);

                type = result.GetType();

                // System.Net.Http.HttpConnectionBase{System.Net.Http.HttpConnection}
                object httpConnection = type.GetField("Item1", BindingFlags.Public | BindingFlags.Instance).GetValue(result);

                MethodInfo sendAsyncCore = httpConnection.GetType().GetMethod("SendAsyncCore", BindingFlags.Public | BindingFlags.Instance);

                Task<HttpResponseMessage> task = sendAsyncCore.Invoke(httpConnection, new object[] { req, CancellationToken.None }) as Task<HttpResponseMessage>;

                var msg = task.Result;

            }

            {// 简化版调用

                object httpConnectionSettings = typeof(HttpClient).Assembly.GetType("System.Net.Http.HttpConnectionSettings").GetConstructors()[0].Invoke(new object[0]);

                Type type = httpConnectionSettings.GetType();

                // 注： 此处必须设置CookieContainer 否则最终SendAsyncCore会出现空指针...
                FieldInfo fieldInfo = type.GetField("_cookieContainer", BindingFlags.Instance | BindingFlags.NonPublic);

                fieldInfo.SetValue(httpConnectionSettings, new CookieContainer());

                object httpConnectionPoolManager = typeof(HttpClient).Assembly.GetType("System.Net.Http.HttpConnectionPoolManager").GetConstructors()[0].Invoke(new object[] { httpConnectionSettings });

                MethodInfo getConnectionKey = httpConnectionPoolManager.GetType().GetMethod("GetConnectionKey", BindingFlags.NonPublic | BindingFlags.Static);

                var req = new HttpRequestMessage(HttpMethod.Get, "https://www.baidu.com/");

                // System.Net.Http.HttpConnectionPoolManager.HttpConnectionKey
                object httpConnectionKey = getConnectionKey.Invoke(null, new object[] { req, null, false });

                ConstructorInfo constructorInfo = typeof(HttpClient).Assembly.GetType("System.Net.Http.HttpConnectionPool").GetConstructors()[0];

                // new HttpConnectionPool(this, connectionKey.Kind, flag ? ("[" + connectionKey.Host + "]") : connectionKey.Host, connectionKey.Port, connectionKey.SslHostName, connectionKey.ProxyUri, _maxConnectionsPerServer);

                type = httpConnectionKey.GetType();

                var param = new object[] {
                    httpConnectionPoolManager,
                    type.GetField("Kind",BindingFlags.Public|BindingFlags.Instance).GetValue(httpConnectionKey),
                    "www.baidu.com",443, "www.baidu.com",
                    null,
                    httpConnectionPoolManager.GetType().GetField("_maxConnectionsPerServer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(httpConnectionPoolManager)
                };

                // System.Net.Http.HttpConnectionPool
                object httpConnectionPool = constructorInfo.Invoke(param);

                MethodInfo getConnectionAsync = httpConnectionPool.GetType().GetMethod("GetConnectionAsync", BindingFlags.NonPublic | BindingFlags.Instance);

                // (HttpConnection, HttpResponseMessage) valueTuple = await GetConnectionAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                object obj = getConnectionAsync.Invoke(httpConnectionPool, new object[] { req, CancellationToken.None });

                object result = obj.GetType().GetProperty("Result", BindingFlags.Public | BindingFlags.Instance).GetValue(obj);

                type = result.GetType();

                // System.Net.Http.HttpConnectionBase{System.Net.Http.HttpConnection}
                object httpConnection = type.GetField("Item1", BindingFlags.Public | BindingFlags.Instance).GetValue(result);

                MethodInfo sendAsyncCore = httpConnection.GetType().GetMethod("SendAsyncCore", BindingFlags.Public | BindingFlags.Instance);

                Task<HttpResponseMessage> task = sendAsyncCore.Invoke(httpConnection, new object[] { req, CancellationToken.None }) as Task<HttpResponseMessage>;

                var msg = task.Result;

            }

            // so 默认实现的 key code in : System.Net.Http.HttpConnection.SendAsyncCore

            // summary 基本的请求发起需要：
            // 通过 uri 和请求方法构造的 HttpRequestMessage req

            // 一个空构造的 HttpConnectionSettings 并设置字段值为一个空构造的 CookieContainer

            // 通过 HttpConnectionSettings 参数构造的 HttpConnectionPoolManager

            // 通过 req构造的 HttpConnectionKey (HttpConnectionPoolManager.GetConnectionKey)

            // 通过 HttpConnectionPoolManager 和 HttpConnectionKey  构建的 HttpConnectionPool

            // 通过 req 构建的 HttpConnection (HttpConnectionPool.GetConnectionAsync)

            // 通过 req 实现请求 (HttpConnection.SendAsyncCore)

            #endregion

        }

    }
}
