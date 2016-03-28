using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ServiceStack.Redis;

namespace CMS.Common
{
    /*
     * 将ASP.Net默认缓存更新为REDIS存储方式进行
     * */
    public class CacheHelperRedis
    {

        public static RedisConfigInfo redisConfigInfo = RedisConfigInfo.GetConfig();
        public static PooledRedisClientManager redisManager = null;
        public static object obj = new object();
        public static PooledRedisClientManager GetRedisManager()
        {
            lock (obj)
            {
                if (redisManager == null)
                {
                    string[] writeServerList = SplitString(redisConfigInfo.WriteServerList, ",");
                    string[] readServerList = SplitString(redisConfigInfo.ReadServerList, ",");

                    redisManager = new PooledRedisClientManager(readServerList, writeServerList,
                                     new RedisClientManagerConfig
                                     {
                                         MaxWritePoolSize = redisConfigInfo.MaxWritePoolSize,
                                         MaxReadPoolSize = redisConfigInfo.MaxReadPoolSize,
                                         AutoStart = redisConfigInfo.AutoStart,
                                     });
                }
            }
            return redisManager;
        }

        /// <summary>
        /// 创建缓存的字符串对象
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="content">值</param>
        /// <param name="time">有效期</param>
        public static void Insert(string key, string content, DateTime? time = null)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    redis.SetValue(key, content);
                    if (time != null) redis.ExpireEntryAt(key, (DateTime)time);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 创建缓存项的自定义对象
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="time">object对象有效期</param>
        public static void Insert(string key, object obj, DateTime? time = null)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    string content = JsonHelper.ObjectToJSON(obj);
                    redis.SetValue(key, content);
                    if (time != null) redis.ExpireEntryAt(key, (DateTime)time);
                }
            }
            catch
            {
            }
        }

        public static long InsertOrIncrease(string key, int? seconds = null)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    long ret = redis.IncrementValue(key);
                    if (ret == 1 && seconds != null) redis.ExpireEntryAt(key, DateTime.Now.AddSeconds((int)seconds));
                    return ret;
                }
            }
            catch
            {
            }
            return 0;
        }

        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="tableid">表名</param>
        /// <param name="key">主键标识</param>
        /// <param name="obj">object对象</param>
        public static void Insert(string tableid, string key, object obj)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    string content = JsonHelper.ObjectToJSON(obj);
                    redis.SetEntryInHash(tableid, key, content);
                }
            }
            catch
            {
            }

        }

        /// <summary>
        /// 移除缓存项的文件
        /// </summary>
        /// <param name="key">缓存Key</param>
        public static void Remove(string key)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    redis.RemoveEntry(key);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 移除缓存表数据项
        /// </summary>
        /// <param name="tableid"></param>
        /// <param name="key"></param>
        public static void Remove(string tableid, string key)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    redis.RemoveEntryFromHash(tableid, key);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>string</returns>
        public static string Get(string key)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    return redis.GetValue(key);
                }
            }
            catch
            {
            }
            return "";
        }

        public static T Get<T>(string tableid, string key)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    string content = redis.GetValueFromHash(tableid, key);
                    return JsonHelper.JSONToObject<T>(content);

                }
            }
            catch
            {
            }

            return default(T);
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">T对象</typeparam>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            try
            {
                using (var redis = GetRedisManager().GetClient())
                {
                    string content = redis.GetValue(key);
                    return JsonHelper.JSONToObject<T>(content);
                }
            }
            catch
            {
            }
            return default(T);
        }

        //字符串处理
        private static string[] SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }

    }
}
