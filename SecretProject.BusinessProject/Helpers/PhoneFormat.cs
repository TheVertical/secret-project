using System.ComponentModel.DataAnnotations;

namespace SecretProject.BusinessProject.Helpers
{
    /// <summary>
    /// Форматы телефонов
    /// </summary>
    public enum PhoneFormat
    {
        /// <summary>
        /// +7-XXX-XXX-XX-XX
        /// </summary>
        [Display(Name = "+7-XXX-XXX-XX-XX")]
        RussiaOnlyHyphenated,
        /// <summary>
        /// (XXX) XXX - XX - XX
        /// </summary>
        [Display(Name = "(XXX) XXX - XX - XX")]
        BracketWithWhitespaceLastTen,
        /// <summary>
        /// XXXXXXXXXX
        /// </summary>
        [Display(Name = "XXXXXXXXXX")]
        DigitsTen
    }
}