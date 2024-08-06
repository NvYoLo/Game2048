using Newtonsoft.Json;

namespace _2048WinFormsApp

{
    public class SaveResultClass
    {
        public static string Path = "resultGame.json";
        public static void Save(List<ClassName> User)
        {
            var jsonData = JsonConvert.SerializeObject(User, Formatting.Indented);
            FileProvider.Replace(Path, jsonData);
        }
        public static List<ClassName> GetResultGame()
        {
            if (!FileProvider.Exists(Path))
            {
                return new List<ClassName>();
            }
            var value = FileProvider.GetValue(Path);
            var GameResult = JsonConvert.DeserializeObject<List<ClassName>>(value);
            return GameResult;
        }
        public static void SaveFileResult(ClassName User)
        {
            var userResult = GetResultGame();
            userResult.Add(User);
            Save(userResult);
        }
    }
}
