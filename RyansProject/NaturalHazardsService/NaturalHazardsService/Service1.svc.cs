using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
namespace NaturalHazardsService
{
    public class Service1 : IService1
    {
        //Leaving method name as NaturalHazards for potential future expansion to support other hazards. Currently only supports earthquakes at a location.
        public double NaturalHazards(double latitude, double longitude)
        {
            return NumberofEarthquakes(latitude, longitude);
        }

        private double NumberofEarthquakes(double latitude, double longitude)
        {
            //Constructing url based on user inputs. Creating diamond coordinates based off user input to encompass surrounding area. 
            string construct_the_url = "http://comcat.cr.usgs.gov/fdsnws/event/1/query?starttime=2014-10-01%2000:00:00&maxlatitude="+ Convert.ToString(latitude)
                + "&minlatitude=" + Convert.ToString(latitude-5) + "&maxlongitude=" + Convert.ToString(longitude) + "&minlongitude=" + Convert.ToString(longitude-5)
                + "&minmagnitude=2&format=geojson&endtime=2014-11-02%2023:59:59&orderby=time&limit=50";

            //Storing original site URL in case of rework
            //string url = "http://comcat.cr.usgs.gov/fdsnws/event/1/query?starttime=2014-10-01%2000:00:00&maxlatitude=40&minlatitude=35&maxlongitude=-120&minlongitude=-125&minmagnitude=1&format=geojson&endtime=2014-11-02%2023:59:59&orderby=time&limit=50";
            
            //Parsing logic using provided WebtoString service
            WebtoString.ServiceClient myClient = new WebtoString.ServiceClient();
            string webpage = myClient.GetWebContent(construct_the_url);
            int first = webpage.IndexOf("count");
            int second = webpage.IndexOf("},\"features");
            string count_ss = webpage.Substring(first + 7, second - first - 7);

            return Convert.ToDouble(count_ss);
        }
    }
}
