partial class Program
{
    static void Main()
    {
        var wf = new WorkFlowEngine();
        wf.RegisterActivity(new VideoEncode());
        wf.RegisterActivity(new VideoUpload());
        wf.RegisterActivity(new SendEmail());

        wf.Run();
    }
}
