using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Author.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }

        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
        {
            private readonly IAuthorRepository _authorRepository;

            public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }

            public async Task<int> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
            {
                var author = new Domain.Author
                {
                    Name = command.Name,
                    Bio = command.Bio,
                    DateOfBirth = command.DateOfBirth
                };

                await _authorRepository.AddAsync(author);
                return author.Id;
            }
        }
    }
}
