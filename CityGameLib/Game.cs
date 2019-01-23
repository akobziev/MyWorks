using System;
using System.Collections.Generic;
using System.Linq;

namespace CityGameLib
{
    public static class Game
    {
        public static List<Answer> Answers { get; private set; } = new List<Answer>();

        public static bool AddNewAnswer(Answer newAnswer)
        {
            if (ValidateAnswer(newAnswer))
            {
                Answers.Add(newAnswer);
                return true;
            }
            return false;
        }

        private static bool ValidateAnswer(Answer newAnswer)
        {
            return CorrectLastAnswer(newAnswer) 
                && IsValidCity(newAnswer) 
                && OriginalCity(newAnswer);            
        }

        private static bool OriginalCity(Answer newAnswer)
        {
            return !Answers.Any(a => string.Equals(a.City, newAnswer.City, StringComparison.InvariantCultureIgnoreCase));
        }

        private static bool IsValidCity(Answer newAnswer)
        {
           return CityChecker.IsValidCity(newAnswer.City);
        }

        private static bool CorrectLastAnswer(Answer newAnswer)
        {
            var lastAnswer = Answers.LastOrDefault();
            return lastAnswer == null || char.ToLower(lastAnswer.City.Last()) == char.ToLower(newAnswer.City[0]);
        }
    }
}
