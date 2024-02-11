using SVTextCutter.Format;

namespace SVTextCutter.Worker;

public class DirectoryFactory
{
	public static StructureFormat GetStructureFormat(string inputDir, string outputDir)
	{
		return new StructureFormat(inputDir, outputDir);
	}

	public static StructureFormat GetStructureFormat()
	{
		return new StructureFormat("Project", "CP");
	}
}