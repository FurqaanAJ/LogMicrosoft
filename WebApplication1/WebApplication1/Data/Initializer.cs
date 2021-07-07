using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Initializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Call.Any())
            {
                return;   // DB has been seeded
            }

            var Call = new Calls[]
            {
                new Calls{StudentID=Guid.NewGuid().ToString(), SubjectLine="BSG LAB Remote Access Issue PC BSG009", Description="I can log onto the Alumni Lab PC’s, but if I log onto the dedicated BSG PC the following message pops up: The connection was denied because the user account is not authorised for remote log in",
                Priority=Calls.priority.Medium, Status= Calls.status.Closed, LogDate=DateTime.Parse("12/11/2020"), CloseDate=DateTime.Parse("12/11/2020"), Comment="Webmaster made a configuration change", TechID=Guid.NewGuid().ToString()},
                new Calls{StudentID=Guid.NewGuid().ToString(), CallID =new Guid().ToString(), SubjectLine="BSG LAB Remote Access Issue PC BSG009", Description="I can log onto the Alumni Lab PC’s, but if I log onto the dedicated BSG PC the following message pops up: The connection was denied because the user account is not authorised for remote log in",
                Priority=Calls.priority.Medium, Status= Calls.status.Closed, LogDate=DateTime.Parse("11/11/2020"), CloseDate=DateTime.Parse("12/11/2020")},
                new Calls{StudentID=Guid.NewGuid().ToString(), SubjectLine="Visual Studio Expired", Description="My product key for visual studio has expired and I am unable to renew the license via the MSDNAA software application as it has been removed from the ICTS website. Please advise on the situation",
                Priority=Calls.priority.High, Status= Calls.status.Open, LogDate=DateTime.Parse("11/11/2020")},
                new Calls{StudentID=Guid.NewGuid().ToString(), SubjectLine="Additional Machine in Hons LAB", Description="For the duration of the IS Hon Project, I require an additional PC for testing to run validation testing and a external system",
                Priority=Calls.priority.Low, Status= Calls.status.Closed, LogDate=DateTime.Parse("2/11/2020"), CloseDate=DateTime.Parse("4/11/2020")},
                new Calls{StudentID=Guid.NewGuid().ToString(), SubjectLine="Laptop crashed", Description="Last night my laptop crashed and will not start again. This was the only computer I had access to and I now find myself unable to take the exam tomorrow",
                Status= Calls.status.Logged, LogDate=DateTime.Parse("1/11/2020")},
                new Calls{StudentID=Guid.NewGuid().ToString(), SubjectLine="Honours PC ISHON32 freezes", Description="I am unable to do any proper coding as the dedicated PC freezes after every 20 minutes ",
                Priority=Calls.priority.High, Status= Calls.status.Open, LogDate=DateTime.Parse("1/11/2020")}
            };
            foreach (Calls c in Call)
            {
                context.Call.Add(c);
            }
            context.SaveChanges();
        }
    }
}