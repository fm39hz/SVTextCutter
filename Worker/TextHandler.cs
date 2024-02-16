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
	private const string BASE_LANG = "es-ES";
	private const string TARGET_LANG = "vi-VI";
	private const string PATTERN = $"*.{BASE_LANG}.json";
	private const string OUTPUT_DIR = "CP";
	private const string INPUT_DIR = "Project";
	private const string STRING_READER = "Microsoft.Xna.Framework.Content.StringReader";
	private static readonly TextHandler Instance = new();
	private readonly Dictionary<string, string?> _fileContents;
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

	private static string? GetContentValue(string inputValue)
	{
		var _defaultText = JsonConvert.DeserializeObject<TextFormat>(inputValue);
		return _defaultText!.Readers!.Any(reader => reader.Type == STRING_READER)
			? JsonConvert.SerializeObject(_defaultText.Content)
			: null;
	}

	private static void CreateOutputDirectory()
	{
		foreach (var _subDirectories in Instance._fileContents.Select(path => path.Key.Split(Instance.SplitChar)))
		{
			var _isSubDirectory = false;
			var _index = 0;
			var _currentPath = Directory.GetCurrentDirectory() + Instance.SplitChar + OUTPUT_DIR + Instance.SplitChar;
			foreach (var _directory in _subDirectories)
			{
				_index++;
				if (_isSubDirectory && _index < _subDirectories.Length)
				{
					_currentPath += _directory + Instance.SplitChar;
					if (!Directory.Exists(_currentPath))
					{
						Directory.CreateDirectory(_currentPath);
					}
				}
				else if (_directory == OUTPUT_DIR)
				{
					_isSubDirectory = true;
				}
			}
		}
	}

	public static void ExportFile()
	{
		CreateOutputDirectory();
		foreach (var _item in Instance._fileContents)
		{
			File.WriteAllText(_item.Key.Replace(BASE_LANG, TARGET_LANG).Replace(INPUT_DIR, OUTPUT_DIR), _item.Value);
		}
	}
}