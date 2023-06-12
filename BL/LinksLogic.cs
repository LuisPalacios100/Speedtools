using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Speedtools.BL
{
    public class LinksLogic
    {
        public string raw = string.Empty;
        public string baseLink = string.Empty;
        public string filePath = string.Empty;
        public string dateFormat = string.Empty;
        public string dateString = string.Empty;
        public List<string> matrix = new List<string>();

        public void readLinksFromFile()
        {
            try
            {
                string csv = string.Empty;
                if (File.Exists(filePath))
                {
                    var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            csv = reader.ReadToEnd();
                        }
                    }
                }
                string[] rawMatrix = Regex.Split(csv, "\n(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                foreach (string line in rawMatrix)
                {
                    matrix.Add(line);
                }
                matrix.Remove(matrix[0]);
            }
            catch (Exception)
            {
                return;
            }
        }

        public List<string> linkNames()
        {
            List<string> result = new List<string>();
            foreach (string line in matrix)
            {
                string[] lineArray = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                if (lineArray.Length < 2)
                {
                    continue;
                }
                result.Add(lineArray[0]);

            }
            return result.Distinct().ToList();
        }

        public void engage(int index)
        {
            string[] lineArray = Regex.Split(matrix[index], ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            baseLink = lineArray[1];
            dateFormat = lineArray[2];

            try
            {
                dateString = DateTime.Now.ToString(dateFormat);
            }
            catch (Exception)
            {
                dateString = string.Empty;
            }

            TextManipulation txt = new TextManipulation();
            string delimiter = txt.detectDelimiter(raw);
            string[] list = raw.Split(new string[] { delimiter },StringSplitOptions.None).ToArray();

            foreach (string value in list)
            {
                if (value.Length == 0)
                {
                    continue;
                }
                else
                {
                    string url = baseLink.Replace("%s", value).Replace("%t", dateString);

                    try
                    {
                        Process.Start(url);
                    }
                    catch
                    {
                        // hack because of this: https://github.com/dotnet/corefx/issues/10361
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            url = url.Replace("&", "^&");
                            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                        }
                        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        {
                            Process.Start("xdg-open", url);
                        }
                        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                        {
                            Process.Start("open", url);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
        }

    }
}
