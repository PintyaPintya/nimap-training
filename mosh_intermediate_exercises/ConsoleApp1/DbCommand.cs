//https://members.codewithmosh.com/courses/object-oriented-programming-in-csharp-1/lectures/3497989
public class DbCommand
{
    private readonly DbConnection _conn;
    private readonly string _instruction;
    public DbCommand(DbConnection conn, string instruction)
    {
        if (conn == null)
            throw new ArgumentNullException("Connection cannot be null");

        if(instruction == null)
            throw new ArgumentNullException("Instruction cannot be null");

        _conn = conn;

        if (_conn.GetType().ToString() == "OracleConnection")
        {
            _instruction = "oracle:" + instruction;
        }
        else if (_conn.GetType().ToString() == "SqlConnection")
        {
            _instruction = "sql:" + instruction;
        }
        else
        {
            _instruction = "default:" + instruction;
        }
    }

    public void Execute()
    {
        _conn.Open();
        Console.WriteLine($"Running {_instruction}");
        _conn.Close();
    }

}