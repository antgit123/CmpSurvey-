using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompassSurveyTestApp.Models;

/*
This is the controller file which uses the dbContext class to implement 
the HTTP API methods for fetching the survey data from the database
*/

namespace CompassSurveyTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly CompassDBContext _context;        

        public SurveysController(CompassDBContext context)
        {
            _context = context;
        }

        // GET: api/Surveys
        [HttpGet]
        public IActionResult GetSurvey()
        {
            return Ok(new { surveys = _context.Survey.ToList()});
        }

        [HttpGet]
        [Route("~/getAllSurveyData")]
        public async Task<IActionResult> GetSurveys()
        {       
            var data = _context.Survey.Include(survey => survey.Questions)
                .ToList();
            return Ok(new {surveys =  data });
        } 

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurvey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var survey = await _context.Survey.FindAsync(id);            

            if (survey == null)
            {
                return NotFound();
            }
            else
            {
                //get survey along with list of questions 
                _context.Survey.Where(s => s.Id == id).Include(q => q.Questions).ToList();
            }     
            return Ok(_context.Questions.Where(question => question.SurveyId == id).Include(q => q.Options).ToList());
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey([FromRoute] int id, [FromBody] Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != survey.Id)
            {
                return BadRequest();
            }

            _context.Entry(survey).State = EntityState.Modified;            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Surveys
        [HttpPost]
        public async Task<IActionResult> PostSurvey([FromBody] Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Survey.Add(survey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurvey", new { id = survey.Id }, survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var survey = await _context.Survey.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }

            _context.Survey.Remove(survey);
            await _context.SaveChangesAsync();

            return Ok(survey);
        }

        private bool SurveyExists(int id)
        {
            return _context.Survey.Any(e => e.Id == id);
        }
    }
}