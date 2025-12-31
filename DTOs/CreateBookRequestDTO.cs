namespace BookAPI.DTOs;

public record CreateBookRequestDTO
(
    string Title,
    string Author,
    int Year_Published,
    bool Is_Read
);