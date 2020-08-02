using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace NapierBankMessageFilter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Message _message;
        private string MessageType;
       
        public MainWindow() 
        {
            MessageType = "email";
            InitializeComponent();
            lblSubject.Visibility = Visibility.Visible;
            btnLoad.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Hides non email components and shows email components 
        /// </summary>
        private void emailButton_Click(object sender, RoutedEventArgs e)
        {
            listHastags.Visibility = Visibility.Hidden;
            listMentions.Visibility = Visibility.Hidden;
            MessageType = "email";
            btnLoad.Visibility = Visibility.Hidden;
            txtMessage.Visibility = Visibility.Visible;
            txtMessage.Height = 350;
            txtMessage.Width = 750;
            txtMessageID.Clear();
            txtSender.Clear();
            txtSubject.Clear();
            txtMessage.Clear();
            btnTrends.Visibility = Visibility.Hidden;
            btnIncidents.Visibility = Visibility.Visible;
            btnQuarantine.Visibility = Visibility.Visible;
            listMessages.Visibility = Visibility.Hidden;
            listIncidents.Visibility = Visibility.Hidden;
            listMessages.Visibility = Visibility.Hidden;
            lblSubject.Visibility = Visibility.Visible;
            listQuarantine.Visibility = Visibility.Hidden;

            txtSubject.Visibility = Visibility.Visible;
            txtSubject.IsEnabled = true;
        } //Allows for email functionality 

        /// <summary>
        /// Hides non sms components and shows sms components 
        /// </summary>
        private void smsButton_Click(object sender, RoutedEventArgs e)
        {
            listHastags.Visibility = Visibility.Hidden;
            listMentions.Visibility = Visibility.Hidden;
            MessageType = "sms";
            btnLoad.Visibility = Visibility.Hidden;
            txtMessage.Visibility = Visibility.Visible;
            txtMessage.Height = 250;
            txtMessage.Width = 500;
            txtMessageID.Clear();
            txtSender.Clear();
            txtSubject.Clear();
            txtMessage.Clear();
            btnTrends.Visibility = Visibility.Hidden;
            btnIncidents.Visibility = Visibility.Hidden;
            btnQuarantine.Visibility = Visibility.Hidden;
            listMessages.Visibility = Visibility.Hidden;
            listIncidents.Visibility = Visibility.Hidden;
            listMessages.Visibility = Visibility.Hidden;
            lblSubject.Visibility = Visibility.Hidden;
            listQuarantine.Visibility = Visibility.Hidden;

            txtSubject.Visibility = Visibility.Hidden;
            txtSubject.IsEnabled = false;

        } //Allows for sms functionality

        /// <summary>
        /// Hides non tweet components and shows tweet components 
        /// </summary>
        private void tweetButton_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Visibility = Visibility.Visible;
            listHastags.Visibility = Visibility.Hidden;
            listMentions.Visibility = Visibility.Hidden;
            MessageType = "tweet";
            btnLoad.Visibility = Visibility.Hidden;
            txtMessage.Height = 250;
            txtMessage.Width = 500;
            txtMessageID.Clear();
            txtSender.Clear();
            txtSubject.Clear();
            txtMessage.Clear();
            txtMessageID.Clear();
            btnTrends.Visibility = Visibility.Visible;
            btnIncidents.Visibility = Visibility.Hidden;
            btnQuarantine.Visibility = Visibility.Hidden;
            listIncidents.Visibility = Visibility.Hidden;
            listMessages.Visibility = Visibility.Hidden;
            lblSubject.Visibility = Visibility.Hidden;
            listQuarantine.Visibility = Visibility.Hidden;
        } //Allows for tweet functionality

        /// <summary>
        /// Hides non tweet data and shows tweet trends 
        /// </summary>
        private void btnTrends_Click(object sender, RoutedEventArgs e)
        {

            txtMessage.Visibility = Visibility.Hidden;
            MessageType = "tweet";
            btnLoad.Visibility = Visibility.Visible;
            btnIncidents.Visibility = Visibility.Hidden;
            btnQuarantine.Visibility = Visibility.Hidden;
            listIncidents.Visibility = Visibility.Hidden;
            listMessages.Visibility = Visibility.Hidden;
            listQuarantine.Visibility = Visibility.Hidden;
            listHastags.Visibility = Visibility.Visible;
            listMentions.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Hides non email components and shows email with URLs quarantined 
        /// </summary>
        private void btnQuarantine_Click(object sender, RoutedEventArgs e)
        {

            MessageType = "email";
            btnLoad.Visibility = Visibility.Visible;
            txtMessage.Visibility = Visibility.Hidden;
            listIncidents.Visibility = Visibility.Hidden;
            listMessages.Visibility = Visibility.Hidden;
            listQuarantine.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Hides non SIR components and shows SIR with Sort Code and Incident
        /// </summary>
        private void btnIncidents_Click(object sender, RoutedEventArgs e)
        {
            MessageType = "email";
            btnLoad.Visibility = Visibility.Visible;
            txtMessage.Visibility = Visibility.Hidden;
            listIncidents.Visibility = Visibility.Visible;
            listQuarantine.Visibility = Visibility.Hidden;
            listMessages.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Hides all components that add messages and views all messages and allows user to load new json files. 
        /// </summary>
        private void btnViewMessages_Click(object sender, RoutedEventArgs e)
        {

            listHastags.Visibility = Visibility.Hidden;
            listMentions.Visibility = Visibility.Hidden;
            MessageType = "";
            btnLoad.Visibility = Visibility.Visible;
            txtMessage.Visibility = Visibility.Hidden;
            listIncidents.Visibility = Visibility.Hidden;
            listMessages.Visibility = Visibility.Visible;
            listQuarantine.Visibility = Visibility.Hidden;
            lblSubject.Visibility = Visibility.Hidden;
            txtSubject.Visibility = Visibility.Hidden;
            txtMessage.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creates new message based on message type
        /// </summary>
        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageType == "email" && txtMessageID.Text.ToUpper().Contains("E"))
                { 
                    MessageGen mf = new MessageGen();
                    _message = mf.CreateMessage(txtMessageID.Text, txtSender.Text, txtMessage.Text.Trim(), txtSubject.Text);
                    listMessages.Items.Add(_message);
                    urlQuarantine((Email)_message);
                }
                if (MessageType == "email" && txtMessageID.Text.ToUpper().Contains("E") && txtSubject.Text.Contains("SIR")){ 
                    MessageGen mf = new MessageGen();
                    _message = mf.CreateMessage(txtMessageID.Text, txtSender.Text, txtMessage.Text.Trim(), txtSubject.Text);
                    listMessages.Items.Add(_message);
                    listIncidents.Items.Add((SIR)_message);
                }

                if (MessageType == "tweet" && txtMessageID.Text.ToUpper().Contains("T"))
                {
                    MessageGen mf = new MessageGen();
                    _message = mf.CreateMessage(txtMessageID.Text, txtSender.Text, txtMessage.Text.Trim(), txtSubject.Text);
                    addHashtagsAndMentions((Tweet)_message);
                    listMessages.Items.Add(_message);
                }
                if (MessageType == "sms" && txtMessageID.Text.ToUpper().Contains("S"))
                {
                    MessageGen mf = new MessageGen();
                    _message = mf.CreateMessage(txtMessageID.Text, txtSender.Text, txtMessage.Text.Trim(), txtSubject.Text);
                    listMessages.Items.Add(_message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            txtMessageID.Clear();
            txtSender.Clear();
            txtSubject.Clear();
            txtMessage.Clear();

        }

        /// <summary>
        /// Saves json file
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saver = new SaveFileDialog(); //Open new dialog
            saver.Filter = "JSON Files|*.json"; //Only allow JSON files
            saver.AddExtension = true; 
            saver.DefaultExt = ".json";

            if (saver.ShowDialog() == true)
            {
                if (!File.Exists(saver.FileName))
                {
                    var newFile = File.Create(saver.FileName); //Create new file 
                    newFile.Close(); //Close file creator 
                }

                StreamWriter sw = new StreamWriter(saver.FileName);
                foreach (Message m in listMessages.Items)
                {
                    sw.WriteLine(JSONClass.JsonSerializer(m)); //Write every message in list to json file
                }

                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// Hides URLs and adds them to list
        /// </summary>
        private void urlQuarantine(Email email)
        {
            foreach (string url in email.URLs) //For each url in email 
            {
                Tuple<string, string> urlTuple = new Tuple<string, string>(email.MessageID, url);
                listQuarantine.Items.Add(urlTuple); //Filter URL and add to list 
            }
        }

        /// <summary>
        /// Adds hashtags and mentions to list
        /// </summary>
        private void addHashtagsAndMentions(Tweet tweet)
        {
            Dictionary<string, int> hashtags = new Dictionary<string, int>(); //Array of hashtags
            Dictionary<string, int> mentions = new Dictionary<string, int>(); //Array of mentions

            listHastags.Items.Clear(); //Clears previous items 
            listMentions.Items.Clear();

            foreach (KeyValuePair<string, int> kv in tweet.Hashtags)
            {
                foreach (KeyValuePair<string, int> item in listHastags.Items)
                {
                    var selectedItem = (dynamic)item;
                    hashtags.Add(selectedItem.Key, Convert.ToInt32(selectedItem.Value));
                }

                //If duplicate then add to count instead of incrementing 
                if (hashtags.ContainsKey(kv.Key))
                {
                    hashtags[kv.Key] += kv.Value;
                }
                else
                {
                    hashtags.Add(kv.Key, kv.Value);
                }
            }

            foreach (KeyValuePair<string, int> kv in tweet.Mentions)
            {
                foreach (KeyValuePair<string, int> item in listMentions.Items)
                {
                    var selectedItem = (dynamic)item;
                    mentions.Add(selectedItem.Key, Convert.ToInt32(selectedItem.Value));
                }

                if (mentions.ContainsKey(kv.Key))
                {
                    mentions[kv.Key] += kv.Value;
                }
                else
                {
                    mentions.Add(kv.Key, kv.Value);
                }
            }

            foreach (KeyValuePair<string, int> kv in hashtags)
            {
                listHastags.Items.Add(kv);
            }
            foreach (KeyValuePair<string, int> kv in mentions)
            {
                listMentions.Items.Add(kv);
            }
        }

        /// <summary>
        /// Loads JSON file
        /// </summary>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            listMessages.Items.Clear(); //Clears previous loaded from list 
            listIncidents.Items.Clear();
            listMentions.Items.Clear();
            listHastags.Items.Clear();
            listQuarantine.Items.Clear();
            OpenFileDialog dialog = new OpenFileDialog(); //Opens dialog box 
            bool messageError = false; 
            dialog.Filter = "JSON Files|*.json"; //ALlows only JSON files 

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    StreamReader sr = new StreamReader(dialog.FileName); //File reader 
                   
                    while (!sr.EndOfStream)
                    {
                        string messageString = sr.ReadLine(); //Read line in JSON file 

                        try
                        {
                            Message message = JSONClass.JsonDeserialize<Message>(messageString); //Creates new message object from JSON 
                            addMessage(message); //Adds message from JSON file 
                        }
                        catch (Exception)
                        {
                            messageError = true;
                        }
                    }

                    sr.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot read file.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error); //Error message
                }

                if (messageError)
                    MessageBox.Show("File Error.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error); //Error message
            }
        }
        /// <summary>
        /// Adds message from JSON file
        /// </summary>
        private void addMessage(Message message)
        {
            if (message.GetType() == typeof(Tweet)) //If tweet then get hashtags and mentions from tweet object
            {
                addHashtagsAndMentions((Tweet)message);
                listMessages.Items.Add(message);
            }
            else if (message.GetType() == typeof(SIR)) //If SIR then add SIR to incidents list 
            {
                listIncidents.Items.Add((SIR)message);
            }
            else if (message.GetType() == typeof(Email)) //If Email then add to list and check URLs
            {
                listMessages.Items.Add(message);
                urlQuarantine((Email)message);
            }
            else
            {
                listMessages.Items.Add(message); //Else it's just a SMS 
            }
        }

    }
}
