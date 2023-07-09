using SalesWebMVC2.Data;
using SalesWebMVC2.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC2.Services
{
    public class SellerService
    {
        private readonly SalesWebMVC2Context _context;

        public SellerService(SalesWebMVC2Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)
        {

            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindByID(int Id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == Id);
        }

        public void remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
