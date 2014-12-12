using System;
using System.IO;

namespace AvsRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            var avsFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.avs");

            foreach (var avsFile in avsFiles)
            {
                var avs = File.ReadAllText(avsFile);
                if (avs.Contains("#renamed")) continue;

                if (!avs.Contains("dss2(D:\\Data"))
                {
                    var search = "dss2(\"";
                    var start = avs.IndexOf(search, 0, StringComparison.Ordinal);
                    if (start > 0)
                    {
                        start += search.Length;
                        var end = avs.IndexOf("\"", start, StringComparison.Ordinal);
                        var path = avs.Substring(start, end - start);
                        var filename = Path.GetFileName(path);
                        var newPath = Path.Combine("D:\\Data\\", filename);
                        avs = avs.Replace(path, newPath);
                    }
                }

                // Replace extension
                avs = avs.Replace(".mkv", string.Empty);
                avs = avs.Replace(".mp4", string.Empty);
                avs = avs.Replace(".wmv", string.Empty);
                avs = avs.Replace(".avi", string.Empty);

                // Replace plugin
                const string origin = "G:\\My Software\\Video Tool\\MeGUI_2028_x86";
                const string replace = "D:\\tool\\MeGUI_2356_x86";
                avs = avs.Replace(origin, replace);

                avs = avs.Insert(0, string.Format("#renamed{0}", Environment.NewLine));
                File.WriteAllText(avsFile, avs);
            }

            MessageBox.Show("Rename complete!");
        }
    }
}

