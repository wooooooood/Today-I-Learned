# The resource could not be loaded because the app transport security policy requires

1. Open `Info.plist`
2. Add key `NSAppTransportSecurity` as **Dictionary**
3. Add subkey `NSExceptionDomains` as **Dictionary**
4. Add subkey `domain.com` as **Dictionary**
5. Add subkey `NSExceptionAllowsInsecureHTTPLoads` as **Boolean, True**  
   Add subkey `NSIncludesSubdomains` as **Boolean, True**

https://stackoverflow.com/questions/32631184/the-resource-could-not-be-loaded-because-the-app-transport-security-policy-requi
