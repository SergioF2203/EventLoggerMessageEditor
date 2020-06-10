namespace DAL.Models
{
    public class EventEntity
    {
        public short Sys_ID { get; set; }
        public short Group { get; set; }
        public short Event { get; set; }
        public string Address { get; set; }
        public string Tag { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string PicFile { get; set; }
        public string DocFile { get; set; }
    }
}
