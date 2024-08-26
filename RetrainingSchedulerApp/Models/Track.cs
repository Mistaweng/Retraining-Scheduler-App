namespace RetrainingSchedulerApp.Models
{
	public class Track
	{
		public List<Session> Sessions { get; private set; } = new List<Session>();
		private DateTime nextAvailableTime;
		private readonly bool isMorning;

		public Track(bool isMorning, DateTime date)
		{
			this.isMorning = isMorning;
			nextAvailableTime = isMorning ?
				new DateTime(date.Year, date.Month, date.Day, 9, 0, 0) :
				new DateTime(date.Year, date.Month, date.Day, 13, 0, 0);
		}

		public bool AddSession(Session session)
		{
			TimeSpan sessionEnd = nextAvailableTime.AddMinutes(session.Duration).TimeOfDay;
			if (isMorning && nextAvailableTime.TimeOfDay < new TimeSpan(12, 0, 0) && sessionEnd <= new TimeSpan(12, 0, 0))
			{
				session.StartTime = nextAvailableTime;
				Sessions.Add(session);
				nextAvailableTime = nextAvailableTime.AddMinutes(session.Duration);
				return true;
			}
			else if (!isMorning && nextAvailableTime.TimeOfDay >= new TimeSpan(13, 0, 0) && sessionEnd <= new TimeSpan(17, 0, 0))
			{
				session.StartTime = nextAvailableTime;
				Sessions.Add(session);
				nextAvailableTime = nextAvailableTime.AddMinutes(session.Duration);
				return true;
			}
			return false;
		}
	}
}
