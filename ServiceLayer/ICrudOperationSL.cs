using WebApplication4.CommomLayer.Model;

namespace WebApplication4.ServiceLayer
{
    public interface ICrudOperationSL
    {
        public  Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

        public Task<ReadRecordResponse> ReadRecord();
        public Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);
        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);

    }
}
