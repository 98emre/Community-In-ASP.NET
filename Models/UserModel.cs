using DistroLabb2.Areas.Identity.Data;
using DistroLabb2.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DistroLabb2.Model
{
    /// <summary>
    /// The Model how the user are handel
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// The constructor 
        /// </summary>
        /// <value>UserModel</value>
        public UserModel()
        {  
        
        }

        /// <summary>
        /// Adding a user too userDb
        /// </summary>
        ///<param name="applicationUser">Use identtiy data </param>
        /// <value>addTheUser</value>
        public void addTheUser(ApplicationUser applicationUser)
        {
                using (var DbContext = new MailDbContext()) {
                    UserDB data = new UserDB();
                    var dateUpdate = DateTime.MinValue;
                    var id = applicationUser.Id;
                    var username = applicationUser.UserName;

                    data.id = id;
                    data.nameOfUser = username;
                    data.amountMonthlyLogin = 1;
                    data.latestLoginTime = dateUpdate;

                    DbContext.users.Add(data);
                    DbContext.SaveChanges();
                }
        }

        /// <summary>
        /// Getting list of the name of all users
        /// </summary>
        /// <param name="id">The id contain the id of user</param>
        /// <value>retrieveNameOfAllUser</value>
        public List<String> retrieveNameOfAllUser(String id)
        {
                using (var DbContext = new MailDbContext())
                {
                    List<String> names = new List<String>();
                    List<UserDB> users = new List<UserDB>();

                    users = DbContext.users.Where(x => x.id != id).ToList();

                    foreach (var i in users)
                    {
                        names.Add(i.nameOfUser);
                    }
                      return names;
                }
        }

        /// <summary>
        /// This is where you get the total numbers of deleted messages
        /// </summary>
        /// <param name="id">Contains the id of the user </param>
        /// <value>retrieveTotalOfDeletedMessages</value>
        public int retrieveTotalOfDeletedMessages(String id)
        {
                using (var DbContext = new MailDbContext())
                {
                    UserDB data = new UserDB();

                    data = DbContext.users.Where(x => x.id == id).FirstOrDefault();
                    int totalOfDeletedMessages = data.amountDeletedMessage;

                    return totalOfDeletedMessages;
                }
        }

        /// <summary>
        /// This is where it counting up everytime a user logged in a month and update total nr of loggin in a month
        /// </summary>
        /// <param name="username">Contains name of the user </param>
        /// <value>countingUpMontlyLogins</value>
        public void countingUpMontlyLogins(String username)
        {
                using (var DbContext = new MailDbContext())
                {
                     UserDB data = new UserDB();
                     data = DbContext.users.Where(x => x.nameOfUser == username).FirstOrDefault();

                     String userDate = data.latestLoginTime.Month.ToString();
                     var monthDate = DateTime.Now.Month.ToString();
                     int counting = data.amountMonthlyLogin;
                     int restart = 1;

                    if (userDate == monthDate)
                    {
                        counting = counting + 1;
                        data.amountMonthlyLogin = counting;
                    }

                    else
                    {
                        data.amountMonthlyLogin = restart;
                    }

                    DbContext.SaveChanges();
                }
        }

        /// <summary>
        /// This is where it save the last time the user was logged in
        /// </summary>
        /// <param name="id">Contains the id of the user </param>
        /// <value>LatestLoginUpdated</value>
        public void LatestLoginUpdated(String id)
        {
                using (var DbContext = new MailDbContext()) {
                    UserDB data = new UserDB();
                    var todayDate = DateTime.Now;

                    data = DbContext.users.Where(x => x.id == id).FirstOrDefault();
                    data.latestLoginTime = todayDate;
                    
                    DbContext.SaveChanges();
                }
        }

        /// <summary>
        /// This is were you get all of the users details
        /// </summary>
        /// <param name="id">Contains the id of the user </param>
        /// <value>retrieveDataOfUser</value
        public User retrieveDataOfUser(String id)
        {
                using (var DbContext = new MailDbContext())
                {
                    UserDB data = new UserDB();
                    User user = new User();

                    data = DbContext.users.Where(x => x.id == id).FirstOrDefault();
                    user.nameOfUser = data.nameOfUser;
                    user.amountDeletedMessage = data.amountDeletedMessage;
                    user.amountMonthlyLogin = data.amountMonthlyLogin;
                    user.latestLoginTime = data.latestLoginTime;

                    return user;
                }
        }
    }
}
