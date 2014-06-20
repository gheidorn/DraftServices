using DraftServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace DraftServices.Controllers
{
    public class DraftController : ApiController
    {
        static readonly IDraftRepository repository = new DraftRepository();

        /**
         *  <summary>
         *  Retrieve all drafts in the system.
         *  </summary>
         *  /api/draft
         */
        public IEnumerable<Draft> GetAllDrafts()
        {
            return repository.GetAll();
        }

        /**
         *  <summary>
         *  Retrieve a single draft in the system by id.
         *  </summary>
         *  /api/draft/{id}
         */
        public Draft GetDraft(int id)
        {
            Draft draft = repository.Get(id);
            if(draft == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return draft;
        }

        /**
         *  <summary>
         *  Retrieve all drafts in the system that start on a given date (date format is yyyy-mm-dd).
         *  </summary>
         *  /api/draft?startDate=
         */
        public IEnumerable<Draft> GetDraftsByStartDate(DateTime startDate)
        {
            return repository.GetAll().Where(
                d => d.StartDate.Date == startDate.Date // hopefully compares date
            );
        }

        /**
         *  <summary>
         *  Retrieve all drafts in the system that start within a given date range (date format is yyyy-mm-dd).
         *  </summary>
         *  /api/draft?startDate=&endDate=
         */
        public IEnumerable<Draft> GetDraftsByStartDateRange(DateTime startDate, DateTime endDate)
        {
            return repository.GetAll().Where(
                d => 
                    (d.StartDate.Date >= startDate.Date && d.StartDate.Date <= endDate.Date) // hopefully compares date
            );
        }

        /**
         *  /api/draft
         *  Http Method = POST
         */
        public HttpResponseMessage PostDraft(Draft draft)
        {
            // TODO needs validation!
            draft = repository.Add(draft);
            var response = Request.CreateResponse<Draft>(HttpStatusCode.Created, draft);

            string uri = Url.Link("DefaultApi", new { id = draft.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        /**
         *  /api/draft
         *  Http Method = PUT
         */
        public void PutDraft(int id, Draft draft)
        {
            draft.Id = id;
            if (!repository.Update(draft))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /**
         *  /api/draft
         *  Http Method = DELETE
         */
        public void DeleteDraft(int id)
        {
            Draft draft = repository.Get(id);
            if(draft == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
