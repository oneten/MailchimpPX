
# Acumatica Mailchimp Integration

## Installation

1) Clone this repository.
2) Install Acumatica directly into the Site directory of this repository.
   i.e. Into C:\...\MailchimpPX\Site\, not into C:\...\MailchimpPX\Site\AcumaticaERP\
3) Run BuildCustomization.bat to get a customization zip file to install.
4) Update the Web.Config in Acumatica to use it's version of Newtonsoft.Json:
   Under `<configuration>` -> `<runtime>` -> `<dependantAssembly>` for Newstonsoft.Json, updating
   `<bindingRedirect oldVersion="0.0.0.0-9.0.0.0" ...>` to "0.0.0.0-10.0.0.0"
5) Upload and publish Mailchimp.zip
6) Set the Mailchimp API Key on /Main?ScreenId=CR101000
