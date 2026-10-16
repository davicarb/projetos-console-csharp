using System.Text.Json;

namespace json_learning
{
  [Serializable]
  public class WeatherPrediction
  {
    public string Dia { get; set; }
    public string Temperatura { get; set; }
    public string UmidadeRelativa { get; set; }
    public string SensacaoTermica { get; set; }
    public string Chuva { get; set; }
    public string Raios { get; set; }

    public WeatherPrediction(string dia,
    string temperatura,
    string umidadeRelativa,
     string sensacaoTermica,
    string chuva,
     string raios)
    {
      Dia = dia;
      Temperatura = temperatura;
      UmidadeRelativa = umidadeRelativa;
      SensacaoTermica = sensacaoTermica;
      Chuva = chuva;
      Raios = raios;
    }
    public static List<WeatherPrediction> Deserializar(List<WeatherPrediction> weatherPrediction_list)
    {
      string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "weather_predictions.json");
      try
        {
          string jsonString = File.ReadAllText(filePath);
          weatherPrediction_list = JsonSerializer.Deserialize<List<WeatherPrediction>>(jsonString);
          return weatherPrediction_list;
        }

        catch (Exception ex)
        {
          System.Console.WriteLine("erro na serialização.");
          return null;
        }
    }
    public bool Serializar(List<WeatherPrediction> weatherPredictions_list)
    {
      string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "weather_predictions.json");
        try
        {
          var toString = new JsonSerializerOptions { WriteIndented = true };
          string jsonString_1 = JsonSerializer.Serialize(weatherPredictions_list, toString);
          File.WriteAllText(filePath, jsonString_1);
          System.Console.WriteLine($"lista serializada! caminho do arquivo: {filePath}");
          return true;
        }

        catch (Exception ex)
        {
          System.Console.WriteLine("erro na serialização.");
          return false;
        }
    }
  }
}