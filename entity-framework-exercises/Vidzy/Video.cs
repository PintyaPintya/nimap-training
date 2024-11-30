public class Video
{
    public int VideoId { get; set; }
    public required string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public Classification Classification { get; set; }
}

public enum Classification
{
    Silver,
    Gold,
    Platinum
}
