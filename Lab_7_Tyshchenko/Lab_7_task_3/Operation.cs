using System;

namespace Lab_7_task_3
{
    public class Operation
    {
        public string ThreadId { get; }
        public string Details { get; }
        public DateTime Timestamp { get; }

        public Operation(string threadId, string details)
        {
            ThreadId = threadId;
            Details = details;
            Timestamp = DateTime.Now;
        }

        public bool ConflictWith(Operation other)
        {
            return false;
        }

        public override string ToString()
        {
            return $"[{Timestamp}] Thread {ThreadId}: {Details}";
        }
    }
}