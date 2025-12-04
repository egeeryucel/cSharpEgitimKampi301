using cSharpEgitimKampi301.BusinessLayer.Abstract;
using cSharpEgitimKampi301.DataAccessLayer.Abstract;
using cSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpEgitimKampi301.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
       private readonly ICategoryDal _categoryDal;  // Dependency Injection ile CategoryDal'ı alıyoruz Neden? Çünkü veri erişim katmanına ihtiyaç duyacağız.
        
        public CategoryManager(ICategoryDal categoryDal) // Constructor ile ICategoryDal'ı alıyoruz
        {
            _categoryDal = categoryDal;
        }


        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity); // CategoryDal'daki Delete metodunu çağırıyoruz
        }

        public List<Category> TGetAll()
        {
             return _categoryDal.GetAll(); // CategoryDal'daki GetAll metodunu çağırıyoruz
        }

        public Category TGetById(int id)
        {
           return _categoryDal.GetById(id); // CategoryDal'daki GetById metodunu çağırıyoruz
        }

        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity); // CategoryDal'daki Insert metodunu çağırıyoruz
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity); // CategoryDal'daki Update metodunu çağırıyoruz
        }
    }
}
