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
    public class EfCategoryDal:GenericRepository<Category>, ICategoryDal
    {

    }
}
