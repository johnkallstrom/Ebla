namespace Ebla.Infrastructure.Persistence.Helpers
{
    public static class FileManager
    {
        public static List<T> ParseJsonFileToEntityList<T>(string fileName)
        {
            var data = Enumerable.Empty<T>();

            string workingDir = Directory.GetCurrentDirectory().Replace("Ebla.Api", "Ebla.Infrastructure");
            string path = $@"{workingDir}\Persistence\SeedData\{fileName}";

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
