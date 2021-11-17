using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceDonkey.Models.Apod
{
    public class ApodResponse
    {
        public ApodResponse(string date, string explanation, string hdurl, string media_type, string service_version, string title, string url)
        {
            Date = date;
            Explanation = explanation;
            Hdurl = hdurl;
            Media_type = media_type;
            Service_version = service_version;
            Title = title;
            Url = url;
        }

        public string Date { get; }
        public string Explanation { get; }
        public string Hdurl { get; }
        public string Media_type { get; }
        public string Service_version { get; }
        public string Title { get; }
        public string Url { get; }
    }
}
