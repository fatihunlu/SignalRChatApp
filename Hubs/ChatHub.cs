using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            MessageModel responseMessage = new MessageModel(user, message);
            await Clients.All.SendAsync("ReceiveMessage", responseMessage);
        }

        public class MessageModel
        {
            public MessageModel(string user, string message)
            {
                this.User = user;
                this.Message = message;
            }
            public string User { get; set; }
            public string Message { get; set; }
        }
    }
}
