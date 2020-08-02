using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankMessageFilter
{
    public class MessageGen ///Generates new messages 
    {

        /// <exception cref="System.ArgumentException"></exception>
        public Message CreateMessage(string msgID, string sender, string messageText, string subject = "")
        {
            if (msgID.ToUpper().Contains("S")) //If message is a SMS then return new SMS object 
            {
                return new SMS(msgID.ToUpper(), sender, messageText);
            }
            else if (msgID.ToUpper().Contains("T")) //If message is a Tweet then return new Tweet object 
            {
                return new Tweet(msgID.ToUpper(), sender, messageText);
            }
            else if (msgID.ToUpper().Contains("E")) //If message is a Email then return new Email object 
            {
                if (subject.Length > 3 && subject.Trim().Substring(0, 3).ToUpper() == "SIR") //If message is a SIR then return new SIR object 
                {
                    return new SIR(msgID.ToUpper(), sender, messageText, subject);
                }
                else
                {
                    return new Email(msgID.ToUpper(), sender, messageText, subject); //If message is a SIR then return new Email object 
                }
            }
            else
            {
                throw new ArgumentException("Please insert a valid Message ID - Message Type(E/T/S) + 123456789"); //Message ID Validation 
            }
        }
    }
}
