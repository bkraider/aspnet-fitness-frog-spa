using AutoMapper;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Data;
using Treehouse.FitnessFrog.Shared.Models;


namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class EntriesController : ApiController
    {

        private EntriesRepository _entriesRepository = null;

        public EntriesController(EntriesRepository entriesRepository)
        {
            _entriesRepository = entriesRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_entriesRepository.GetList());
        }


        public IHttpActionResult Get(int id )
        {
            var entry =  _entriesRepository.Get(id);

            if(entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        public IHttpActionResult Post(EntryDto entrydto)
        {

            ValidateEntry(entrydto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = Mapper.Map<Entry>(entrydto);

            _entriesRepository.Add(entry);

            entrydto.Id = entry.Id;

            return Created(
                Url.Link("DefaultApi", new { controller = "Entries", id = entrydto.Id }),
                entrydto);
        }

        public IHttpActionResult Put(int id, EntryDto entrydto)
        {
            ValidateEntry(entrydto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = Mapper.Map<Entry>(entrydto);

            _entriesRepository.Update(entry);

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }


        public void Delete(int id)
        {
            _entriesRepository.Delete(id);
        }

        private void ValidateEntry(EntryDto entry)
        {
            // If there aren't any "Duration" field validation errors
            // then make sure that the duration is greater than "0".
            if (ModelState.IsValidField("Duration") && entry.Duration <= 0)
            {
                ModelState.AddModelError("entry.Duration",
                    "The Duration field value must be greater than '0'.");
            }
        }
    }
}
