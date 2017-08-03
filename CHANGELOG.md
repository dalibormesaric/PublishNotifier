# Road map

- [ ] Add git branch info to notification (https://github.com/thiagotts/show-my-git-branch/blob/master/ShowMyGitBranch/BranchGetter.cs)
- [ ] Add publish profile info to notification
- [ ] Add custom message to notification
- [ ] Add user info from signed in user to notification (http://stackoverflow.com/questions/31353014/accessing-current-microsoft-account-from-visual-studio-extension or Environment.UserName)

Features that have a checkmark are complete and available for
download in the
[CI build](http://vsixgallery.com/extension/763d21f2-0b6e-49d1-ac3c-bd3a74e78566/).

# Change log

These are the changes to each version that has been released
on the official Visual Studio extension gallery.

## 1.2

- [x] Support Visual Studio 2017

## 1.1

- [x] Change Slack library from [SlackAPI](https://github.com/Inumedia/SlackAPI) to [Slack.Webhooks](https://github.com/nerdfury/Slack.Webhooks)

## 1.0

- [x] Initial release
- [x] One-Click Publish sends a notification to your Slack channel and/or HipChat room
- [x] The configuration is saved in PublishNotifier.json so you can commit it to source control