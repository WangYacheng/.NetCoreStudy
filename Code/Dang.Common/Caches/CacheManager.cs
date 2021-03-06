using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyCaching.Core;
using JLSys.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dang.Common.Caches
{
    /// <summary>
    /// EasyCaching缓存服务
    /// </summary>
    public class CacheManager : ICache
    {
        /// <summary>
        /// 缓存提供器
        /// </summary>
        private readonly IEasyCachingProvider _provider;

        private readonly ILogger<CacheManager> _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 过期分钟
        /// </summary>
        const int ExpireMinute = 24 * 60;

        /// <summary>
        /// 初始化缓存
        /// </summary>
        /// <param name="provider">EasyCaching缓存提供器</param>
        public CacheManager(IEasyCachingProvider provider, ILogger<CacheManager> logger, IConfiguration configuration)
        {
            _provider = provider;
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// 是否存在指定键的缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public bool Exists(string key)
        {
            return _provider.Exists(key);
        }

        /// <summary>
        /// 是否存在指定键的缓存 Async
        /// </summary>
        /// <param name="key">缓存键</param>
        public async Task<bool> ExistsAsync(string key)
        {
            return await _provider.ExistsAsync(key);
        }

        /// <summary>
        /// 从缓存中获取数据，如果不存在，则执行获取数据操作并添加到缓存中
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="func">获取数据操作</param>
        /// <param name="expiration">过期时间间隔</param>
        public T Get<T>(string key, Func<T> func, TimeSpan? expiration = null)
        {
            var result = _provider.Get(key, func, GetExpiration(expiration));
            return result.Value;
        }

        /// <summary>
        /// 获取过期时间间隔
        /// </summary>
        private TimeSpan GetExpiration(TimeSpan? expiration)
        {
            int expireMinute = _configuration["Caching:CacheTime"].IsEmpty() ? ExpireMinute : _configuration["Caching:CacheTime"].ToInt();

            expiration = expiration ?? TimeSpan.FromMinutes(expireMinute);
            return expiration.SafeValue();
        }

        /// <summary>
        /// 当缓存数据不存在则添加，已存在不会添加，添加成功返回true
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="expiration">过期时间间隔</param>
        public bool TryAdd<T>(string key, T value, TimeSpan? expiration = null)
        {
            var expireTime = GetExpiration(expiration);
            var seconds = Convert.ToInt32(expireTime.TotalSeconds);
            return RedisHelper.Set(key, value, seconds, CSRedis.RedisExistence.Nx);
            //return _provider.TrySet(key, value, GetExpiration(expiration));
        }

        /// <summary>
        /// 当缓存数据不存在则添加，已存在不会添加，添加成功返回true Async
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="expiration">过期时间间隔</param>
        public async Task<bool> TryAddAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var expireTime = GetExpiration(expiration);
            var seconds = Convert.ToInt32(expireTime.TotalSeconds);
            return await RedisHelper.SetAsync(key, value, seconds, CSRedis.RedisExistence.Nx);
            //return await _provider.TrySetAsync(key, value, GetExpiration(expiration));
        }

        /// <summary>
        /// 添加数据到缓存
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="expiration">过期时间间隔</param>
        public void Set<T>(string key, T value, TimeSpan? expiration = null)
        {
            _provider.Set(key, value, GetExpiration(expiration));
        }

        /// <summary>
        /// 添加数据到缓存 Async
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="expiration">过期时间间隔</param>
        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            await _provider.SetAsync(key, value, GetExpiration(expiration));
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public void Remove(string key)
        {
            _provider.Remove(key);
            _logger.LogDebug($"Remove : {key}");
        }

        /// <summary>
        /// 移除缓存 Async
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public async Task RemoveAsync(string key)
        {
            await _provider.RemoveAsync(key);
            _logger.LogDebug($"RemoveAsync : {key}");
        }

        /// <summary>
        /// 移除缓存通过缓存键前缀
        /// </summary>
        /// <param name="prefix">缓存键前缀</param>
        public void RemoveByPrefix(string prefix)
        {
            _provider.RemoveByPrefix(prefix);
            _logger.LogDebug($"RemoveByPrefix : {prefix}");
        }

        /// <summary>
        /// 移除缓存通过缓存键前缀 Async
        /// </summary>
        /// <param name="prefix">缓存键前缀</param>
        public async Task RemoveByPrefixAsync(string prefix)
        {
            await _provider.RemoveByPrefixAsync(prefix);
            _logger.LogDebug($"RemoveByPrefixAsync : {prefix}");
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public void Clear()
        {
            _provider.Flush();
            _logger.LogDebug("Clear All Cache");
        }

        /// <summary>
        /// 清空缓存 Async
        /// </summary>
        public async Task ClearAsync()
        {
            await _provider.FlushAsync();
            _logger.LogDebug("Clear All Cache Async");
        }
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        public T Get<T>(string key)
        {
            var result = _provider.Get<T>(key);
            if (result.HasValue)
            {
                return result.Value;
            }
            return default(T);
        }
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        public async Task<T> GetAsync<T>(string key)
        {
            var result = await _provider.GetAsync<T>(key);
            if (result.HasValue)
            {
                return result.Value;
            }
            return default(T);
        }
    }
}
