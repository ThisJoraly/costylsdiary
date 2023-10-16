namespace diaryjm;

public class Note
{
    public string name { get; set; }
    public string text { get; set; }
    public DateTime date { get; set; }
    public DateTime deadline { get; set; }

    public Note(string name, string text, DateTime date, DateTime deadline)
    {
        this.name = name;
        this.text = text;
        this.date = date;
        this.deadline = deadline;
        

    }
}