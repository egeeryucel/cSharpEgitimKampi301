using cSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpEgitimKampi301.DataAccessLayer.Context
{
    public class KampContext : DbContext// ? KampContext sınıfı, Entity Framework'ün DbContext sınıfından türetilmiştir. NEDEN KULLANILIR: Veritabanı bağlantısını ve varlıkların yönetimini sağlamak için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu sınıf, veritabanı tablolarını temsil eden DbSet özelliklerini içerir ve Entity Framework'ün veritabanı işlemlerini gerçekleştirmesine olanak tanır.
    {
        public DbSet<Category> Categories { get; set; } // ? Categories özelliği, Category varlıklarını temsil eden bir DbSet'tir. NEDEN KULLANILIR: Veritabanındaki Category tablosu ile etkileşimde bulunmak için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu özellik, Category türündeki varlıkların CRUD işlemlerini gerçekleştirmek için kullanılır.
        public DbSet<Product> Products { get; set; } // ? Products özelliği, Product varlıklarını temsil eden bir DbSet'tir. NEDEN KULLANILIR: Veritabanındaki Product tablosu ile etkileşimde bulunmak için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu özellik, Product türündeki varlıkların CRUD işlemlerini gerçekleştirmek için kullanılır.
        public DbSet<Customer> Customers { get; set; } // ? Customers özelliği, Customer varlıklarını temsil eden bir DbSet'tir. NEDEN KULLANILIR: Veritabanındaki Customer tablosu ile etkileşimde bulunmak için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu özellik, Customer türündeki varlıkların CRUD işlemlerini gerçekleştirmek için kullanılır.
        public DbSet<Order> Orders { get; set; } // ? Orders özelliği, Order varlıklarını temsil eden bir DbSet'tir. NEDEN KULLANILIR: Veritabanındaki Order tablosu ile etkileşimde bulunmak için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu özellik, Order türündeki varlıkların CRUD işlemlerini gerçekleştirmek için kullanılır.
        public DbSet<Admin> Admins { get; set; } // ? Admins özelliği, Admin varlıklarını temsil eden bir DbSet'tir. NEDEN KULLANILIR: Veritabanındaki Admin tablosu ile etkileşimde bulunmak için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu özellik, Admin türündeki varlıkların CRUD işlemlerini gerçekleştirmek için kullanılır.


    }
}
