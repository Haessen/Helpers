using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Helpers
{
    public class JsonConfigHelper
    {
        /// <summary>
        /// 将配置对象保存至指定文件
        /// </summary>
        /// <param name="filePath"></param>
        public static async Task SaveConfigAsync<T>(T obj, string filePath)
        {
            string json;
            try
            {
                json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { ContractResolver = new StaticPropertyContractResolver() });
                await FileHelper.WriteToFileAsync(json, filePath);
            }
            catch (JsonException e)
            {
                LoggerHelper.Error($"对象序列化失败：{e.Message}", e);
            }
            catch (IOException e)
            {
                LoggerHelper.Error($"配置文件写入失败：{e.Message}", e);
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"（未知错误）配置文件写入失败：{e.Message}", e);
            }
        }

        /// <summary>
        /// 从指定文件读取配置对象
        /// </summary>
        /// <param name="filePath"></param>
        public static async Task LoadConfigAsync<T>(string filePath)
        {
            string json;
            try
            {
                json = await FileHelper.ReadFromFileAsync(filePath);
                var config = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings() { ContractResolver = new StaticPropertyContractResolver() });
            }
            catch (IOException e)
            {
                LoggerHelper.Error($"配置文件读取失败：{e.Message}", e);
            }
            catch (JsonException e)
            {
                LoggerHelper.Error($"对象反序列化失败：{e.Message}", e);
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"（未知错误）配置文件读取失败：{e.Message}", e);
            }
        }

        /// <summary>
        /// 序列化配置属性，静态变量也需要被序列化
        /// </summary>
        public class StaticPropertyContractResolver : DefaultContractResolver
        {
            protected override List<MemberInfo> GetSerializableMembers(Type objectType)
            {
                var baseMembers = base.GetSerializableMembers(objectType);

                PropertyInfo[] staticMembers =
                    objectType.GetProperties(BindingFlags.Static | BindingFlags.Public);

                baseMembers.AddRange(staticMembers);

                return baseMembers;
            }
        }
    }
}
