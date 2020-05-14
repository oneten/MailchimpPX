<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="CR581000.aspx.cs" Inherits="Page_CR581000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="Mailchimp.UpdateMailchimp"
        PrimaryView="Contacts"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="ProcessFilter" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXDropDown CommitChanges="True" runat="server" ID="CstPXDropDown1" DataField="Action" ></px:PXDropDown></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="Contacts">
			    <Columns>
				<px:PXGridColumn AllowCheckAll="True" AllowShowHide="True" TextAlign="Center" Type="CheckBox" DataField="Selected" Width="40px" ></px:PXGridColumn>
				<px:PXGridColumn DataField="ContactID" Width="70" ></px:PXGridColumn>
				<px:PXGridColumn DataField="DisplayName" Width="280" ></px:PXGridColumn>
				<px:PXGridColumn Type="CheckBox" DataField="IsActive" Width="60" ></px:PXGridColumn>
				<px:PXGridColumn DataField="BAccountID" Width="140" ></px:PXGridColumn>
				<px:PXGridColumn DataField="EMail" Width="280" ></px:PXGridColumn>
				<px:PXGridColumn DataField="UsrMailchimpListStatus" Width="140" ></px:PXGridColumn>
				<px:PXGridColumn DataField="UsrMailchimpListID" Width="120" ></px:PXGridColumn></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
		<ActionBar >
		</ActionBar>
	</px:PXGrid>
</asp:Content>
