using SVTextCutter.Worker;

namespace SVTextCutter;

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("Stardew Valley text cutter tool");
		foreach (var _item in JsonTextHandler.GetAllStrings(Directory.GetCurrentDirectory() + "/Project"))
		{
			JsonTextHandler.SplitTextValue(_item);
		}
	}
}