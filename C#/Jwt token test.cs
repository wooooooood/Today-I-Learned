using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace wooooooood.Test
{
    [TestClass]
    public class JwtTokenTest
    {
        [TestMethod]
        public void GetJWTTokenData()
        {
            var sampleToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6Indvb29vb29vb2QiLCJpYXQiOjE1MTYyMzkwMjJ9.-eR2A-OYJAg25raVO6zRj3b_ckF-ad-_Dx7e7c9aprE";
            //{
            //  "sub": "1234567890",
            //  "name": "wooooooood",
            //  "iat": 1516239022
            //}
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(sampleToken) as JwtSecurityToken;

            Assert.IsTrue(jwtToken.Claims.Where(x => x.Type == "name").Single().Value == "wooooooood");
        }
    }
}
// ref: https://jwt.io/
