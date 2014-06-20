using System;
using System.Collections.Generic;

namespace DraftServices.Models
{
    public class DraftRepository : IDraftRepository
    {
        private List<Draft> drafts = new List<Draft>();
        private int _nextId = 1;

        // ctor
        public DraftRepository()
        {
            DateTime createdDate = DateTime.Now;

            List<User> users = new List<User> {
                new User { Id = 1, Username = "Greg" }, 
                new User { Id = 2, Username = "Kristin" }
            };

            // create 3 draft objects for today's date, 3 hours apart
            for (int i = 1; i < 4; i++ )
            {
                Add(new Draft
                {
                    CompetitionType = "NFL",
                    CreatedDate = createdDate,
                    StartDate = createdDate.AddHours(i),  // create a start date X hours in the future
                    Users = users
                });
            }

            // create 3 draft objects for tomorrow's date, 3 hours apart
            for (int i = 1; i < 4; i++)
            {
                Add(new Draft
                {
                    CompetitionType = "NFL",
                    CreatedDate = createdDate,
                    StartDate = createdDate.AddDays(1).AddHours(i),  // create a start date X days and X hours in the future
                    Users = users
                });
            }

            // create 3 draft objects for 2 days from now, 3 hours apart
            for (int i = 1; i < 4; i++)
            {
                Add(new Draft
                {
                    CompetitionType = "NFL",
                    CreatedDate = createdDate,
                    StartDate = createdDate.AddDays(2).AddHours(i),  // create a start date X days and X hours in the future
                    Users = users
                });
            }
        }

        public IEnumerable<Draft> GetAll()
        {
            return drafts;
        }

        public Draft Get(int id)
        {
            return drafts.Find(p => p.Id == id);
        }

        public Draft Add(Draft newDraft)
        {
            if (newDraft == null)
            {
                throw new ArgumentNullException("newDraft");
            }
            newDraft.Id = _nextId++;
            drafts.Add(newDraft);
            return newDraft;
        }

        public void Remove(int id)
        {
            drafts.RemoveAll(d => d.Id == id);
        }

        public bool Update(Draft draft)
        {
            if (draft == null)
            {
                throw new ArgumentNullException("draft");
            }

            int index = drafts.FindIndex(d => d.Id == draft.Id);
            if (index == -1)
            {
                return false;
            }

            drafts.RemoveAt(index);
            drafts.Add(draft);
            return true;
        }
    }
}