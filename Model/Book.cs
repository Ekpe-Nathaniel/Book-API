using BookAPI.Model.Common;
using Microsoft.Net.Http.Headers;

namespace BookAPI.Model;

public class Book:Entity
{
    public string? Title { get; set; }

    public string? Author { get; set; }

    public int? Year_Published { get; set; }

    public bool? Is_Read { get; set; }
}