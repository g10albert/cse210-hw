public class Assignment
{
  protected string _studentName = "";
  private string _topic = "";


  public Assignment() {}
  public Assignment(string studentName, string topic)
  {
    _studentName = studentName;
    _topic = topic;
  }
  public string GetName()
  {
    return $"{_studentName}";
  }

  public string GetTopic()
  {
    return $"{_topic}";
  }

  public void SetTopic(string topic)
  {
    _topic = topic;
  }

  public void setName(string name)
  {
    _studentName = name;
  }
  public string GetSummary()
  {
    return $"{_studentName} - {_topic}";
  }
}