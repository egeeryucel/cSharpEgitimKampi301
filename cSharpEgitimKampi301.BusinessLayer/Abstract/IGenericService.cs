using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpEgitimKampi301.BusinessLayer.Abstract
{
    public interface IGenericService <T> where T : class // T değeri bizim entity classlarımızı temsil edecek
    {
        //NEDEN T EKLEDİK? aşağıdaki metotların başına T ekledik çünkü bu metotlar generic olacak ? yani her entity için geçerli olacak
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);

        List<T> TGetAll();// Tüm verileri listeleme

        T TGetById(int id);// Id'ye göre veri getirme
    }
}
