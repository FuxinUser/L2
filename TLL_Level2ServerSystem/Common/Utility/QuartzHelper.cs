using Quartz;
using Quartz.Impl;

namespace L2
{
    public class QuartzHelper
    {
        /// <summary>每日工作</summary>
        /// <typeparam name="T">IJob</typeparam>
        /// <param name="hour">時</param>
        /// <param name="min">分</param>
        /// <param name="sec">秒</param>
        public void DailyWork<T>(int hour, int min, int sec)where T:IJob
        {
            //1.創建調度工廠,類似Quartz的核心
            ISchedulerFactory iFactory = new StdSchedulerFactory();

            //2.通過TriggerBuilder構建Trigger
            TriggerBuilder iTriggerBuilder = TriggerBuilder.Create();

            //3.通過工廠獲取調度器實例(異步)
            var asyncTask = iFactory.GetScheduler();
            
            //4.通過TriggerBuilder構建Trigger
            var trigger = iTriggerBuilder
                .WithDailyTimeIntervalSchedule(w =>
                            //w.WithIntervalInSeconds(5)//間隔
                            w.WithRepeatCount(0)//重複幾次
                            .StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(hour, min, sec)) //每天hour:min:sec開始
                                                                                                 //.EndingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(hour, min, sec)) //每天14:00:00結束
                ).Build();

            //等待調度器回來:
            asyncTask.Wait();
            IScheduler iScheduler = asyncTask.Result;

            //5.通過JobBuilder構建Job
            IJobDetail iJobDetail = JobBuilder.Create<T>().Build();

            //6.組裝各個組件<Job,Trigger>
            iScheduler.ScheduleJob(iJobDetail, trigger);
            
            //7.啟動
            iScheduler.Start();

        }
    }
}
