﻿namespace PizzaForum.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}