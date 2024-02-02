using Newtonsoft.Json;
using SVTextCutter.Format;

namespace SVTextCutter.Worker;

public static class JsonTextHandler
{
	private static IEnumerable<string> FileHandling(string folderName)
	{
		var _files = Directory.GetFiles(Directory.GetCurrentDirectory() + folderName, "*.json", SearchOption.AllDirectories);
		foreach (var _file in _files)
		{
			Console.WriteLine($"Đang xử lý {_file}");
			var _a = File.ReadAllLines(_file).Aggregate("", (current, item) => current + item);
			yield return _a;
		}
	}
	public static void StringCutting(string inputValue)
	{
		foreach (var _item in FileHandling(inputValue))
		{
			var _defaultText = JsonConvert.DeserializeObject<DefaultTextFormat>(_item);
			Console.WriteLine(JsonConvert.SerializeObject(_defaultText?.Content));
		}
	}
}