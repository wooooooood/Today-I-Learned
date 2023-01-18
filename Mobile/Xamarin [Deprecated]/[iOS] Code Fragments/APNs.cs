using Newtonsoft.Json;

namespace APNS_API
{
    public class APNs : IDisposable
    {
        private readonly string p8privateKey = "GetFromApple";
        private readonly string p8privateKeyId = "GetFromApple";
        private readonly string teamId = "GetFromApple";
        private readonly string deviceToken = "GetFromActualDevice";
        private readonly string priority = "10";
        private readonly string expiration = "0";

        private readonly HttpClient http = new HttpClient(new WinHttpHandler());  // HTTP/2 protocol is NOT supported on any version of .NET Framework binaries
        private readonly Uri serverUri = new Uri("https://api.development.push.apple.com");  //use https://api.push.apple.com in production
        private readonly string appBundleIdentifier = "com.companyName.appName";

        public async Task<HttpResponseMessage> SendAsync(Dictionary<string, string> data)
        {
            try
            {
                var path = $"/3/device/{deviceToken}";
                var content = JsonConvert.SerializeObject(data);
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(serverUri, path))
                {
                    Version = new System.Version(2, 0),
                    Content = new StringContent(content)
                };
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", CreateJwtToken());
                request.Headers.TryAddWithoutValidation(":method", "POST");
                request.Headers.TryAddWithoutValidation(":path", path);
                request.Headers.Add("apns-topic", appBundleIdentifier);
                request.Headers.Add("apns-priority", priority);
                request.Headers.Add("apns-expiration", expiration);

                return await http.SendAsync(request);
            }
            catch (Exception ex)
            {
                throw ex;  //or do sth
            }
        }

        //Token published time matters in production
        private string CreateJwtToken()
        {
            var header = JsonConvert.SerializeObject(new { alg = "ES256", kid = p8privateKeyId });
            var payload = JsonConvert.SerializeObject(new { iss = teamId, iat = ToEpoch(DateTime.UtcNow) });

            var key = CngKey.Import(Convert.FromBase64String(p8privateKey), CngKeyBlobFormat.Pkcs8PrivateBlob);
            using (var dsa = new ECDsaCng(key))
            {
                dsa.HashAlgorithm = CngAlgorithm.Sha256;
                var headerBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(header));
                var payloadBasae64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
                var unsignedJwtData = $"{headerBase64}.{payloadBasae64}";
                var signature = dsa.SignData(Encoding.UTF8.GetBytes(unsignedJwtData));
                return $"{unsignedJwtData}.{Convert.ToBase64String(signature)}";
            }
        }

        private static int ToEpoch(DateTime time)
        {
            var span = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return Convert.ToInt32(span.TotalSeconds);
        }
    }
}
