namespace FizzBuzzApp.Model
{
    public interface IFizzBuzzUtilityService
    {
        string GetFizzBuzzResult(int number);
        List<string> GetDivisionResults(int number);
    }

    public class FizzBuzzUtilityService : IFizzBuzzUtilityService
    {
        public string GetFizzBuzzResult(int number)
        {
            if (number % 15 == 0) return FizzBuzzConstants.FizzBuzz;
            if (number % 3 == 0) return FizzBuzzConstants.Fizz;
            if (number % 5 == 0) return FizzBuzzConstants.Buzz;
            return null;
        }

        public List<string> GetDivisionResults(int number)
        {
            var results = new List<string>
        {
            $"Divided {number} by 3",
            $"Divided {number} by 5"
        };
            return results;
        }
    }

}
