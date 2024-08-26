using RetrainingSchedulerApp.Models;
using RetrainingSchedulerApp.Services;

namespace RetrainingSchedulerApp
{
	public class SchedulerManager
	{
		private readonly SchedulerService _schedulerService;

		public SchedulerManager(SchedulerService schedulerService)
		{
			_schedulerService = schedulerService;
		}

		public List<Session> GetSessions()
		{
			return new List<Session>
			{
				new Session("Organizing Parents for Academy Improvements", 60),
				new Session("Teaching Innovations in the Pipeline", 45),
				new Session("Making Your Academy Beautiful", 45),
				new Session("Academy Tech Field Repair", 45),
				new Session("Sync Hard", 45),
				new Session("Unusual Recruiting", 5),
				new Session("Parent Teacher Conferences", 60),
				new Session("Managing Your Dire Allowance", 45),
				new Session("AIMs – 'Managing Up'", 30),
				new Session("Dealing with Problem Teachers", 45),
				new Session("Hiring the Right Cook", 60),
				new Session("Government Policy Changes and New Globe", 60),
				new Session("Adjusting to Relocation", 45),
				new Session("Public Works in Your Community", 30),
				new Session("Talking To Parents About Billing", 30),
				new Session("So They Say You're a Devil Worshipper", 60),
				new Session("Two-Streams or Not Two-Streams", 30),
				new Session("Piped Water", 30)
			};
		}

		public void ScheduleAndDisplayTracks(List<Session> sessions)
		{
			DateTime startDate = DateTime.Today;
			var tracks = _schedulerService.ScheduleSessions(sessions, startDate);
			DisplayTracks(tracks);
		}

		private void DisplayTracks(List<Track> tracks)
		{
			int trackNumber = 1;
			foreach (var track in tracks)
			{
				Console.WriteLine($"Track {trackNumber++}");

				var firstSession = track.Sessions.FirstOrDefault();
				if (firstSession != null)
				{
					var sessionTime = firstSession.StartTime.TimeOfDay;
					var period = sessionTime < new TimeSpan(12, 0, 0) ? "Morning" : "Afternoon";
					Console.WriteLine($"Period: {period}");
				}

				foreach (var session in track.Sessions)
				{
					Console.WriteLine($"{session.StartTime:hh:mm tt} | {session.Name} | {session.Duration}min");
				}
				Console.WriteLine("12:00 PM | Lunch |");
				Console.WriteLine("05:00 PM | Sharing Session |");
				Console.WriteLine();
			}
		}
	}
}
