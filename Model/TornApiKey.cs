namespace ApiKeyStorageService.Model
{
    public class TornApiKey
    {
        public int PlayerId { get; set; }
        
        public int FactionId { get; set; }
        
        public int CompanyId { get; set; }
        
        public string ApiKey { get; set; }
        
        public bool Enabled { get; set; }
        
        public bool TrackPlayer { get; set; }
        
        public bool TrackFaction { get; set; }
        
        public bool TrackCompany { get; set; }
        
        public bool TrackTorn { get; set; }
    }
}
