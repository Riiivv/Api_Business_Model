using Api_Business.DataTransferObject;
using Api_Business_Model.DataTransferObject;
using System.Collections.Generic;
using System;


namespace Api_Business
{
    internal class Program
    {

        //Lavet en Instans af klassen som kalder GetJson som henter JsonFilen
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Vælg en Quiz");
                Console.WriteLine("1. Lokale Quiz");
                Console.WriteLine("2. ApiQuiz");
                Console.WriteLine("0. Tryk 0 for at afslutte");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        JsonHandler jsonHandler = new JsonHandler();
                        jsonHandler.GetJson();
                        break;
                    case "2":
                        
                        List<ApiQuizData> data = new List<ApiQuizData>();
                        HentApi quizApi = new HentApi();
                        string categoryChooser = quizApi.CategoryChooser();
                        data = quizApi.ConvertApi("Easy", "1", categoryChooser);
                        quizApi.PrintInfo(data);

                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                }

            }

        }

    }
}
