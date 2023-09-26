﻿namespace UrlShortener.Data.Models
{
    public class UrlDb
    {
        public int? Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public int ClicksCount { get; set; }
        public string Created { get; set; }
    }
}
