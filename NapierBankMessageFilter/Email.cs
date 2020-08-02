using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NapierBankMessageFilter
{
    [DataContract]
    public class Email : Message
    {
        protected string _subject;
        private List<string> _URLs = new List<string>();

        protected new const int msgLength = 20; //Sets default message length
        private const string urlRegrex = @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)"; //Used to detect urls and quarantine them.

        /// <exception cref="System.ArgumentException"></exception>
        public Email(string messageID, string sender, string messageText, string subject) : base(messageID, sender, messageText, 1028, @"^[A-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-z0-9](?:[A-z0-9-]*[A-z0-9])?\.)+[A-z0-9](?:[A-z0-9-]*[A-z0-9])?") //Object body 
        {
            Subject = subject; //Email has a subject attribute 
            filterMessage(); //Filters email message
        }

        /// <exception cref="System.ArgumentException"></exception>
        [DataMember]
        public string Subject //Subject attribute getter and setter
        {
            get { return _subject; }
            set
            {
                if (value.Length > msgLength)
                    throw new ArgumentException("Subject has too many characters!"); //Subject length validation 

                _subject = value; 
            }
        }

        protected override void filterMessage() //Filters email is url is found 
        {
            _filteredMessage = _messageText;

            foreach (Match url in Regex.Matches(_messageText, urlRegrex))
            {
                _filteredMessage = _filteredMessage.Replace(url.Value, "<URL Quarantined>"); //Changes URL to <URL Quarantined>
                _URLs.Add(url.Value); 
            }
        }

        /// <exception cref="System.ArgumentException"></exception>
        [DataMember]
        public List<string> URLs //Gets list of URLs found
        {
            get { return _URLs; }
            set { _URLs = value; }
        }
    }
}
