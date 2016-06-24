using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {

            var a=  RedisHelper.Delete("UserName");
            var b= RedisHelper.Delete("UserInfo");
            var c=RedisHelper.Delete("Bc");
            var d=    RedisHelper.Delete("Computer");

            var isdelete =  RedisHelper.Delete("UserName");
            var isexits = RedisHelper.GetKeyIsExists("UserName");

            RedisHelper.SetStringToRedis("UserName", "asdfasdfasf");

            var username = RedisHelper.GetStringFromRedis("UserName");


            RedisHelper.SetHashValuesToRedis("UserInfo", "UserName", "chengjun");
            RedisHelper.SetHashValuesToRedis("UserInfo", "UserPass", "xxooxxoo");
            RedisHelper.SetHashValuesToRedis("UserInfo", "UserName", "wangxiangfu");
            RedisHelper.SetHashValuesToRedis("UserInfo", "UserPass", "xxooxxoo");

            List<string> keyList = RedisHelper.GetHashKeyList("UserInfo");
            List<string> valueList = RedisHelper.GetHashValueList("UserInfo");


            for (int i = 0; i < 10; i++)
            {
                RedisHelper.SetEnqueueItemOnListToRedis("Bc", "asp.net" + (i + 100));
            }
            List<string> books = RedisHelper.GetListFromRedis("Bc");

            List<string> books3 =RedisHelper.GetListFromRedis("Bc");

            for (int i = 0; i < 10; i++)
            {
                RedisHelper.SetStackItemOnListToRedis("Computer", "lenovo" + i);
            }
            List<string> computers = RedisHelper.GetListFromRedis("Computer");

        }
    }
    public class User
    {
        public string name { get; set; }
        public string pass { get; set; }
    }
}
