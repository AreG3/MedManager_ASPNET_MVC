using MedManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MedManager.Repositories
{
    public interface IMedRepository
    {
        MedTakeModel Get(int medId);
        IQueryable<MedTakeModel> GetAllActive();

        void Add(MedTakeModel medtake);
        void update(int medID, MedTakeModel medtakes);
        void delete(int medID);
    }
}
