using QS.Utilities.Numeric;

namespace SecretProject.BusinessProject.Models.UserData
{
    public class Phone
    {
        public PhoneFormat PhoneFormat = PhoneFormat.RussiaOnlyHyphenated;
        private string phoneNumber;
        public string PhoneNumber {
            get => phoneNumber;
            set
            {
                PhoneFormatter formatter = new PhoneFormatter(PhoneFormat);
                phoneNumber = formatter.FormatString(value);
                formatter.Format = PhoneFormat.DigitsTen;
                PhoneDigits = formatter.FormatString(value);
            }
        }
        public string PhoneDigits { get; private set; }
    }
}