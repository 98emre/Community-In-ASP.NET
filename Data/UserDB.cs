using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Data
{
    public class UserDB
    {

        /// <summary>
        /// Gets or Sets User identifier
        /// </summary>
        /// <value>id</value>
        [Key]
        public String id{get; set;}

        /// <summary>
        /// Gets or Sets Amount of Logins in a month 
        /// </summary>
        /// <value>amounthMontlyLogin</value>
        public int amountMonthlyLogin{get; set;}

        /// <summary>
        /// Gets or Sets how many message you have deleted
        /// </summary>
        /// <value>amountDeletedMessage</value>
        public int amountDeletedMessage{get; set;}

        /// <summary>
        /// Gets or Sets name of ther user
        /// </summary>
        /// <value>nameOfUser</value>
        public String nameOfUser{get; set;}

        /// <summary>
        /// Gets or Sets check the last time you logged in
        /// </summary>
        /// <value>latestLoginTime</value>
        public DateTime latestLoginTime{get; set;}
    }
}
