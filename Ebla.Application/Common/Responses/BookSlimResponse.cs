﻿namespace Ebla.Application.Common.Responses
{
    public record BookSlimResponse
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string Genre { get; init; }
        public string Language { get; init; }
        public string Country { get; init; }
        public string ImageLink { get; init; }
    }
}