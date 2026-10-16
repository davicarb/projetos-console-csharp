using System.Text.Json;

namespace json_learning
{
  public class Program
  {
    static void Main(string[] args)
    {
      List<WeatherPrediction> weather_pred_list = new List<WeatherPrediction>();
      System.Console.WriteLine("json weather client.");
      System.Console.WriteLine("1- ver previsões do clima atuais");
      System.Console.WriteLine("2- adicionar nova previsão");

      bool valid = int.TryParse(Console.ReadLine(), out int opcao);
      while (!valid || opcao < 1 || opcao > 2)
      {
        System.Console.WriteLine("incorreto. insira novamente: ");
        valid = int.TryParse(Console.ReadLine(), out opcao);
      }

      switch (opcao)
      {
        case 1:
          var deserializedList = WeatherPrediction.Deserializar(weather_pred_list);
          foreach (WeatherPrediction weatherPred in deserializedList)
          {
            System.Console.WriteLine(weatherPred.Dia);
            System.Console.WriteLine(weatherPred.Temperatura);
            System.Console.WriteLine(weatherPred.UmidadeRelativa);
            System.Console.WriteLine(weatherPred.SensacaoTermica);
            System.Console.WriteLine(weatherPred.Chuva);
            System.Console.WriteLine(weatherPred.Raios);
            System.Console.WriteLine("\n");
            System.Console.WriteLine("\n");
          }
          break;

        case 2:
          string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "weather_predictions.json");
          if (File.Exists(filePath))
          {
            string jsonExistente = File.ReadAllText(filePath);
            // Desserializa o JSON antigo de volta para a lista
            var listaAntiga = JsonSerializer.Deserialize<List<WeatherPrediction>>(jsonExistente);
            if (listaAntiga != null)
            {
              weather_pred_list = listaAntiga; // A sua lista agora tem o que já estava salvo!
            }
          }
          System.Console.WriteLine("insira o dia que deseja salvar a previsão: ");
          string dia = Console.ReadLine();

          System.Console.WriteLine("previsão da temperatura: ");
          string temperatura = Console.ReadLine();

          System.Console.WriteLine("previsão da umidade relativa do ar: ");
          string umidadeRelativa = Console.ReadLine();

          System.Console.WriteLine("previsão da sensação térmica: ");
          string sensacaoTermica = Console.ReadLine();

          System.Console.WriteLine("previsão da chuva ( em % ): ");
          string chuva = Console.ReadLine();

          System.Console.WriteLine("previsão de raios ( em % ): ");
          string raios = Console.ReadLine();

          var weatherDataObject = new WeatherPrediction(dia,
          temperatura,
          umidadeRelativa,
          sensacaoTermica,
          chuva,
          raios);

          weather_pred_list.Add(weatherDataObject);
          System.Console.WriteLine(weatherDataObject.Dia);
          System.Console.WriteLine(weatherDataObject.Temperatura);
          System.Console.WriteLine(weatherDataObject.UmidadeRelativa);
          System.Console.WriteLine(weatherDataObject.SensacaoTermica);
          System.Console.WriteLine(weatherDataObject.Chuva);
          System.Console.WriteLine(weatherDataObject.Raios);
          System.Threading.Thread.Sleep(1500);
          bool serializationResult = weatherDataObject.Serializar(weather_pred_list);
          if (serializationResult) System.Console.WriteLine("serializado com sucesso.");
          else System.Console.WriteLine("falha na serialização.");

          break;
        default:
          System.Console.WriteLine("falha.");
          break;
      }
    }
  }
}