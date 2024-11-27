//https://members.codewithmosh.com/courses/object-oriented-programming-in-csharp-1/lectures/3497972

public class WorkFlowEngine
{
    private readonly List<IActivity> _activities = new();
    public void Run()
    {
        foreach (var activity in _activities)
        {
            activity.Execute();
        }
    }

    public void RegisterActivity(IActivity activity)
    {
        _activities.Add(activity);
    }
}

public interface IActivity
{
    void Execute();
}

public class VideoUpload : IActivity
{
    public void Execute()
    {
        Console.WriteLine("Video Uploaded");
    }
}

public class VideoEncode : IActivity
{
    public void Execute()
    {
        Console.WriteLine("Video Encoded");
    }
}

public class SendEmail : IActivity
{
    public void Execute()
    {
        Console.WriteLine("Email Sent");
    }
}