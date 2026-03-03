using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_EgitimKampi301.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class //Bir T değeri alacaksın ve bu T değeri bir class olacak diyoruz
    {

        //CRUD işlemleri için gerekli metotları tanımladık. Standart olarak tüm entitylere özgü olması için generic bir yapı kurduk. T entitysi için ekleme, güncelleme, silme, tümünü getirme ve id'ye göre getirme işlemlerini tanımladık.
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);

    }
}
