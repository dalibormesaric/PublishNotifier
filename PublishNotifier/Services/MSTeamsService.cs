using System;
using System.Windows;
using TeamsHook.NET;

namespace PublishNotifier
{
    public class MSTeamsService : IDisposable
    {
        public MSTeamsService(string msTeamsWebhookUrl, string projectName)
        {
            try
            {
                var msTeamsHookClient = new TeamsHookClient();
                var messageCard = new MessageCard
                {
                    Text = $"{projectName} was just published!"
                };
                msTeamsHookClient.PostAsync(msTeamsWebhookUrl, messageCard).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MS Teams Webhook URL");
            }
        }

        public void Dispose()
        {
        }
    }
}
