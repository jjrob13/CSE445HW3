using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Xml;

namespace NearByPlaces
{
    public class Service1 : IService1
    {
        // URL for google Places api with a private key.
        public static string PlacesURL = "https://maps.googleapis.com/maps/api/place/textsearch/xml?key=AIzaSyBEyJi2s7PV3LuYacImmbwvfzLIhWgcTbc&query=restaurants%20in%20";
        public static string PerHotelDetails = "https://maps.googleapis.com/maps/api/place/details/xml?key=AIzaSyBtKHpv3Z6jMlmb_heh8lBzEvs-rUzRIvY&placeid=";
        
        // This function is the endpoint function for the web service, which takes in the city name as the parameter and returns the list of Places.
        public List<PlacesList> GetPlacesData(string placename)
        {
            string request = CreateRequest(PlacesURL, placename);
            List<PlacesList> response = new List<PlacesList>();
            List<Object> tmp = MakeResponse(request, 0);
            for (int i = 0; i < tmp.Count; i++)
            {
                response.Add((PlacesList)tmp[i]);
            }
            return response;
        }

        // This function creates the final URL by appending the city name with the initial URL, and feeds this URL to MakeResponse function.
        public static string CreateRequest(string url, string value)
        {
            string url1 = url + value;
            return url1;
        }

        // This function actually developes a connection with the google places api and gets the restaurants list.
        public static List<Object> MakeResponse(string url, int fnSelector)
        {

            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            List<Object> list = new List<Object>();
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());
            if (fnSelector == 0)
            {
                XmlNodeList locationElements = xmlDoc.SelectNodes("PlaceSearchResponse/result");
                foreach (XmlNode node in locationElements)
                {
                    if (node.SelectSingleNode("rating") != null)
                    {
                        PlacesList tmp = new PlacesList();
                        tmp.name = node.SelectSingleNode("name").InnerText;
                        tmp.formatted_address = node.SelectSingleNode("formatted_address").InnerText;
                       // tmp.price_level = node.SelectSingleNode("price_level").InnerText;
                        tmp.rating = node.SelectSingleNode("rating").InnerText;
                        tmp.lat = node.SelectSingleNode("geometry/location/lat").InnerText;
                        tmp.lng = node.SelectSingleNode("geometry/location/lng").InnerText;
                        tmp.referenceId = node.SelectSingleNode("place_id").InnerText;
                        list.Add(tmp);
                    }

                }
            }

            return list;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


    }
}
