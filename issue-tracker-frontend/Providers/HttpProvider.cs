using issue_tracker_frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace issue_tracker_frontend.Providers
{
    public static class HttpProvider
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<T> GetRequestAsync<T>(string path, Page page, bool isAuthorized = false)
        {
            var baseUrl = "http://localhost:8500/";
            var httpRequestMessage = GenerateGetRequest(baseUrl, path, isAuthorized);
            try
            {
                using (var response = await client.SendAsync(httpRequestMessage))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<RespondAPIViewModel<T>>();
                        return result.Data;
                    }
                    else
                    {
                        var errorstring = await response.Content.ReadAsStringAsync();
                        string scriptText = "alert('" + errorstring + "')";
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "alertMessage", scriptText, true);
                        return default(T);
                    }
                }
            }
            catch(Exception e)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "alertMessage", "Server not available, please try again", true);
                return default(T);
            }

        }
        public static HttpRequestMessage GenerateGetRequest(string baseUrl, string path, bool isAuthorized)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, baseUrl + path);
            if (isAuthorized)
            {
                var token = UserDetails.Token;
                httpRequestMessage.Headers.Add("Authorization", "Bearer " + token);
            }
            httpRequestMessage.Headers.Add("Accept", "application/json");

            return httpRequestMessage;
        }
        public static async Task<T> PostRequestAsync<T>(string path, object model, Page page, bool isAuthorized = false)
        {
            var baseUrl = "http://localhost:8500/";
            var httpRequestMessage = GeneratePostRequest(baseUrl, path, model, isAuthorized);
            try
            {
                using (var response = await client.SendAsync(httpRequestMessage))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<RespondAPIViewModel<T>>();
                        return result.Data;
                    }
                    else
                    {
                        var error = await response.Content.ReadAsAsync<APIFail>();
                        string scriptText = "alert('" + error.Message + "')";
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "alertMessage", scriptText, true);
                        return default(T);
                    }
                }
            }
            catch(Exception e)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "alertMessage", "Server not available, please try again", true);
                return default(T);
            }

        }
        public static HttpRequestMessage GeneratePostRequest(string baseUrl, string path, object model, bool isAuthorized)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl + path)
            {
                Content = new ObjectContent<object>
                   (model, new JsonMediaTypeFormatter(), (MediaTypeHeaderValue)null),
            };
            if (isAuthorized)
            {
                var token = UserDetails.Token;
                httpRequestMessage.Headers.Add("Authorization", "Bearer " + token);
            }

            httpRequestMessage.Headers.Add("Accept", "application/json");

            return httpRequestMessage;
        }
    }
}