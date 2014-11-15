﻿using System;
using Mediocr.Application.TodoItems;
using Nancy;

namespace Mediocr.Example
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => "Home, is 127.0.0.1!";
        }
    }

    public class TodoItemsModule : NancyModule
    {
        private readonly IMediator _mediator;

        public TodoItemsModule(IMediator mediator) : base("/todo-items")
        {
            _mediator = mediator;
            Get["/"] = parameters =>
            {
                return "/todo-items/{id}";
            };

            Get["/{id}"] = parameters =>
            {
                var todoItem = _mediator.Send(new GetTodoItemById(parameters.id));

                return Response.AsJson(todoItem);
            };

            Post["/"] = parameters =>
            {
                var item =_mediator.Send(new CreateTodoItem{ Description = "Created at: " + DateTime.Now});
                return item;
            };
        }
    }
}