﻿namespace Module.Catalog.Core.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Synopsis { get; set; }
    public string Director { get; set; }
    public List<string> Actors { get; set; }
    public List<string> Genres { get; set; }
}
