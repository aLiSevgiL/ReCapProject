 using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCorDal : IColorDal
    {


        List<Color> _color;

        public InMemoryCorDal()
        {
            _color = new List<Color>
            {
                new Color{ColorId =1 , ColorName = "Sari"},
                new Color{ColorId =2 , ColorName = "Kirmizi"},
                new Color{ColorId =3 , ColorName = "Mavi"},
                new Color{ColorId =4 , ColorName = "Beyaz"},
                new Color{ColorId =5 , ColorName = "Pembe"},
                new Color{ColorId =6 , ColorName = "Mor"},
                new Color{ColorId =7 , ColorName = "Gri"},
                new Color{ColorId =8 , ColorName = "Siyah"},
                new Color{ColorId =9 , ColorName = "Eflatun"},

            };


        }


        public void Add(Color color)
        {
            _color.Add(color);

        }

        public void Delete(Color color)
        {
            Color DeleteColor = _color.First(p=>p.ColorId == color.ColorId);

            _color.Remove(DeleteColor);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _color;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetByColorId(int colorid)
        {
            return _color.Where(p => p.ColorId == colorid).ToList(); ;
        }

        public Color GetT(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Color color)
        {

            Color UpdateColor = _color.First(p => p.ColorId == color.ColorId);

            UpdateColor.ColorName = color.ColorName;

        }
    }
}
