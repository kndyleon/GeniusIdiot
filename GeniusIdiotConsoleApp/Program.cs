using System;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static string[] GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей, сколько нужно сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно минут для трёх уколов?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";

            return questions;
        }

        static int[] GetAnswers(int countQuestions) 
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;

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
        static void Main(string[] args)
        {
            int countQuestions = 5;
            string[] questions = GetQuestions(countQuestions);
            int[] answers = GetAnswers(countQuestions);
            int countRightAnswers = 0;
            Random random = new Random();

            for (int i = 0; i < countQuestions; i++)
            {
                int randomQuestionIndex = random.Next(0, countQuestions);
                Console.WriteLine($"Вопрос №{i + 1}. {questions[randomQuestionIndex]}");

                int userAnswer = Convert.ToInt32(Console.ReadLine());
                int rightAnswer = answers[randomQuestionIndex];

                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
            }
            
            string diagnosis = GetDiagnosis(countRightAnswers);
            Console.WriteLine($"Количество правильных ответов: {countRightAnswers}");
            Console.WriteLine($"Ваш диагноз: {diagnosis}");
        }
    }
}
