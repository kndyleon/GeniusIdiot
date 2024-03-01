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

                    int userAnswer = GetUserAnswer();
                    int rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                    countLeftQuestions--;
                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);
                }

                string diagnosis = GetDiagnosis(countRightAnswers, countQuestions);
                Console.WriteLine($"Количество правильных ответов: {countRightAnswers}");
                Console.WriteLine($"{name}, Ваш диагноз: {diagnosis}");
                userWantsToContinue = GetUserDecision();
            }
        }

        static int GetUserAnswer()
        {
            while (true)
            {
                string userAnswer = Console.ReadLine();

                if (int.TryParse(userAnswer, out int answer))
                {
                    return answer;
                }
                else
                {
                    Console.WriteLine("Ответ должен быть числом, по модулю не превыщающим 2000000000!");
                }
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

        static string GetDiagnosis(int countRightAnswers, int countQuestions)
        {
            string diagnosis = string.Empty;
            double diagnosisInPercent = (double)countRightAnswers / countQuestions;

            if (diagnosisInPercent <= 0.2)
            {
                diagnosis = "Идиот";
            }
            if (diagnosisInPercent >= 0.2)
            {
                diagnosis = "Кретин";
            }
            if (diagnosisInPercent >= 0.4)
            {
                diagnosis = "Дурак";
            }
            if (diagnosisInPercent >= 0.6)
            {
                diagnosis = "Нормальный";
            }
            if (diagnosisInPercent >= 0.8)
            {
                diagnosis = "Талант";
            }
            if (diagnosisInPercent >= 0.9)
            {
                diagnosis = "Гений";
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
