using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Net;

namespace WeatherWebService
{
    public class Service1 : IService1
    {
        public string Weather7day(string zipcode)
        {
            //Preparing the url for the RESTFul request from user input. Weather API takes in city name, so zipcode needs to 
            //be converted into city name.
            string city = ziptocity(zipcode);
            string front = "http://api.openweathermap.org/data/2.5/forecast/daily?q=";
            string back = "&mode=xml&units=metric&cnt=7&APPID=d42de83c4fc21d617ab676e2f10339b5";
            string url = front+city+back;

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
            XmlNodeList templist = xmlDoc.GetElementsByTagName("temperature");
            XmlNodeList daylist = xmlDoc.GetElementsByTagName("time");

            string result = "The forecast is: ";

            //Appending all results to single string variable for return 
            for (int i = 0; i < templist.Count && i < daylist.Count; i++)
            {
                if (templist[i].Attributes["max"].Value == null || daylist[i].Attributes["day"].Value == null)
                {
                    return "error";
                }
                else
                {
                    result +=  C2F(templist[i].Attributes["max"].Value);
                    result += " ";
                    result += "(" + daylist[i].Attributes["day"].Value + ")";
                    result += " ";
                }
            }
                
            return result;
         
        }

        //Method converts celcius to fahrenheit. Pulled method logic from HW1
        public string C2F(string input)
        {
            double input_dbl = Convert.ToDouble(input);
            double value =  (int)((9.0 / 5.0) * input_dbl + 32);
            return Convert.ToString((int)value);
        }

        //Using Google API geocode to convert zipcode to actual city name for use with weather API
        public string ziptocity(string zipcode)
        {
    
            string front = "http://maps.googleapis.com/maps/api/geocode/xml?address=";
            string back = "&sensor=true";
            string url = front+zipcode+back;

            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());
    
            XmlNodeList city_list = xmlDoc.GetElementsByTagName("long_name");
          
            return city_list[1].InnerText;
           
        }
    }
}
