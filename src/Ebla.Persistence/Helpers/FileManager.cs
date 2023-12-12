namespace Ebla.Persistence.Helpers
{
    public static class FileManager
    {
        public static List<T> ParseJsonFileToList<T>(string fileName) where T : class
        {
            var data = Enumerable.Empty<T>();

            string workingDir = Directory.GetCurrentDirectory().Replace("Ebla.Api", "Ebla.Persistence");
            string path = $@"{workingDir}\SeedData\{fileName}";

            if (Path.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    var json = sr.ReadToEnd();
                    data = JsonConvert.DeserializeObject<List<T>>(json);
                }
            }

            return data.ToList();
        }
    }
}
