using System;
using System.Windows;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace WpfCallingWin10Api.Core
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonShowToast_Click(object sender, RoutedEventArgs e)
        {
            string title = "The current time is";
            string timeString = $"{DateTime.Now:HH:mm:ss}";
            string thomasImage = "https://www.thomasclaudiushuber.com/thomas.jpg";

            string toastXmlString =
            $@"<toast><visual>
                    <binding template='ToastGeneric'>
                    <text>{title}</text>
                    <text>{timeString}</text>
                    <image src='{thomasImage}'/>
                    </binding>
                </visual></toast>";

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(toastXmlString);

            var toastNotification = new ToastNotification(xmlDoc);

            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toastNotification);
        }
    }
}
