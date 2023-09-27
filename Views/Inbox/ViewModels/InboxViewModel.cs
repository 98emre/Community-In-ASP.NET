using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Views.Inbox.ViewModels
{
    /// <summary>
    /// InboxViewModel is use too get mail details from sender
    /// </summary>
    public class InboxViewModel
    {
        /// <summary>
        /// Gets or sets name of the sender
        /// </summary>
        /// <value>fromUser</value>
        public string fromUser { get; set; }

        /// <summary>
        /// Gets or sets of a text message
        /// </summary>
        /// <value>fromUser</value>
        public string message { get; set; }

        /// <summary>
        /// Gets or sets detaisl in message like header, message and time it was sent
        /// </summary>
        /// <value>messageDetails</value>
        public List<InboxViewModel> messageDetails { get; set; }

        /// <summary>
        /// Gets or sets of the id of the user
        /// </summary>
        /// <value>id</value>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the header of the message
        /// </summary>
        /// <value>header</value>
        public String header { get; set; }

        /// <summary>
        /// Gets or sets when the message was sent
        /// </summary>
        /// <value>theTimeStamp</value>
        public DateTime theTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets if the message is read or not
        /// </summary>
        /// <value>readTheMessage</value>
        public bool readTheMessage { get; set; }
    }
}
