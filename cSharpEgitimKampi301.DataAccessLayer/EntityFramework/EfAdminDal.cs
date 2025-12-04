using cSharpEgitimKampi301.DataAccessLayer.Abstract;
using cSharpEgitimKampi301.DataAccessLayer.Repositories;
using cSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpEgitimKampi301.DataAccessLayer.EntityFramework
{
    public class EfAdminDal:GenericRepository<Admin>, IAdminDal // ? EfAdminDal sınıfı, bu class için ne tür ek işlemler tanımlanabilir: Örneğin, Admin kullanıcılarının yetkilerini yönetme, şifre sıfırlama veya özel sorgular gibi işlemler tanımlanabilir. yani ef nin sağladığı metotlar haricinde de ek özellikler eklenebilmesi için yapıldı: Evet, EfAdminDal sınıfı GenericRepository<Admin> sınıfından türetildiği için temel CRUD işlemlerini miras alır. Ancak, IAdminDal arayüzü aracılığıyla Admin varlıkları için özel veri erişim işlemleri tanımlanabilir. Bu sayede, Admin varlıklarına özgü ek metotlar eklenebilir ve bu metotlar EfAdminDal sınıfında uygulanabilir.
    {

    }
}
