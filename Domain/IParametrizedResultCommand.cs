namespace Islands.Domain
{
    public interface IParametrizedResultCommand<in TParameter, out TResult>
    {
        TResult Execute(TParameter input);
    }
}
