namespace FizzBuzzApp.Model
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public List<FizzBuzzResult> ProcessValues(string[] values)
        {
            var results = new List<FizzBuzzResult>();
            foreach (var value in values)
            {
                if (int.TryParse(value, out int intValue))
                {
                    if (intValue % 3 == 0 && intValue % 5 == 0)
                    {
                        results.Add(new FizzBuzzResult { Input = value, Result = "FizzBuzz" });
                    }
                    else if (intValue % 3 == 0)
                    {
                        results.Add(new FizzBuzzResult { Input = value, Result = "Fizz" });
                    }
                    else if (intValue % 5 == 0)
                    {
                        results.Add(new FizzBuzzResult { Input = value, Result = "Buzz" });
                    }
                    else
                    {
                        results.Add(new FizzBuzzResult { Input = value, Result = $"Divided {intValue} by 3\nDivided {intValue} by 5" });
                    }
                }
                else
                {
                    results.Add(new FizzBuzzResult { Input = value, Result = "Invalid item" });
                }
            }
            return results;
        }
    }

}
