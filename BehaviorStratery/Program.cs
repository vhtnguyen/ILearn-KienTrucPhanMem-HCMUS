public interface IExporter
{
    void ExportFile(string fileName);
}
public class ExportJPG : IExporter
{
    public void ExportFile(string fileName)
    {
        Console.WriteLine("Export file: '" + fileName
             + ".JPG' successfully");
    }
}
public class ExportContext
{
    private IExporter Exporter;

    public ExportContext(IExporter exporter)
    {
        this.Exporter = exporter;
    }
    public void SetStrategy(IExporter exporter) // The key point here
    {
        this.Exporter = exporter;
    }
    public void CreateArchive(string fileName)
    {
        Exporter.ExportFile(fileName);
    }
}

public class ExportPDF : IExporter
{
    public void ExportFile(string fileName)
    {
        Console.WriteLine("Export file: '" + fileName
             + ".PDF' successfully");
    }
}

public class ExportPNG : IExporter
{
    public void ExportFile(string fileName)
    {
        Console.WriteLine("Export file: '" + fileName
             + ".PNG' successfully");
    }
}

class Client
{
    static void Main(string[] args)
    {
        ExportContext ctx = new ExportContext(new ExportPNG());
        ctx.CreateArchive("Mushroom");
        ctx.SetStrategy(new ExportJPG());
        ctx.CreateArchive("Mushroom");
        ctx.SetStrategy(new ExportPDF());
        ctx.CreateArchive("Mushroom");
        Console.Read();
    }
}