using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebWriter.Server.Services
{
    public class ChapterTitleDate
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public ChapterTitleDate(string title, DateTime date)
        {
            Title = title;
            Date = date;
        }
    }

    public class Analytics
    {
        private readonly RoyalRoadAPI _api = new RoyalRoadAPI();

        private int? GetId(string url)
        {
            var trimmedUrl = url.Trim();
            var match = System.Text.RegularExpressions.Regex.Match(trimmedUrl, @"/fiction/(\d+)/");
            return match.Success ? int.Parse(match.Groups[1].Value) : (int?)null;
        }

        private async Task<Fiction> GetFiction(string url)
        {
            var id = GetId(url);
            if (id == null) throw new Exception("Invalid URL");
            var response = await _api.Fiction.GetFictionAsync(id.Value);
            return response.Data;
        }

        public async Task<Fiction> GetFictionObj(string url)
        {
            return await GetFiction(url);
        }

        public async Task<Dictionary<string, List<string>>> GetConsistencyAnalytics(string url)
        {
            var fiction = await GetFiction(url);
            var chapterArray = fiction.Chapters;

            var chapterDateArray = chapterArray
                .Select(ch => new ChapterTitleDate(ch.Title, ch.Release))
                .ToList();

            return TitleDateToMap(chapterDateArray);
        }

        private Dictionary<string, List<string>> TitleDateToMap(List<ChapterTitleDate> chapterDateArray)
        {
            var dateDict = new Dictionary<string, List<string>>();

            foreach (var cd in chapterDateArray)
            {
                var monthYear = cd.Date.ToString("MMMM yyyy", CultureInfo.InvariantCulture);

                if (!dateDict.ContainsKey(monthYear))
                {
                    dateDict[monthYear] = new List<string>();
                }

                dateDict[monthYear].Add(cd.Title);
            }

            return dateDict;
        }
    }
}
