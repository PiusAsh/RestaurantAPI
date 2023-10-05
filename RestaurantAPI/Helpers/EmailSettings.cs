namespace RestaurantAPI.Helpers
{
    public class EmailSettings
    {
        public string MailFrom { get; set; }
        public string MailFromName { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public bool EnableSsl { get; set; }
    }

}
