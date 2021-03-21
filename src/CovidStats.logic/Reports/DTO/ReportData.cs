namespace CovidStats.logic.Reports.DTO
{
    public class ReportData
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public string ProvinceName { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
    }
}