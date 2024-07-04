using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Api_Business_Model.DataTransferObject
{
    public class ApiQuizData

    {

        public int Id { get; set; }
        public string Question { get; set; }
        public string Mulitple_correct_answers { get; set; }
        public string Category { get; set; }
        public Dictionary<string, string> Answers { get; set; }
        public Dictionary<string, string> Correct_answers { get; set; }

    }
    public class HentApi
    {
        public void PrintInfo(List<ApiQuizData> apiData)
        {
            Console.WriteLine($"Velkommen til Api Quizzen");
            Console.WriteLine($"tryk for at komme videre til første spørgsmål");
            Console.ReadLine();
            foreach (var Question in apiData)
            {
                if (Question.Answers == null) continue;
                Console.WriteLine(Question.Question);
                int i = 0;
                foreach (var answer in Question.Answers)
                {
                    Console.WriteLine(++i + ". " + answer.Value);
                }
                string userAnswer;
                userAnswer = Console.ReadLine();
                string checkValue = "";
                switch (userAnswer)
                {
                    case "1":
                        Question.Correct_answers.TryGetValue("answer_a_correct", out checkValue);
                        if (checkValue.Equals("true"))
                        {
                            Console.WriteLine("svar er korrekt");
                        }
                        else
                        {
                            Console.WriteLine("ikke korrekt");
                        }
                        break;
                    case "2":
                        Question.Correct_answers.TryGetValue("answer_b_correct", out  checkValue);
                        if (checkValue.Equals("true"))
                        {
                            Console.WriteLine("svar er korrekt");
                        }
                        else
                        {
                            Console.WriteLine("ikke korrekt");
                        }
                        break;
                    case "3":
                        Question.Correct_answers.TryGetValue("answer_c_correct", out  checkValue);
                        if (checkValue.Equals("true"))
                        {
                            Console.WriteLine("svar er korrekt");
                        }
                        else
                        {
                            Console.WriteLine("ikke korrekt");
                        }
                        break;
                    case "4":
                        Question.Correct_answers.TryGetValue("answer_d_correct", out checkValue);
                        if (checkValue.Equals("true"))
                        {
                            Console.WriteLine("svar er korrekt");
                        }
                        else
                        {
                            Console.WriteLine("ikke korrekt");
                        }
                        break;
                    case "5":
                        Question.Correct_answers.TryGetValue("answer_e_correct", out checkValue);
                        if (checkValue.Equals("true"))
                        {
                            Console.WriteLine("svar er korrekt");
                        }
                        else
                        {
                            Console.WriteLine("ikke korrekt");
                        }
                        break;
                    case "6":
                        Question.Correct_answers.TryGetValue("answer_f_correct", out checkValue);
                        if (checkValue.Equals("true"))
                        {
                            Console.WriteLine("svar er korrekt");
                        }
                        else
                        {
                            Console.WriteLine("ikke korrekt");
                        }
                        break;
                }

                Console.ReadLine();
            }
        }
        private string GetApiResponse(string difficulty = "Easy", string limit = "10", string category = "Code", string id = "id")
        {
            var client = new RestClient("https://quizapi.io/api/v1/questions");
            var request = new RestRequest();

            request.AddParameter("apiKey", "UYLc4lIkwtKwcg67EMNOCBk1susVt9b6dYmEtfjO"); // Add your API-Key
            request.AddParameter("limit", limit); // Set the limit of questions
            request.AddParameter("difficulty", difficulty); // Set the difficulty
            request.AddParameter("category", category); // Set the category
            request.AddParameter("id", id);

            return client.Execute(request).Content; // Return the response content from the API
        }

        // Method to convert API response to list of ApiQuizData
        public List<ApiQuizData> ConvertApi(string difficulty, string limit, string category)
        {
            string response = GetApiResponse(difficulty, limit, category);
            return JsonConvert.DeserializeObject<List<ApiQuizData>>(response);
        }
        public string CategoryChooser()
        {
            Console.WriteLine("Hej og velkommen til Api Quiz vælg hvad for en kategori du vil vælge");
            Console.WriteLine("1. Linux");
            Console.WriteLine("2. Bash");
            Console.WriteLine("3. uncategorized");
            Console.WriteLine("4. Code");
            Console.WriteLine("5. CMS");
            Console.WriteLine("6. Docker");
            Console.WriteLine("7. SQL");
            string choice = Console.ReadLine();
            string category = "";

            switch (choice)
            {
                case "1":
                    category = "Linux";
                    break;
                case "2":
                    category = "Bash";
                    break;
                case "3":
                    category = "uncategorized";
                    break;
                case "4":
                    category = "Code";
                    break;
                case "5":
                    category = "CMS";
                    break;
                case "6":
                    category = "Docker";
                    break;
                case "7":
                    category = "SQL";
                    break;
            }
            return category;
        }
    }
}