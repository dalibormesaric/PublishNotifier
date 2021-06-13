using System;
using System.Threading.Tasks;
using System.Windows;
using TeamsHook.NET;

namespace PublishNotifier
{
    public class MSTeamsService : IDisposable
    {
        private readonly TeamsHookClient _msTeamsHookClient;
        private readonly MessageCard _messageCard;
        private readonly string _msTeamsWebhookUrl;

        public MSTeamsService(string msTeamsWebhookUrl, string projectName)
        {
            _msTeamsHookClient = new TeamsHookClient();
            _messageCard = new MessageCard
            {
                Text = $"{projectName} was just published!"
            };
            _msTeamsWebhookUrl = msTeamsWebhookUrl;
        }

        public async Task SendMessage()
        {
            try
            {
                await _msTeamsHookClient.PostAsync(_msTeamsWebhookUrl, _messageCard);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MS Teams Message");
            }
        }

        public void Dispose()
        {
        }
    }
}
