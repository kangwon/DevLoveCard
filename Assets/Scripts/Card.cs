public class Card
{
    public string Type { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }

    public Card(string type, string slug, string title)
    {
        this.Type = type;
        this.Slug = slug;
        this.Title = title;
    }
}
