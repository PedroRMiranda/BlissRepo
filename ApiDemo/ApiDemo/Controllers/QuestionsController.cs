using ApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiDemo.Controllers
{
    public class QuestionsController : ApiController
    {

        public class QuestionDB : DbContext
        {
            public DbSet<QuestionModel> Questions { get; set; }
        }

        // GET api/questions
        public IHttpActionResult Questions(int limit, int offset, string filter=null)
        {
            IList<QuestionModel> res = null;

            using (var ent = new QuestionDB())
            {
                if (filter != null)
                    ent.Questions.Where(e => e.question.Contains(filter));

                res = ent.Questions.Take(limit).Skip(offset).Select(q => new QuestionModel()
                {
                    id = q.id,
                    question = q.question,
                    image_url = q.image_url,
                    thumb_url = q.thumb_url,
                    choices = q.choices
                }).ToList<QuestionModel>();
            }

            return Ok(res);
        }

        // GET api/questions/5
        public IHttpActionResult Questions(int question_id)
        {
            QuestionModel res = null;

            using (var ent = new QuestionDB())
            {
                res = ent.Questions.Where(e => e.id == question_id).Select(q => new QuestionModel()
                {
                    id = q.id,
                    question = q.question,
                    image_url = q.image_url,
                    thumb_url = q.thumb_url,
                    choices = q.choices
                }).First<QuestionModel>();
            }

            return Ok(res);
        }

        // POST api/questions
        public IHttpActionResult Questions([FromBody]QuestionModel q)
        {
            if (!ModelState.IsValid)
                return BadRequest("Bad Request. All fields are mandatory.");
            
            using (var ent = new QuestionDB())
            {
                ent.Questions.Add(new QuestionModel()
                {
                    question = q.question,
                    image_url = q.image_url,
                    thumb_url = q.thumb_url,
                    choices = q.choices
                });

                ent.SaveChanges();
            }
            return Created(new Uri(Request.RequestUri.AbsoluteUri), q);
        }

        // PUT api/questions/
        public IHttpActionResult Questions(int question_id, [FromBody]QuestionModel q)
        {
            if (!ModelState.IsValid)
                return BadRequest("Bad Request.All fields are mandatory.");

            using (var ent = new QuestionDB())
            {
                var oldQ = ent.Questions.Where(e => e.id == q.id).FirstOrDefault<QuestionModel>();

                if (oldQ != null)
                {
                    oldQ.question = q.question;
                    oldQ.image_url = q.image_url;
                    oldQ.thumb_url = q.thumb_url;
                    oldQ.choices = q.choices;

                    ent.SaveChanges();
                }
            }

            return Ok();
        }
    }
}
