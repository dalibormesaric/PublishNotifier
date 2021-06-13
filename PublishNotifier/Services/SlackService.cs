using Slack.Webhooks;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace PublishNotifier
{
    public class SlackService : IDisposable
    {
        private readonly SlackClient _client;
        private readonly SlackMessage _message;

        public SlackService(string slackWebhookUrl, string projectName)
        {
            try
            {
                _client = new SlackClient(slackWebhookUrl);
                _message = new SlackMessage
                {
                    Text = $"{projectName} was just published!",
                    Username = "PublishNotifier"
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Slack Webhook URL");
            }
        }

        public async Task<bool> SendMessage() => await _client.PostAsync(_message);

        public void Dispose()
        {
        }
    }
}
