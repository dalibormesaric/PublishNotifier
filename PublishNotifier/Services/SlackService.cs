using Slack.Webhooks;
using System;
using System.Windows;

namespace PublishNotifier
{
    public class SlackService : IDisposable
    {
        public SlackService(string slackWebhookUrl, string projectName)
        {
            try
            {
                var slackClient = new SlackClient(slackWebhookUrl);
                var slackMessage = new SlackMessage
                {
                    Text = $"{projectName} was just published!",
                    Username = "PublishNotifier"
                };
                slackClient.Post(slackMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Slack Webhook URL");
            }
        }

        public void Dispose()
        {
        }
    }
}
