namespace CoreService_backend.Models.Result;

public class ResponseResult
{
    public bool Success {get;set;}
}

public class CreateResponseResult : ResponseResult
{
    public ResponseHandler Response { get; set; }
}

public class GetResponseResult : CreateResponseResult
{

}

public class GetResponsesResult : ResponseResult
{
    public IEnumerable<ResponseHandler> Responses
}

public class UpdateResponseResult : ResponseResult
{
    public ResponseHandler Response {get;set;}
}