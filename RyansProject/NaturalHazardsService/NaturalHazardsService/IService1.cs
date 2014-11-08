using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NaturalHazardsService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        double NaturalHazards(double latitude, double longitude);
    }
}
