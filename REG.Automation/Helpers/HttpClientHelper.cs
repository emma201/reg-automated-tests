using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace REG.Automation.Helpers
{
    public static class HttpClientHelper
    {
        public static void ClearUserData(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest("api/ClearData", Method.DELETE);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"Email\":\"***REMOVED***\"}", ParameterType.RequestBody);

            client.Execute(request);
        }

    }
}
