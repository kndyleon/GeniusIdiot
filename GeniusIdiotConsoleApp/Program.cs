using System;
using System.Collections.Generic;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите Ваше имя: ");
            string name = Console.ReadLine();
            bool userWantsToContinue = true;
            while (userWantsToContinue)
            {
                int countQuestions = 5;
                List<string> questions = GetQuestions(countQuestions);
                List<int> answers = GetAnswers(countQuestions);
                int countRightAnswers = 0;
                Random random = new Random();
                int countLeftQuestions = countQuestions;

                for (int i = 0; i < countQuestions; i++)
                {
                    int randomQuestionIndex = random.Next(0, countLeftQuestions);
                    Console.WriteLine($"Вопрос №{i + 1}. {questions[randomQuestionIndex]}");

                    int userAnswer = Convert.ToInt32(Console.ReadLine());
                    int rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                    countLeftQuestions--;
                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);
                }

                string diagnosis = GetDiagnosis(countRightAnswers);
                Console.WriteLine($"Количество правильных ответов: {countRightAnswers}");
                Console.WriteLine($"{name}, Ваш диагноз: {diagnosis}");
                userWantsToContinue = GetUserDecision();
            }
        }

        static List<string> GetQuestions(int countQuestions)
        {
            List<string> questions = new List<string>(countQuestions)
            {
                "Сколько будет два плюс два умноженное на два?",
                "Бревно нужно распилить на 10 частей, сколько нужно сделать распилов?",
                "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
                "Укол делают каждые полчаса, сколько нужно минут для трёх уколов?",
                "Пять свечей горело, две потухли. Сколько свечей осталось?"
            };
            return questions;
        }

        static List<int> GetAnswers(int countQuestions)
        {
            List<int> answers = new List<int>(countQuestions)
            {
                6,
                9,
                25,
                60,
                2
            };
            return answers;
        }

        static string GetDiagnosis(int countRightAnswers)
        {
            string diagnosis = string.Empty;
            switch (countRightAnswers)
            {
                case 0: diagnosis = "Идиот"; break;
                case 1: diagnosis = "Кретин"; break;
                case 2: diagnosis = "Дурак"; break;
                case 3: diagnosis = "Нормальный"; break;
                case 4: diagnosis = "Талант"; break;
                case 5: diagnosis = "Гений"; break;
            }

            return diagnosis;
        }

        static bool GetUserDecision()
        {
            Console.WriteLine("Хотите повторить попытку? Введите Да или Нет.");
            bool userDecided = false;
            while (!userDecided)
            {
                string userDecision = Console.ReadLine().ToLower();

                if (userDecision == "да")
                {
                    return true;
                }
                if (userDecision == "нет")
                {
                    Console.WriteLine("Тест завершён.");
                    return false;
                }
                else 
                {
                    Console.WriteLine("Ответ не распознан. Введите Да или Нет.");
                }
            }
            return false;
        }
    }
}
