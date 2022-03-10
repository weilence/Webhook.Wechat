using System.Collections.Generic;

namespace Webhook.Wechat
{
    public class WebhookRequest
    {
        public string Msgtype { get; set; }

        public TextMessage Text { get; set; }
    }

    public class TextMessage
    {
        public string Content { get; set; }

        public IEnumerable<string> MentionedList { get; set; }

        public IEnumerable<string> MentionedMobileList { get; set; }
    }
}