using System.Collections.Generic;

namespace Quick_Kids_Quiz
{
    public class QuizQuestion
    {
        public string? Question { get; set; }
        public required string OptionA { get; set; }
        public required string OptionB { get; set; }
        public required string OptionC { get; set; }
        public required string OptionD { get; set; }
        public required string CorrectAnswer { get; set; }
        public required string Explanation { get; set; }
    }

    public static class QuizQuestions
    {
        public static List<QuizQuestion> GetQuestions()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What color do you get when you mix red and yellow?",
                    OptionA = "Purple",
                    OptionB = "Orange",
                    OptionC = "Green",
                    OptionD = "Blue",
                    CorrectAnswer = "B",
                    Explanation = "Red and yellow make orange!"
                },
                new QuizQuestion
                {
                    Question = "How many legs does a spider have?",
                    OptionA = "6",
                    OptionB = "4",
                    OptionC = "8",
                    OptionD = "10",
                    CorrectAnswer = "C",
                    Explanation = "Spiders have 8 legs!"
                },
                new QuizQuestion
                {
                    Question = "What is the largest planet in our solar system?",
                    OptionA = "Earth",
                    OptionB = "Jupiter",
                    OptionC = "Mars",
                    OptionD = "Saturn",
                    CorrectAnswer = "B",
                    Explanation = "Jupiter is the biggest planet!"
                },
                new QuizQuestion
                {
                    Question = "Which animal is known as the 'King of the Jungle'?",
                    OptionA = "Tiger",
                    OptionB = "Elephant",
                    OptionC = "Lion",
                    OptionD = "Gorilla",
                    CorrectAnswer = "C",
                    Explanation = "The lion is called the King of the Jungle!"
                },
                new QuizQuestion
                {
                    Question = "How many days are there in a week?",
                    OptionA = "5",
                    OptionB = "6",
                    OptionC = "7",
                    OptionD = "8",
                    CorrectAnswer = "C",
                    Explanation = "There are 7 days in a week!"
                },
                new QuizQuestion
                {
                    Question = "What do bees make?",
                    OptionA = "Milk",
                    OptionB = "Honey",
                    OptionC = "Butter",
                    OptionD = "Cheese",
                    CorrectAnswer = "B",
                    Explanation = "Bees make delicious honey!"
                },
                new QuizQuestion
                {
                    Question = "Which season comes after winter?",
                    OptionA = "Summer",
                    OptionB = "Fall",
                    OptionC = "Spring",
                    OptionD = "Autumn",
                    CorrectAnswer = "C",
                    Explanation = "Spring comes after winter!"
                },
                new QuizQuestion
                {
                    Question = "What do caterpillars turn into?",
                    OptionA = "Birds",
                    OptionB = "Butterflies",
                    OptionC = "Bees",
                    OptionD = "Beetles",
                    CorrectAnswer = "B",
                    Explanation = "Caterpillars transform into beautiful butterflies!"
                },
                new QuizQuestion
                {
                    Question = "How many sides does a triangle have?",
                    OptionA = "2",
                    OptionB = "3",
                    OptionC = "4",
                    OptionD = "5",
                    CorrectAnswer = "B",
                    Explanation = "A triangle has 3 sides!"
                },
                new QuizQuestion
                {
                    Question = "What sound does a cow make?",
                    OptionA = "Woof",
                    OptionB = "Meow",
                    OptionC = "Moo",
                    OptionD = "Quack",
                    CorrectAnswer = "C",
                    Explanation = "Cows say 'Moo'!"
                },
                new QuizQuestion
                {
                    Question = "Which fruit is yellow and curved?",
                    OptionA = "Apple",
                    OptionB = "Orange",
                    OptionC = "Banana",
                    OptionD = "Grape",
                    CorrectAnswer = "C",
                    Explanation = "A banana is yellow and curved!"
                },
                new QuizQuestion
                {
                    Question = "What do we use to see?",
                    OptionA = "Ears",
                    OptionB = "Eyes",
                    OptionC = "Nose",
                    OptionD = "Mouth",
                    CorrectAnswer = "B",
                    Explanation = "We use our eyes to see!"
                },
                new QuizQuestion
                {
                    Question = "Which bird cannot fly?",
                    OptionA = "Eagle",
                    OptionB = "Sparrow",
                    OptionC = "Penguin",
                    OptionD = "Robin",
                    CorrectAnswer = "C",
                    Explanation = "Penguins cannot fly, but they are great swimmers!"
                },
                new QuizQuestion
                {
                    Question = "What comes after the number 9?",
                    OptionA = "8",
                    OptionB = "10",
                    OptionC = "11",
                    OptionD = "7",
                    CorrectAnswer = "B",
                    Explanation = "The number 10 comes after 9!"
                },
                new QuizQuestion
                {
                    Question = "Where do fish live?",
                    OptionA = "In trees",
                    OptionB = "In water",
                    OptionC = "In caves",
                    OptionD = "In the sky",
                    CorrectAnswer = "B",
                    Explanation = "Fish live in water!"
                }
            };
        }
    }
}