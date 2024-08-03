﻿using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.UpdateCategory
{
    //Update ederken ihtiyacim olan ozellikler
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}