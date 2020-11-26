using QS.Utilities.Numeric;

namespace SecretProject.BusinessProject.Models.User
{
    public class Phone
    {
        private string phoneNumber;
        public string PhoneNumber {
            get => phoneNumber;
            set
            {
                PhoneFormatter formatter = new PhoneFormatter(PhoneFormat.RussiaOnlyHyphenated);
                phoneNumber = formatter.FormatString(value);
                formatter.Format = PhoneFormat.DigitsTen;
                PhoneDigits = formatter.FormatString(value);
            }
        }
        public string PhoneDigits { get; private set; }
    }
}