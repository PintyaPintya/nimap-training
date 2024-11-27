//https://members.codewithmosh.com/courses/object-oriented-programming-in-csharp-1/lectures/3497989
public abstract class DbConnection
{
    protected string ConnectionString { get; set; }
    protected bool IsOpen { get; set; }
    protected TimeSpan _timeout;

    public DbConnection(string connectionString)
    {
        if (connectionString == null)
            throw new ArgumentNullException("Connection string cannot be null");

        ConnectionString = connectionString;
        IsOpen = false;
        _timeout = TimeSpan.FromSeconds(2);
    }

    public abstract void Open();

    public abstract void Close();
}

public class SqlConnection : DbConnection
{
    public SqlConnection(string connectionString) : base(connectionString)
    {

    }
    public override void Open()
    {
        if (IsOpen)
            throw new InvalidOperationException("Connection already open");

        IsOpen = true;
        Console.WriteLine("SqlConnection is connected to {0}", ConnectionString);
    }

    public override void Close()
    {
        if (!IsOpen)
            throw new InvalidOperationException("Connection already closed");

        IsOpen = false;
        Console.WriteLine("SqlConnection closed of {0}", ConnectionString);
    }

}

public class OracleConnection : DbConnection
{
    public OracleConnection(string connectionString) : base(connectionString) 
    {
        
    }

    public override void Open()
    {
        if (IsOpen)
            throw new InvalidOperationException("Connection already open");

        IsOpen = true;
        Console.WriteLine("OracleConnection is connected to {0}", ConnectionString);
    }

    public override void Close()
    {
        if (!IsOpen)
            throw new InvalidOperationException("Connection already closed");

        IsOpen = false;
        Console.WriteLine("OracleConnection closed of {0}", ConnectionString);
    }
}
