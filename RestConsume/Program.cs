using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using RestConsume;

// JSON TO CSHARP : https://json2csharp.com/
//Toujours deserialize sur l'objet "Root"

// Instancier le HTTPCLIENT

HttpClient http = new HttpClient();


//METHOD POST / PUT / DELETE

var person = new { Id = 1, Name = "LePluBo" };

string json = JsonSerializer.Serialize(person);

StringContent data = new StringContent(json, Encoding.UTF8, "Application/json");

HttpResponseMessage resultPost = await  http.PostAsync("https://localhost:7005/WeatherForecast", data);

string content = await resultPost.Content.ReadAsStringAsync();

PostLocalhostClass.RootPlus monRoot = JsonSerializer.Deserialize<PostLocalhostClass.RootPlus>(content);

Console.WriteLine(monRoot.name);
    
// Method GET

string result = await http.GetStringAsync("https://api.randomuser.me/");

Root root = JsonSerializer.Deserialize<Root>(result);

Console.WriteLine(root.results[0].gender);






var test = new
{
    name = "test",
    age = 15,
};


//Result results = JsonSerializer.Deserialize<Result>(result);

//Console.WriteLine(results.id);