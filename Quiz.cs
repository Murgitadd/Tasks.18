using System;
using System.Collections.Generic;

public class Quiz
{
    private static int _id = 0;

    public int Id { get; set; }
    public int QuizSize { get; set; }
    public List<Question> Questions { get; set; }
    public string QuizName { get; set; }

    public Quiz(string quizName, int quizSize)
    {
        _id++;
        Id = _id;
        Questions = new List<Question>();
        QuizName = quizName;
        QuizSize = quizSize;
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        List<Quiz> myQuizzes = new List<Quiz>();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("   ________________  \r\n ((                ))\r\n  ))Kesir  Academy(( \r\n ((                ))\r\n   ----------------  ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1 Create New Quiz    ");
            Console.WriteLine("2 Solve a Quiz       ");
            Console.WriteLine("3 Show Quizzes        ");
            Console.WriteLine("4 Quit               ");
            Console.ResetColor();

            Console.WriteLine("");
            string choice = Console.ReadLine();
            Console.WriteLine("");

            switch (choice)
            {
                case "1":
                    CreateQuiz(myQuizzes);
                    break;
                case "2":
                    SolveQuiz(myQuizzes);
                    break;
                case "3":
                    AllQuizzes(myQuizzes);
                    break;
                case "4":
                    Console.WriteLine("4 chosen");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            if (choice == "4")
            {
                break;
            }
        }
    }

    private static void CreateQuiz(List<Quiz> quizzes)
    {
        Console.WriteLine("Quiz:");
        string quizName = Console.ReadLine();
        Console.WriteLine("Length:");
        int quizSize = int.Parse(Console.ReadLine());
        Quiz newQuiz = new Quiz(quizName, quizSize);

        for (int i = 0; i < quizSize; i++)
        {
            Console.WriteLine("Enter Question Text:");
            string questionText = Console.ReadLine();
            List<string> variants = new List<string>();

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine("Enter Variant" + (j + 1));
                string variant = Console.ReadLine();
                variants.Add(variant);
            }

            Console.WriteLine("Enter the correct answer variant (1-4):");
            int correctAnswer = int.Parse(Console.ReadLine());

            if (correctAnswer < 1 || correctAnswer > 4)
            {
                Console.WriteLine("Invalid answer (1-4).");
                return;
            }

            Question newQuestion = new Question(questionText, variants, correctAnswer);
            newQuiz.Questions.Add(newQuestion);
        }
        Console.WriteLine("Your Quiz has been created!");
        Console.WriteLine("");
        quizzes.Add(newQuiz);
    }

    private static void SolveQuiz(List<Quiz> quizzes)
    {
        Console.WriteLine("Quiz Id:");
        int quizId = int.Parse(Console.ReadLine());
        Quiz quizToSolve = quizzes.Find(q => q.Id == quizId);

        if (quizToSolve == null)
        {
            Console.WriteLine("Incorrect quiz");
            return;
        }

        int score = 0;

        foreach (var question in quizToSolve.Questions)
        {
            Console.WriteLine(question.Text);
            for (int i = 0; i < question.Variants.Count; i++)
            {
                Console.WriteLine((i + 1) + " " + question.Variants[i]);
            }

            Console.WriteLine("Enter your answer (1-4):");
            int userAnswer = int.Parse(Console.ReadLine());

            if (userAnswer == question.CorrectAnswer)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Wrong...");
            }
        }

        Console.WriteLine("Score: " + score + " out of " + quizToSolve.Questions.Count);
    }

    private static void AllQuizzes(List<Quiz> quizzes)
    {
        Console.WriteLine("Quizzes:");
        foreach (var quiz in quizzes)
        {
            Console.WriteLine(quiz.Id + "." + quiz.QuizName);
        }
    }
}

public class Question
{
    private static int _id = 0;

    public int Id { get; set; }
    public string Text { get; set; }
    public List<string> Variants { get; set; }
    public int CorrectAnswer { get; set; }

    public Question(string text, List<string> variants, int correctAnswer)
    {
        _id++;
        Id = _id;
        Text = text;
        Variants = variants;
        CorrectAnswer = correctAnswer;
    }
}
