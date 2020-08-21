using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSite
{
    public class PersonalityWindow
    {
        public string Header { get; set; }
        public string IconPath { get; set; }
        public HtmlString Description { get; set; }
        public string BackgroundPath { get; set; }

        public PersonalityWindow(string header, string iconPath, HtmlString description, string backgroundPath)
        {
            Header = header;
            IconPath = iconPath;
            Description = description;
            BackgroundPath = backgroundPath;
        }
    }
}
