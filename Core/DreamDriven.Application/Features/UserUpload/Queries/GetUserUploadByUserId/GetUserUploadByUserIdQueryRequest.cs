using MediatR;

namespace DreamDriven.Application.Features.UserUpload.Queries.GetUserUploadByUserId
{
    //Hangi degere gore veri cekecegim
    public class GetUserUploadByUserIdQueryRequest : IRequest<IList<GetUserUploadByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
