using DistroLabb2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistroLabb2.Model
{
    /// <summary>
    /// The Model how the messaages are handel
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// The constructor 
        /// </summary>
        /// <value>MessageModel</value>
        public MessageModel()
        {

        }

        /// <summary>
        /// Adding a message too MailDbContext 
        /// </summary>
        /// <param name="msg">Hold all value of gets sets of message </param>
        /// <value>messaAdd</value>
        public void messageAdd(Message message)
        {
                using (var DbContext = new MailDbContext()) {
                    var messageData = new MessageDB();
                    var dataSender = DbContext.users.Where(u => u.nameOfUser == message.nameOfSender).FirstOrDefault();
                    var dataReceiver = DbContext.users.Where(u => u.nameOfUser == message.nameOfReceiver).FirstOrDefault();

                    messageData.messageWasRead = message.messageWasRead;
                    messageData.theTimeStamp = message.theTimeStame;
                    messageData.header = message.header;
                    messageData.message = message.message;
                    messageData.toUser = dataReceiver;
                    messageData.fromUser = dataSender;

                    DbContext.messages.Add(messageData);
                    DbContext.SaveChanges();
                }
        }

        /// <summary>
        /// This is list of message from the user
        /// </summary>
        /// <param name="id"> The id contains the user id </param>
        /// <value>messageOfTheUser</value

        public List<Message> messageOfTheUser(String id)
        {
               using (var DbContext = new MailDbContext())
                {
                    List<Message> listOfMessages = new List<Message>();
                    List<MessageDB> data = DbContext.messages.Where(x => x.toUser.id == id).Include(r => r.toUser).Include(s => s.fromUser).ToList();

                    foreach (var i in data)
                    {
                        Message msg = new Message();

                        msg.id = i.id;
                        msg.message = i.message;
                        msg.header = i.header;
                        msg.messageWasRead = i.messageWasRead;
                        msg.theTimeStame = i.theTimeStamp;
                        msg.nameOfSender = i.fromUser.nameOfUser;
                        msg.nameOfReceiver = i.toUser.nameOfUser;

                        listOfMessages.Add(msg);
                    }
                    return listOfMessages;
                }
        }

        /// <summary>
        /// Counting up if the was read
        /// </summary>
        /// <param name="id"> The id contains the message of user id</param>
        /// <value>retriveReadMessages</value>
        public int retriveReadMessages(String id)
        {
            int counterReadMsg = 0;
            List<Message> listOfmessages = messageOfTheUser(id);

            foreach (var i in listOfmessages)
             {
                if (i.messageWasRead == true)
                {
                    counterReadMsg = counterReadMsg + 1;
                }
            }            
                return counterReadMsg;
        }

        /// <summary>
        /// Adding upp total message that was sent from the sender
        /// </summary>
        /// <param name="id"> The id contains the receiver id</param>
        /// <param name="fromUser">The String is who is the senders</param>
        /// <value>messageOfTheSender</value>
        public List<Message> messageOfTheSender(String fromUser, String id)
        {
           using (var DbContext = new MailDbContext()) {
                    
               List<MessageDB> data = DbContext.messages.Where(x => x.toUser.id == id).Include(r=> r.toUser).Include(s=>s.fromUser).ToList();
               List<Message> listOfMessages = new List<Message>();

                foreach (var i in data)
                {
                   if (fromUser.Equals(i.fromUser.nameOfUser))
                   {
                        Message msg = new Message();

                        msg.id = i.id;
                        msg.message = i.message;
                        msg.messageWasRead = i.messageWasRead;
                        msg.header = i.header;
                        msg.theTimeStame = i.theTimeStamp;
                        msg.nameOfSender = i.fromUser.nameOfUser;
                        msg.nameOfReceiver = i.toUser.nameOfUser;

                        listOfMessages.Add(msg);
                   }
                 }
                         
                return listOfMessages;
            }
        }

        /// <summary>
        /// Deleting the message from MessageDB and couting up how many delete the user has made
        /// </summary>
        /// <param name="id"> The id contains the receiver id</param>
        /// <value>messageDeleting</value>
        public void messageDeleting(int id)
        {
           using (var DbContext = new MailDbContext())
          {
               int count = 0;
               var dataMesage = new MessageDB();
               var dataUser = new UserDB();

               dataMesage = DbContext.messages.Where(x => x.id == id).Include(r=> r.toUser).FirstOrDefault();
               dataUser = DbContext.users.Where(x => x.id == dataMesage.toUser.id).FirstOrDefault();

               count = dataUser.amountDeletedMessage + 1;
               dataUser.amountDeletedMessage = count;

               DbContext.Remove(dataMesage);
               DbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Counting up the total of message that are not read
        /// </summary>
        /// <param name="id"> The id contains message of the user </param>
        /// <value>messageDeleting</value
        public int retriveUnreadMessages(string id)
        {
             int counterUnreadMsg = 0;
             List<Message> listOfmessages = messageOfTheUser(id);

             foreach (var i in listOfmessages)
             {
                 if (i.messageWasRead == false)
                 {
                    counterUnreadMsg = counterUnreadMsg + 1;
                 }
             }
              
            return counterUnreadMsg;
        }


        /// <summary>
        /// This retrive the message that where sent 
        /// </summary>
        /// <param name="id"> The id contains message of the id </param>
        /// <value>messageDeleting</value
        public Message retriveTheMessage(int id)
        {
            using (var DbContext = new MailDbContext())
            {

                MailDbContext communityContext = new MailDbContext();
                MessageDB dataMessage = communityContext.messages.Where(m => m.id == id).Include("fromUser").Include("toUser").FirstOrDefault();
                var message = new Message();

                if (dataMessage == null)
                {
                    message = null;
                    return message;
                }

                dataMessage.messageWasRead = true;
                message.id = dataMessage.id;
                message.message = dataMessage.message;
                message.messageWasRead = dataMessage.messageWasRead;
                message.nameOfReceiver = dataMessage.toUser.nameOfUser;
                message.nameOfSender = dataMessage.fromUser.nameOfUser;
                communityContext.SaveChanges();
                
                return message;
            }
        }

        /// <summary>
        /// This gets all the sender
        /// </summary>
        /// <param name="id"> The id contains the user id </param>
        /// <value>retriveTheSenders</value
        public List<String> retriveTheSenders(String id)
        {
                using (var DbContext = new MailDbContext())
                {
                    List<String> listOfSenders = new List<String>();
                    List<MessageDB> dataList = new List<MessageDB>();

                    dataList = DbContext.messages.Where(x => x.toUser.id == id).Select(i => new MessageDB { fromUser = i.fromUser }).ToList();
                    
                    foreach (var i in dataList)
                    {
                        if (listOfSenders.Any(x => x == i.fromUser.nameOfUser) == false)
                        {
                            listOfSenders.Add(i.fromUser.nameOfUser);
                        }
                    }   
                     
                    return listOfSenders;
                }
          }
    } 
    
}
