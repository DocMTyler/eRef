using eRef.Data;
using eRef.Models.LegislatorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Services.LegislatorService
{
    public class LegislatorService
    {
        public Guid _userID;

        private readonly ApplicationDbContext _legislator = new ApplicationDbContext();

        public LegislatorService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateNewLegislator(NewLegislatorCreate model)
        {
            Legislator entity = new Legislator
            {
                ID = model.ID,
                Name = model.Name,
                JobRole = model.JobRole,
                District = model.District
            };

            _legislator.Legislators.Add(entity);
            return _legislator.SaveChanges() == 1;
        }

        public IEnumerable<LegislatorListItem> ListLegislators()
        {
            var legislatorEntries = _legislator.Legislators.ToList();

            var listOfLegislators = legislatorEntries.Select(l => new LegislatorListItem
            {
                ID = l.ID,
                Name = l.Name,
                JobRole = l.JobRole,
                District = l.District
            }).ToList();

            return listOfLegislators;
        }

        public LegislatorListItem LegislatorEntry(int id)
        {
            var legislatorEntry = _legislator.Legislators.Single(l => l.ID == id);

            return new LegislatorListItem
            {
                ID = legislatorEntry.ID,
                Name = legislatorEntry.Name,
                JobRole = legislatorEntry.JobRole,
                District = legislatorEntry.District
            };
        }

        public bool UpdateLegislator(LegislatorUpdate model)
        {
            var legislatorEntry = _legislator.Legislators.Single(l => l.ID == model.ID);

            legislatorEntry.Name = model.Name;
            legislatorEntry.JobRole = model.JobRole;
            legislatorEntry.District = model.District;

            return _legislator.SaveChanges() == 1;
        }

        public bool DeleteLegislator(int id)
        {
            var legislatorEntry = _legislator.Legislators.Single(l => l.ID == id);
            _legislator.Legislators.Remove(legislatorEntry);
            return _legislator.SaveChanges() == 1;
        }

    }
}
