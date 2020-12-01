using eRef.Data;
using eRef.Models.LawModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Services.LawServices
{
    public class LawService
    {
        public Guid _userID;

        private readonly ApplicationDbContext _law = new ApplicationDbContext();

        public LawService(Guid userID)
        {
            _userID = userID;
        }

        public bool AuthorLaw(LawAuthor model)
        {
            Law entity = new Law
            {
                ID = model.ID,
                Name = model.Name,
                MajDescrip = model.MajDescrip,
                MinDescrip = model.MinDescrip,
                AddDescrip = model.AddDescrip,
                Author = model.Author,
                VoteScheduled = model.VoteScheduled
            };

            _law.Laws.Add(entity);
            return _law.SaveChanges() == 1;
        }

        public IEnumerable<LawListItem> ListLaw()
        {
            var lawEntries = _law.Laws.ToList();
            
            var listOfLaws = lawEntries.Select(l => new LawListItem
            {
                Name = l.Name,
                MajDescrip = l.MajDescrip,
                MinDescrip = l.MinDescrip,
                AddDescrip = l.AddDescrip,
                Author = l.Author,
                VoteScheduled = l.VoteScheduled
            }).ToList();

            return listOfLaws;
        }

        public LawListItem IndLaw(int id)
        {
            var lawEntry = _law.Laws.Single(l => l.ID == id);

            return new LawListItem
            {
                Name = lawEntry.Name,
                MajDescrip = lawEntry.MajDescrip,
                MinDescrip = lawEntry.MinDescrip,
                AddDescrip = lawEntry.AddDescrip,
                Author = lawEntry.Author,
                VoteScheduled = lawEntry.VoteScheduled
            };
        }

        public bool UpdateLaw(LawUpdate model)
        {
            var lawEntry = _law.Laws.Single(l => l.ID == model.ID);

            lawEntry.Name = model.Name;
            lawEntry.MajDescrip = model.MajDescrip;
            lawEntry.MinDescrip = model.MinDescrip;
            lawEntry.AddDescrip = model.AddDescrip;
            lawEntry.Author = model.Author;
            lawEntry.VoteScheduled = model.VoteScheduled;

            return _law.SaveChanges() == 1;
        }

        public bool DeleteLaw(int id)
        {
            var lawEntry = _law.Laws.Single(l => l.ID == id);
            _law.Laws.Remove(lawEntry);
            return _law.SaveChanges() == 1;
        }
    }
}
