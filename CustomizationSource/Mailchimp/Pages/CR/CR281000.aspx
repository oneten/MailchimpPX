<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="CR281000.aspx.cs" Inherits="Page_CR281000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="Mailchimp.MailchimpListMaint"
        PrimaryView="Lists"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Primary" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="Lists">
			    <Columns>
				<px:PXGridColumn DataField="ListID" Width="120" />
				<px:PXGridColumn DataField="ListCD" Width="220" />
				<px:PXGridColumn DataField="MemberCount" Width="70" />
				<px:PXGridColumn DataField="UnsubscribeCount" Width="70" />
				<px:PXGridColumn DataField="CleanedCount" Width="70" />
				<px:PXGridColumn DataField="CampaignCount" Width="70" />
				<px:PXGridColumn DataField="CampaignLastSent" Width="140" /></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
		<ActionBar >
		</ActionBar>
	</px:PXGrid>
</asp:Content>