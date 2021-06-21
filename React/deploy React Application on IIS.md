 - https://medium.com/@sumit.kharche/how-to-deploy-react-application-on-iis-server-a71b09152fa2
 - One page는 상관없는(것같은)데 `page navigation`이 있으면 빌드폴더를 복붙해도 `404Err`가 뜬다.
 
### Solve
1. 서버에 https://www.iis.net/downloads/microsoft/url-rewrite 설치 
2. **web.config** under public folder
 ```
<?xml version="1.0"?>
<configuration>
 <system.webServer>
 <rewrite>
 <rules>
 <rule name="React Routes" stopProcessing="true">
 <match url=".*" />
 <conditions logicalGrouping="MatchAll">
 <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
 <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
 <add input="{REQUEST_URI}" pattern="^/(api)" negate="true" />
 </conditions>
 <action type="Rewrite" url="/" />
 </rule>
 </rules>
 </rewrite>
 </system.webServer>
</configuration>
```
