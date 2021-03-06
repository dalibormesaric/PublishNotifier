﻿using System.Windows;
using Microsoft.VisualStudio.PlatformUI;

namespace PublishNotifier
{
    /// <summary>
    /// Interaction logic for PublishNotifierDialog.xaml.
    /// </summary>
    public partial class PublishNotifierDialog : DialogWindow
    {
        public ConfigurationModel configurationModel { get; set; }
        public bool isNotify { get; set; } = false;

        public PublishNotifierDialog(ConfigurationModel _configurationModel)
        {
            InitializeComponent();
            configurationModel = _configurationModel;
            txtSlack.Text = configurationModel?.slackWebhookUrl;
            txtMSTeams.Text = configurationModel?.msTeamsWebhookUrl;
        }

        private void btnNotify_Click(object sender, RoutedEventArgs e)
        {
            isNotify = true;
            configurationModel.slackWebhookUrl = txtSlack.Text;
            configurationModel.msTeamsWebhookUrl = txtMSTeams.Text;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
