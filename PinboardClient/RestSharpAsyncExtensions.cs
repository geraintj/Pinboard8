using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PinboardApi
{
    public static class RestSharpAsyncExtensions
    {
        public static Task<IRestResponse> ExecuteTaskAsync(this RestClient @this, RestRequest request)
        {
            if (@this == null)
                throw new NullReferenceException();

            var tcs = new TaskCompletionSource<IRestResponse>();

            @this.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                    tcs.TrySetException(response.ErrorException);
                else
                    tcs.TrySetResult(response);
            });

            return tcs.Task;
        }

        public static Task<T> ExecuteTaskAsync<T>(this RestClient @this, RestRequest request) where T : new()
        {
            if (@this == null)
                throw new NullReferenceException();

            var tcs = new TaskCompletionSource<T>();

            @this.ExecuteAsync<T>(request, (response) =>
            {
                if (response.ErrorException != null)
                    tcs.TrySetException(response.ErrorException);
                else
                    tcs.TrySetResult(response.Data);
            });

            return tcs.Task;
        }

    }
}
