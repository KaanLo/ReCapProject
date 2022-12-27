using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _ICarDal;

        public CarManager(ICarDal ıCarDal)
        {
            _ICarDal = ıCarDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0&& car.Description.Length>1)
            {
                _ICarDal.Add(car);
                Console.WriteLine("Arac sisteme Eklendi!");
            }
            else
            {
                Console.WriteLine("Hatalı araba girisi!");
                Console.WriteLine("Araç İsmini ve Araç Günlük Fiyatını Kontrol Ediniz!");
            }



            
        }

        public List<Car> GetAll()
        {
            return _ICarDal.GetAll();

        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _ICarDal.GetAll(p=>p.DailyPrice>=min && p.DailyPrice<=max );
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _ICarDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _ICarDal.GetAll(p=>p.ColorId== colorId);
        }
    }
}
