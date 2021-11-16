using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();


                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(new List<Supplier>()
                    {
                        new Supplier()
                        {
                            Name = "Lays",
                            Logo = "https://logos-world.net/wp-content/uploads/2020/12/Lays-Logo.png",
                            Description = "Lay's is a brand of potato chips, as well as the name of the company that founded the chip brand in the United States. The brand has also sometimes been referred to as Frito-Lay because both Lay’s and Fritos are brands sold by the Frito-Lay company, which has been a wholly owned subsidiary of PepsiCo since 1965."
                        },
                        new Supplier()
                        {
                            Name = "Adidas",
                            Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Adidas_Logo.svg/2560px-Adidas_Logo.svg.png",
                            Description = "Adidas AG is a German multinational corporation, founded and headquartered in Herzogenaurach, Germany, that designs and manufactures shoes, clothing and accessories. It is the largest sportswear manufacturer in Europe, and the second largest in the world, after Nike."
                        },
                        new Supplier()
                        {
                            Name = "Dell",
                            Logo = "https://1000logos.net/wp-content/uploads/2017/07/Dell-Logo.png",
                            Description = "Dell is an American multinational computer technology company that develops, sells, repairs, and supports computers and related products and services, and is owned by its parent company of Dell Technologies."
                        },
                        new Supplier()
                        {
                            Name = "Toyota",
                            Logo = "https://www.carlogos.org/car-logos/toyota-logo-2019-3700x1200.png",
                            Description = "Toyota Motor Corporation is a Japanese multinational automotive manufacturer headquartered in Toyota City, Aichi, Japan. It was founded by Kiichiro Toyoda and incorporated on August 28, 1937. Toyota is one of the largest automobile manufacturers in the world, producing about 10 million vehicles per year."
                        },
                        new Supplier()
                        {
                            Name = "Hot Wheels",
                            Logo = "https://logosvector.net/wp-content/uploads/2013/03/hot-wheels-toy-vector-logo.png",
                            Description = "Hot Wheels is a brand of die-cast toy cars introduced by American toymaker Mattel in 1968. It was the primary competitor of Matchbox until 1997, when Mattel bought Tyco Toys, former owner of Matchbox."
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Shippings.Any())
                {
                    context.Shippings.AddRange(new List<Shipping>()
                    {
                        new Shipping()
                        {
                            ImageURL = "https://cdn-icons-png.flaticon.com/512/3/3843.png",
                            Name = "Train",
                            Description = "Products transported by train have the best chance of not getting broken, even if it takes a little longer"
                        },
                        new Shipping()
                        {
                            ImageURL = "https://lh3.googleusercontent.com/proxy/pRxfYDRIq-sWpjqBqQXx3_BXXOw7oIUIibG5NwWjcDSA0F4_j9lAwVUhPrpSKOP4vsPHYihGsxY_tPBROocXGUGB027UFEaZduZYlbfBfhXWfkDCN-JLj5K2tvNICW46X9uZNeteC83OjtFg-DcBSLY",
                            Name = "Truck",
                            Description = "Trucks are the best way to get a bunch of stuff from one location to another"
                        },
                        new Shipping()
                        {
                            ImageURL = "https://cdn.pixabay.com/photo/2019/10/14/07/53/travel-4548127_1280.png",
                            Name = "Plane",
                            Description = "Planes are the fastest way to get things from one place to another but are also the most risky"
                        },
                        new Shipping()
                        {
                            ImageURL = "https://cdn.pixabay.com/photo/2016/01/20/10/43/travel-1151274_1280.png",
                            Name = "Boat",
                            Description = "Boats may not be the fastest, but they sure can move a lot of stuff"
                        },
                        new Shipping()
                        {
                            ImageURL = "https://freesvg.org/img/Drone_simple.png",
                            Name = "Drone",
                            Description = "Drones are not a popular form of moving products, YET, but they are pretty reliable"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Warranties.Any())
                {
                    context.Warranties.AddRange(new List<Warranty>()
                    {
                        new Warranty()
                        {
                            ImageURL = "http://skyhighstudent.com/images/30Day.png",
                            Name = "30 Day Warranty",
                            Description = "Return your item within 30 Days for a moneyback Guarantee"
                        },
                        new Warranty()
                        {
                            ImageURL = "http://skyhighstudent.com/images/6Month.png",
                            Name = "6 Month Warranty",
                            Description = "Return your item within 6 Months for a moneyback Guarantee"
                        },
                        new Warranty()
                        {
                            ImageURL = "http://skyhighstudent.com/images/1Year.png",
                            Name = "1 Year Warranty",
                            Description = "Return your item within 1 Year for a moneyback Guarantee"
                        },
                        new Warranty()
                        {
                            ImageURL = "http://skyhighstudent.com/images/3Year.png",
                            Name = "3 Year Warranty",
                            Description = "Return your item within 3 Years for a moneyback Guarantee"
                        },
                        new Warranty()
                        {
                            ImageURL = "http://skyhighstudent.com/images/5Year.png",
                            Name = "5 Year Warranty",
                            Description = "Return your item within 5 Years for a moneyback Guarantee"
                        },
                        new Warranty()
                        {
                            ImageURL = "http://skyhighstudent.com/images/5Year.png",
                            Name = "No Warranty",
                            Description = "Item is Not Eligable for a Warranty"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ImageURL = "https://m.media-amazon.com/images/I/81vJyb43URL._SL1500_.jpg",
                            Name = "Lays Classic Potato Chips",
                            Description = "You know and love them (8oz)",
                            Price = 4.79,
                            Added = DateTime.Now,
                            ProductCategory = ProductCategory.Food,
                            WarrantyId = 6,
                            SupplierId = 1
                        },
                        new Product()
                        {
                            ImageURL = "https://assets.adidas.com/images/w_600,f_auto,q_auto/d55a5bfc35404d228b4eacb800d333c4_9366/NMD_R1_Shoes_Black_GZ7922_01_standard.jpg",
                            Name = "NMD_R1 Shoes",
                            Description = "Stand out in the concrete jungle. Inspired by an acclaimed '80s runner from the adidas archives, these NMD_R1 Shoes provide a sock-like fit with a stretchy and supportive knit upper. Energy-returning Boost cushioning provides all-day comfort, and midsole plugs on the sides stand out as the recognizable mark of iconic NMD style. And if that isn't enough to draw some attention, the chic colors sure will.",
                            Price = 150,
                            Added = DateTime.Now,
                            ProductCategory = ProductCategory.Clothing,
                            WarrantyId = 3,
                            SupplierId = 2
                        },
                        new Product()
                        {
                            ImageURL = "https://m.media-amazon.com/images/I/61lpHybomRS._AC_SL1500_.jpg",
                            Name = "Dell Latitude 3510 Business Laptop",
                            Description = "8GB DDR4 Memory, 10th Gen Intel Core I5-10210U Processor, 15.6\"HD Anti-Glare Screen, Type-C Charger",
                            Price = 999.99,
                            Added = DateTime.Now,
                            ProductCategory = ProductCategory.Electronics,
                            WarrantyId = 4,
                            SupplierId = 3
                        },
                        new Product()
                        {
                            ImageURL = "https://www.toyota.com/imgix/content/dam/toyota/jellies/max/2022/4runner/sr5/8664/8s6/2.png?fm=webp&bg=white&w=768&h=328",
                            Name = "Toyota 4Runner",
                            Description = "If your interest mostly revolves around off-roading and going on adventures, then the 4Runner is a great buy.",
                            Price = 50000,
                            Added = DateTime.Now,
                            ProductCategory = ProductCategory.Cars,
                            WarrantyId = 5,
                            SupplierId = 4
                        },
                        new Product()
                        {
                            ImageURL = "https://m.media-amazon.com/images/I/81QP8gl5ETS._AC_SL1500_.jpg",
                            Name = "20 Pack Hot Wheels Cars",
                            Description = "20 Randomly selected Hot Wheel cars that are perfect for the kids to play with",
                            Price = 50,
                            Added = DateTime.Now,
                            ProductCategory = ProductCategory.Toys,
                            WarrantyId = 2,
                            SupplierId = 5
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Shipping_Products.Any())
                {
                    context.Shipping_Products.AddRange(new List<Shipping_Product>()
                    {
                        new Shipping_Product()
                        {
                            ShippingId = 1,
                            ProductId = 1
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 2,
                            ProductId = 1
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 3,
                            ProductId = 2
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 4,
                            ProductId = 2
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 5,
                            ProductId = 2
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 1,
                            ProductId = 3
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 2,
                            ProductId = 3
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 3,
                            ProductId = 3
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 4,
                            ProductId = 3
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 1,
                            ProductId = 4
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 1,
                            ProductId = 5
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 2,
                            ProductId = 5
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 3,
                            ProductId = 5
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 4,
                            ProductId = 5
                        },
                        new Shipping_Product()
                        {
                            ShippingId = 5,
                            ProductId = 5
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
