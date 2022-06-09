using MedManager.Models;
using System.Threading.Tasks;

namespace MedManager.Repositories
{
    public class MedTakeRepository : IMedRepository
    {
        private readonly MedManagerContext _context;
        public MedTakeRepository(MedManagerContext context)
        {
            _context = context;
        }

        public MedTakeModel Get(int medId)
            => _context.Take.SingleOrDefault(x => x.MedId == medId);

        public IQueryable<MedTakeModel> GetAllActive()
            => _context.Take.Where(x => !x.Done);

        public void Add(MedTakeModel medtake)
        {
            _context.Take.Add(medtake);
            _context.SaveChanges();
        }
        public void update(int medID, MedTakeModel medtakes)
        {
            var result = _context.Take.SingleOrDefault(x => x.MedId == medID);
            if (result != null)
            {
                result.Name = medtakes.Name;
                result.Dose = medtakes.Dose;
                result.Hour = medtakes.Hour;
                result.Done = medtakes.Done;

                _context.SaveChanges();
            }
        }

        public void delete(int medID)
        {
            var result = _context.Take.SingleOrDefault(x => x.MedId == medID);
            if(result != null)
            {
                _context.Take.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
