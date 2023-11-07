using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RNCADLEAPI.Data;

namespace RNCADLEAPI.Controllers
{
    [Route("quizquestions")]
    public class QuizQuestionsController : ControllerBase
    {
        // GET api/rncadleapi/quizquestions/all
        [HttpGet]
        [Route("all")]
        public IEnumerable<QuizQuestion> GetAllQuizQuestions()
        {
            return null;
            // Implement logic to retrieve all quiz questions from the database
        }

        // GET api/rncadleapi/quizquestions/{id}
        [HttpGet]
        [Route("{id}")]
        public QuizQuestion GetQuizQuestionById(int id)
        {
            return null;
            // Implement logic to retrieve specific quiz question by id from the database
        }

        // POST api/rncadleapi/quizquestions/add
        [HttpPost]
        [Route("add")]
        public void AddQuizQuestion([FromBody] QuizQuestion quizQuestion)
        {
            // Implement logic to add new quiz question to the database
        }

        // PUT api/rncadleapi/quizquestions/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public void UpdateQuizQuestion(int id, [FromBody] QuizQuestion quizQuestion)
        {
            // Implement logic to update existing quiz question in the database
        }

        // DELETE api/rncadleapi/quizquestions/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteQuizQuestion(int id)
        {
            // Implement logic to delete quiz question from the database
        }
    }
}
