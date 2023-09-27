using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Model
{     /// <summary>
      /// User is use too make an update in the UserDB
      /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or Sets of the name of the user 
        /// </summary>
        /// <value>nameOfUser</value>
        public String nameOfUser{get; set;}

        /// <summary>
        /// Gets or Sets of how many time in a month user has been logged in 
        /// </summary>
        /// <value>amountMonthlyLogin</value>
        public int amountMonthlyLogin{get; set; }

        /// <summary>
        /// Gets or Sets of how many deleted message has been made 
        /// </summary>
        /// <value>amountDeletedMessage</value>
        public int amountDeletedMessage{get; set;}

        /// <summary>
        /// Gets or Sets when user was last seen logged in 
        /// </summary>
        /// <value>latestLoginTime</value>
        public DateTime latestLoginTime {get; set;}
    }
}
