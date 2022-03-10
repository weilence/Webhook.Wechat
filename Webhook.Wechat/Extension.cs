using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Webhook.Wechat
{
    public static class Extension
    {
        public static IServiceCollection AddWechatWebhook(this IServiceCollection services, string webhookUrl,
            HttpClient httpClient = null)
        {
            services.AddSingleton(new WebhookClient(webhookUrl, httpClient ?? new HttpClient()));
            return services;
        }
    }
}