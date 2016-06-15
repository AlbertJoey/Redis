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
            var redisClient = new RedisClient("192.168.100.37", 6379);


            //string
            string userName = "chengjun";
            //塞入
            redisClient.Set<string>("UserName", userName);
            //判断是否存在此键
            var exist = redisClient.Exists("UserName");
            //获取
            var getUserName = redisClient.Get("UserName");
            //删除
            var delUserName = redisClient.Del("UserName");


            //Hash
            redisClient.SetEntryInHash("UserInfo", "UserName", userName);
            redisClient.SetEntryInHash("UserInfo", "UserPass", "123456");
            //获取
            List<string> keyList = redisClient.GetHashKeys("UserInfo");
            List<string> valuesList = redisClient.GetHashValues("UserInfo");
            //打印
            Console.WriteLine("Key为：{0},value为：{1}", keyList[0], valuesList[0]);

            //List--队列
            redisClient.EnqueueItemOnList("Queue", "hello");
            redisClient.EnqueueItemOnList("Queue", "world");
            int queueCount = (int)redisClient.GetListCount("Queue");
            for (int i = 0; i < queueCount; i++)
            {
                Console.Write(redisClient.DequeueItemFromList("Queue")+"|");
            }
            Console.WriteLine("\n");


            //栈
            redisClient.PushItemToList("stack", "good");
            redisClient.PushItemToList("stack", "girl");
            int pushCount = (int)redisClient.GetListCount("stack");
            for (int i = 0; i < pushCount; i++)
            {
                Console.Write(redisClient.PopItemFromList("stack") + "|");
            }
            Console.ReadKey();
        }
    }
}
