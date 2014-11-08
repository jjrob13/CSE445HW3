using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HotelApplication.ServiceReference1;
namespace HotelApplication
{
    public partial class _default : System.Web.UI.Page
    {
       
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text.Trim() != "")
                {
                    Label1.Text = "";
                    Service1Client sc = new Service1Client();
                    HotelList[] list;
                    list = sc.GetHotelData(TextBox1.Text.Trim());
                    for (int i = 0; i < list.Count(); i++)
                    {
                        Label1.Text = Label1.Text + "<b>Name:</b> " + list[i].name + " <br /><b>Reference: </b>" + list[i].referenceId + "<br /><br />";
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter a place.')", true);
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "No Data Found";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox2.Text.Trim() != "")
                {
                    Label1.Text = "";
                    Service1Client sc1 = new Service1Client();
                    HotelDetails[] list1;
                    list1 = sc1.GetPerHotelDetails(TextBox2.Text.Trim());
                    for (int i = 0; i < list1.Count(); i++)
                    {
                        string s;
                        string number = "";
                        string website = "";
                        if (list1[i].formatted_number != null)
                        {
                            number = list1[i].formatted_number;
                        }
                        if (list1[i].website != null)
                        {
                            website = list1[i].website;
                        }
                        s = "<b>Name:</b> " + list1[i].name +
                            " <br /><b>Phone Number: </b>" + number +
                            "<br /> <b>Website: </b>" + website + "<br /><br />";
                        for (int j = 0; j < list1[i].review.Count(); j++)
                        {
                            Review r = new Review();
                            string rate = "";
                            if (list1[i].review[j].rate != null)
                            {
                                rate = list1[i].review[j].rate;
                            }
                            s = s + "<b>Review " + j + "</b>: " + list1[i].review[j].text +
                                "<br /><b>Author</b>: " + list1[i].review[j].author_name +
                                "<br /><b>Rating</b>: " + rate +
                                "<br /><br />";
                        }
                        Label1.Text = Label1.Text + s;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter a reference.')", true);
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "No Data Found";
            }
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}