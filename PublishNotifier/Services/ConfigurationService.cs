using EnvDTE;
using Newtonsoft.Json;
using System;
using System.IO;

namespace PublishNotifier
{
    public class ConfigurationService : IDisposable
    {
        private ConfigurationModel _configurationModel;

        public ConfigurationService(SelectedItem selectedItem, string configurationFileFullPath)
        {
            EnsureConfigurationFileExists(selectedItem, configurationFileFullPath);
        }

        public ConfigurationModel GetConfigurationModel()
        {
            return _configurationModel;
        }

        public void SaveConfiguration(string path, ConfigurationModel publishNotifierConfiguration)
        {
            var publishNotifierConfigurationString = JsonConvert.SerializeObject(publishNotifierConfiguration);

            using (StreamWriter writetext = new StreamWriter(path))
            {
                writetext.WriteLine(publishNotifierConfigurationString);
            }
        }

        private void EnsureConfigurationFileExists(SelectedItem selectedItem, string configurationFileFullPath)
        {
            if (File.Exists(configurationFileFullPath))
            {
                EnsureConfigurationIsValid(configurationFileFullPath);
            }
            else
            {
                SaveDefaultConfiguration(configurationFileFullPath);

                selectedItem.Project.ProjectItems.AddFromFile(configurationFileFullPath);
                selectedItem.Project.Save();
            }
        }

        private void EnsureConfigurationIsValid(string path)
        {
            try
            {
                string readContents;
                using (StreamReader streamReader = new StreamReader(path))
                {
                    readContents = streamReader.ReadToEnd();
                }

                _configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(readContents);
            }
            catch
            {
                SaveDefaultConfiguration(path);
            }
        }

        private void SaveDefaultConfiguration(string path)
        {
            _configurationModel = GetDefaultConfiguration();
            SaveConfiguration(path, _configurationModel);
        }

        private ConfigurationModel GetDefaultConfiguration()
        {
            return new ConfigurationModel()
            {
                slackBotIntegrationApiToken = string.Empty,
                hipChatBotIntegrationUrl = string.Empty
            };
        }

        public void Dispose()
        {
        }
    }
}
