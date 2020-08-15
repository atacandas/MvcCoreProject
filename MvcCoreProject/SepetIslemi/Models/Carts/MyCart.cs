using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SepetIslemi.Models.Carts
{
    [Serializable]
    public class MyCart
    {
        public MyCart()
        {
            ListMyCartItems = new List<CartItem>();
        }

        public List<CartItem> ListMyCartItems { get; set; }

        public decimal TotalPrice => ListMyCartItems.Sum(x => x.SubPrice);

        public void Add(CartItem cartItem)
        {
            CartItem addedItem = ListMyCartItems.
                FirstOrDefault(x => x.ID == cartItem.ID);

            if (addedItem != null)
            {
                addedItem.Amount++;
            }
            else
            {
                ListMyCartItems.Add(cartItem);
            }
        }

        public void Delete(int id)
        {
            CartItem deletedItem = ListMyCartItems.FirstOrDefault(x => x.ID == id);

            if (deletedItem != null)
            {
                if (deletedItem.Amount > 1)
                {
                    deletedItem.Amount--;
                }
                else
                {
                    ListMyCartItems.Remove(deletedItem);
                }
            }
        }
    }
}
