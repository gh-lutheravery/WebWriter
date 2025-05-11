using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebWriter.Server.Services
{
    
    public class RoyalRoadAPI
    {
        private readonly HttpClient _httpClient;

        public RoyalRoadAPI()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:3000")
            };
        }

        public async Task<String> GetFictionAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(
                    $"/getFiction?fictionUrl={Uri.EscapeDataString(url)}");

                if (response == null)
                    throw new Exception("No response data");

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch fiction: {ex.Message}");
            }
        }

        public async Task<String> GetPrevWorksAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(
                    $"/getPrevWorksAnalytics?fictionUrl={Uri.EscapeDataString(url)}");

                if (response == null)
                    throw new Exception("No response data");

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch fiction: {ex.Message}");
            }
        }

        public async Task<String> GetGenresAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(
                    $"/getGenreAnalytics?fictionUrl={Uri.EscapeDataString(url)}");

                if (response == null)
                    throw new Exception("No response data");

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch fiction: {ex.Message}");
            }
        }

        public async Task<string> GetConsistencyAnalyticsAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(
                    $"/getConsistencyAnalytics?fictionUrl={Uri.EscapeDataString(url)}");

                if (response == null)
                    throw new Exception("No analytics data returned");

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch analytics: {ex.Message}");
            }
        }
    }

    //public class FictionResponse
    //{
    //    public Fiction Data { get; set; }
    //}
    

    public class Analytics
    {
        private readonly RoyalRoadAPI _api = new RoyalRoadAPI();

        private int? GetId(string url)
        {
            var trimmedUrl = url.Trim();
            var match = System.Text.RegularExpressions.Regex.Match(trimmedUrl, @"/fiction/(\d+)/");
            return match.Success ? int.Parse(match.Groups[1].Value) : (int?)null;
        }

        private async Task<String> GetFiction(string url)
        {
            //var id = GetId(url);
            //if (id == null) throw new Exception("Invalid URL");
            var response = await _api.GetFictionAsync(url);
            return response;
        }

        public async Task<String> GetPrevWorks(string url)
        {
            var response = await _api.GetPrevWorksAsync(url);
            return response;
        }

        public async Task<String> GetGenres(string url)
        {
            var response = await _api.GetGenresAsync(url);
            return response;
        }

        public async Task<Fiction> GetFictionObj(string url)
        {
            string fictStr =  await GetFiction(url);
            var result = JsonConvert.DeserializeObject<Fiction>(fictStr);
            return result;
        }

        public async Task<Dictionary<string, List<string>>> GetConsistencyAnalytics(string url)
        {
            var response = await _api.GetConsistencyAnalyticsAsync(url);
            var result = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(response);
            return result;
        }

        //public async Task<Dictionary<string, List<string>>> GetConsistencyAnalytics(string url)
        //{
        //    var fiction = await GetFictionObj(url);
        //    var chapterArray = fiction.Chapters;

        //    var chapterDateArray = chapterArray
        //        .Select(ch => new ChapterTitleDate(ch.Title, new DateTime(ch.Release)))
        //        .ToList();

        //    return TitleDateToMap(chapterDateArray);
        //}

        //private Dictionary<string, List<string>> TitleDateToMap(List<ChapterTitleDate> chapterDateArray)
        //{
        //    var dateDict = new Dictionary<string, List<string>>();

        //    foreach (var cd in chapterDateArray)
        //    {
        //        var monthYear = cd.Date.ToString("MMMM yyyy", CultureInfo.InvariantCulture);

        //        if (!dateDict.ContainsKey(monthYear))
        //        {
        //            dateDict[monthYear] = new List<string>();
        //        }

        //        dateDict[monthYear].Add(cd.Title);
        //    }

        //    return dateDict;
        //}
    }
}
