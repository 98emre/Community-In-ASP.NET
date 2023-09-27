using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Views.Home.ViewModels
{
    /// <summary>
    /// Use SendViewModel on the send meny
    /// </summary>
    public class SendViewModel
    {
        /// <summary>
        /// Gets or Sets list of users and is made in items
        /// </summary>
        /// <value>listOfUsers</value>
        public SelectList listOfUsers { get; set; }

        /// <summary>
        /// Gets or Sets of the receiver
        /// </summary>
        /// <value>amountDeletedMessage</value>
        [Required(ErrorMessage = "You must choose user")]
        public string toUser { get; set; }

        /// <summary>
        /// Gets or Sets the name of the title of message
        /// </summary>
        /// <value>header</value>
        [Required(ErrorMessage = "You forgot too write header")]
        public string header { get; set; }
        
        /// <summary>
        /// Gets or Sets of the text message
        /// </summary>
        /// <value>message</value>
        [Required(ErrorMessage = "You forgot too write message")]
        public string message { get; set; }
    }
}
