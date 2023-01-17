using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace ToyNJoy.Utiliy
{
    public class TokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public TokenHelper(IConfiguration configuration, JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            _configuration = configuration;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        /// <summary>
        /// 创建包含用户信息的 CalimList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="authUser"></param>
        /// <returns></returns>
        public List<Claim> CreateClaimList<T>(T authUser) 
        {
            var Class = typeof(T);
            List<Claim> claimList = new List<Claim>();
            foreach (var item in Class.GetProperties()) 
            {
                claimList.Add(new Claim(item.Name, Convert.ToString(item.GetValue(authUser))));
            }
            return claimList;
        }

        /// <summary>
        /// 创建加密JwtToken
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <returns></returns>
        public string CreateJwtToken<T>(T user)
        {
            var claimList = this.CreateClaimList(user);
            // 从 appsetting.json 中读取 SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:IssuerSigninKey"]));
            // 从 appsetting.json 中读取 Expires
            var expires = Convert.ToDouble(_configuration["JwtSettings:Expires"]);
            // 选择【加密算法】
            var algorithm = SecurityAlgorithms.HmacSha256;
            // 生成 Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                _configuration["JwtSettings:ValidIssuer"],
                _configuration["JwtSettings:ValidAudience"],
                claims: claimList,
                DateTime.Now,
                DateTime.Now.AddDays(expires),
                signingCredentials
            );
            string jwtToken = _jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }

        public T GetToken<T>(string Token)
        {
            Type type = typeof(T);
            object objA = Activator.CreateInstance(type);
            var b = _jwtSecurityTokenHandler.ReadJwtToken(Token);
            foreach (var item in b.Claims)
            {
                PropertyInfo propertyInfo = type.GetProperty(item.Type);
                if (propertyInfo != null && propertyInfo.CanRead)
                {
                    var propertyType = propertyInfo.PropertyType;

                    if (propertyType == typeof(string))
                    {
                        propertyInfo.SetValue(objA, item.Value, null);
                    }
                    else if (propertyType == typeof(DateTime))
                    {
                        propertyInfo.SetValue(objA, Convert.ToDateTime(item.Value), null);
                    }
                    else if (propertyType == typeof(int))
                    {
                        propertyInfo.SetValue(objA, Convert.ToInt32(item.Value), null);
                    }
                }
            }
            return (T)objA;
        }
    }
}
