using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers
{
    public class TaskHelper
    {
        public static async Task Run(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Task.Run(function);
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"任务运行失败：{e.Message}", e);

                // Throw it as normal
                throw;
            }
        }

        public static async void RunAndForget(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Run(function, origin, filePath, lineNumber);
            }
            catch { }
        }

        public static async Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Try and run the task
                return await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"任务运行失败：{ex.Message}", ex);

                // Throw it as normal
                throw;
            }
        }

        public static async Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Try and run the task
                return await Task.Run(function);
            }
            catch (Exception ex)
            {
                // Log error
                LoggerHelper.Error($"任务运行失败：{ex.Message}", ex);

                // Throw it as normal
                throw;
            }
        }

        public static async Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Try and run the task
                return await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                // Log error
                LoggerHelper.Error($"任务运行失败：{ex.Message}", ex);

                // Throw it as normal
                throw;
            }
        }

        public static async Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Try and run the task
                return await Task.Run(function);
            }
            catch (Exception ex)
            {
                // Log error
                LoggerHelper.Error($"任务运行失败：{ex.Message}", ex);

                // Throw it as normal
                throw;
            }
        }

        public static async Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Try and run the task
                await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                // Log error
                LoggerHelper.Error($"任务运行失败：{ex.Message}", ex);

                // Throw it as normal
                throw;
            }
        }

        public static async void RunAndForget(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Run(function, origin, filePath, lineNumber);
            }
            catch { }
        }

        public static async Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Try and run the task
                await Task.Run(action, cancellationToken);
            }
            catch (Exception ex)
            {
                // Log error
                LoggerHelper.Error($"任务运行失败：{ex.Message}", ex);

                // Throw it as normal
                throw;
            }
        }
        
        public static async void RunAndForget(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Run(action, origin, filePath, lineNumber);
            }
            catch { }
        }

        public static async Task Run(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Try and run the task
                await Task.Run(action);
            }
            catch (Exception ex)
            {
                // Log error
                LoggerHelper.Error($"任务运行失败：{ex.Message}", ex);

                // Throw it as normal
                throw;
            }
        }

        public static async void RunAndForget(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Run(action, origin, filePath, lineNumber);
            }
            catch { }
        }
        
    }
}
