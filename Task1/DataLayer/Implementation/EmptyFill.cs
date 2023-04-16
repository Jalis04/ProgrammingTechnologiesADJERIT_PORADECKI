using DataLayer.API;

namespace DataLayer.Implementation
{
    public class EmptyFill : IFill
    {
        public override void Fill(IDataRepository dataRepository)
        {
        }
    }
}
