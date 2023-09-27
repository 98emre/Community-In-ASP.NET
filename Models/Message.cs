using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Model
{     /// <summary>
      /// Messsage is use too make an update in the MessageDb
      /// </summary>
      
    public class Message
    {
        /// <summary>
        /// Gets or Sets of the id of the message 
        /// </summary>
        /// <value>id</value>
        public int id {get; set;}

        /// <summary>
        /// Gets or Sets name of the sender
        /// </summary>
        /// <value>nameOfSender</value>
        public String nameOfSender{get; set;}

        /// <summary>
        /// Gets or Sets time when the message was sent
        /// </summary>
        /// <value>theTimeStame</value>
        public DateTime theTimeStame{get; set;}

        /// <summary>
        /// Gets or Sets of messages header
        /// </summary>
        /// <value>header</value>
        public String header{get; set;}

        /// <summary>
        /// Gets or Sets name of the reveiver
        /// </summary>
        /// <value>nameOfReceiver</value>
        public String nameOfReceiver{get; set;}

        /// <summary>
        /// Gets or Sets of an text message
        /// </summary>
        /// <value>message</value>
        public String message{get; set;}

        /// <summary>
        /// Gets or Sets check if the was meesage is read or not
        /// </summary>
        /// <value>messageWasRead</value>
        public bool messageWasRead{get; set;}
    }
}
