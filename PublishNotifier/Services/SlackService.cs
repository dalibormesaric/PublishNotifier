using Slack.Webhooks;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace PublishNotifier
{
    public class SlackService : IDisposable
    {
        private SlackClient Client;
        private SlackMessage Message;
        public SlackService(string slackWebhookUrl, string projectName)
        {
            try
            {
                Client = new SlackClient(slackWebhookUrl);
                Message = new SlackMessage
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

        public async Task<bool> SendMessage()
        {
            return await Client.PostAsync(Message);
        }

        public void Dispose()
        {
        }
    }
}
