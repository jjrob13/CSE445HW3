using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NearbyWeb.ServiceReference1;

namespace NearbyWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text.Trim() != "")
                {
                    Label1.Text = "";
                    ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
                    PlacesList[] list;
                    string placeName = TextBox1.Text;
                    list = sc.GetPlacesData(placeName);
                    for (int i = 0; i < list.Count(); i++)
                    {
                        Label1.Text = Label1.Text + "<br /><b>Name:</b> " + list[i].name + /*" <br /><b>Price Level: </b>" + list[i].price_level + */"<br />" + "<b>Rating:</b>" + list[i].rating + "<br />" +"<b>Address:</b>" + list[i].formatted_address + "<br /><br />=============================================<br /><br />";
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter a place.')", true);
                }
            }
            catch (Exception)
            {
                Label1.Text = "No Data Found";
            }
        }
    }
}