using CEM_TUT.Data;
using CEM_TUT.Interfaces;
using CEM_TUT.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CEM_TUT.Repository
{
    public class CSATCalculator : ICSATCalculator
    {

        private readonly AppDbContext _context;

        public CSATCalculator(AppDbContext context)
        {
            _context = context;  
        }
        public int  CalculatorCSAT(List<int>  scores)
        {


         
         
            if (scores == null) {

                return 0;
              }

            int totalScore = scores.Sum();
            double averageScore = (double)totalScore / scores.Count;
           
            
           
            
            return (int)(averageScore*10);

        }

       public int CountAlerts(List<GeoAlert> list)
        { 

         int totalAlerts = list.Count;

            return totalAlerts;
        }

       public  int CountRatingPerService(List<Feedback> list) 
        {  
            int totalAlerts = list.Count;
            return totalAlerts; 
        }

        public int CountHappyCustomers(List<Feedback> list)
        { 

            int count = list.Count;

            return count;
        }

        public int CountUnHappyCustomers(List<Feedback> list){

            int count = list.Count;

            return count;
        }



        public int[] grouobyAge(List<Customer> list)
        {

            int[] ageGroupCounter = { 0, 0, 0, 0, 0,0,0 };

            foreach (Customer customer in list)
            {
                int age;
                bool parsedSuccessfully = int.TryParse(customer.age, out age);

                if (age >= 15 && age <= 25)
                {
                    ageGroupCounter[0]++;
                }
                else if (age >= 25 && age <= 35)
                {
                    ageGroupCounter[1]++;

                }
                else if (age >= 35 && age <= 45)
                {
                    ageGroupCounter[2]++;
                }
                else if (age >= 45 && age <= 55)
                {
                    ageGroupCounter[3]++;
                }
                else if (age >= 55 && age <= 65)
                {
                    ageGroupCounter[4]++;
                }
                else if (age >= 65 && age <= 75)
                {
                    ageGroupCounter[5]++;
                }
                else
                {
                    ageGroupCounter[6]++;
                }

            }
            return ageGroupCounter;
        }

        public int[] countGender(List<Customer> list) {

            int[] genderCount = { 0, 0 };

            foreach(Customer customer in list)
            {
                if (customer.gender == "Male") 
                {
                    genderCount[0]++;
                }
                else
                {
                    genderCount[1]++;
                }
            }

            return genderCount;
       }

        public int[] countPerProvince(List<GeoAlert> list) {

            int[] province = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach(GeoAlert customer in list)
            {
                if(customer.loaction == "Gauteng")
                {
                    province[7]++;
                }
                else if (customer.loaction == "Limpopo")
                {
                    province[1]++;
                }
                else if (customer.loaction == "Mphumalanga")
                {
                    province[8]++;
                }
                else if (customer.loaction == "Northern Cape")
                {
                    province[4]++;
                }
                else if (customer.loaction == "Western Cape")
                {
                    province[3]++;
                }
                else if (customer.loaction == "Kwa Zulu Natal")
                {
                    province[2]++;
                }
                else if (customer.loaction == "Estern Cape")
                {
                    province[0]++;
                }
                else if (customer.loaction == "Free State")
                {
                    province[6]++;
                }
                else if (customer.loaction == "North West")
                {
                    province[5]++;
                }


            }

            return province;
        }

        public string usedService(List<Customer> list) 
        {
            
            int smsCounter = 0;
            int smsDATA = 0;
            int smsMinutes = 0;
            int smsNight = 0;
            foreach (Customer customer in list)
            { 
             
                if(customer.serviceName == "SMS")
                {
                    smsCounter++;
                }else if(customer.serviceName == "ALL NETWORK DATA")
                {
                    smsDATA++;
                }else if(customer.serviceName == "ALL NETWORK MINUTES")
                {
                    smsMinutes++;
                }else
                {  smsNight++; }    
            }

            int[] services = {smsCounter,smsDATA,smsMinutes,smsNight};

            int max = 0;
          
            string used = " ";
            // Loop through the array starting from the second element
            for (int i = 0; i < services.Length; i++)
            {
                // Update max if the current element is greater
                if (services[i] > max)
                {
                    max = services[i];
                    if (i == 0)
                    {
                        used = "SMS";
                    }

                    else if(i == 1)
                    {
                        used = "ALL NETWORK DATA";
                    }
                    else if (i == 2)
                    {
                        used = "ALL NETWORK MINUTES";
                    }
                    else
                    {
                        used = "NIGHT SUFFER";
                    }

                 }
                }
            return used;
            }

        public string UnusedService(List<Customer> list)
        {


            int smsCounter = 0;
            int smsDATA = 0;
            int smsMinutes = 0;
            int smsNight = 0;
            foreach (Customer customer in list)
            {

                if (customer.serviceName == "SMS")
                {
                    smsCounter++;
                }
                else if (customer.serviceName == "ALL NETWORK DATA")
                {
                    smsDATA++;
                }
                else if (customer.serviceName == "ALL NETWORK MINUTES")
                {
                    smsMinutes++;
                }
                else
                { smsNight++; }
            }

            int[] services = { smsCounter, smsDATA, smsMinutes, smsNight };

          
            int min = services[0] + 1;

            string used = " ";
            // Loop through the array starting from the second element
            for (int i = 0; i < services.Length; i++)
            {
                // Update max if the current element is greater

                // Update min if the current element is smaller
                if (services[i] < min)
                {
                    min = services[i];
                    if (i == 0)
                    {
                        used =  "SMS";
                    }
                    else if (i == 1)
                    {
                    used = "ALL NETWORK DATA";
                    }
                    else if (i == 2)
                    {
                        used =  "ALL NETWORK MINUTES";
                    }
                    else
                    {
                       used = "NIGHT SUFFER";
                    }
                }

            }

            return used;
        }
    }




    
}
