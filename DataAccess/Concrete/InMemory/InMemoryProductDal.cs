using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryProductDal()
        {
            _cars = new List<Car> { new Car { Id = 1, BrandId="Fiat", ColorId="Kırmızı", DailyPrice=100000},
                new Car { Id = 2, BrandId="Ford", ColorId="Sarı", DailyPrice=200000},
                new Car { Id = 3, BrandId="Skoda", ColorId="Siyah", DailyPrice=300000}




            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car DeleteOne = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(DeleteOne);

        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int categoryId)
        {
            return _cars.Where(p => p.Id == categoryId).ToList();
        }

        public void Update(Car car)
        {
            Car UpdateOne = _cars.SingleOrDefault(p => p.Id == car.Id);
            UpdateOne.DailyPrice = car.DailyPrice;
            UpdateOne.ColorId = car.ColorId;

        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
