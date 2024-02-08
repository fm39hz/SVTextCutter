using SVTextCutter.Worker;

namespace SVTextCutter;

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("Stardew Valley text cutter tool");
		foreach (var _item in TextHandler.GetAllText(Directory.GetCurrentDirectory() + "/Project"))
		{
			var _content = TextHandler.GetContentValue(_item);
			Console.WriteLine(_content);
		}
	}
}