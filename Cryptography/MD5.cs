using System.Security.Cryptography;
using System.Text;

namespace Codu.Cryptography
{
    public class MD5
    {
        /// <summary>
        /// 创建MD5hash值
        /// </summary>
        /// <param name="source">字符串源</param>
        /// <returns></returns>
        public static string CreateMD5Hash(string source)
        {
            var md5= System.Security.Cryptography.MD5.Create();
            var datas= md5.ComputeHash(Encoding.UTF8.GetBytes(source));
            return Convert.ToHexString(datas);
        }
        public static string CreateMD5Hash(string[] sources)
        {
            List<char> chars = new List<char>(sources.Sum(x=>x.Length));
            var length = sources.Max(x => x.Length);
            for (int i = 0; i < length; i++)
            {
                foreach (var item in sources)
                {
                    if (item.Length > i)
                        chars.Add(item[i]);
                }
            }
            var newString= new string(chars.ToArray());
            //return new string(chars.ToArray());
            return CreateMD5Hash(newString);
        }
    }
}
