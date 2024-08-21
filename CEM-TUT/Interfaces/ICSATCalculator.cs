using CEM_TUT.Models;

namespace CEM_TUT.Interfaces
{
    public interface ICSATCalculator
    {
        int CalculatorCSAT(List<int> scores);

        int CountAlerts(List<GeoAlert> list);

        int CountRatingPerService(List<Feedback> list);

        int CountHappyCustomers(List<Feedback> list);

        int CountUnHappyCustomers(List<Feedback> list);

        int[] grouobyAge(List<Customer> list);

        int[] countGender(List<Customer> list);

        int[] countPerProvince(List<GeoAlert> list);

        string usedService(List<Customer> list);

        string UnusedService(List<Customer> list);
    }
}
