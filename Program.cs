using SVTextCutter.Worker;

namespace SVTextCutter;

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("Stardew Valley text cutter tool");
		TextHandler.GetAllText(Directory.GetCurrentDirectory() + "/Project");
	}
}