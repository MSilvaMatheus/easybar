using EasyBar.Domain.Interfaces;
namespace EasyBar.Domain.Entity.Validation
{
    public class ValidateResult :  IResult
    {
        public object Data { get; set; }
        public bool isSucess { get; set; }
        public string Message { get; set; }

        public ValidateResult(object data, bool sucess, string message)
        {
            Data = data;
            isSucess = sucess;
            Message = message;
        }
    }
}
