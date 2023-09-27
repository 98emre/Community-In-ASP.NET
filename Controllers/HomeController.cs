using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DistroLabb2.Model;
using Microsoft.AspNetCore.Identity;
using DistroLabb2.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using DistroLabb2.Views.Home.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using DistroLabb2.Views.Inbox.ViewModels;
using DistroLabb2.Models;

namespace DistroLabb2.Controllers
{
    /// <summary>
    /// This is the controller for the home page and send page
    /// </summary>
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _user;
        private ApplicationUser appUser;
        private UserModel userModel;
        private MessageModel messageModel;

         [BindProperty]
         public SendViewModel sendViewModel { get; set; }


        public HomeController(UserManager<ApplicationUser> user)
        {
            _user = user;
            userModel = new UserModel();
            messageModel = new MessageModel();
            appUser = new ApplicationUser();
        }

        /// <summary>
        /// This is controller for the home page where you can see
        /// last time login, total montly login, name of your user and total unread message 
        /// And it update the page with indexViewModel for the UI
        /// </summary>
        /// <returns>View() or View(indexModel)</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
               
            var status = HttpContext.User.Identity.IsAuthenticated;

            if (status == true)
            {
                    
                appUser = await _user.GetUserAsync(User);

                var user = userModel.retrieveDataOfUser(appUser.Id);
                var username = user.nameOfUser;
                var nrUnReadMsg = messageModel.retriveUnreadMessages(appUser.Id);
                var totalMonthLogin = user.amountMonthlyLogin;
                var previousLoginTime = user.latestLoginTime;
                var indexModel = new Views.Home.ViewModels.IndexViewModel();

                indexModel.nameOfUser = username;
                indexModel.latestLoginTime = previousLoginTime;
                indexModel.amountMontlyLogin = totalMonthLogin;
                indexModel.amountUnReadMessage = messageModel.retriveUnreadMessages(appUser.Id);

                return View(indexModel);
             }
                
            return View();
        }

        /// <summary>
        /// This is controller for the send page where you 
        /// enter the page too send message and uppload
        /// list of user you can send too, the page contains who you want too
        /// send the message too, name of the title and the text you want too send
        /// And get list of user with help of SendViewModel 
        /// </summary>
        /// <returns>View() or View(sendViewModel)</returns>
        
        [HttpGet]
        public async Task<IActionResult> Send(string nameOfUser)
        {
             appUser = await _user.GetUserAsync(User);
             sendViewModel = new SendViewModel();

             sendViewModel.listOfUsers = new SelectList(userModel.retrieveNameOfAllUser(appUser.Id));
             sendViewModel.toUser = nameOfUser;

              return View(sendViewModel);
        }

        /// <summary>
        /// This is handel also for also the send page where you can send the message
        /// this save the your message inte model messageAdd soo the message gets
        /// updated in the database.
        /// When you have send your message you will redirect too send page
        /// </summary>
        /// <returns>View() or Redirect("Send?nameOfUser=" + toUser))</returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send()
        {

                var status = ModelState.IsValid;

          if (status == true)
          {
             appUser = await _user.GetUserAsync(User);

             var message = new Message();
             var header = sendViewModel.header;
             var textState = false;
             var text = sendViewModel.message;
             var toUser = sendViewModel.toUser;
             var timeDate = DateTime.Now;
             var fromUser = appUser.UserName;

             message.header = header;
             message.messageWasRead = textState;
             message.message = text;
             message.nameOfReceiver = toUser;
             message.theTimeStame = timeDate;
             message.nameOfSender = fromUser;

             messageModel.messageAdd(message);

              return Redirect("Send?nameOfUser=" + sendViewModel.toUser);
          }

            else
            {
              return View(sendViewModel);
            }

        }

        /// <summary>
        /// This is handel the privacy site
        /// </summary>

        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// This is handel error virew
        /// </summary>
        /// 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
    }
}
