using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SepetIslemi.Models.Carts
{
    [Serializable]
    public class CartItem
    {
        public CartItem()
        {
            Amount = 1;
        }

        //[JsonProperty("ID")]
        public int ID { get; set; }

        //[JsonProperty("Name")]
        public string Name { get; set; }
        
        //[JsonProperty("Amount")]
        public short Amount { get; set; }

        //[JsonProperty("Price")]
        public decimal Price { get; set; }

        //[JsonProperty("SubPrice")]
        public decimal SubPrice => Amount * Price;
    }
}
