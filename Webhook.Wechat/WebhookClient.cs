using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Webhook.Wechat
{
    public class WebhookClient
    {
        private readonly string _webhookUrl;
        private readonly HttpClient _client;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public WebhookClient(string webhookUrl, HttpClient client)
        {
            _webhookUrl = webhookUrl;
            _client = client;
        }

        public async Task<WebhookResponse> Send(WebhookRequest request)
        {
            var content = JsonSerializer.Serialize(request, _options);
            var response = await _client.PostAsync(_webhookUrl,
                new StringContent(content, Encoding.UTF8, "application/json"));
            var resContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WebhookResponse>(resContent, _options);
        }
    }
}