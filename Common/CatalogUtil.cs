using ObjectDetectionProgram.ImageIdentification;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObjectDetectionProgram.Common
{
    public static class CatalogUtil
    {
        // regexes with different new line symbols
        private const string CatalogItemPattern = @"item {{{0}  name: ""(?<name>.*)""{0}  id: (?<id>\d+){0}  display_name: ""(?<displayName>.*)""{0}}}";
        private static readonly string CatalogItemPatternEnv = string.Format(CultureInfo.InvariantCulture, CatalogItemPattern, Environment.NewLine);
        private static readonly string CatalogItemPatternUnix = string.Format(CultureInfo.InvariantCulture, CatalogItemPattern, "\n");

        public static IEnumerable<CatalogItem> ReadCatalogItems(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            using (StreamReader reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(text))
                {
                    yield break;
                }

                Regex regex = new Regex(CatalogItemPatternEnv);
                var matches = regex.Matches(text);
                if (matches.Count == 0)
                {
                    regex = new Regex(CatalogItemPatternUnix);
                    matches = regex.Matches(text);
                }

                foreach (Match match in matches)
                {
                    var name = match.Groups[1].Value;
                    var id = int.Parse(match.Groups[2].Value);
                    var displayName = match.Groups[3].Value;

                    yield return new CatalogItem()
                    {
                        Id = id,
                        Name = name,
                    };
                }
            }
        }
    }
}
