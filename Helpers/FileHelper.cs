using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Writes the text to the specified file
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="path">The path of the file to write to</param>
        /// <param name="append">If true, writes the text to the end of the file, otherwise overrides any existing file</param>
        /// <returns></returns>
        public static async Task WriteToFileAsync(string text, string path, bool append = false)
        {
            try
            {
                // Normalize path
                path = NormalizePath(path);

                // Resolve to absolute path
                path = Path.GetFullPath(path);

                // Lock the task
                await AsyncHelper.AwaitAsync(nameof(FileHelper) + path, async () =>
                {
                    // Run the synchronous file access as a new task
                    await TaskHelper.Run(() =>
                    {
                        if (!File.Exists(path))
                        {
                            File.WriteAllText(path, "");
                        }
                        // Write the log message to file
                        using var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create));
                        fileStream.Write(text);
                    });
                });
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"文件写入失败：{e.Message}", e);
                throw new IOException();
            }
        }

        public static async Task<string> ReadFromFileAsync(string path)
        {
            string text = string.Empty;
            try
            {
                // Normalize path
                path = NormalizePath(path);

                // Resolve to absolute path
                path = Path.GetFullPath(path);

                // Lock the task
                await AsyncHelper.AwaitAsync(nameof(FileHelper) + path, async () =>
                {
                    // Run the synchronous file access as a new task
                    await TaskHelper.Run(() =>
                    {
                        // Write the log message to file
                        using var reader = new StreamReader(path);
                        text = reader.ReadToEnd();
                    });
                });
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"文件读取失败：{e.Message}", e);
                throw new IOException();
            }

            return text;
        }

        /// <summary>
        /// Normalizing a path based on the current operating system
        /// </summary>
        /// <param name="path">The path to normalize</param>
        /// <returns></returns>
        public static string NormalizePath(string path)
        {
            // If on Windows...
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                // Replace any / with \
                return path?.Replace('/', '\\').Trim();
            // If on Linux/Mac
            else
                // Replace any \ with /
                return path?.Replace('\\', '/').Trim();
        }

    }
}
