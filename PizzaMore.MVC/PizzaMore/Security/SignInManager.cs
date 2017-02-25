namespace PizzaMore.Security
{
    using System.Linq;
    using SimpleHttpServer.Models;
    using Interfaces;
    using System;

    public class SignInManager
    {
        private IDbIdentityContext dbContext;

        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }
             return this.dbContext.Sessions.Any(s => s.SessionId == session.Id && s.isActive);
        }

        public void Logout(HttpSession session)
        {
            dbContext.Sessions.FirstOrDefault(s => s.SessionId == session.Id).isActive = false;
            session.Id = new Random().Next().ToString();
            this.dbContext.SaveChanges();
        }
    }
}