﻿using eRef.Data;
using eRef.Models;
using eRef.Models.VoterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Services
{
    public class VoterService
    {
        private readonly Guid _userID;

        private readonly ApplicationDbContext _voter = new ApplicationDbContext();

        public VoterService(Guid userID)
        {
            userID = _userID;
        }

        public bool RegisterVoter(VoterRegister model)
        {
            Voter entity = new Voter
            {
                ID = model.ID,
                Name = model.Name,
                VoterID = model.VoterID,
                PartyAff = model.PartyAff,
                Location = model.Location
            };

            _voter.Voters.Add(entity);
            return _voter.SaveChanges() == 1;
        }

        public IEnumerable<VoterListItem> ListVoter()
        {
            var voterEntries = _voter.Voters.ToList();
            var voterList = voterEntries.Select(v => new VoterListItem
            {
                Name = v.Name,
                VoterID = v.VoterID,
                PartyAff = v.PartyAff,
                Location = v.Location
            }).ToList();

            return voterList;
        }

        public VoterListItem ListVoterByID(int id)
        {
            var voterEntry = _voter.Voters.Single(v => v.VoterID == id);
            return new VoterListItem
            {
                Name = voterEntry.Name,
                VoterID = voterEntry.VoterID,
                PartyAff = voterEntry.PartyAff,
                Location = voterEntry.Location
            };
        }

        public bool UpdateVoterRegistrationInfo(VoterUpdate voter)
        {
            var voterEntry = _voter.Voters.Single(v => v.ID == voter.ID);

            voterEntry.Name = voter.Name;
            voterEntry.VoterID = voter.VoterID;
            voterEntry.PartyAff = voter.PartyAff;
            voterEntry.Location = voter.Location;

            return _voter.SaveChanges() == 1;
        }

        public bool DeleteVoter(int id)
        {
            var voterEntry = _voter.Voters.Single(v => v.ID == id);
            _voter.Voters.Remove(voterEntry);

            return _voter.SaveChanges() == 1;
        }
    }
}
