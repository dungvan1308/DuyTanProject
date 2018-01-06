using ServiceStack;

namespace ScheduleEntity
{
    [Route("/cache/{Name}")]
    public class CacheObject
    {
        public string Name { get; set; }
    }
}
