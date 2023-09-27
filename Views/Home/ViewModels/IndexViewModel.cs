using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Views.Home.ViewModels
{
    /// <summary>
    /// IndexViewModel is use too update the view for user in home meny
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Gets or Sets of the username
        /// </summary>
        /// <value>nameOfUser</value>
        public String nameOfUser { get; set; }

        /// <summary>
        /// Gets or Sets total of montly login 
        /// </summary>
        /// <value>amountMontlyLogin</value>
        public int amountMontlyLogin { get; set; }

        /// <summary>
        /// Gets or Sets total of deleted message
        /// </summary>
        /// <value>amountDeletedMessage</value>
        public int amountDeletedMessage { get; set; }

        /// <summary>
        /// Gets or Sets the last time user was logged in 
        /// </summary>
        /// <value>latestLoginTime</value>
        public DateTime latestLoginTime { get; set; }

        /// <summary>
        /// Gets or Sets of total un read message 
        /// </summary>
        /// <value>amountUnReadMessage</value>
        public int amountUnReadMessage { get; set; }
    }
}
