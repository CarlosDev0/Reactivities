﻿using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context) 
        {
            if (context.Activities.Any()) return; //if there are some
            //activities (records on database) then it will exit
            var activities = new List<Activity>{
                new Activity
                {
                    Title = "Past Activity 1",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description="Activity 2 months ago",
                    Category= "drinks",
                    City= "London",
                    Venue= "Pub"
                },
                new Activity
                {
                    Title = "Past Activity 2",
                    Date = DateTime.UtcNow.AddMonths(-3),
                    Description="Activity 3 months ago",
                    Category= "culture",
                    City= "Paris",
                    Venue= "Louvre"
                },
                new Activity
                {
                    Title = "Past Activity 3",
                    Date = DateTime.UtcNow.AddMonths(-4),
                    Description="Activity 4 months ago",
                    Category= "drinks",
                    City= "London",
                    Venue= "Pub"
                },
                new Activity
                {
                    Title = "Future Activity 4",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description="Activity 1 month in future",
                    Category= "culture",
                    City= "London",
                    Venue= "Natural History Museum"
                },
                new Activity
                {
                    Title = "Future Activity 5",
                    Date = DateTime.UtcNow.AddMonths(2),
                    Description="Activity 2 month in future",
                    Category= "music",
                    City= "London",
                    Venue= "02 Arena"
                },
                new Activity
                {
                    Title = "Future Activity 6",
                    Date = DateTime.UtcNow.AddMonths(3),
                    Description="Activity 3 month in future",
                    Category= "drinks",
                    City= "London",
                    Venue= "Another pub"
                },
                new Activity
                {
                    Title = "Future Activity 7",
                    Date = DateTime.UtcNow.AddMonths(4),
                    Description="Activity 4 month in future",
                    Category= "drinks",
                    City= "London",
                    Venue= "yet another pub"
                },
                new Activity
                {
                    Title = "Future Activity 8",
                    Date = DateTime.UtcNow.AddMonths(5),
                    Description="Activity 5 month in future",
                    Category= "music",
                    City= "London",
                    Venue= "Roundhouse Camden"
                },
                new Activity
                {
                    Title = "Future Activity 9",
                    Date = DateTime.UtcNow.AddMonths(6),
                    Description="Activity 6 month in future",
                    Category= "travel",
                    City= "London",
                    Venue= "Somewhere on the Thames"
                },
                new Activity
                {
                    Title = "Future Activity 10",
                    Date = DateTime.UtcNow.AddMonths(7),
                    Description="Activity 7 month in future",
                    Category= "film",
                    City= "London",
                    Venue= "Cinema"
                },
                new Activity
                {
                    Title = "Future Activity 11",
                    Date = DateTime.UtcNow.AddMonths(7),
                    Description="Activity 7 month in future",
                    Category= "travel",
                    City= "Milan",
                    Venue= "Traviata"
                }
            };
            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}
