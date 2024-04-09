using System.Text.Json;

namespace ARMO_Test
{
    internal class Saver
    {
        private class DataToSave
        {
            public string StartDirectoryPath { get; set; }
            public string RegularExpression { get; set; }
        }

        public void Save(string path, string regex)
        {
            try
            {
                var dataToSave = new DataToSave()
                {
                    StartDirectoryPath = path,
                    RegularExpression = regex
                };
                string json = JsonSerializer.Serialize(dataToSave);
                File.WriteAllText("data.json", json);
            }
            catch (Exception)
            {
                MessageBox.Show("Сохранение не удалось");
            }

        }

        public void Load(out string path, out string regex)
        {
            try
            {
                string json = File.ReadAllText("data.json");
                DataToSave? dataToSave = JsonSerializer.Deserialize<DataToSave>(json);
                path = dataToSave.StartDirectoryPath;
                regex = dataToSave.RegularExpression;
            }
            catch (Exception)
            {
                path = "";
                regex = "";
            }
        }


    }
}
