using ApplicationCore.DomainModel;
using WebShop.DAL.POCO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace WebShop.DAL
{
    public class DataBaseContext : DbContext 
    {
        public DataBaseContext() : base("DB")
        {
            Database.SetInitializer(new DBInitializer());
        }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }

   public class DBInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>

   // public class DBInitializer : DropCreateDatabaseAlways<DataBaseContext>
    {
        protected override void Seed(DataBaseContext db)
        {
            db.Roles.Add(new Role { RoleId = 1, Name = "admin" });
            db.Roles.Add(new Role { RoleId = 2, Name = "user" });

            db.Users.Add(new User
            {
                Name = "admin",
                Password = "123123",
                UserId = 1,
                RoleId = 1
            });
            db.Users.Add(new User
            {
                Name = "tom@gmail.com",
                Password = "123456",
                UserId = 2,
                RoleId = 2
            });

            db.Materials.Add(new Material { MaterialID = 1, MaterialName = "Хлопок" });
            db.Materials.Add(new Material { MaterialID = 2, MaterialName = "Полипропилен" });
            db.Materials.Add(new Material { MaterialID = 3, MaterialName = "Капрон" });
            db.Materials.Add(new Material { MaterialID = 4, MaterialName = "Полиэфир" });

            db.Delivery.Add(new Delivery { DeliveryID = 1, DeliveryService = "Интайм", DeliveryPrice = 30 });
            db.Delivery.Add(new Delivery { DeliveryID = 2, DeliveryService = "Новая почта", DeliveryPrice = 35 });
            db.Delivery.Add(new Delivery { DeliveryID = 3, DeliveryService = "Укрпочта", DeliveryPrice = 40 });
            db.Delivery.Add(new Delivery { DeliveryID = 4, DeliveryService = "Гюнсел", DeliveryPrice = 45 });
                        
            #region Products
            db.Products.Add(new Product
            {
                Description = "1",
                Diameter = 2,
                LargeImgPath = "~/Images/cords/1.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/1.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 65,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "2",
                Diameter = 3,
                LargeImgPath = "~/Images/cords/2.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/2.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 18,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "3",
                Diameter = 4,
                LargeImgPath = "~/Images/cords/3.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/3.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 16,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "4",
                Diameter = 5,
                LargeImgPath = "~/Images/cords/4.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/4.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 10,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "5",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/5.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/5.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 5,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "6",
                Diameter = 8,
                LargeImgPath = "~/Images/cords/6.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/6.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 2,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "7",
                Diameter = 10,
                LargeImgPath = "~/Images/cords/7.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/7.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 7,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "8",
                Diameter = 2,
                LargeImgPath = "~/Images/cords/8.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/8.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 4,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "9",
                Diameter = 3,
                LargeImgPath = "~/Images/cords/9.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/9.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 6,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "9",
                Diameter = 4,
                LargeImgPath = "~/Images/cords/10.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/10.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 6,
                SKU = "4862123"

            });

            db.Products.Add(new Product
            {
                Description = "1",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/11.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/11.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 65,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "2",
                Diameter = 10,
                LargeImgPath = "~/Images/cords/12.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/12.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 18,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "3",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/13.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/13.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 16,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "4",
                Diameter = 5,
                LargeImgPath = "~/Images/cords/14.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/14.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 10,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "5",
                Diameter = 4,
                LargeImgPath = "~/Images/cords/15.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/15.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 5,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "6",
                Diameter = 2,
                LargeImgPath = "~/Images/cords/16.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/16.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 2,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "7",
                Diameter = 3,
                LargeImgPath = "~/Images/cords/17.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/17.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 7,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "8",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/18.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/18.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 4,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "9",
                Diameter = 8,
                LargeImgPath = "~/Images/cords/19.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/19.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 6,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "9",
                Diameter = 8,
                LargeImgPath = "~/Images/cords/20.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/20.jpg",
                MaterialID = 2,
                Name = "Шнур рыболовный",
                PricePerMeter = 6,
                SKU = "2"

            });
            db.Products.Add(new Product
            {
                Description = "1",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/21.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/21.jpg",
                MaterialID = 3,
                Name = "Шнур рыболовный",
                PricePerMeter = 65,
                SKU = "3"

            });
            db.Products.Add(new Product
            {
                Description = "2",
                Diameter = 4,
                LargeImgPath = "~/Images/cords/22.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/22.jpg",
                MaterialID = 3,
                Name = "Шнур рыболовный",
                PricePerMeter = 18,
                SKU = "3"

            });
            db.Products.Add(new Product
            {
                Description = "3",
                Diameter = 2,
                LargeImgPath = "~/Images/cords/23.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/23.jpg",
                MaterialID = 3,
                Name = "Шнур рыболовный",
                PricePerMeter = 16,
                SKU = "3"

            });
            db.Products.Add(new Product
            {
                Description = "4",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/24.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/24.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 10,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "5",
                Diameter = 8,
                LargeImgPath = "~/Images/cords/25.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/25.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 5,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "6",
                Diameter = 8,
                LargeImgPath = "~/Images/cords/26.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/26.jpg",
                MaterialID = 3,
                Name = "Шнур рыболовный",
                PricePerMeter = 2,
                SKU = "3"

            });
            db.Products.Add(new Product
            {
                Description = "7",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/27.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/27.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 7,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "8",
                Diameter = 4,
                LargeImgPath = "~/Images/cords/28.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/28.jpg",
                MaterialID = 3,
                Name = "Шнур рыболовный",
                PricePerMeter = 4,
                SKU = "3"

            });           
            db.Products.Add(new Product
            {
                Description = "9",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/30.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/30.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 6,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "1",
                Diameter = 8,
                LargeImgPath = "~/Images/cords/31.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/31.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 65,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "2",
                Diameter = 10,
                LargeImgPath = "~/Images/cords/32.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/32.jpg",
                MaterialID = 4,
                Name = "Шнур рыболовный",
                PricePerMeter = 18,
                SKU = "4"

            });
            db.Products.Add(new Product
            {
                Description = "3",
                Diameter = 8,
                LargeImgPath = "~/Images/cords/33.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/33.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 16,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "4",
                Diameter = 5,
                LargeImgPath = "~/Images/cords/34.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/34.jpg",
                MaterialID = 4,
                Name = "Шнур рыболовный",
                PricePerMeter = 10,
                SKU = "4"

            });
            db.Products.Add(new Product
            {
                Description = "5",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/35.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/35.jpg",
                MaterialID = 4,
                Name = "Шнур рыболовный",
                PricePerMeter = 5,
                SKU = "4"

            });
            db.Products.Add(new Product
            {
                Description = "6",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/36.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/36.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 2,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "7",
                Diameter = 4,
                LargeImgPath = "~/Images/cords/37.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/37.jpg",
                MaterialID = 4,
                Name = "Шнур рыболовный",
                PricePerMeter = 7,
                SKU = "4"

            });
            db.Products.Add(new Product
            {
                Description = "8",
                Diameter = 4,
                LargeImgPath = "~/Images/cords/38.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/38.jpg",
                MaterialID = 4,
                Name = "Шнур рыболовный",
                PricePerMeter = 4,
                SKU = "4"

            });
            db.Products.Add(new Product
            {
                Description = "9",
                Diameter = 4,
                LargeImgPath = "~/Images/cords/39.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/39.jpg",
                MaterialID = 4,
                Name = "Шнур рыболовный",
                PricePerMeter = 6,
                SKU = "4"

            });
            db.Products.Add(new Product
            {
                Description = "9",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/40.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/40.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 6,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "1",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/41.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/41.jpg",
                MaterialID = 1,
                Name = "Шнур рыболовный",
                PricePerMeter = 65,
                SKU = "4862123"

            });
            db.Products.Add(new Product
            {
                Description = "2",
                Diameter = 6,
                LargeImgPath = "~/Images/cords/42.jpg",
                ThumbImgPath = "~/Images/cords/thumbs/42.jpg",
                MaterialID = 4,
                Name = "Шнур рыболовный",
                PricePerMeter = 18,
                SKU = "4"

            });
            //db.Products.Add(new Product
            //{
            //    Description = "3",
            //    Diameter = 8,
            //    LargeImgPath = "~/Images/cords/43.jpg",
            //    ThumbImgPath = "~/Images/cords/thumbs/43.jpg",
            //    MaterialID = 1,
            //    Name = "Шнур рыболовный",
            //    PricePerMeter = 16,
            //    SKU = "4862123"

            //});
            //db.Products.Add(new Product
            //{
            //    Description = "4",
            //    Diameter = 8,
            //    LargeImgPath = "~/Images/cords/44.jpg",
            //    ThumbImgPath = "~/Images/cords/thumbs/44.jpg",
            //    MaterialID = 4,
            //    Name = "Шнур рыболовный",
            //    PricePerMeter = 10,
            //    SKU = "4"

            //});
            //db.Products.Add(new Product
            //{
            //    Description = "5",
            //    Diameter = 8,
            //    LargeImgPath = "~/Images/cords/45.jpg",
            //    ThumbImgPath = "~/Images/cords/thumbs/45.jpg",
            //    MaterialID = 4,
            //    Name = "Шнур рыболовный",
            //    PricePerMeter = 5,
            //    SKU = "4"

            //});
            //db.Products.Add(new Product
            //{
            //    Description = "6",
            //    Diameter = 4,
            //    LargeImgPath = "~/Images/cords/46.jpg",
            //    ThumbImgPath = "~/Images/cords/thumbs/46.jpg",
            //    MaterialID = 3,
            //    Name = "Шнур рыболовный",
            //    PricePerMeter = 2,
            //    SKU = "3"

            //});
            //db.Products.Add(new Product
            //{
            //    Description = "7",
            //    Diameter = 4,
            //    LargeImgPath = "~/Images/cords/47.jpg",
            //    ThumbImgPath = "~/Images/cords/thumbs/47.jpg",
            //    MaterialID = 3,
            //    Name = "Шнур рыболовный",
            //    PricePerMeter = 7,
            //    SKU = "3"

            //});
            #endregion

           
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
