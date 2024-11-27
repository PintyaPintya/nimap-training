//https://members.codewithmosh.com/courses/object-oriented-programming-in-csharp-1/lectures/3497972
public class Stack
{
    private List<object> stack = new List<object>();

    public void Push(object obj)
    {
        if (obj == null)
        {
            throw new InvalidOperationException("cannot push null");
        }
        stack.Add(obj);
    }

    public Object Pop()
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException("Stack empty");
        }

        object temp = stack.Last();
        stack.Remove(temp);
        return temp;
    }

    public void Clear()
    {
        stack.Clear();
    }
}
