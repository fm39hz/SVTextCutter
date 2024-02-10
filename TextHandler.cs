using Newtonsoft.Json;
using SVTextCutter.Format;

namespace SVTextCutter.Worker;

public static class OsSplittingChar
{
	public const string Window = "\\";
	public const string Linux = "/";
}

public class TextHandler
{
	private const string PATTERN = "*.json";
	private const string OUTPUT_DIR = "CP";
	private static readonly TextHandler Instance = new();
	private readonly Dictionary<string, string> _fileContents;

	public TextHandler()
	{
		_fileContents = new();
	}

	public static void GetAllText(string projectPath)
	{
		var _files = Directory.GetFiles(projectPath, PATTERN, SearchOption.AllDirectories);
		foreach (var _file in _files)
		{
			var _value = File.ReadAllText(_file);
			Instance._fileContents.Add(_value, _file);
		}
	}

	public static string GetContentValue(string inputValue)
	{
		var _defaultText = JsonConvert.DeserializeObject<DefaultTextFormat>(inputValue);
		return JsonConvert.SerializeObject(_defaultText?.Content);
	}

	public static void CreateOutputDirectory()
	{
		var _splitChar = OperatingSystem.IsWindows()? OsSplittingChar.Window : OsSplittingChar.Linux;
		var _currentDirectory = Directory.GetCurrentDirectory() + _splitChar + OUTPUT_DIR;
		if (!Directory.Exists(_currentDirectory))
		{
			Directory.CreateDirectory(_currentDirectory);
		}
	}

	public static void ExportFile(string inputValue, string fileName)
	{
		CreateOutputDirectory();
	}
}