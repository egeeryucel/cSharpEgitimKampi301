using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpEgitimKampi301.DataAccessLayer.Abstract
{

    // T değeri bizim entity classlarımızı temsil edecek
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAll();// Tüm verileri listeleme

        T GetById(int id);// Id'ye göre veri getirme


    }
}
