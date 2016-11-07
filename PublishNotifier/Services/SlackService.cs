using Slack.Webhooks;
using System;

namespace PublishNotifier
{
    public class SlackService : IDisposable
    {
        public SlackService(string slackWebhookUrl, string projectName)
        {
            var slackClient = new SlackClient(slackWebhookUrl);
            var slackMessage = new SlackMessage
            {
                Text = $"{projectName} was just published!",
                Username = "PublishNotifier"
            };
            slackClient.Post(slackMessage);
        }

        public void Dispose()
        {
        }
    }
}
