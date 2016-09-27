using System;

namespace Cloud.Domain
{
    public class TestEvent
    {
        public string Url { get; set; }

        public TestManager TestManager { get; set; }

        public DateTime ExcuteTime { get; set; } = DateTime.Now;

        public int EventSendCategory { get; set; } = 1;

        public string EmailOrPhone { get; set; }

    }
}