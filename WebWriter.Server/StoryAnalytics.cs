namespace WebWriter.Server
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generic response wrapper for Royal API responses
    /// </summary>
    /// <typeparam name="T">Type of data contained in the response</typeparam>
    public class RoyalResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public long Timestamp { get; set; }

        public RoyalResponse(T data, bool success = true)
        {
            Data = data;
            Success = success;
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }

    /// <summary>
    /// Error response for Royal API
    /// </summary>
    //public class RoyalError : RoyalResponse<dynamic>
    //{
    //    public RoyalError(string message, object data = null)
    //    {
    //        var stackTrace = Environment.StackTrace.Split('\n');

    //        var errorData = new
    //        {
    //            message = message,
    //            stack = stackTrace
    //        };
            
    //        // Combine errorData with any additional data provided
    //        Data = data == null ? errorData : new { message, stack = stackTrace, additionalData = data };
    //        Success = false;
    //        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    //    }
    //}

    /// <summary>
    /// Fiction model representing a parsed fiction
    /// </summary>
    public class Fiction
    {
        public string Type { get; set; }
        public List<string> Tags { get; set; }
        public Stats Stats { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public Author Author { get; set; }
        public List<string> Warnings { get; set; }
        public List<Chapter> Chapters { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Author information for a fiction
    /// </summary>
    public class Author
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public int Id { get; set; }
    }

    /// <summary>
    /// Statistics for a fiction
    /// </summary>
    public class Stats
    {
        public int Pages { get; set; }
        public int Ratings { get; set; }
        public int Followers { get; set; }
        public int Favorites { get; set; }
        public Views Views { get; set; }
        public Score Score { get; set; }
    }

    /// <summary>
    /// View statistics
    /// </summary>
    public class Views
    {
        public int Total { get; set; }
        public int Average { get; set; }
    }

    /// <summary>
    /// Score ratings
    /// </summary>
    public class Score
    {
        public float Style { get; set; }
        public float Story { get; set; }
        public float Grammar { get; set; }
        public float Overall { get; set; }
        public float Character { get; set; }
    }

    /// <summary>
    /// Chapter information
    /// </summary>
    public class Chapter
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public long Release { get; set; }
    }

    /// <summary>
    /// Review model for fiction reviews
    /// </summary>
    public class Review
    {
        public Score Score { get; set; }
        public Author Author { get; set; }
        public Rating Rating { get; set; }
        public string Content { get; set; }
        public long Posted { get; set; }
    }

    /// <summary>
    /// Rating for reviews
    /// </summary>
    public class Rating
    {
        public int Up { get; set; }
        public int Down { get; set; }
    }
}
