namespace Home
{
    using System.Collections.Generic;
    using PizzaMore.Data.Models;
    using PizzaMore.Utility;
    using System;

    public class Home
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header;
        private static string Language;

        static void Main()
        {
            Header = new Header();
            AddDefaultLanguageCookie();
            ShowPage();
        }

        private static void ShowPage()
        {
            Console.WriteLine(Header);
            if (Language == "BG")
            {
                ServeHtmlBg();
            }
            else
            {
                ServeHtmlEn();
            }
        }

        private static void ServeHtmlBg()
        {
            WebUtil.PrintFileContent(@"../htdocs/pm/home-bg.html");
        }

        private static void ServeHtmlEn()
        {
            WebUtil.PrintFileContent(@"../htdocs/pm/home.html");
        }

        public static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
            }
            else
            {
                if (WebUtil.IsGet())
                {
                    RequestParameters = WebUtil.RetrieveGetParameters();
                    Language = WebUtil.GetCookies()["lang"].Value;
                }
                else if (WebUtil.IsPost())
                {
                    RequestParameters = WebUtil.RetrievePostParameters();
                    string lng = RequestParameters["language"];
                    Cookie newCookie = new Cookie("lang", lng);
                    Header.AddCookie(newCookie);
                    Language = lng;
                }
            }


        }
    }
}