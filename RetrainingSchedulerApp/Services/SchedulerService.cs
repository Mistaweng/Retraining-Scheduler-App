using RetrainingSchedulerApp.Models;

namespace RetrainingSchedulerApp.Services
{
	public class SchedulerService
	{
		public List<Track> ScheduleSessions(List<Session> sessions, DateTime startDate)
		{
			List<Track> tracks = new List<Track>();
			sessions = sessions.OrderByDescending(s => s.Duration).ToList();

			bool isMorning = true; 

			foreach (var session in sessions)
			{
				bool sessionAdded = false;

				foreach (var track in tracks)
				{
					if (track.AddSession(session))
					{
						sessionAdded = true;
						break;
					}
				}

				if (!sessionAdded)
				{
					var newTrack = new Track(isMorning, startDate);
					if (!newTrack.AddSession(session))
					{
						throw new InvalidOperationException("Session duration does not fit in the available time slot.");
					}

					tracks.Add(newTrack);
					isMorning = !isMorning; 
				}
			}

			return tracks;
		}
	}
}
