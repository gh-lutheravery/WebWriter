namespace WebWriter.Server
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
}
