using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DistroLabb2.Model;
using Microsoft.AspNetCore.Identity;
using DistroLabb2.Areas.Identity.Data;
using DistroLabb2.Views.Inbox.ViewModels;
using DistroLabb2.Models;

namespace DistroLabb2.Controllers
{
    /// <summary>
    /// This is controller for the inbox
    /// </summary>
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class InboxController : Controller
    {
        private readonly UserManager<ApplicationUser> _user;
        private ApplicationUser appUser;
        private UserModel userModel;
        private MessageModel messageModel;

        public InboxController(UserManager<ApplicationUser> user)
        {
            _user = user;
            userModel = new UserModel();
            messageModel = new MessageModel();
            appUser = new ApplicationUser();
        }

        /// <summary>
        /// This is handel for the inbox page where you can see your inbox 
        /// you can see how have sent message too you, you also see
        /// how many message you have, the ammount of read message and
        /// how many messages you have deleted
        /// </summary>
        /// <returns>View() or View(indexViewModel)</returns>
       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
                appUser = await _user.GetUserAsync(User);
                List<String> listOfSenders = messageModel.retriveTheSenders(appUser.Id);

                var indexViewModel = new IndexViewModel();
                var totalNrOfMessages = messageModel.messageOfTheUser(appUser.Id).Count();
                var totalOfReadMessages = messageModel.retriveReadMessages(appUser.Id);
                var totalOfDeletedMessage = userModel.retrieveTotalOfDeletedMessages(appUser.Id);

                indexViewModel.senders = listOfSenders;
                indexViewModel.amountOfMessages = totalNrOfMessages;
                indexViewModel.amountReadMessages = totalOfReadMessages;
                indexViewModel.amountDeletedMessages = totalOfDeletedMessage;

                return View(indexViewModel);

                return View();
        }

        /// <summary>
        /// This is handel the senders in the inbox where you can see
        /// who has sent too you and if the same user send another message
        /// it will be added too their collectur message 
        /// </summary>
        /// <returns>View() or View(indexViewModel)</returns>
        
        [HttpGet]
        public async Task<IActionResult> InboxSender(string id)
        {
                if (id != null)
                {
                    appUser = await _user.GetUserAsync(User);
                    List<Message> listOfMessage = messageModel.messageOfTheSender(id, appUser.Id);
                    List<InboxViewModel> collectUserMessage = new List<InboxViewModel>();

                    var inboxSenderMessage = new InboxViewModel();

                    foreach (var i in listOfMessage)
                    {
                        var msg = new InboxViewModel();

                        msg.id = i.id;
                        msg.header = i.header;
                        msg.theTimeStamp = i.theTimeStame;
                        msg.readTheMessage = i.messageWasRead;

                        collectUserMessage.Add(msg);
                    }

                    inboxSenderMessage.messageDetails = collectUserMessage;

                    return View(inboxSenderMessage);
                }

                else
                {
                    return View();
                }

        }

        /// <summary>
        /// This is handel inbox message when click on read message you will be able too see the
        /// text message from the user.
        /// After you will able the option too return too the home page of inbox or delete the message
        /// </summary>
        /// <returns>View(), View(messageModel),NotFound() or Unauthorized() </returns>
       
        [HttpGet]
        public async Task<ActionResult> InboxMessage(int id)
        {
            var message = messageModel.retriveTheMessage(id);

            if (id == null || message == null)
            {
                return NotFound();
            }
                    
            appUser = await _user.GetUserAsync(User);

            if (message.nameOfReceiver == appUser.UserName)
            {
               var messageModel = new InboxViewModel();
               var messageId = message.id;
               var nameOfSender = message.nameOfSender;
               var header = message.header;
               var textMessage = message.message;

               messageModel.id = messageId;
               messageModel.fromUser = nameOfSender;
               messageModel.header = header;
               messageModel.message = textMessage;

               return View(messageModel);
            }
               
            else 
            {
              return Unauthorized();
            }
       }

        /// <summary>
        /// This is handel the delete a message when you open it
        /// and if you decided too delete it will redirect you too 
        /// the home site of inbox and update your number of deleted message
        /// </summary>
        /// <returns>View(), RedirectToAction(nameof(Index)),NotFound() or Unauthorized() </returns>
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var message = messageModel.retriveTheMessage(id);

            if (id == null || message == null)
            {
                return NotFound();
            }

            appUser = await _user.GetUserAsync(User);

            if (appUser.UserName == message.nameOfReceiver)
            {
                messageModel.messageDeleting(id);
                return RedirectToAction(nameof(Index));
            }

            else
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// This is handel privacy site
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// This is handel Error
        /// </summary>

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
    }
}
