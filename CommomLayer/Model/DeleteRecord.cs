﻿namespace WebApplication4.CommomLayer.Model
{
    public class DeleteRecordRequest
    {
        public int Id { get; set; }

    }
    public class DeleteRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get;  set; }    
    }
}
 