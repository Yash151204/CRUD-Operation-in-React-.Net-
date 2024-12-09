using Microsoft.AspNetCore.Mvc;
using WebApplication4.CommomLayer.Model;
using WebApplication4.ServiceLayer;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {

        public readonly ICrudOperationSL _crudOperationSL;

        public CrudOperationController(ICrudOperationSL crudOperationSL)
        {

            _crudOperationSL = crudOperationSL;
        }

        [HttpPost]
        [Route("CreateRecord")]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.CreateRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);

        }
        [HttpGet]
        [Route("ReadRecord")]
        public async Task<IActionResult> ReadRecord()
        {
             ReadRecordResponse response = null;

            try
            {
                response =await _crudOperationSL.ReadRecord();
            }
            catch(Exception ex)
            {

            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateRecord/{id}")]
        public async Task<IActionResult> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.UpdateRecord(request);
            }
            catch (Exception ex)
            {

            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRecord/{id}")]

        public async Task<IActionResult> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.DeleteRecord(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }


    }
}
