<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Async="true"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TCM Mining</title>
    <style type="text/css">
        .newStyle1 {
            font-family: Calibri;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        TCM Optimisation Tool<br />
        <br />
        <asp:Label ID="Label24" runat="server" Text="Currency" Width="93px" Font-Bold="True" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Label25" runat="server" Text="1080Ti" Font-Bold="True" Font-Names="Calibri" Width="68px"></asp:Label>
        <asp:Label ID="Label26" runat="server" Text="1060" Font-Bold="True" Font-Names="Calibri" Width="68px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:CheckBox ID="Box1" runat="server" Width="20px" Font-Names="Calibri" Checked="True"/>
        <asp:TextBox ID="Cur_1" runat="server" Height="16px" Width="60px">LBC</asp:TextBox>
        <asp:TextBox ID="HR1_80" runat="server" Height="16px" Width="60px">500</asp:TextBox>
        <asp:TextBox ID="HR1_60" runat="server" Height="16px" Width="60px">175</asp:TextBox>
        <asp:DropDownList ID="HashUnit1" runat="server" DataValueField="Mh/s"> 
            <asp:ListItem Value="1">h/s</asp:ListItem>
            <asp:ListItem Value="1000">kh/s</asp:ListItem>
            <asp:ListItem Selected="True" Value="1000000">Mh/s</asp:ListItem>
            <asp:ListItem Value="1000000000">Gh/s</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:CheckBox ID="Box2" runat="server" Width="20px" Font-Names="Calibri"  Checked="True"/>
        <asp:TextBox ID="Cur_2" runat="server" Height="16px" Width="60px">ZCL</asp:TextBox>
        <asp:TextBox ID="HR2_80" runat="server" Height="16px" Width="60px">750</asp:TextBox>
        <asp:TextBox ID="HR2_60" runat="server" Height="16px" Width="60px">295</asp:TextBox>
        <asp:DropDownList ID="HashUnit2" runat="server">
            <asp:ListItem Selected="True" Value="1">h/s</asp:ListItem>
            <asp:ListItem Value="1000">kh/s</asp:ListItem>
            <asp:ListItem Value="1000000">Mh/s</asp:ListItem>
            <asp:ListItem Value="1000000000">Gh/s</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:CheckBox ID="Box3" runat="server" Width="20px" Font-Names="Calibri"  Checked="True"/>
        <asp:TextBox ID="Cur_3" runat="server" Height="16px" Width="60px">ZEC</asp:TextBox>
        <asp:TextBox ID="HR3_80" runat="server" Height="16px" Width="60px">750</asp:TextBox>
        <asp:TextBox ID="HR3_60" runat="server" Height="16px" Width="60px">295</asp:TextBox>
        <asp:DropDownList ID="HashUnit3" runat="server">
            <asp:ListItem Value="1">h/s</asp:ListItem>
            <asp:ListItem Value="1000">kh/s</asp:ListItem>
            <asp:ListItem Value="1000000">Mh/s</asp:ListItem>
            <asp:ListItem Value="1000000000">Gh/s</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:CheckBox ID="Box4" runat="server" Width="20px" Font-Names="Calibri"  Checked="True"/>
        <asp:TextBox ID="Cur_4" runat="server" Height="16px" Width="60px">ZEN</asp:TextBox>
        <asp:TextBox ID="HR4_80" runat="server" Height="16px" Width="60px">750</asp:TextBox>
        <asp:TextBox ID="HR4_60" runat="server" Height="16px" Width="60px">295</asp:TextBox>
        <asp:DropDownList ID="HashUnit4" runat="server">
            <asp:ListItem Selected="True" Value="1">h/s</asp:ListItem>
            <asp:ListItem Value="1000">kh/s</asp:ListItem>
            <asp:ListItem Value="1000000">Mh/s</asp:ListItem>
            <asp:ListItem Value="1000000000">Gh/s</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:CheckBox ID="Box5" runat="server" Width="20px" Font-Names="Calibri" Checked="True" />
        <asp:TextBox ID="Cur_5" runat="server" Height="16px" Width="60px">SIB</asp:TextBox>
        <asp:TextBox ID="HR5_80" runat="server" Height="16px" Width="60px">19.5</asp:TextBox>
        <asp:TextBox ID="HR5_60" runat="server" Height="16px" Width="60px">7.2</asp:TextBox>
        <asp:DropDownList ID="HashUnit5" runat="server">
            <asp:ListItem Value="1">h/s</asp:ListItem>
            <asp:ListItem Value="1000">kh/s</asp:ListItem>
            <asp:ListItem Selected="True" Value="1000000">Mh/s</asp:ListItem>
            <asp:ListItem Value="1000000000">Gh/s</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:checkbox id="box6" runat="server" Width="20px" font-names="calibri" Checked="True"/>
        <asp:TextBox ID="Cur_6" runat="server" Height="16px" Width="60px">ETH</asp:TextBox>
        <asp:textbox id="hr6_80" runat="server" height="16px" width="60px" >35</asp:textbox>
        <asp:textbox id="hr6_60" runat="server" height="16px" width="60px" >21.3</asp:textbox>
        <asp:DropDownList ID="HashUnit6" runat="server">
            <asp:ListItem Value="1">h/s</asp:ListItem>
            <asp:ListItem Value="1000">kh/s</asp:ListItem>
            <asp:ListItem Selected="True" Value="1000000">Mh/s</asp:ListItem>
            <asp:ListItem Value="1000000000">Gh/s</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:checkbox id="box7" runat="server" Width="20px" font-names="calibri" Checked="True"/>
        <asp:TextBox ID="Cur_7" runat="server" Height="16px" Width="60px">SPR</asp:TextBox>
        <asp:textbox id="hr7_80" runat="server" height="16px" width="60px" >11.4</asp:textbox>
        <asp:textbox id="hr7_60" runat="server" height="16px" width="60px" >0</asp:textbox>
        <asp:DropDownList ID="HashUnit7" runat="server">
            <asp:ListItem Value="1">h/s</asp:ListItem>
            <asp:ListItem Value="1000">kh/s</asp:ListItem>
            <asp:ListItem Selected="True" Value="1000000">Mh/s</asp:ListItem>
            <asp:ListItem Value="1000000000">Gh/s</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:checkbox id="box8" runat="server" Width="20px" cssclass="newstyle1" font-names="calibri" Checked="True"/>
        <asp:TextBox ID="Cur_8" runat="server" Height="16px" Width="60px">SIGT</asp:TextBox>
        <asp:textbox id="hr8_80" runat="server" height="16px" width="60px" >48</asp:textbox>
        <asp:textbox id="hr8_60" runat="server" height="16px" width="60px" >0</asp:textbox>
        <asp:DropDownList ID="HashUnit8" runat="server">
            <asp:ListItem Value="1">h/s</asp:ListItem>
            <asp:ListItem Value="1000">kh/s</asp:ListItem>
            <asp:ListItem Selected="True" Value="1000000">Mh/s</asp:ListItem>
            <asp:ListItem Value="1000000000">Gh/s</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Get Profit" OnClick="Button1_Click" Font-Bold="True" Font-Names="Calibri" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
            <SelectedRowStyle HorizontalAlign="Justify" />
        </asp:GridView>
        <br />
    </form>
</body>
</html>
