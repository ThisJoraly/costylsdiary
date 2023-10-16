namespace diaryjm;

public class Note
{
    public string name { get; set; }
    public string text { get; set; }
    public DateTime date { get; set; }


    public Note(string name, string text, DateTime date )
    {
        this.name = name;
        this.text = text;
        this.date = date;

    }
}