using WebApplication4.CommomLayer.Model;
using WebApplication4.RepositaryLayer;

namespace WebApplication4.ServiceLayer
{
    public class CrudOperationSL : ICrudOperationSL
    {
        public readonly ICrudOPerationRL _crudOperationRL;

        public CrudOperationSL(ICrudOPerationRL crudOperationRL)
        {
            _crudOperationRL = crudOperationRL;
        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
                return await _crudOperationRL.CreateRecord(request);
                }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _crudOperationRL.ReadRecord();      
        }
        public async Task<UpdateRecordResponse?> UpdateRecord(UpdateRecordRequest request)
        {
            return await _crudOperationRL.UpdateRecord(request);
        }
        public async Task<DeleteRecordResponse?> DeleteRecord(DeleteRecordRequest request)
        {
            return await _crudOperationRL.DeleteRecord(request);
        }
    }
}
