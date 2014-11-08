using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Xml;

namespace NearByHotelService
{
    public class Service1 : IService1
    {
        public static string PlaceURL = "https://maps.googleapis.com/maps/api/place/textsearch/xml?key=AIzaSyBtKHpv3Z6jMlmb_heh8lBzEvs-rUzRIvY&query=restaurants%20in%20";
        public static string ReviewDetails = "https://maps.googleapis.com/maps/api/place/details/xml?key=AIzaSyBtKHpv3Z6jMlmb_heh8lBzEvs-rUzRIvY&placeid=";
        
        // This function gives the list of the restaurants in a city along with their referenceId which will help in fetching the reviews.
        public List<HotelList> GetHotelData(string placename)
        {
            string request = CreateRequest(PlaceURL, placename);
            List<HotelList> response = new List<HotelList>();
            List<Object> tmp = GenerateList(request, 0);
            for (int i = 0; i < tmp.Count;i++ )
            {
                response.Add((HotelList)tmp[i]);
            }
            return response;
        }
      
        // This function takes in the referenceId and gives reviews about a particular restaurant.
        public List<HotelDetails> GetPerHotelDetails(string referenceID)
        {
            string request = CreateRequest(ReviewDetails, referenceID);
            List<HotelDetails> response = new List<HotelDetails>();
            List<Object> tmp = GenerateList(request, 1);
            for (int i = 0; i < tmp.Count; i++)
            {
                response.Add((HotelDetails)tmp[i]);
            }
            return response;
        }

        //This function creates a final URL for both the functions above.
        public static string CreateRequest(string url, string value)
        {
            string Finalurl;
            return Finalurl = url + value;
           
        }

        // This is the soul function of the service which establishes the web connections and returns a list to the calling functions.
        public static List<Object> GenerateList(string url, int functionnSelector)
        {

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            List<Object> list = new List<Object>();
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());
            if(functionnSelector == 0){
                XmlNodeList locationElements = xmlDoc.SelectNodes("PlaceSearchResponse/result");
                foreach (XmlNode node in locationElements)
                {
                    if (node.SelectSingleNode("rating")!=null)
                    {
                        HotelList tmp = new HotelList();
                        tmp.name = node.SelectSingleNode("name").InnerText;
                        tmp.formatted_address = node.SelectSingleNode("formatted_address").InnerText;
                        tmp.rating = node.SelectSingleNode("rating").InnerText;
                        tmp.referenceId = node.SelectSingleNode("place_id").InnerText;
                        list.Add(tmp);
                    }
                    
                }
            }
            else if (functionnSelector == 1) // functionnSelector = 1 is for the second case where we want to print the reviews of a particular restaurant.
            {
                XmlNodeList Elements = xmlDoc.SelectNodes("PlaceDetailsResponse/result");
                foreach (XmlNode node in Elements)
                {
                    HotelDetails hoteldetails = new HotelDetails();
                    hoteldetails.name = node.SelectSingleNode("name").InnerText;
                    hoteldetails.formatted_number = node.SelectSingleNode("formatted_phone_number").InnerText;
                    hoteldetails.url = node.SelectSingleNode("url").InnerText;
                    hoteldetails.website = node.SelectSingleNode("website").InnerText;
                    XmlNodeList ReviewList = node.SelectNodes("review");
                    List<Review> listR = new List<Review>();
                    foreach (XmlNode nodeReview in ReviewList)
                    {
                        Review tab = new Review();
                        tab.author_name = nodeReview.SelectSingleNode("author_name").InnerText;
                        tab.time = nodeReview.SelectSingleNode("time").InnerText;
                        tab.rate = nodeReview.SelectSingleNode("rating").InnerText;
                        tab.text = nodeReview.SelectSingleNode("text").InnerText;
                        listR.Add(tab);
                    }
                    hoteldetails.review = listR;
                    list.Add(hoteldetails);
                }
            }
            
            return list;
        }
       /* public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }*/


    }
}
