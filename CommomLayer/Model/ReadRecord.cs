namespace WebApplication4.CommomLayer.Model
{
    public class ReadRecordResponse
    {

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<ReadRecordData> readRecordData { get; set; }
    }

    public class ReadRecordData
    {
        public String UserName { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }

    }
}
