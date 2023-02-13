using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
 
    public class EfProductDal : EfEntityRepositoryBase<Product, OzztechContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (OzztechContext context = new OzztechContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto 
                             {
                                 ProductId = p.ProductId, ProductName = p.ProductName
                                 
                             };
                return result.ToList();
            }
        }
    }
}
