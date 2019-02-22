
# Acumatica Mailchimp Integration

## Summary
See your Mailchimp data right alongside your Acumatica data! No more wondering about if that contact is subscribed to Mailchimp or if they opened the last campaign you sent them. This Mailchimp integration allows you to pull Mailchimp list membership and status (subscribed, unsubscribed or cleaned) and the Mailchimp activity stream for your list members right into the corresponding Acumatica contacts. Mailchimp-driven Activities are shown right alongside Acumatica-driven activities, so you can see a comprehensive view of your contact and all interactions with them in one spot.

## Features

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

## Further Explanation
