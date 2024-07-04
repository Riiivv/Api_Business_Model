using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;


namespace Api_Business.DataTransferObject
{
    // Lavet en klasse med navn VandQuizData der har properties for mit program
    public class LokalQuizData
    {
        public string Question { get; set; }
        public List<string> Svarmuligheder { get; set; }
        public string Hint { get; set; }
        public int TrueAnswer { get; set; }
    }
    // Klasse JsonHandler for at hente min Jsonfil ind der så bliver ''Deserialized'' igennem Main programmet med en Metode
    public class JsonHandler
    {
        public void GetJson()
        {
            Console.WriteLine("Vælg en Quiz");
            Console.WriteLine("1. VandQuiz");
            Console.WriteLine("2 ProgrammeringsQuiz");
            Console.WriteLine("Sql Quiz");

            int quizvalg = Convert.ToInt32(Console.ReadLine().ToLower());

            string Json = "";

            if (quizvalg == 1)
            {
                Json = File.ReadAllText(@"C:\Users\matal\source\repos\Api_Business_Model\Api_Business_Model\DataTransferObject\VandQuiz.Json");
            }
            else if (quizvalg == 2)
            {
                Json = File.ReadAllText(@"C:\Users\matal\source\repos\Api_Business_Model\Api_Business_Model\DataTransferObject\ProgrammeringsQuiz.Json");
            }
            else if (quizvalg == 3)
            {
                Json = File.ReadAllText(@"C:\Users\matal\source\repos\Api_Business_Model\Api_Business_Model\DataTransferObject\SqlQuiz.Json");
            }
            else
            {
                return;
            }
            List<LokalQuizData> deseralize = JsonConvert.DeserializeObject<List<LokalQuizData>>(Json);

            QuestionHandler questionHandler = new JsonHandler.QuestionHandler();
            questionHandler.HandleQuestion(deseralize);
            JsonHandler.QuizChoice quizChoice = new JsonHandler.QuizChoice();
            quizChoice.ChooseQuiz(this);

        }
        public class QuizChoice
        {
            public void ChooseQuiz(JsonHandler userChoice)
            {
                JsonHandler jsonHandler = new JsonHandler();

                ChooseQuiz(userChoice);

            }
        }
        // Klasse QuestionHandler med en metode HandleQuestion som håndtere spørgsmålene i min JsonFil
        //som bliver Deserializered og bliver udskrevet 1 efter 1 og checker om brugersvar er Korrekt eller forkert
        public class QuestionHandler
        {
            public void HandleQuestion(List<LokalQuizData> deserialize)
            {
                JsonHandler.AnswerTrue questionTrue = new JsonHandler.AnswerTrue();
                foreach (var item in deserialize)
                {
                    Console.WriteLine(item.Question);


                    for (int i = 0; i < item.Svarmuligheder.Count; i++)
                    {
                        Console.WriteLine(item.Svarmuligheder[i]);
                    }
                    Console.WriteLine("tryk på (0) : (1) (2) for at finde ud at det korrekte svar");

                    int UserInput = Convert.ToInt32(Console.ReadLine());

                    questionTrue.CheckUserAnswer(item, UserInput);
                }
                Console.ReadLine();
            }
        }
        // Klasse med en metode der Checker og
        public class AnswerTrue
        {
            public void CheckUserAnswer(LokalQuizData DeserializeItem, int UserAnswer)
            {
                if (UserAnswer == DeserializeItem.TrueAnswer)
                {
                    Console.WriteLine("det er korrekt");
                }
                else
                {
                    Console.WriteLine("det er forkert");
                }
            }
        }
    }

}
