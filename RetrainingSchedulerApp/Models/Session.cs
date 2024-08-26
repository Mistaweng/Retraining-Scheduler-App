namespace RetrainingSchedulerApp.Models
{
    public class Session
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }

        public Session(string name, int duration)
        {
            Name = name;
            Duration = duration.ToString().ToLower() == "lightning" ? 5 : int.Parse(duration.ToString().Replace("min", "").Trim());
        }
    }
}
