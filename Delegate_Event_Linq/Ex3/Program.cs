using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Event_Linq.Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var brands = new List<Brand>()
            {
                new Brand{ID=1, Name="Công ty AAA" },
                new Brand{ID=2, Name="Công ty BBB" },
                new Brand{ID=4, Name="Công ty CCC" },
            };

            var products = new List<Product>()
            {
                new Product(1,  "Bàn Trà",     400,  new string[]{"Xám", "Xanh"},        2),
                new Product(2,  "Tranh Treo",  400,  new string[]{"Vàng", "Xanh"},       1),
                new Product(3,  "Đèn Trùm",    500,  new string[]{"Trắng"},              3),
                new Product(4,  "Bàn Học",     200,  new string[]{"Trắng", "Xanh"},      1),
                new Product(5,  "Túi Da",      300,  new string[]{"Đỏ", "Đen", "Vàng"},  2),
                new Product(6,  "Giường Ngủ",  500,  new string[]{"Trắng"},              2),
                new Product(7,  "Tủ Áo",       600,  new string[]{"Trắng"},              3)
            };

            Console.WriteLine("List all Products with their Brands");
            var ketqua = from product in products
                         join brand in brands on product.Brand equals brand.ID into t
                         from brand in t.DefaultIfEmpty()
                         select new
                         {
                             name = product.Name,
                             brand = (brand == null)? "NO-BRAND" : brand.Name,
                             price = product.Price
                         };
            foreach (var item in ketqua)
            {
                Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
            }

            //111111111111111111
            Console.WriteLine("Filter out products with a price of 400.");
            var kq1 = from product in products
                      where product.Price == 400
                      select product;
            foreach(var item in kq1 ) Console.WriteLine(item.ToString());
            
            //222222222222222222
            Console.WriteLine("Filter out products that contain the color yellow.");
            var kq2 = from product in products
                      where product.Colors.Contains("Vàng")
                      select product;
            foreach (var item in kq2) Console.WriteLine(item.ToString());
            
            //333333333333333333
            Console.WriteLine("Display the list of products in descending order of price.");
            var kq3 = from product in products
                      orderby product.Price descending 
                      select product;
                      
            foreach (var item in kq3) Console.WriteLine(item.ToString());

            Console.ReadLine();
        }

    }
}
