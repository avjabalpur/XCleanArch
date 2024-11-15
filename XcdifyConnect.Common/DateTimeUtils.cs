using System;

namespace XcdifyConnect.Common
{
	public static class DateTimeUtils
	{
		public static double CalculateDuration(DateTimeOffset? startDateTime, DateTimeOffset? endDateTime, TimeUnit timeUnit = TimeUnit.Minutes)
		{
			if (startDateTime.HasValue && endDateTime.HasValue)
			{
				var duration = endDateTime.Value - startDateTime.Value;

				// Return the duration in the specified time unit
				return timeUnit switch
				{
					TimeUnit.Seconds => duration.TotalSeconds,
					TimeUnit.Minutes => duration.TotalMinutes,
					TimeUnit.Hours => duration.TotalHours,
					TimeUnit.Days => duration.TotalDays,
					_ => duration.TotalMinutes // Default to minutes
				};
			}
			return 0;
		}
	}
	public enum TimeUnit
	{
		Seconds,
		Minutes,
		Hours,
		Days
	}

}
