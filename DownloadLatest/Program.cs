using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DownloadLatest {
    sealed class Program {
        static async Task Main() {
            const string Repo = "shinydevelopment/SimulatorStatusMagic";
            using (var httpClient = new HttpClient()) {
                Console.WriteLine($"Downloading latest release for {Repo}");
                httpClient.DefaultRequestHeaders.UserAgent.Add(
                    new ProductInfoHeaderValue("SimulatorStatusMagicXamarinBindings", "2019.1"));
                var response = await httpClient.GetStringAsync($"https://api.github.com/repos/{Repo}/tags");
                var tags = JsonConvert.DeserializeObject<GitHubTag[]>(response);
                if (tags.Length == 0) {
                    Console.WriteLine($"Could not find any releases for {Repo}");
                    Environment.Exit(1);
                }

                Console.WriteLine($"Latest version is {tags[0].Name}");
                var latestReleaseZip = await httpClient.GetStreamAsync(tags[0].ZipballUrl);
                using (var archive = new ZipArchive(latestReleaseZip, ZipArchiveMode.Read)) {
                    var extractPath = Path.GetFullPath("../../../../");
                    archive.ExtractToDirectory(extractPath, true);
                    var extractedPath = Path.Combine(extractPath, archive.Entries.First().FullName);
                    var finalPath = Path.Combine(extractPath, "SimulatorStatusMagic");
                    if (Directory.Exists(finalPath)) {
                        Directory.Delete(finalPath);
                    }

                    Directory.Move(extractedPath, finalPath);
                    Console.WriteLine($"Uzipped to {finalPath}");
                }
            }
        }
    }

    [DebuggerDisplay("{Name}")]
    public readonly struct GitHubTag {
        [JsonConstructor]
        public GitHubTag(string name, Uri zipball_url) {
            Name = name;
            ZipballUrl = zipball_url;
        }

        public string Name { get; }

        public Uri ZipballUrl { get; }
    }
}