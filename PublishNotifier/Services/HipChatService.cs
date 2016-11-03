using HipChat.Net;
using HipChat.Net.Http;
using System;
using System.Text.RegularExpressions;

namespace PublishNotifier
{
    public class HipChatService : IDisposable
    {
        private const string regexAuthToken = @"^.+?auth_token=(.*)$";
        private const string regexRoom = @"^.+?room\/(.*)\/.+?$";

        public HipChatService(string hipChatBotIntegrationUrl, string projectName)
        {
            var hipChat = new HipChatClient(new ApiConnection(new Credentials(GetAuthToken(hipChatBotIntegrationUrl))));
            hipChat.Rooms.SendNotificationAsync(
                GetRoomName(hipChatBotIntegrationUrl),
                $"{projectName} was just published!");
        }

        private string GetAuthToken(string hipChatBotIntegrationUrl)
        {
            Regex re = new Regex(regexAuthToken);
            Match m = re.Match(hipChatBotIntegrationUrl);
            if (m.Success && m.Groups.Count == 2)
            {
                return m.Groups[1].Value;
            }
            return null;
        }

        private string GetRoomName(string hipChatBotIntegrationUrl)
        {
            Regex re = new Regex(regexRoom);
            Match m = re.Match(hipChatBotIntegrationUrl);
            if (m.Success && m.Groups.Count == 2)
            {
                return m.Groups[1].Value;
            }
            return null;
        }

        public void Dispose()
        {
        }
    }
}
