using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (IResult logic in logics)
            {
                if (logic.Success == false)
                {
                    return logic;
                }
            }
            return new SuccessResult();
        }
        public static List<IResult> RunAsList(params IResult[] logics)
        {
            List<IResult> results = new();
            foreach (IResult logic in logics)
            {
                results.Add(logic);
            }
            return results;
        }
    }
}
