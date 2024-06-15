namespace ByteCuisine.Shared.DTOs
{
    public class LogDTO
    {
        public DateTime ActivityTime { get; set; }
        public string ActivityName { get; set; }
        public int AccountId { get; set; }

        public LogDTO()
        {

        }

        public LogDTO(DateTime activityTime, string activityName,int accountId)
        {
            ActivityTime = activityTime;
            ActivityName = activityName;
            AccountId = accountId;
        }
    }
}
