using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GlanceReddit.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace WebWriter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{ 
			_logger = logger;
		}

        [HttpGet("landing")]
        public async Task<IActionResult> Home()
        {
            HomeViewModel vm = new HomeViewModel();

			//if (!IsRefreshTokenSet())
			//{
			//    string originalUrl = new AuthTokenRetrieverLib(AppId, Port, host: HostName,
			//        redirectUri: RedirectUri, AppSecret).AuthURL();

			//    string serverRedirectUri = ToDeployedRedirectUri(originalUrl);
			//    vm.RedditUrl = ToCompactUrl(serverRedirectUri);
			//}

			vm.RedditUrl = "http";
			vm.IsAuth = true;

			//if (TempData["ErrorMessage"] != null)
			vm.ErrorMessage = "ErrorMessage";

			//else if (TempData["SuccessMessage"] != null)
			vm.SuccessMessage = "SuccessMessage";

			return Ok(vm);
        }


        // redirect uri that reddit uses in oauth process
  //      [Route("auth-redirect")]
		//public ActionResult AuthRedirect()
		//{
		//	OauthController oauthController = new OauthController();

		//	string state = GetQueryString("state");
		//	string code = GetQueryString("code");

		//	string token = oauthController.FetchToken(code, state).RefreshToken;

		//	CookieOptions options = new CookieOptions();
		//	options.Expires = DateTime.Now.AddDays(2);
		//	options.Secure = true;
		//	Response.Cookies.Append("RefreshToken", token, options);

		//	return View();
		//}

		//// go back to home page after opening oauth page
		//[Route("login")]
		//[ValidateAntiForgeryToken]
		//[HttpPost]
		//public ActionResult BeginLogin(RedditRequestViewModel viewRequest)
		//{
		//	if (!IsRefreshTokenSet())
		//	{
		//		return RedirectToAction(nameof(Home));
		//	}

		//	TempData["ErrorMessage"] = AlreadyAuthError;
		//	return RedirectToAction(nameof(Home));
		//}

		//public ActionResult SignOut()
		//{
		//	if (IsRefreshTokenSet())
		//	{
		//		Response.Cookies.Delete("RefreshToken");
		//		TempData["SuccessMessage"] = LogOutSuccess;
		//	}

		//	else
		//		TempData["ErrorMessage"] = NotAuthError;

		//	return RedirectToAction(nameof(Home));
		//}

		//private List<Reddit.Controllers.Post> Search(string query, RedditUser redditor)
		//{
		//	if (!IsRefreshTokenSet())
		//	{
		//		return null;
		//	}

		//	Reddit.Inputs.Search.SearchGetSearchInput q =
		//					new Reddit.Inputs.Search.SearchGetSearchInput(query) { limit = SearchSubmissionLimit, sort = "best" };

		//	var queryList = redditor.Client.Search(q).ToList();

		//	return queryList;
		//}

		//[Route("search")]
		//public async Task<IActionResult> SearchResult(int? page, string searchBar)
		//{
		//	var redditor = InitRedditor();
		//	var queryList = Search(searchBar, redditor);

		//	if (queryList == null)
		//	{
		//		TempData["ErrorMessage"] = NotAuthError;
		//		return RedirectToAction(nameof(Home));
		//	}

		//	else if (!queryList.Any())
		//	{ 
		//		return View(new SearchResultViewModel(
		//			queryList.ToPagedList(0, 0),
		//			searchBar));
		//	}
			
		//	int pageSize = 5;
		//	int pageNumber = (page ?? 1);

		//	SearchResultViewModel vm = 
		//		new SearchResultViewModel(
		//			queryList.ToPagedList(pageNumber, pageSize), 
		//			searchBar);

		//	vm.StatsModel = await PopulateSearchStatsModel(searchBar, redditor, queryList);

		//	return View(vm);
		//}
	}
}
