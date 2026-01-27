using C_EgitimKampi301.EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_EgitimKampi301.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product> //GenericDal'dan miras al Product sınıfı için anlamına geliyor
    {
    }
}
