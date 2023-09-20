namespace Corso.Core.ReqRes;

public  interface IReqResData
{
    Task<ReqResResponse?> GetDataAsync();
    void CancelRequest();
    Task<ReqResRequest?> PostSomeData(ReqResRequest reqResRequest);
}
