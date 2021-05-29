using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    class Notification
    {
        public string Title { get; set; }
        public string NotificationText { get; set; }
        Diver Diver;

        public Notification(string title, string notificationtext, Diver diver)
        {
            this.Title = title;
            this.NotificationText = notificationtext;
            this.Diver = diver;
        }
    }
}
