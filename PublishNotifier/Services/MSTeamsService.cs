using System;
using TeamsHook.NET;

namespace PublishNotifier
{
    public class MSTeamsService : IDisposable
    {
        public MSTeamsService(string msTeamsWebhookUrl, string projectName)
        {
            var msTeamsHookClient = new TeamsHookClient();
            var messageCard = new MessageCard
            {
                Text = $"{projectName} was just published!"
            };
            msTeamsHookClient.PostAsync(msTeamsWebhookUrl, messageCard).ConfigureAwait(false);
        }

        public void Dispose()
        {
        }
    }
}
