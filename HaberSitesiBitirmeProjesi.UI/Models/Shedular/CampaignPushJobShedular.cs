using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace HaberSitesiBitirmeProjesi.UI.Models.Shedular
{
    public class CampaignPushJobShedular
    {
        public static void Start()
        {
            IScheduler schedular = StdSchedulerFactory.GetDefaultScheduler();
            schedular.Start();

            IJobDetail job = JobBuilder.Create<CampaignPushJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule(
                    s => s.WithIntervalInHours(24)
                        .OnEveryDay()
                        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(21, 21))
                                        ).Build();

            schedular.ScheduleJob(job, trigger);
        }
    }
}