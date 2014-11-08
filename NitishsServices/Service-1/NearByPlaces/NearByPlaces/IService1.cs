using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NearByPlaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<PlacesList> GetPlacesData(string value);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class PlacesList
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string formatted_address { get; set; }
        [DataMember]
        public string rating { get; set; }
        [DataMember]
        public string price_level { get; set; }
        [DataMember]
        public string lat { get; set; }
        [DataMember]
        public string lng { get; set; }
        [DataMember]
        public string referenceId { get; set; }

    }
    [DataContract]
    public class PlacesDetails
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string formatted_number { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string website { get; set; }
        [DataMember]
        public List<Review> review { get; set; }
    }
    [DataContract]
    public class Review
    {
        [DataMember]
        public string time { get; set; }
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public string author_name { get; set; }
        [DataMember]
        public string rate { get; set; }

    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
