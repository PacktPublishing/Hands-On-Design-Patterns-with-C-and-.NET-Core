namespace FlixOne.Web.Models
{
    public class MessageViewModel
    {
        public string MsgId { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public override string ToString() => $"Id:{MsgId}, Success:{IsSuccess}, Message:{Message}";
    }
}
