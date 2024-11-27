//https://members.codewithmosh.com/courses/object-oriented-programming-in-csharp-1/lectures/3497740
public class Stopwatch
{
    private DateTime? _startTime;
    private TimeSpan _totalDuration;
    private bool _isRunning;

    public Stopwatch()
    {
        _startTime = null;
        _totalDuration = TimeSpan.Zero;
        _isRunning = false;
    }

    public void Start()
    {
        if (_isRunning)
        {
            throw new InvalidOperationException("Stopwatch already started");
        }

        _startTime = DateTime.Now;
        _isRunning = true;
    }

    public void Stop()
    {
        if (!_isRunning)
        {
            throw new InvalidOperationException("Stopwatch already stopped");
        }

        var duration = DateTime.Now - _startTime.Value;
        _totalDuration += duration;

        _isRunning = false;
        _startTime = null;
    }

    public TimeSpan GetDuration()
    {
        return _totalDuration;
    }

    public void Reset()
    {
        _startTime = null;
        _totalDuration = TimeSpan.Zero;
        _isRunning = false;
    }
}