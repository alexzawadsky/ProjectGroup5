using System;

namespace SomerenModel
{
    public class Drink
    {
        public int Id { get; set; }
        public string DrinkType { get; set; }

        public bool IsAlcoholic { get; set; }

        public int Stock { get; set;}

        public decimal Price { get; set;}
    }
}
