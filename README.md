# Publish Notifier

[![Build status](https://ci.appveyor.com/api/projects/status/6sm7bs39dqck0n37?svg=true)](https://ci.appveyor.com/project/dalibormesaric/publishnotifier)

<!-- Update the VS Gallery link after you upload the VSIX-->
Download this extension from the [VS Gallery](https://marketplace.visualstudio.com/items?itemName=dalibormesaric.PublishNotifier)
or get the [CI build](http://vsixgallery.com/extension/763d21f2-0b6e-49d1-ac3c-bd3a74e78566/).

---------------------------------------

Notify your team in Slack or HipChat when you [Deploy a Web Project Using One-Click Publish from Visual Studio](https://msdn.microsoft.com/en-us/library/dd465337(v=vs.110).aspx).

See the [change log](CHANGELOG.md) for changes and road map.

## Features

- One-Click Publish sends a notification to your Slack channel and/or HipChat room
- The configuration is saved in PublishNotifier.json so you can commit it to source control

![Publish](./docs/publish.png)

![Publish](./docs/config.png)

### Slack
To enable Slack notifications you have to add a [custom integration](https://slack.com/apps/build/custom-integration) and choose *Incoming WebHooks*. Then choose a Channel where you would like to see notifications and click *Add Incoming WebHooks integration*. Copy the Webhook URL to the Publish Notifer dialog that shows up after you Publish an application.

![Publish](./docs/slack_api_token.png)

![Publish](./docs/slack_notification.png)

### HipChat
To enable HipChat notifications you have to add an [integration](https://hipchat.com/addons/) and select a room where you would like to see notifications. Create a new integration with a name *PublishNotifier*, and copy the URL for posting messages to the Publish Notifer dialog that shows up after you Publish an application.

![Publish](./docs/hipchat_api_token.png)

![Publish](./docs/hipchat_notification.png)

## Contribute
Check out the [contribution guidelines](CONTRIBUTING.md)
if you want to contribute to this project.

For cloning and building this project yourself, make sure
to install the
[Extensibility Essentials 2019](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.ExtensibilityEssentials2019)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)