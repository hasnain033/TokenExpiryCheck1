using System;

class Program
{
    static void Main()
    {
        //date string
        string orExpiryDate = "2024-09-26 15:00:00";

        try
        {
            //Calling expiryAuth
            bool isExpiring = isORAuthExpired(orExpiryDate);

            Console.WriteLine("Is expiring in one hour? " + isExpiring);
        }
        catch (Exception ex)
        {
            //exception
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static bool isORAuthExpired(string orExpiryDate)
    {
        try
        {
            // if TryParse Fails to convert to DateTime Format
            if (!DateTime.TryParse(orExpiryDate, out var expiryDate))
            {
                throw new FormatException("Invalid date format.");
            }

            expiryDate = expiryDate.AddDays(1).Date;
            var currentDate = DateTime.UtcNow;
            Console.WriteLine(expiryDate + " " + currentDate);
            var diff = expiryDate - currentDate;
            Console.WriteLine(diff);
            return diff.TotalHours <= 1;

            /*var nextDate = expiryDate.AddDays(1).Date;
			Console.WriteLine(expiryDate +" "+ nextDate);
            var diff = nextDate - expiryDate;
			Console.WriteLine(diff);
            return diff.TotalHours <= 1;*/
        }
        catch (FormatException ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
