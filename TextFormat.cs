namespace SVTextCutter.Format;

public sealed class Header
{
	public string? Target { get; set; }
	public int FormatVersion { get; set; }
	public bool Hidef { get; set; }
	public int Compressed { get; set; }
}

public sealed class Reader
{
	public string? Type { get; set; }
	public int Version { get; set; }
}

public sealed class DefaultTextFormat
{
	public Header? Header { get; set; }
	public List<Reader>? Readers { get; set; }
	public Dictionary<string, string> Content { get; } = new();
}