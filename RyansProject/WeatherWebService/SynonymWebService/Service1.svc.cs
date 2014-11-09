using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Net;
using System.Xml;

using System.Collections;

namespace SynonymWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public TextMessage getSynonyms(string input, string type)
        {
            //Preparing the url for the GET request from user input. 

            //noun verb adv adj

            string front = "http://thesaurus.altervista.org/thesaurus/v1?word=";
            //http://thesaurus.altervista.org/thesaurus/v1?word=hello&key=HIFZqjfEgPxHYQaDG23n&language=en_US&output=xml
            string back = "&key=HIFZqjfEgPxHYQaDG23n&language=en_US&output=xml";
            string url = front + input + back;

            //Creating web connection with previously constructed url
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));

            //Using Xml structure to hold the results. Grabbing the max temperatures and day of each node.
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());
            XmlNodeList wordlist = xmlDoc.GetElementsByTagName("list");
            //XmlNodeList daylist = xmlDoc.GetElementsByTagName("time");

            string result = "";
            TextMessage message = new TextMessage();
           

            //Appending all results to single string variable for return 
            for (int i = 0; i < wordlist.Count; i++)
            {
                if (wordlist[i].FirstChild.InnerText == ("("+type+")"))
                {
                    result += wordlist[i].LastChild.InnerText + " ";
                    
                    //break;
                    //return result;
                }
                //message.Message = "error";
            }
            ArrayList myAL = new ArrayList();
            //Parsing logic
            string synonyms = "", antonyms = "", holder = "";
            int s_num = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if(result[i].Equals('|'))
                {
                    synonyms += holder + " ";
                    myAL.Add(holder);
                    holder = "";
                    s_num++;
                }
                else if(result[i].Equals('('))
                {
                    while(!(result[i].Equals(')')))
                    {
                        i++;
                    }
                        //i += 8;
                        //antonyms += holder + " ";
                        holder = "";
              
                    //holder += result[i];
                }
                else
                {
                    holder += result[i];
                }
            }

           

            message.Message = synonyms;
            Random rnd1 = new Random();
            if(s_num != 0)
            {
                int random = rnd1.Next(s_num); 
                message.Message = (string)myAL[random];
            }
            else
            {
                message.Message = "";
            }
            return message;
         
        }

    
    }
}
