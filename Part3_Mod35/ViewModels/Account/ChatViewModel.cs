using Part3_Mod35.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part3_Mod35.ViewModels.Account
{
    public class ChatViewModel
    {
        public User You { get; set; }
        public User ToWhom { get; set; }
        public List<Message> History { get; set; }
        public MessageViewModel NewMessage { get; set; }
        public ChatViewModel()
        {
            NewMessage = new MessageViewModel();
        }

    }
}
