# Retraining Scheduler App

The Retraining Scheduler App is a console-based application designed to schedule training sessions into morning and afternoon tracks, ensuring that sessions are organized efficiently within the available time slots. The project includes a scheduling service, models for sessions and tracks, and unit tests to validate the scheduling logic.

## Features

- **Session Scheduling**: Automatically schedules training sessions into morning and afternoon tracks based on duration and availability.
- **Customizable Time Slots**: Supports custom start times for sessions, depending on whether it's a morning or afternoon track.
- **Unit Testing**: Includes unit tests to verify the functionality of the scheduling service.
  

## Setup and Build Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Mistaweng/Retraining-Scheduler-App
   cd retraining-scheduler

2. **Restore dependencies:**: dotnet restore

3. **Build the solution**: dotnet build

4. **Run the application:**: dotnet run --project RetrainingSchedulerApp

5. **Build the solution**: dotnet test


