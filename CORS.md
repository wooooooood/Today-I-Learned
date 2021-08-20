### CORS: Cross Origin Resource Sharing  
도메인 또는 포트가 다른 서버의 자원을 요청하는 것  
![https://flaviocopes.com/cors/fetch-failed-cors.png](https://flaviocopes.com/cors/fetch-failed-cors.png)


What “**preflight**” means:  
before the browser tries the `POST` in the code in the question, it’ll first send an `OPTIONS` request to the server — to determine if the server is opting-in to receiving a cross-origin `POST` that has `Authorization` and `Content-Type: application/json` headers.

이 오류를 해결하기 위해서는 server side에서 자원을 request하는 도메인에 대해 CORS허용을 해야 한다.
- [ASP.NET5 case](https://github.com/wooooooood/Today-I-Learned/blob/master/ASP.NET/enable-cors.md)

### Ref
- https://developer.mozilla.org/docs/Web/HTTP/Access_control_CORS#Preflighted_requests
