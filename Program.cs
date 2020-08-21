using System;
using System.IO;
using PortfolioSite;
using System.Collections.Generic;
using Microsoft.CSharp;
using Microsoft.AspNetCore.Server;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Html;
using PortfolioSite.Models;

namespace RazorPages
{
    public class Program
    {
        public static List<PersonalityWindow> personalities = new List<PersonalityWindow>();
        public static List<ProjectWindow> doneProjects = new List<ProjectWindow>();
        public static List<ProjectWindow> wipProjects = new List<ProjectWindow>();
        public static List<ProjectWindow> futureProjects = new List<ProjectWindow>();
        public static List<List<ProjectWindow>> projectsLists = new List<List<ProjectWindow>>();

        public static void Main(string[] args)
        {

            projectsLists.Add(doneProjects);
            projectsLists.Add(wipProjects);
            projectsLists.Add(futureProjects);

            ReadData();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void ReadData()
        {
            string[] csvPaths =
            {
                @"./wwwroot/Files/PersonalityInfoCSV.csv", //Personality
                @"./wwwroot/Files/DoneProjectsInfoCSV.csv",
                @"./wwwroot/Files/WIPProjectsInfoCSV.csv",
                @"./wwwroot/Files/FutureProjectsInfoCSV.csv"
            };

            for (int i = 0; i < csvPaths.Length; i++)
            {
                StreamReader sr = new StreamReader(csvPaths[i]);
                string headers = sr.ReadLine();
                string text;
                do
                {
                    text = sr.ReadLine();

                    if (text == null || text.Contains(";;;"))
                        break;

                    string[] info = text.Split(';');

                    if (info.Length == 7)
                    {
                        HtmlString description = new HtmlString(info[3]);
                        ProjectWindow window = new ProjectWindow(info[0], info[1], info[2], description, info[4], info[5], info[6]);
                        projectsLists[i - 1].Add(window);
                    }
                    else
                    {
                        HtmlString description = new HtmlString(info[2]);
                        PersonalityWindow window = new PersonalityWindow(info[0], info[1], description, info[3]);
                        personalities.Add(window);
                    }
                } while (true);

                sr.Close();

            }
        }
    }
}
