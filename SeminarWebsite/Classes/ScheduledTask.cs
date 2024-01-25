using System;
using System.Threading;

public class ScheduledTask
{
    private Timer timer;

    public ScheduledTask()
    {
        // Set the date and time for the task (every September 1st at midnight)
        DateTime now = DateTime.Now;
        DateTime scheduledDate = new DateTime(now.Year, 1, 15, 15, 47, 0);

        // Calculate the time difference between now and the scheduled date
        TimeSpan timeUntilScheduledTask = scheduledDate > now ? scheduledDate - now : scheduledDate.AddYears(1) - now;

        // Create a timer with the calculated interval
        timer = new Timer(OnTimerElapsed, null, (long)timeUntilScheduledTask.TotalMilliseconds, Timeout.Infinite);
    }

    private void OnTimerElapsed(object state)
    {
        // Perform the desired task here
        Console.WriteLine("Scheduled task executed on September 1st.");

        // Reschedule the timer for the next year
        timer.Change(TimeSpan.FromDays(365), Timeout.InfiniteTimeSpan);
    }
}
