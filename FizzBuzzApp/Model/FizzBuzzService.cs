namespace FizzBuzzApp.Model
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IFizzBuzzUtilityService _fizzBuzzUtilityService;

        public FizzBuzzService(IFizzBuzzUtilityService fizzBuzzUtilityService)
        {
            _fizzBuzzUtilityService = fizzBuzzUtilityService;
        }

        public List<FizzBuzzResult> ProcessValues(string[] values)
        {
            var results = new List<FizzBuzzResult>();

            foreach (var value in values)
            {
                if (int.TryParse(value, out int number))
                {
                    var result = _fizzBuzzUtilityService.GetFizzBuzzResult(number);
                    if (result != null)
                    {
                        results.Add(new FizzBuzzResult { Input = value, Result = result });
                    }
                    else
                    {
                        results.Add(new FizzBuzzResult { Input = value, Result = string.Join("\n", _fizzBuzzUtilityService.GetDivisionResults(number)) });
                    }
                }
                else
                {
                    results.Add(new FizzBuzzResult { Input = value, Result = FizzBuzzConstants.InvalidItem });
                }
            }

            return results;
        }
    }


}
