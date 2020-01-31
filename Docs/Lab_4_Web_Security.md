# **CS296 Web-Development**

### Lab 4 - WebSecurity

Security has been added to the site!

The method, ConfigureServices, now includes a CookiePolicy that is set to always secure cookies.  

The method Configure(...) configures the app to add Headers to the pages that prevent sniffing of MIME responses with "X-Content-Type-Options", "nosniff" and "Cache-Control", "no-cache" 

###### Note: The method services.AddResponseCaching(); was added as part of the support for implementing Cache-Control.  



Jan 30, 2020