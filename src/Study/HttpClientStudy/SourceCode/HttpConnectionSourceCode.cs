using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientStudy.SourceCode
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/26/2020 10:27:40 AM
    /// @source : System.Net.Http.HttpConnection
    /// @des : 
    /// </summary>
    public class HttpConnectionSourceCode
    {

        private HttpRequestMessage _currentRequest;

        public async Task<HttpResponseMessage> SendAsyncCore(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            TaskCompletionSource<bool> allowExpect100ToContinue = null;
            _currentRequest = request;
            //HttpMethod normalizedMethod = HttpMethod.Normalize(request.Method);

            /**
             * // s_knownMethods -> Dic<HttpMethod,HttpMethod>
             * // 查看 method 是否已知 是-》返回对应 method (源码查看对应 method 其实就是原有 method) 否 返回原有 method
             * internal static HttpMethod Normalize(HttpMethod method)
             * {
             *     if (!s_knownMethods.TryGetValue(method, out HttpMethod value))
             *     {
             *          return method;
             *     }
             *     return value;
             * }
             * 
             */

            // 发生异常是否继续执行 默认false
            //bool hasExpectContinueHeader = request.HasHeaders && request.Headers.ExpectContinue == true;


            //_canRetry = true;

            // EventSource 事件追踪 --> 类似于日志
            //if (NetEventSource.IsEnabled)
            //{
            //    Trace($"Sending request: {request}", "SendAsyncCore");
            //}

            //CancellationTokenRegistration cancellationRegistration = RegisterCancellation(cancellationToken);
            try
            {
                // 将Method写入 buffer byte[]
                //await WriteStringAsync(normalizedMethod.Method).ConfigureAwait(continueOnCapturedContext: false);

                // 补充 buffer 或将 buffer 写入流中 重置 buffer 偏移量 (offset)
                // 故 WriteXxx 是用于将数据写入缓冲区，若缓冲区已满则写入流中 重置缓冲区(偏移量)

                // 写入标记？
                //await WriteByteAsync(32).ConfigureAwait(continueOnCapturedContext: false);

                //if ((object)normalizedMethod == HttpMethod.Connect)
                //{
                //    if (!request.HasHeaders || request.Headers.Host == null)
                //    {
                //        throw new HttpRequestException(SR.net_http_request_no_host);
                //    }
                //    await WriteAsciiStringAsync(request.Headers.Host).ConfigureAwait(continueOnCapturedContext: false);
                //}
                //else
                //{
                //    if (Kind == HttpConnectionKind.Proxy)
                //    {
                //        await WriteBytesAsync(s_httpSchemeAndDelimiter).ConfigureAwait(continueOnCapturedContext: false);
                //        if (request.RequestUri.HostNameType != UriHostNameType.IPv6)
                //        {
                //            await WriteAsciiStringAsync(request.RequestUri.IdnHost).ConfigureAwait(continueOnCapturedContext: false);
                //        }
                //        else
                //        {
                //            await WriteByteAsync(91).ConfigureAwait(continueOnCapturedContext: false);
                //            await WriteAsciiStringAsync(request.RequestUri.IdnHost).ConfigureAwait(continueOnCapturedContext: false);
                //            await WriteByteAsync(93).ConfigureAwait(continueOnCapturedContext: false);
                //        }
                //        if (!request.RequestUri.IsDefaultPort)
                //        {
                //            await WriteByteAsync(58).ConfigureAwait(continueOnCapturedContext: false);
                //            await WriteDecimalInt32Async(request.RequestUri.Port).ConfigureAwait(continueOnCapturedContext: false);
                //        }
                //    }

                //    写入 根据FC 2396 中的规则执行转义，获取相对路径、#标记、Query参数 组合的地址
                //    await WriteStringAsync(request.RequestUri.GetComponents(UriComponents.Path | UriComponents.Query | UriComponents.Fragment, UriFormat.UriEscaped)).ConfigureAwait(continueOnCapturedContext: false);
                //}

                // 默认false 
                //bool flag = request.Version.Minor == 0 && request.Version.Major == 1;

                // 写入http协议及版本  " HTTP/1.0\r\n" or " HTTP/1.1\r\n"
                //await WriteBytesAsync(flag ? s_spaceHttp10NewlineAsciiBytes : s_spaceHttp11NewlineAsciiBytes).ConfigureAwait(continueOnCapturedContext: false);

                // 若使用cookies 获取cookie头部
                //string text = null;
                //if (_pool.Settings._useCookies)
                //{
                //    text = _pool.Settings._cookieContainer.GetCookieHeader(request.RequestUri);
                //    if (text == "")
                //    {
                //        text = null;
                //    }
                //}
                //if (request.HasHeaders || text != null)// 写入头部
                //{
                //    await WriteHeadersAsync(request.Headers, text).ConfigureAwait(continueOnCapturedContext: false);
                //}
                //if (request.Content != null) // 写入Content头部
                //{
                //    await WriteHeadersAsync(request.Content.Headers, null).ConfigureAwait(continueOnCapturedContext: false);
                //}
                // 若 method 不为 Get、Head、Connect 
                //else if ((object)normalizedMethod != HttpMethod.Get && (object)normalizedMethod != HttpMethod.Head && (object)normalizedMethod != HttpMethod.Connect)
                //{
                //    // 写入 Content-Length: 0\r\n
                //    await WriteBytesAsync(s_contentLength0NewlineAsciiBytes).ConfigureAwait(continueOnCapturedContext: false);
                //}

                // 若 host 或 无头部 则写入 请求地址
                //if (!request.HasHeaders || request.Headers.Host == null)
                //{
                //    await WriteHostHeaderAsync(request.RequestUri).ConfigureAwait(continueOnCapturedContext: false);
                //}

                // 写入标记？
                //await WriteTwoBytesAsync(13, 10).ConfigureAwait(continueOnCapturedContext: false);

                //Task sendRequestContentTask = null;
                //if (request.Content == null)// 内容为空 
                //{
                //    // 刷新缓冲区 -》 将缓冲区写入流中 重置缓冲区
                //    await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
                //}
                //else if (!hasExpectContinueHeader) // 无异常继续执行标记
                //{
                //    直接写入content
                //    await SendRequestContentAsync(request, CreateRequestContentStream(request), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                //}
                else
                {
                    await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
                    allowExpect100ToContinue = new TaskCompletionSource<bool>();
                    Timer expect100Timer = new Timer(delegate (object s)
                    {
                        ((TaskCompletionSource<bool>)s).TrySetResult(result: true);
                    }, allowExpect100ToContinue, _pool.Settings._expect100ContinueTimeout, Timeout.InfiniteTimeSpan);
                    sendRequestContentTask = SendRequestContentWithExpect100ContinueAsync(request, allowExpect100ToContinue.Task, CreateRequestContentStream(request), expect100Timer, cancellationToken);
                }
                _allowedReadLineBytes = (int)Math.Min(2147483647L, (long)_pool.Settings._maxResponseHeadersLength * 1024L);
                ValueTask<int>? valueTask = ConsumeReadAheadTask();
                if (valueTask.HasValue)
                {
                    int num = await valueTask.GetValueOrDefault().ConfigureAwait(continueOnCapturedContext: false);
                    if (NetEventSource.IsEnabled)
                    {
                        Trace($"Received {num} bytes.", "SendAsyncCore");
                    }
                    if (num == 0)
                    {
                        throw new IOException(SR.net_http_invalid_response);
                    }
                    _readOffset = 0;
                    _readLength = num;
                }
                _canRetry = false;
                HttpResponseMessage response = new HttpResponseMessage
                {
                    RequestMessage = request,
                    Content = new HttpConnectionResponseContent()
                };
                ParseStatusLine(await ReadNextResponseHeaderLineAsync().ConfigureAwait(continueOnCapturedContext: false), response);
                while (response.StatusCode >= HttpStatusCode.Continue && response.StatusCode <= (HttpStatusCode)199)
                {
                    if (allowExpect100ToContinue != null && response.StatusCode == HttpStatusCode.Continue)
                    {
                        allowExpect100ToContinue.TrySetResult(result: true);
                        allowExpect100ToContinue = null;
                    }
                    else if (response.StatusCode == HttpStatusCode.SwitchingProtocols)
                    {
                        break;
                    }
                    if (NetEventSource.IsEnabled)
                    {
                        Trace($"Current {response.StatusCode} response is an interim response or not expected, need to read for a final response.", "SendAsyncCore");
                    }
                    while (!IsLineEmpty(await ReadNextResponseHeaderLineAsync().ConfigureAwait(continueOnCapturedContext: false)))
                    {
                    }
                    ParseStatusLine(await ReadNextResponseHeaderLineAsync().ConfigureAwait(continueOnCapturedContext: false), response);
                }
                if (allowExpect100ToContinue != null)
                {
                    if (response.StatusCode >= HttpStatusCode.MultipleChoices && request.Content != null && (!request.Content.Headers.ContentLength.HasValue || request.Content.Headers.ContentLength.GetValueOrDefault() > 1024))
                    {
                        allowExpect100ToContinue.TrySetResult(result: false);
                        if (!allowExpect100ToContinue.Task.Result)
                        {
                            _connectionClose = true;
                        }
                    }
                    else
                    {
                        allowExpect100ToContinue.TrySetResult(result: true);
                    }
                }
                if (sendRequestContentTask != null)
                {
                    await sendRequestContentTask.ConfigureAwait(continueOnCapturedContext: false);
                }
                while (true)
                {
                    ArraySegment<byte> line = await ReadNextResponseHeaderLineAsync(foldedHeadersAllowed: true).ConfigureAwait(continueOnCapturedContext: false);
                    if (IsLineEmpty(line))
                    {
                        break;
                    }
                    ParseHeaderNameValue(line, response);
                }
                if (response.Headers.ConnectionClose.GetValueOrDefault())
                {
                    _connectionClose = true;
                }
                cancellationRegistration.Dispose();
                CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                HttpContentStream stream;
                if ((object)normalizedMethod == HttpMethod.Head || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotModified)
                {
                    stream = EmptyReadStream.Instance;
                    CompleteResponse();
                }
                else if ((object)normalizedMethod == HttpMethod.Connect && response.StatusCode == HttpStatusCode.OK)
                {
                    stream = new RawConnectionStream(this);
                    _connectionClose = true;
                }
                else if (response.StatusCode == HttpStatusCode.SwitchingProtocols)
                {
                    stream = new RawConnectionStream(this);
                }
                else if (!response.Content.Headers.ContentLength.HasValue)
                {
                    stream = ((response.Headers.TransferEncodingChunked != true) ? ((HttpContentReadStream)new ConnectionCloseReadStream(this)) : ((HttpContentReadStream)new ChunkedEncodingReadStream(this)));
                }
                else
                {
                    long valueOrDefault = response.Content.Headers.ContentLength.GetValueOrDefault();
                    if (valueOrDefault <= 0)
                    {
                        stream = EmptyReadStream.Instance;
                        CompleteResponse();
                    }
                    else
                    {
                        stream = new ContentLengthReadStream(this, (ulong)valueOrDefault);
                    }
                }
                ((HttpConnectionResponseContent)response.Content).SetStream(stream);
                if (NetEventSource.IsEnabled)
                {
                    Trace($"Received response: {response}", "SendAsyncCore");
                }
                if (_pool.Settings._useCookies)
                {
                    CookieHelper.ProcessReceivedCookies(response, _pool.Settings._cookieContainer);
                }
                return response;
            }
            catch (Exception ex)
            {
                cancellationRegistration.Dispose();
                allowExpect100ToContinue?.TrySetResult(result: false);
                if (NetEventSource.IsEnabled)
                {
                    Trace($"Error sending request: {ex}", "SendAsyncCore");
                }
                Dispose();
                if (CancellationHelper.ShouldWrapInOperationCanceledException(ex, cancellationToken))
                {
                    throw CancellationHelper.CreateOperationCanceledException(ex, cancellationToken);
                }
                if (ex is InvalidOperationException || ex is IOException)
                {
                    throw new HttpRequestException(SR.net_http_client_execution_error, ex);
                }
                throw;
            }
        }

    }
}
