using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSite.Models
{
    public class ProjectWindow
    {
        public string picturePath { get; set; }
        public string title { get; set; }
        public string projectType { get; set; }
        public HtmlString description { get; set; }
        public string language { get; set; }
        public string youtubeLink { get; set; }
        public string githubLink { get; set; }

        public ProjectWindow(string picturePath, string title, string projectType, HtmlString description, string language, string youtubeLink, string githubLink)
        {
            this.picturePath = picturePath;
            this.title = title;
            this.projectType = projectType;
            this.description = description;
            this.language = language;
            this.youtubeLink = youtubeLink;
            this.githubLink = githubLink;
        }
    }
}
