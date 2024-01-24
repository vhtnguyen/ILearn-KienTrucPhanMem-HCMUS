public class Singleton
{
    private static Singleton instance;
    private static readonly object lockObject = new object();

    private Singleton()
    {
        // Private constructor to prevent instantiation outside the class.
    }

    public static Singleton Instance
    {
        get
        {
            // Double-check locking for thread safety
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }

            return instance;
        }
    }

    public void PrintMessage()
    {
        Console.WriteLine("Hello, I am a Singleton instance!");
    }
}
