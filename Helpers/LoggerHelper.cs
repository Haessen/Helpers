
using log4net;
using log4net.Config;
using System;
using System.IO;

namespace Helpers
{
    public class LoggerHelper
    {
        public static ILog Logger { get; set; }

        public LoggerHelper()
        {
            if (Logger == null)
            {
                try
                {
                    var repository = LogManager.CreateRepository("Repository");
                    //从log4net.config文件中读取配置信息
                    XmlConfigurator.Configure(repository, new FileInfo("Configurations/log4net.config"));
                    Logger = LogManager.GetLogger(repository.Name, "InfoLogger");
                    Debug("log4net.config配置文件读取成功");
                }
                catch (Exception)
                {
                    Error("log4net.config配置文件读取失败");
                    throw;
                }
                
            }
        }

        /// <summary>
        /// Info日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Info(string message, Exception e = null)
        {
            if (e is null)
                Logger.Info(message);
            else
                Logger.Info(message, e);
        }

        /// <summary>
        /// Debug日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Debug(string message, Exception e = null)
        {
            if (e is null)
                Logger.Debug(message);
            else
                Logger.Debug(message, e);
        }

        /// <summary>
        /// Warn日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Warn(string message, Exception e = null)
        {
            if (e is null)
                Logger.Warn(message);
            else
                Logger.Warn(message, e);
        }

        /// <summary>
        /// Error日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Error(string message, Exception e = null)
        {
            if (e is null)
                Logger.Error(message);
            else
                Logger.Error(message, e);
        }

        internal static void LogDebugSource(string v)
        {
            throw new NotImplementedException();
        }
    }
}
