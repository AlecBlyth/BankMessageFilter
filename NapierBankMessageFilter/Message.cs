using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NapierBankMessageFilter
{
    [DataContract] //Allows for serialsation of types. 
    [KnownType(typeof(SMS))]
    [KnownType(typeof(Tweet))]
    [KnownType(typeof(Email))]
    [KnownType(typeof(SIR))]
    public abstract class Message
    { 
        protected string _messageID;
        protected string _sender;
        protected string _messageText;
        protected string _filteredMessage;

        protected const string textSpeak = @"../../textwords.csv"; //Gets textspeak from csv file found in res or main folder 

        protected readonly int msgLength; //Set max message length
        protected readonly string senderRegrex; //Used to validate sender info 

        /// <exception cref="System.ArgumentException"></exception>
        public Message(string messageID, string sender, string messageText, int textLength, string senderRegex)
        {
            //values are passed in by classes
            msgLength = textLength;
            senderRegrex = senderRegex;

            MessageID = messageID;
            MessageText = messageText;
            Sender = sender;
        }

        protected abstract void filterMessage();

        #region Getters and Setters

        /// <exception cref="System.ArgumentException"></exception>
        [DataMember]
        public string MessageID
        {
            get { return _messageID; }
            set
            {
                //ID validation  
                if (!Regex.IsMatch(value, @"^[SET][0-9]{9}"))
                    throw new ArgumentException("Invalid format! Enter 'X123456789' X = E / T / S");

                _messageID = value;
            }
        }

        /// <exception cref="System.ArgumentException"></exception>
        [DataMember]
        public string Sender //Gets and sets sender info in message object 
        {
            get { return _sender; }
            set
            {
                if (!Regex.IsMatch(value, senderRegrex))
                {
                    string helper; //If user inputs wrong sender type, these hints pop up. 
                    if (this is SMS)
                    {
                        helper = "+44770499348";
                    }
                    else if (this is Tweet)
                    {
                        helper = "@AdamSmith";
                    }
                    else
                    {
                        helper = "john.smith1@example.com";
                    }

                    throw new ArgumentException("Please enter correct sender info : '" + helper + "'.");
                }

                _sender = value;
            }
        }

        /// <exception cref="System.ArgumentException"></exception>
        [DataMember]
        public string MessageText //Gets and sets message text in message object 
        {
            get { return _messageText; } 
            set
            {
                if (value.Length > msgLength)
                    throw new ArgumentException("You have exceeded the message character limit!"); //Informs user of char limit exceeded. 

                _messageText = value;
            }
        }

        public string filteredMessage //Gets filtered message 
        {
            get { return _filteredMessage; }
        }

        #endregion
    }
}
