namespace Core.Library.Types.Complex
{
  public class Result<TReturn, TError>
  {
    public TReturn Value;
    public TError Error;
    public Bool Successfull;

    public Result(TReturn result)
    {
      Value = result;
      Successfull = true;
    }
    
    public Result(TError error)
    {
      Error = error; 
      Successfull = false;
    }
  }
}
