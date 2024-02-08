using Newtonsoft.Json;
using SVTextCutter.Format;

namespace SVTextCutter.Worker;

public static class JsonTextHandler
{
	private const string PATTERN = "*.json";

	public static IEnumerable<string> GetAllStrings(string projectPath)
	{
		var _files = Directory.GetFiles(projectPath, PATTERN, SearchOption.AllDirectories);
		foreach (var _file in _files)
		{
			yield return File.ReadAllText(_file);
		}
	}

	public static void SplitTextValue(string inputValue)
	{
		var _defaultText = JsonConvert.DeserializeObject<DefaultTextFormat>(inputValue);
		Console.WriteLine(JsonConvert.SerializeObject(_defaultText?.Content));
	}
}