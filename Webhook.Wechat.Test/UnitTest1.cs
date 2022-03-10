using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Webhook.Wechat.Test;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        var webhookUrl = "";
        var httpClient = new HttpClient();
        var client = new WebhookClient(webhookUrl, httpClient);

        var result = await client.Send(new WebhookRequest()
        {
            Msgtype = "text",
            Text = new TextMessage()
            {
                Content = "hello world",
            }
        });
        Assert.Equal(0, result.Errcode);
    }
}