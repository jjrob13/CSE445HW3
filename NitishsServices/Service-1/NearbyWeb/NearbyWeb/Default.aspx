<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NearbyWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 215px">
    <form id="form1" runat="server">
    <div style="font-family: 'Eras Medium ITC'; font-size: x-large; font-weight: 200; text-decoration: blink">
    
        Hello people, this web service provides you with the list of restaurants around the place you enter in the text box below.<br />
        <br />
    
        Enter City Name&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="254px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Find!" />
    
        <br />
        <br />
        Here is the List of Fine Restaurants:</div>
        <asp:Label ID="Label1" runat="server" Text="Restaurants List coming soon..." Font-Names="Berlin Sans FB" Font-Size="Large"></asp:Label>
    </form>
</body>
</html>
