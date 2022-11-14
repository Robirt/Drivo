namespace Drivo.Responses;

public class ActionResponse
{
    public ActionResponse()
    {

    }

    public ActionResponse(bool isSucceeded, string message)
    {
        IsSucceeded = isSucceeded;
        Message = message;
    }

    public bool IsSucceeded { get; set; }

    public string Message { get; set; }
}