﻿using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace ToyNJoy.DAL
{
    public class WishListDAL
    {
        private ToyNjoyContext context;

        public WishListDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<WishList> find(string? userName, string? orderBy, string productName, int? productTypeId, int? productMinPrice, int? productMaxPrice)
        {
            IQueryable<WishList> result = context.WishLists;
            if (!string.IsNullOrEmpty(userName))
                result = result.Where(w => w.UserName.Equals(userName));
            if (!string.IsNullOrEmpty(productName))
                result = result.Where(w => w.Product.Name.Contains(productName));
            if (productTypeId != null)
                result = result.Where(w => w.Product.TypeId == productTypeId);
            if (productMinPrice != null)
                result = result.Where(w => w.Product.Price >= productMinPrice);
            if (productMaxPrice != null)
                result = result.Where(w => w.Product.Price <= productMaxPrice);
            if (!string.IsNullOrEmpty(orderBy)) 
            {
                switch (orderBy)
                {
                    case "SerialNamber":
                        result = result.OrderByDescending(w => w.SerialNamber);
                        break;
                    case "JoinDate":
                        result = result.OrderByDescending(w => w.JoinDate);
                        break;
                    case "Name":
                        result = result.OrderByDescending(x => x.Product.Name);
                        break;
                    case "Price":
                        result = result.OrderByDescending(x => x.Product.Price);
                        break;
                    case "ReleaseDate":
                        result = result.OrderByDescending(x => x.Product.ReleaseDate);
                        break;
                    case "Browse":
                        result = result.OrderByDescending(x => x.Product.Browse);
                        break;
                    case "Purchases":
                        result = result.OrderByDescending(x => x.Product.Purchases);
                        break;
                    case "Discount":
                        result = result.OrderByDescending(x => x.Product.Discount);
                        break;
                }
            }

            return result.Include(w => w.Product);
        }

        public bool del(string userName, IEnumerable<OrderItem> orderItems)
        {
            context.WishLists
                .Where(w => w.UserName.Equals(userName) && orderItems.Any(o => w.ProductId == o.ProductId))
                .ExecuteDelete();
            return context.SaveChanges() >= orderItems.Count();
        }
    }
}
