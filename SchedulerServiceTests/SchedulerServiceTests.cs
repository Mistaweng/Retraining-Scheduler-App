using Xunit;
using RetrainingSchedulerApp.Models;
using RetrainingSchedulerApp.Services;
using System;

namespace RetrainingScheduler.Tests.Tests
{
	public class SchedulerServiceTests
	{
		[Fact]
		public void TestSingleSessionScheduling()
		{
			var scheduler = new SchedulerService();
			var sessions = new List<Session>
			{
				new Session("Sample Session", 60)
			};

			DateTime startDate = new DateTime(2024, 8, 24);
			var tracks = scheduler.ScheduleSessions(sessions, startDate);

			Assert.Single(tracks);
			Assert.Single(tracks[0].Sessions);
		}

		[Fact]
		public void TestMultipleSessionsScheduling()
		{
			var scheduler = new SchedulerService();
			var sessions = new List<Session>
			{
				new Session("Session 1", 60),
				new Session("Session 2", 30),
				new Session("Session 3", 45),
				new Session("Session 4", 30),
				new Session("Session 5", 60)
			};

			DateTime startDate = new DateTime(2024, 8, 24);
			var tracks = scheduler.ScheduleSessions(sessions, startDate);

			Assert.Equal(2, tracks.Count);
			Assert.Equal(3, tracks[0].Sessions.Count);
			Assert.Equal(2, tracks[1].Sessions.Count);
		}

		[Fact]
		public void TestTrackStartTimes()
		{
			var scheduler = new SchedulerService();
			var sessions = new List<Session>
			{
				new Session("Session 1", 60),
				new Session("Session 2", 45),
				new Session("Session 3", 30),
			};

			DateTime startDate = new DateTime(2024, 8, 24);
			var tracks = scheduler.ScheduleSessions(sessions, startDate);

			Assert.Equal(new DateTime(2024, 8, 24, 9, 0, 0), tracks[0].Sessions[0].StartTime);
			Assert.Equal(new DateTime(2024, 8, 24, 10, 0, 0), tracks[0].Sessions[1].StartTime);

		}
	}
}
