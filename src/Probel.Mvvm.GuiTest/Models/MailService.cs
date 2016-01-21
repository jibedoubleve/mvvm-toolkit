namespace Probel.Mvvm.GuiTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MailService
    {
        #region Fields

        private static IList<Mail> MailRepository = new List<Mail>();

        #endregion Fields

        #region Constructors

        static MailService()
        {
            MailRepository.Add(new Mail("Robert", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tempor viverra ipsum. Donec dignissim aliquet massa, at "));
            MailRepository.Add(new Mail("Marcel", "aliquet. Donec vehicula metus nec bibendum bibendum. Integer leo nibh, sodales non nunc in, vehicula sollicitudin augue. "));
            MailRepository.Add(new Mail("Joseph", "tempor vehicula nisi, vitae consequat arcu eleifend in. Mauris tristique dolor eget elementum auctor. Maecenas luctus "));
        }

        #endregion Constructors

        #region Methods

        public void AddMail(string to, string message)
        {
            MailRepository.Add(new Mail(to, message));
        }

        public IEnumerable<Mail> GetMails()
        {
            return MailRepository;
        }

        public void UpdateMail(int id, string message)
        {
            var current = (from m in MailRepository
                           where m.Id == id
                           select m).SingleOrDefault();
            if (current != null)
            {
                current.Message = message;
            }
        }

        #endregion Methods
    }
}