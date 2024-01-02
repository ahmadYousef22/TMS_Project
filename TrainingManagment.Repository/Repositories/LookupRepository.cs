using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models.Enums;
using TrainingManagment.Domain.Models;
using TrainingManagment.Repository.Data;
using TrainingManagment.Repository.Interfaces;

namespace TrainingManagment.Repository.Repositories
{
    public class LookupRepository : BaseRepository<Lookup>, ILookupRepository
    {
 
        public LookupRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Lookup> GetAllResults()
        {
            List<Lookup> results = new List<Lookup>();

            results = _context.Lookup.Where(x => x.IsActive && !x.IsDeleted && x.LookupCategoryId == (int)LookupEnum.CategoryCode.Results) .ToList();

            return results;
        }

        public List<Lookup> GetAllStatus()

        {
            List<Lookup> Status = new List<Lookup>();

            Status = _context.Lookup.Where(x => x.IsActive && !x.IsDeleted  && x.LookupCategoryId == (int)LookupEnum.CategoryCode.Status) .ToList();

            return Status;
        }

        public List<Lookup> GetAllTopics()
        {
            List<Lookup> Topics = new List<Lookup>();

            Topics = _context.Lookup.Where(x => x.IsActive && !x.IsDeleted && x.LookupCategoryId == (int)LookupEnum.CategoryCode.Topics).ToList();

            return Topics;
        }



        public List<Lookup> GetAllTrainer()
        {
            List<Lookup> trainers = new List<Lookup>();

            trainers = _context.Lookup.Where(x => x.IsActive && !x.IsDeleted && x.LookupCategoryId == (int)LookupEnum.CategoryCode.TrainerName).ToList();

            return trainers;
        }

        public List<Lookup> GetAllTypes()
        {
            List<Lookup> types = new List<Lookup>();

            types = _context.Lookup.Where(x => x.IsActive && !x.IsDeleted && x.LookupCategoryId == (int)LookupEnum.CategoryCode.Type).ToList();

            return types;
        }

        public List<Lookup> GetAllYear()
        {
            List<Lookup> year = new List<Lookup>();

            year = _context.Lookup.Where(x => x.IsActive && !x.IsDeleted && x.LookupCategoryId == (int)LookupEnum.CategoryCode.Year).OrderBy(x => x.NameEn).ToList(); ;

            return year;
        }

        public void CheckYear(string name)
        {
            string newYear = DateTime.Now.Year.ToString();
            var YearList = _context.Lookup.ToList().Select(s => s.NameEn);

            if (!YearList.Contains(newYear))
            {

                var addYear = new Lookup
                {
                    CreatedBy = name,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    LookupCategoryId =(int) LookupEnum.CategoryCode.Year,
                    NameEn = newYear,
                    NameAr = newYear
                };
                _context.Lookup.AddAsync(addYear);
                _context.SaveChanges();
            }
        }


    }
}
