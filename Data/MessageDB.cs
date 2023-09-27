using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Data
{
    public class MessageDB
    {
        /// <summary>
        /// Gets or Sets for message identity
        /// </summary>
        /// <value>id</value>
        [Key]
        public int id {get; set;}

        /// <summary>
        /// Gets or Sets stamp of your text when it was deliver  
        /// </summary>
        /// <value>theTimeStamp</value>
        public DateTime theTimeStamp {get; set;}

        /// <summary>
        /// Gets or Sets the name of the header of message
        /// </summary>
        /// <value>header</value>
        public String header {get; set;}

        /// <summary>
        /// Gets or Sets check if you have read the message or not
        /// </summary>
        /// <value>messageWasRead</value>
        public bool messageWasRead {get; set;}

        /// <summary>
        /// Gets or Sets of message writing
        /// </summary>
        /// <value>message</value>
        public String message {get; set;}

        /// <summary>
        /// Gets or Sets who is the sender
        /// </summary>
        /// <value>fromUSertifier</value>
        public virtual UserDB fromUser {get; set;}

        /// <summary>
        /// Gets or Sets who is the receiver
        /// </summary>
        /// <value>toUSer</value>
        public virtual UserDB toUser {get; set;}
    }
}
