namespace SVTextCutter.Format;

public sealed class TextFormat
{
	public Header? Header { get; set; }
	public List<Reader>? Readers { get; set; }
	public Dictionary<string, string> Content { get; } = new();
}