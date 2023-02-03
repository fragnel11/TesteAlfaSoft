using System.Net.Mail;

namespace TesteALFASOFT.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string? Name { get;  set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get;  set; }

        
        public bool IsValid()
        {
            if (Name.Length <= 5)
            {
                return false;
            }

            if (ContactNumber.Length != 9)
            {
                return false;
            }

            try
            {
                MailAddress m = new MailAddress(EmailAddress);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
