using Application.Abstraction;
using Application.Abstraction.AppConfig;
using Application.Abstraction.Repository.Read;
using Application.Abstraction.Repository.Read.Core;
using Application.Abstraction.Service.Core;
using Application.Models.Data.Core;
using Domain.Concrete.Core.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Service
{
    public class ExceptionNotificationService : IExceptionNotificationService
    {
        private readonly IExceptionNotificationReadRepository _exceptionNotificationReadRepository;
        public IAppSetting _appSetting { get; set; }
        public IAppSession _appSession { get; set; }
        public ExceptionNotificationService(IUnitOfWork unitOfWork, 
            IAppSetting appSetting, IAppSession appSession, 
            IExceptionNotificationReadRepository exceptionNotificationReadRepository)
        {
            _appSetting = appSetting;
            _appSession = appSession;
            _exceptionNotificationReadRepository = exceptionNotificationReadRepository;
        }

        public async Task<Content> GetByKey(string key)
        {
            var description=await GetDescription(key);

            return new Content(description,key);
        }
        public async Task<string> GetDescription(string key)
        {
            ExceptionNotification exceptionModel = await _exceptionNotificationReadRepository.FirstOrDefaultAsync(x => x.Key == key);

            return exceptionModel?.Description;
        } 
    }
}
