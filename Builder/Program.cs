using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        class ProductViewModel
        {
            public int Id { get; set; }
            public string CategoryName { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal DiscountedPrice { get; set; }
            public bool DiscountApplied { get; set; }
        }

        abstract class ProductBuilder
        {
            public abstract void GetProductData();
            public abstract void ApplyDiscount();
            public abstract ProductViewModel GetModel();
        }

        class NewCustomerProductBuilder : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();

            public override void ApplyDiscount()
            {
                model.Id = 1;
                model.CategoryName = "Beverages";
                model.ProductName = "Chai";
                model.UnitPrice = 20;
            }

            public override ProductViewModel GetModel()
            {
                return model;
            }

            public override void GetProductData()
            {
                model.DiscountedPrice = model.UnitPrice* (decimal)0.90;
                model.DiscountApplied = true;
            }
        }

        class OldCustomerProductBuilder : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();

            public override void ApplyDiscount()
            {
                model.Id = 1;
                model.CategoryName = "Beverages";
                model.ProductName = "Chai";
                model.UnitPrice = 20;
            }

            public override ProductViewModel GetModel()
            {
                return model;
            }

            public override void GetProductData()
            {
                model.DiscountedPrice = model.UnitPrice;
                model.DiscountApplied = false;
            }
        }
   

    }

    public class ProductDirector
    {
        public void GenereteProduct(ProductBuilder builder)
        {

        }
    }
}
