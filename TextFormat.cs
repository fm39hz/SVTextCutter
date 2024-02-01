namespace SVTextCutter.Format;
public abstract class Header
{
	public string? Target { get; set; }
	public int FormatVersion { get; set; }
	public bool Hidef { get; set; }
	public bool Compressed { get; set; }
}

public abstract class Reader
{
	public string? Type { get; set; }
	public int Version { get; set; }
}

public class DefaultTextFormat
{
	public Header? Header { get; set; }
	public List<Reader>? Readers { get; set; }
	public Dictionary<string, string>? Content { get; set; }
}
