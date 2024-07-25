namespace FizzBuzzApp.Model
{
    public interface IFizzBuzzService
    {
        List<FizzBuzzResult> ProcessValues(string[] values);
    }
}
