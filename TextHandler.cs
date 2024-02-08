using Newtonsoft.Json;
using SVTextCutter.Format;

namespace SVTextCutter.Worker;

public static class TextHandler
{
	private const string PATTERN = "*.json";

	public static IEnumerable<string> GetAllText(string projectPath)
	{
		var _files = Directory.GetFiles(projectPath, PATTERN, SearchOption.AllDirectories);
		foreach (var _file in _files)
		{
			yield return File.ReadAllText(_file);
		}
	}

	public static string GetContentValue(string inputValue)
	{
		var _defaultText = JsonConvert.DeserializeObject<DefaultTextFormat>(inputValue);
		return JsonConvert.SerializeObject(_defaultText?.Content);
	}
}