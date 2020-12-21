using QS.Utilities.Numeric;

namespace SecretProject.BusinessProject.Models.UserData
{
    public class Phone
    {
        public PhoneFormat PhoneFormat = PhoneFormat.BracketWithWhitespaceLastTen;
        private string phoneNumber;
        public string PhoneNumber {
            get => phoneNumber;
            set
            {
                if (value == null)
                    return;
                PhoneFormatter formatter = new PhoneFormatter(PhoneFormat);
                phoneNumber = formatter.FormatString(value);
                formatter.Format = PhoneFormat.DigitsTen;
                PhoneDigits = formatter.FormatString(value);

            }
        }
        public string PhoneDigits { get; private set; }

        public override string ToString()
        {
            return "+7" + phoneNumber;
        }
    }
}