using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChatbaseApi
{
    public class API
    {
        private string apiKey;
        private string chatId;

        public API(string apiKey, string chatId)
        {
            this.apiKey = apiKey;
            this.chatId = chatId;
        }

        public async Task<Response> SendMessage(string message, string conversationId, string model = "gpt-3.5-turbo")
        {
            var messages = new[]
            {
                new
                {
                    content = message,
                    role = "user"
                }
            };

            var request = new
            {
                messages,
                chatId,
                stream = true,
                temperature = 0,
                model,
                conversationId,
            };

            string apiUrl = "https://www.chatbase.co/api/v1/chat";
            return await Post(apiUrl, request);
        }

        public async Task<Response> UpdateChat(object request)
        {
            //var request = new
            //{
            //    chatbotId = "",
            //    chatbotName = "new name",
            //    sourceText = "Source text that is less than your plan character limit..."
            //};

            var url = "https://www.chatbase.co/api/v1/update-chatbot-data";
            return await Post(url, request);
        }

        public async Task<Response> GetConversations(DateTime start, DateTime end, int page = 1, int size = 1000)
        {
            var url = $"https://www.chatbase.co/api/v1/get-conversations?chatbotId={chatId}&startDate={start:yyyy-MM-dd}&endDate={end:yyyy-MM-dd}&page={page}&size={size}";
            return await Get(url);
        }

        public async Task<Response> GetLeads(DateTime start, DateTime end, int page = 1, int size = 1000)
        {
            var url = $"https://www.chatbase.co/api/v1/get-leads?chatbotId={chatId}&startDate={start:yyyy-MM-dd}&endDate={end:yyyy-MM-dd}&page={page}&size={size}";
            return await Get(url);
        }

        private async Task<Response> Get(string url)
        {
            var rs = new Response();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var jsonResponse = JToken.Parse(responseBody);
                rs.Code = 200;
                rs.Message = jsonResponse.ToString();
            }
            catch (HttpRequestException e)
            {
                rs.Code = 500;
                rs.Message = $"Request error: {e.Message}";
            }

            return rs;
        }

        private async Task<Response> Post(string url, object request)
        {
            var rs = new Response();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    rs.Code = 200;
                    rs.Message = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    rs.Code = 500;
                    rs.Message = $"Request error: {e.Message}";
                }
            }

            return rs;
        }
    }
}
