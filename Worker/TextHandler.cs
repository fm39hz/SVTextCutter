using Newtonsoft.Json;
using SVTextCutter.Format;

namespace SVTextCutter.Worker;

public static class OsSplittingChar
{
	public const string? Window = "\\";
	public const string Linux = "/";
}

public class TextHandler
{
	private const string PATTERN = "*.json";
	private const string OUTPUT_DIR = "CP";
	private const string INPUT_DIR = "Project";
	private static readonly TextHandler Instance = new();
	private readonly Dictionary<string, string> _fileContents;
	public readonly string InputDir;
	public readonly string? SplitChar;

	public TextHandler()
	{
		SplitChar = OperatingSystem.IsWindows()? OsSplittingChar.Window : OsSplittingChar.Linux;
		InputDir = Directory.GetCurrentDirectory() + SplitChar + INPUT_DIR;
		_fileContents = new();
	}

	public static void GetAllText()
	{
		var _files = Directory.GetFiles(Instance.InputDir, PATTERN, SearchOption.AllDirectories);
		foreach (var _file in _files)
		{
			var _value = File.ReadAllText(_file);
			Instance._fileContents.Add(_file, GetContentValue(_value));
		}
	}

	private static string GetContentValue(string inputValue)
	{
		var _defaultText = JsonConvert.DeserializeObject<DefaultTextFormat>(inputValue);
		return JsonConvert.SerializeObject(_defaultText?.Content);
	}

	private static void CreateOutputDirectory()
	{
		var _currentDirectory = Directory.GetCurrentDirectory() + Instance.SplitChar + OUTPUT_DIR;
		if (!Directory.Exists(_currentDirectory))
		{
			Directory.CreateDirectory(_currentDirectory);
		}
	}

	public static void ExportFile()
	{
		CreateOutputDirectory();
		foreach (var _item in Instance._fileContents)
		{
			File.WriteAllText(_item.Key, _item.Value);
		}
	}
}