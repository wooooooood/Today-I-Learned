### System.Text.Json이 날 힘들게 한 경우들
`NewtonSoft.Json`으로 변경하면 해결됨^^
1. Xamarin iOS에서 사용 => https://github.com/wooooooood/Today-I-Learned/blob/master/Xamarin/%5BiOS%5D%20TroubleShoot/ExecutionEngineException.md
2. API Post시 `TimeSpan` 타입을 전송할 때 => https://stackoverflow.com/a/58284103
3. js에서 API Post시 Body를 object가 아니라 string 등의 타입으로 전송할 때 => https://stackoverflow.com/a/57652537
`The JSON value could not be converted to System.String`
