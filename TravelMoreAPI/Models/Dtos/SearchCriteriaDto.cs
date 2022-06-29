namespace TravelMoreAPI.Models.Dtos
{
    public class SearchCriteriaDto
    {
        public string? Address { get; set; }
        public int BedNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? City { get; set; }
    }
}
