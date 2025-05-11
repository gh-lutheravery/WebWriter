using GlanceReddit.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebWriter.Server.Controllers
{
    public class StoryApiController : Controller
    {
        readonly string GenericError = "Something went wrong... try again.";
        readonly string NotAuthError = "You're not logged into reddit here; try again.";
        readonly string AlreadyAuthError = "You're already authenticated.";
        readonly string NoSubError = "There seems to be no subreddit with that name; " +
            "remember that there has to be a subreddit with that exact name.";
        readonly string NoUserError = "There seems to be no user with that name; " +
            "remember that there has to be a user with that exact name.";
        readonly string SocketError = "Authentication failed; try again.";
        readonly string ForbiddenError = "Reddit says you are forbidden from accessing that; it " +
            "might have been deleted or privated.";
        readonly string LoginSuccess = "Logging in was successful! ";
        readonly string LogOutSuccess = "Logging out was successful!";

        private bool IsRefreshTokenSet()
        {
            if (Request != null)
            {
                if (Request.Cookies["RefreshToken"] != null)
                    return true;
            }

            return false;
        }

        // check input before going into method
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ApiRequest(HomeViewModel viewRequest)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (viewRequest.SubredditName != null)
        //            {
        //                if (!IsRefreshTokenSet())
        //                {
        //                    TempData["ErrorMessage"] = NotAuthError;
        //                    return RedirectToAction(nameof(Home));
        //                }

        //                return RedirectToAction(nameof(Subreddit),
        //                        new { name = viewRequest.SubredditName });
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = GenericError;
        //    }

        //    return RedirectToAction(nameof(Home));
        //}
    }
}
