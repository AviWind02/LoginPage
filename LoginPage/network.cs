using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LoginPage
{
    internal class network
    {
        public  async Task<string> postRespone(string URL, string var = "null", string value = "null")
        {
            var values = new Dictionary<string, string>
            {
                {var, value}
            };
            var content = new FormUrlEncodedContent(values);
            var response = await new HttpClient().PostAsync(URL, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async Task<bool> postResponeAuth(string username, string password)
        {
            var values = new Dictionary<string, string>
            {
                {"login_user", "login_user" },
                { "username", username },
                { "password", password },

            };

            var content = new FormUrlEncodedContent(values);
            var response = await new HttpClient().PostAsync("https://horizon.bond/Forms/response.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString == "true";

        }
    }
}
