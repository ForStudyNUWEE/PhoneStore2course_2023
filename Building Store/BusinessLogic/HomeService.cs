using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic
{
    public class HomeService
    {
        private readonly ApplicationDbContext _context;
        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}