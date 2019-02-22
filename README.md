
# Acumatica Mailchimp Integration

## Summary
See your Mailchimp data right alongside your Acumatica data! No more wondering about if that contact is subscribed to Mailchimp or if they opened the last campaign you sent them. This Mailchimp integration allows you to pull Mailchimp list membership and status (subscribed, unsubscribed or cleaned) and the Mailchimp activity stream for your list members right into the corresponding Acumatica contacts. Mailchimp-driven Activities are shown right alongside Acumatica-driven activities, so you can see a comprehensive view of your contact and all interactions with them in one spot.

## Features

1) Pull Mailchimp Lists into Acumatica
2) Automatically designate Acumatica contacts as being on Mailchimp lists
3) Update contact list status (subscribed, unsubscribed, cleaned)
4) Pull latest Mailchimp Activity into Acumatica Contact Activities

## Installation & Setup

### Get customization project
1) Clone this repository.
2) Install Acumatica directly into the Site directory of this repository.
   i.e. Into C:\...\MailchimpPX\Site\, not into C:\...\MailchimpPX\Site\AcumaticaERP\
3) Run BuildCustomization.bat to get a customization zip file to install.
4) Update the Web.Config in Acumatica to use it's version of Newtonsoft.Json:
   Under `<configuration>` -> `<runtime>` -> `<dependantAssembly>` for Newstonsoft.Json, updating
   `<bindingRedirect oldVersion="0.0.0.0-9.0.0.0" ...>` to "0.0.0.0-10.0.0.0"
5) Upload and publish Mailchimp.zip

### Connect to Mailchimp instance
1) Sign in to your Mailchimp Account and grab your Mailchimp API Key
    - Select "Account" from the dropdown that appears when you hover over your name in the top right corner
    - Select "Extras" and then "API Keys" from the navigation
2) Set the Mailchimp API Key
     - In Acumatica, navigate to the Customer Management Preferences screen (ScreenId=CR101000)
     - On the bottom right of the General Settings tab, you'll find a Mailchimp Settings section
     - Enter your API key into the "Mailchimp API Key" field and save
  
### Configure workspaces and schedules
1) Add the following screens to a workspace (we recommend the Marketing workspace or whatever workspace you use for Contacts)
   - Mailchimp Lists (ScreenId=CR281000)
   - Update Mailchimp Data (ScreenId=CR581000)
 2) Schedule the following processes (this step is optional - you could choose to run these manually if you prefer). For most uses, updated nightly would be sufficient but the frequency is up to the discretion of the user. Use the Update Mailchimp Data screen to schedule the following:
      - Get lists
      - Update who's subscribed
      - Update subscription status
      - Pull in Mailchimp Activities
   
## Further Explanation

**A Note About Duplicates**: In Acumatica, a contact can only be associated with a single Mailchimp list. In Mailchimp, contacts only exist in the context of a list. In other words, if the same email address is subscribed to multiple lists, Mailchimp treats those contacts as two separate subscribers. Mailchimp [recommends using a single master list](https://mailchimp.com/help/requirements-and-best-practices-for-lists/) and using groups and segments to organize that list rather than maintaining multiple lists. However, if for some reason, you have multiple lists in Mailchimp that are synced to Acumatica, be aware that if you have duplicate email addresses in those lists, Acumatica will only be able to connect that contact to one of those lists.

1) Pull Mailchimp Lists into Acumatica

2) Automatically designate Acumatica contacts as being on Mailchimp lists
3) Update contact list status (subscribed, unsubscribed, cleaned)
4) Pull latest Mailchimp Activity into Acumatica Contact Activities

![Contact Activities Tab displays Mailchimp-driven activities along with Acumatica-driven Activities](/Screenshots/Contact%20Activity%20Tab.PNG?raw=true "Contact Activities Tab")

![Contact Details Tab includes a Mailchimp section which shows the Mailchimp list the contact is subscribed to as well as the subscription status](/Screenshots/Contact%20Details%20Tab.PNG?raw=true "Contact Details Tab")

![The Integration Adds a new Activity Type "MC" for Mailchimp Activities](/Screenshots/Mailchimp%20Activity%20Type.PNG?raw=true "Activity Types")


