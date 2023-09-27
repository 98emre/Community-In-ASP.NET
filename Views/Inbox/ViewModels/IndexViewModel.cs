using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Views.Inbox.ViewModels
{

    /// <summary>
    /// IndexViewModel is use too update the view for user in the inbox
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Gets or sets of a list of sender
        /// </summary>
        /// <value>senders</value>
        public List<String> senders { get; set; }

        /// <summary>
        /// IndexViewModel is numbers of total message user have
        /// </summary>
        /// <value>amountOfMessages</value>
        public int amountOfMessages { get; set; }

        /// <summary>
        /// IndexViewModel is numbers of how many user has read of the message in the box
        /// </summary>
        /// <value>amountReadMessages</value>
        public int amountReadMessages { get; set; }

        /// <summary>
        /// IndexViewModel is numbers of deleted messages
        /// </summary>
        /// <value>amountDeletedMessages</value>
        public int amountDeletedMessages { get; set; }
    }
}
