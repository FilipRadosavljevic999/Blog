using Application;
using Application.Exceptions;
using Application.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class UseCaseHandler
    {
        private IApplicationUser _user;
        private IUseCaseLogger _logger;
        public UseCaseHandler(IApplicationUser user,IUseCaseLogger logger)
        {
            _user = user;
            _logger = logger;
        }
        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(command, data);
                _logger.Add(new UseCaseLogEntry
                {
                    Actor = _user.Username,
                    ActorId = _user.Id,
                    Data = data,
                    UseCaseName = command.Name
                });
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query, data);
                _logger.Add(new UseCaseLogEntry
                {
                    Actor = _user.Username,
                    ActorId = _user.Id,
                    Data = data,
                    UseCaseName = query.Name
                });
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = query.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseExecutionException(useCase.Name, _user.Identity);
            }
        }
    }
}
