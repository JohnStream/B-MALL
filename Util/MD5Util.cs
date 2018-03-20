using System.Security.Cryptography;
using System.Text;
namespace B_MALL.Util
{
    public class MD5Util
    {
        public static string GetMD5(string result)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(result);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }
    }
}