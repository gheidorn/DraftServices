using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftServices.Models
{
    interface IDraftRepository
    {
        IEnumerable<Draft> GetAll();
        Draft Get(int id);
        Draft Add(Draft newDraft);
        void Remove(int id);
        bool Update(Draft newDraft);
    }
}
