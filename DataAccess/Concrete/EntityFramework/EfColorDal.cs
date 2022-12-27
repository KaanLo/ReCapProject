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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var AddedOne = context.Entry(entity);
                    AddedOne.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Color entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var DeleteOne = context.Entry(entity);
                DeleteOne.State = EntityState.Deleted;
                context.SaveChanges();
            }
            

        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);

            }
        }

       

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return null == 0 ?
                    context.Set<Color>().ToList() 
                    :context.Set<Color>().Where(filter).ToList();
            }
            
        }

        public void Update(Color entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var UptadeOne = context.Entry(entity);
                UptadeOne.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
