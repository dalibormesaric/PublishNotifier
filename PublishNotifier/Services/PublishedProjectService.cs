﻿using EnvDTE;
using EnvDTE80;
using System;
using System.IO;

namespace PublishNotifier
{
    public class PublishedProjectService : IDisposable
    {

        private DTE2 _application;
        private SelectedItem _selectedItem;

        private const string _publishNotifierFileName = "PublishNotifier.json";

        public PublishedProjectService(DTE2 application)
        {
            _application = application;
        }

        public SelectedItem GetSelectedItem()
        {
            if (_selectedItem == null)
            {
                _selectedItem = _application.SelectedItems.Count == 1 ? _application.SelectedItems.Item(1) : null;
            }

            return _selectedItem;
        }

        public string GetProjectName()
        {
            return GetSelectedItem()?.Name;
        }

        public string GetProjectFullPath()
        {
            return GetSelectedItem()?.Project?.FullName;
        }

        public string GetConfigurationFileFullPath()
        {
            var projectDirectory = Path.GetDirectoryName(GetProjectFullPath());
            return Path.Combine(projectDirectory, _publishNotifierFileName);
        }

        public void Dispose()
        {
        }
    }
}
