using cSharpEgitimKampi301.DataAccessLayer.Abstract;
using cSharpEgitimKampi301.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpEgitimKampi301.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class // ? Bu sınıf, T türünde bir generic repository (depo) sınıfıdır. NEDEN KULLANILIR: Farklı türlerdeki varlıklar için ORTAK VERİ İŞLEMLERİ gerçekleştirmek amacıyla kullanılır. DAHA DETAYLI AÇIKLAMA: Bu sınıf, IGenericDal<T> arayüzünü uygular ve T türünde varlıklar için temel veri erişim işlemlerini sağlar. T türü, sınıf (class) kısıtlamasıyla belirtilmiştir, yani sadece referans türleri için kullanılabilir.

    {
      KampContext context = new KampContext();
        // ? KampContext sınıfının bir örneğini oluşturur. NEDEN KULLANILIR: Veritabanı işlemlerini gerçekleştirmek için kullanılır. DAHA DETAYLI AÇIKLAMA: KampContext, Entity Framework DbContext sınıfından türetilmiş bir sınıftır ve veritabanı bağlantısını ve varlıkların yönetimini sağlar. Bu örnek, veri erişim işlemlerinde kullanılacaktır.
       private readonly DbSet<T> _object;
        // ? T türünde bir DbSet nesnesi tanımlar. NEDEN KULLANILIR: Veritabanındaki T türündeki varlıkları temsil eder ve bu varlıklar üzerinde CRUD işlemlerini gerçekleştirmek için kullanılır. DAHA DETAYLI AÇIKLAMA: DbSet<T>, Entity Framework tarafından sağlanan bir sınıftır ve belirli bir varlık türü için veritabanı tablolarını temsil eder. Bu örnek, T türündeki varlıklar üzerinde işlemler yapmak için kullanılacaktır.

        public GenericRepository() // ? GenericRepository sınıfının yapıcı (constructor) metodudur. NEDEN KULLANILIR: Sınıfın bir örneği oluşturulduğunda, _object alanını başlatmak için kullanılır. DAHA DETAYLI AÇIKLAMA: Yapıcı metod, KampContext içindeki T türündeki DbSet'i alır ve _object alanına atar, böylece veri erişim işlemlerinde kullanılabilir hale getirir.
        { 
            _object = context.Set<T>();
        }

        public void Delete(T entity)// ? T türünde bir varlığı silmek için kullanılan metottur. NEDEN KULLANILIR: Veritabanından belirli bir varlığı kaldırmak için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu metod, verilen entity parametresini context'e ekler, durumunu "Deleted" olarak işaretler ve ardından SaveChanges() metodunu çağırarak değişiklikleri veritabanına kaydeder.
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll() // DAHA DETAYLI AÇIKLAMA: Bu metod, _object DbSet'ini kullanarak tüm varlıkları alır ve bir liste olarak döner. neden _object ile contextin farkı ne ve neden kullanıldı: _object, T türündeki varlıkları temsil eden DbSet'tir ve GetAll() metodunda bu DbSet kullanılarak tüm varlıklar alınır. context ise veritabanı bağlantısını ve varlıkların yönetimini sağlar, ancak burada doğrudan kullanılmaz. üstteki delete ile farkı ne orada context kullanıldı burada _object kullanıldı: Delete metodunda context kullanılarak varlık durumu değiştirilirken, GetAll() metodunda _object kullanılarak varlıklar alınır. Bu, her iki metodun farklı amaçlara hizmet etmesinden kaynaklanır. farkını anlamadım: _object, T türündeki varlıkları temsil eden DbSet'tir ve GetAll() metodunda bu DbSet kullanılarak tüm varlıklar alınır. context ise veritabanı bağlantısını ve varlıkların yönetimini sağlar, ancak burada doğrudan kullanılmaz. db set ile contextin farkı ne: DbSet, belirli bir varlık türü için veritabanı tablolarını temsil ederken, context veritabanı bağlantısını ve varlıkların yönetimini sağlar. DbSet, context'in bir parçasıdır ve belirli varlıklar üzerinde işlemler yapmak için kullanılır.
        {
            return _object.ToList();
        }

        public T GetById(int id) // ? Belirli bir kimlik (ID) ile T türünde bir varlığı almak için kullanılan metottur. NEDEN KULLANILIR: Veritabanından belirli bir varlığı kimlik numarasına göre almak için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu metod, _object DbSet'ini kullanarak verilen id parametresine sahip varlığı bulur ve döner.
        {
            return _object.Find(id);
        }

        public void Insert(T entity) // ? T türünde bir varlığı eklemek için kullanılan metottur. NEDEN KULLANILIR: Veritabanına yeni bir varlık eklemek için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu metod, verilen entity parametresini context'e ekler, durumunu "Added" olarak işaretler ve ardından SaveChanges() metodunu çağırarak değişiklikleri veritabanına kaydeder.
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(T entity)// ? T türünde bir varlığı güncellemek için kullanılan metottur. NEDEN KULLANILIR: Veritabanındaki mevcut bir varlığı güncellemek için kullanılır. DAHA DETAYLI AÇIKLAMA: Bu metod, verilen entity parametresini context'e ekler, durumunu "Modified" olarak işaretler ve ardından SaveChanges() metodunu çağırarak değişiklikleri veritabanına kaydeder.
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
