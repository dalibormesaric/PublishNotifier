using SlackAPI;
using System;
using System.Linq;

namespace PublishNotifier
{
    public class SlackService : IDisposable
    {
        private SlackClient _sc;
        private string visualStudioPublishIconUrl = "";

        public SlackService(string slackBotIntegrationApiToken, string projectName)
        {
            _sc = new SlackClient(slackBotIntegrationApiToken);
            _sc.Connect((connected) => {
                //This is called once the client has emitted the RTM start command
                HandleConnected(connected, projectName);
            }, () => {
                //This is called once the RTM client has connected to the end point
            });
        }

        private void HandleConnected(LoginResponse loginResponse, string projectName)
        {
            var channels = _sc.Channels.Where(s => s.is_member).ToList();
            for (int i = 0; i < channels.Count(); i++)
            {
                _sc.PostMessage(null, channels[i].id, $"{projectName} was just published!", loginResponse.self.name);//, null, false, null, false, visualStudioPublishIconUrl);
            }
        }

        public void Dispose()
        {
        }
    }
}
