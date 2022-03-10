using System.Linq;
using System.Text.Json;

namespace Webhook.Wechat
{
    public class SnakeCaseJsonNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return SnakeCase(name);
        }

        private static string SnakeCase(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()))
                .ToLower();
        }
    }
}