using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Redis
{
   public class PubConstant
    {
       public static string RedisIp
       {
           get
           {
               string _redisIp = ConfigurationManager.AppSettings["RedisIp"];
               return _redisIp;
           }
       }
       public static string RedisPort
       {
           get
           {
               string _redisPort = ConfigurationManager.AppSettings["RedisPort"];
               return _redisPort;
           }
       }
       public static string RedisPass
       {
           get
           {
               string _redisPass=ConfigurationManager.AppSettings["RedisPass"];
               return _redisPass;
           }
       }
    }
}
