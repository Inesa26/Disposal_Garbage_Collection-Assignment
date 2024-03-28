using System.Configuration;

namespace DisposalApplication
{

    public class EmailConfiguration
    {
        public string SmtpHost { get; }
        public int SmtpPort { get; }
        public string SmtpUsername { get; }
        public string SmtpPassword { get; }
        public bool EnableSsl { get; }

        public EmailConfiguration()
        {

            SmtpHost = ConfigurationManager.AppSettings["Host"];
            SmtpPort = int.Parse(ConfigurationManager.AppSettings["Port"]);
            SmtpUsername = ConfigurationManager.AppSettings["Username"];
            SmtpPassword = ConfigurationManager.AppSettings["Password"];
            EnableSsl = bool.Parse(ConfigurationManager.AppSettings["EnableSsl"]);
        }
    }
}

