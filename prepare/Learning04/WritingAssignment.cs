// WritingAssignment.cs
public class WritingAssignment : Assignment
{
    public WritingAssignment(string studentName, string topic) : base(studentName, topic)
    {
    }

    public string GetWritingInformation()
    {
        // Example implementation. Adjust as needed.
        return $"The Causes of World War II by {StudentName}";
    }
}
