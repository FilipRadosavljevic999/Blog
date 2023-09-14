using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ForbiddenUseCaseExecutionException: Exception
    {
        public ForbiddenUseCaseExecutionException(string useCase, string user) :
            base($"User {user} has tried to execute {useCase} without being authorized to do so.")
        {

        }
    }
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityType, int id)
            : base($"Entity of type {entityType} with an id of {id} was not found.")
        {

        }
    }

    public class UseCaseConflictException : Exception
    {
        public UseCaseConflictException(string message) : base(message)
        {

        }
    }
}
