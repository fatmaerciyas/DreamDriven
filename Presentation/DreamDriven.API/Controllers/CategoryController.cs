using DreamDriven.Application.Features.Categories.Command.CreateCategory;
using DreamDriven.Application.Features.Categories.Command.DeleteFolder;
using DreamDriven.Application.Features.Categories.Command.UpdateCategory;
using DreamDriven.Application.Features.Categories.Queries.GettAllCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamDriven.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories() // GetAllCategories(GettAllCategoriesQueryRequest request)
        {

            var response = await mediator.Send(new GettAllCategoriesQueryRequest()); //herhangi bir querye gore donmek istemedigim icin boyle yoksa // Send( request )

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

    }
}
