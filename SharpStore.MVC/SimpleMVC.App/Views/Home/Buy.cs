using System.IO;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Views.Home
{
    public class Buy : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/buy.html");
        }
    }
}