namespace PizzaMore.ServiceLayers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Models;
    using ViewModels;
    using SimpleHttpServer.Models;

    public class DisplayAllPizzas
    {
        public IEnumerable<PizzaViewModel> GetPizzas(HttpSession session)
        {
            var pizzasVMs = new List<PizzaViewModel>();
            ConfigureMapper();

            using (var context = new PizzaMoreContext())
            {
                var pizzas = context.Pizzas.ToList();
                foreach (var pizza in pizzas)
                {
                    PizzaViewModel pizzaVM = new PizzaViewModel
                    {
                        Id = pizza.Id,
                        ImageUrl = pizza.ImageUrl,
                        Title = pizza.Title,
                        Owner = context.Sessions.FirstOrDefault(s => s.SessionId == session.Id).User,
                        UpVotes = pizza.UpVotes,
                        DownVotes = pizza.DownVotes,
                        VotedUsers = pizza.UsersVoted
                    };
                    pizzasVMs.Add(pizzaVM);
                }
            }
            return pizzasVMs;
        }

        public void ConfigureMapper()
        {
            Mapper.Initialize(expression => expression.CreateMap<PizzaViewModel, Pizza>());
        }
    }
}