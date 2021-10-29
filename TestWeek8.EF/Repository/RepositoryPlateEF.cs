using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;

namespace TestWeek8.EF.Repository
{
    public class RepositoryPlateEF : IRepositoryPlate
    {
        private readonly MenuContext _ctx;

        public RepositoryPlateEF(MenuContext context)
        {
            _ctx = context;
        }
        public bool AddItem(Plate item)
        {
            if (item == null)
                return false;
            _ctx.Plates.Add(item);
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            if (id <= 0)
                return false;

            var plateToDelete = _ctx.Plates.Find(id);
            if (plateToDelete == null)
                return false;
            _ctx.Plates.Remove(plateToDelete);
            _ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Plate> Fetch(Func<Plate, bool> filter = null)
        {
            if (filter != null)
                return this._ctx.Plates.Where(filter);
            return _ctx.Plates;
        }

        public Plate GetById(int id)
        {
            if (id <= 0)
                return null;
            return _ctx.Plates.Find(id);
        }

        public Plate GetMenuById(int id)
        {
            if (id<=0)
                return null;
            return _ctx.Plates.FirstOrDefault(e => e.Name.Equals(id));
        }
    }
}
