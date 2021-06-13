using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using EnvDTE80;
using EnvDTE;

namespace PublishNotifier
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)] // Info on this package for Help/About
    [ProvideAutoLoad(UIContextGuids80.SolutionBuilding, PackageAutoLoadFlags.BackgroundLoad)]
    [Guid(VSPackage.PackageGuidString)]
    public sealed class VSPackage : Package
    {
        public const string PackageGuidString = "5b816723-9ba2-4002-9fc6-d8f416462ef7";

        // http://stackoverflow.com/questions/32593610/what-is-the-correct-way-to-subscribe-to-the-envdte80-dte2-events2-publishevents
        private DTE2 application;
        private Events2 events;
        private PublishEvents publishEvents;

        protected override void Initialize()
        {
            base.Initialize();

            application = (DTE2)GetService(typeof(DTE));
            events = (Events2)application.Events;
            publishEvents = events.PublishEvents;

            publishEvents.OnPublishDone += PublishEvents_OnPublishDone;
        }

        private void PublishEvents_OnPublishDone(bool Success)
        {
            if (!Success) return;

            using (var publishedProjectService = new PublishedProjectService(application))
            {
                var selectedItem = publishedProjectService.GetSelectedItem();
                if (selectedItem != null)
                {
                    using (var configurationService = new ConfigurationService(selectedItem, publishedProjectService.GetConfigurationFileFullPath()))
                    {
                        PublishNotifierDialog dialog = new PublishNotifierDialog(configurationService.GetConfigurationModel());
                        dialog.Closing += async (sender, e) => await Dialog_Closing(publishedProjectService, configurationService, sender, e);
                        dialog.ShowModal();
                    }
                }
            }
        }

        private async System.Threading.Tasks.Task Dialog_Closing(PublishedProjectService publishedProjectService, ConfigurationService configurationService, object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender != null && sender is PublishNotifierDialog publishNotifierDialog && publishNotifierDialog.isNotify)
            {
                configurationService.SaveConfiguration(publishedProjectService.GetConfigurationFileFullPath(), publishNotifierDialog.configurationModel);

                    if (!string.IsNullOrEmpty(publishNotifierDialog.configurationModel.slackWebhookUrl))
                    {
                        using (var slackService = new SlackService(publishNotifierDialog.configurationModel.slackWebhookUrl, publishedProjectService.GetProjectName()))
                        {
                            bool success = await slackService.SendMessage();
                        }
                    }

                if (!string.IsNullOrEmpty(publishNotifierDialog.configurationModel.msTeamsWebhookUrl))
                {
                    using (var msTeamsService = new MSTeamsService(publishNotifierDialog.configurationModel.msTeamsWebhookUrl, publishedProjectService.GetProjectName()))
                    {
                    }
                }
            }
        }
    }
}
