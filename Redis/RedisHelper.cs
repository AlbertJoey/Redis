using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    public class RedisHelper
    {
        private static  readonly object SyscObject = new object();
        private static RedisClient _redisclient;
        public static RedisClient GetRedisClient
        {
            get
            {
                if (_redisclient == null)
                {
                    lock (SyscObject)
                    {
                        _redisclient = new RedisClient(PubConstant.RedisIp, Convert.ToInt32(PubConstant.RedisPort));
                    }
                }
                return _redisclient;
            }
        }

        //Set string
        public static void SetStringToRedis(string key, string value)
        {
            GetRedisClient.Set<string>(key, value);
        }
        //Get string
        public static string GetStringFromRedis(string key)
        {
            return System.Text.Encoding.Default.GetString(GetRedisClient.Get(key));
        }
        //Key is Exists
        public static bool GetKeyIsExists(string key)
        {
            if ((int)GetRedisClient.Exists(key) == (int)isExists.Exists)
                return true;
            else
                return false;
        }
        // delete value 
        public static bool Delete(string key)
        {
            if ((int)GetRedisClient.Del(key) == (int)isDelete.Delete)
                return true;
            else
                return false;
        }
        //set Hash table
        public static void SetHashValuesToRedis(string key, string hashKey, string hashValue)
        {
            GetRedisClient.SetEntryInHash(key, hashKey, hashValue);
        }
        //get hash hashKeys 
        public static List<string> GetHashKeyList(string key)
        {
            return GetRedisClient.GetHashKeys(key);
        }
        //get hash hashValues
        public static List<string> GetHashValueList(string key)
        {
            return GetRedisClient.GetHashValues(key);
        }
        //set value on list (Enqueue)
        public static void SetEnqueueItemOnListToRedis(string key, string value)
        {
            GetRedisClient.EnqueueItemOnList(key, value);
        }
        //set value on list (Stack)
        public static void SetStackItemOnListToRedis(string key, string value)
        {
            GetRedisClient.PushItemToList(key, value);
        }
        //get value on list
        public static List<string> GetListFromRedis(string key)
        {
            return GetRedisClient.GetAllItemsFromList(key);
        }
    }
    public enum isExists
    {
        Exists = 1,
        NoExists = 0
    }
    public enum isDelete
    {
        Delete = 1,
        NoDelete = 0
    }
}
