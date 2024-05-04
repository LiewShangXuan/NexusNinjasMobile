using Microsoft.Maui.Controls;
using NexusNinjasMobile.Chatbox;
using NexusNinjasMobile.Services;
using System;

namespace NexusNinjasMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SendMessage_Clicked(object sender, EventArgs e)
        {
            string message = MessageEntry.Text;
            if (!string.IsNullOrEmpty(message))
            {
                var messageBubble = new MessageBubble
                {
                    BindingContext = new MessageViewModel { MessageText = message, BubbleColor = Colors.Blue, HorizontalAlignment = LayoutOptions.End }
                };

                MessageContainer.Children.Add(messageBubble);

                var service = new ApiService("");
                var result = await service.Test(message);

                var messageBubble2 = new MessageBubble
                {
                    BindingContext = new MessageViewModel { MessageText = result, BubbleColor = Colors.Green, HorizontalAlignment = LayoutOptions.End }
                };

                MessageContainer.Children.Add(messageBubble2);

                MessageEntry.Text = "";
            }
        }

        private void MessageEntry_Completed(object sender, EventArgs e)
        {
            // No need to limit the text length, so no additional logic required
        }
    }
}