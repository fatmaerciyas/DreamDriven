namespace DreamDriven.Application.Features.Counters.Queries.GetAllCountersByUserId
{
    //Gostermek istedigim veriler
    public class GetAllCountersByUserIdQueryResponse
    {

        public string Name { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime CreatedDate { get; set; }

        //User
        public Guid UserId { get; set; }
    }
}
