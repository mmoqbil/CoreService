﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CoreService_Core.Model.Dto;
using CoreService_Core.Service.Interface;

namespace CoreService_Core.Service
{
    public class ResponseService : IResponseService
    {
        private readonly IDataManager _dataManager;

        public ResponseService(IDataManager dataManager)
        {
            _dataManager = dataManager ?? throw new ArgumentNullException(nameof(dataManager));
        }

        public void CreateResponseHandler(HttpStatusCode httpStatusCode, ResourceDto resource)
        {
            _dataManager.CreateResponse(httpStatusCode, resource);
        }

        public void CreateResponseHandlerWithErrorMessage(ResourceDto resource, string errorMessage)
        {
            _dataManager.CreateResponseWithErrorMessage(resource, errorMessage);
        }
    }
}
