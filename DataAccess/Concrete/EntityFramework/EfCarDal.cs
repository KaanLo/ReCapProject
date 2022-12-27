using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var AddedOne = context.Entry(entity);
                AddedOne.State=EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var DeleteOne = context.Entry(entity);
                DeleteOne.State=EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return null == 0 
                    ? context.Set<Car>().ToList()
                    :context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var UptadeOne = context.Entry(entity);
                UptadeOne.State=EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
