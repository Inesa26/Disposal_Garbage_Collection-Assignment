namespace DisposalApplication
{
    public class Program
    {
        static void Main(string[] args)
        {   //Hello message
            Console.WriteLine("Welcome to the ParkingLot Management System!");

            // Read email address from the user
            Console.WriteLine("For subscription please enter your email address: ");
            string recipientEmail = Console.ReadLine();

            // Create email sender
            EmailSender emailSender = new EmailSender();

            // Send email
            emailSender.SendEmail(recipientEmail, "Thank you for subscribing!", "Dear subscriber, thank you for subscribing to our newsletter.");
        }
    }
}
