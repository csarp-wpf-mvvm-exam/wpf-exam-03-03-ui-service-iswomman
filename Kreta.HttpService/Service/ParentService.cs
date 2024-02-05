﻿using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Kreta.Shared.Extensions;

namespace Kreta.HttpService.Service
{
    public class ParentService : IParentService
    {
        private readonly HttpClient? _httpClient;

        public ParentService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("KretaApi");
            }
        }

        public async Task<List<Parent>> SelectAllParent()
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<ParentDto>? resultDto = await _httpClient.GetFromJsonAsync<List<ParentDto>>("api/Parent");
                    if (resultDto is not null)
                    {
                        List<Parent> result = resultDto.Select(studentDto => studentDto.ToParent()).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Parent>();
        }

        public async Task<ControllerResponse> UpdateAsync(Parent parent)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
            }
            defaultResponse.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return defaultResponse;
        }

        public async Task<ControllerResponse> DeleteAsync(Guid id)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
            }
            defaultResponse.ClearAndAddError("Az adatok törlése nem lehetséges!");
            return defaultResponse;
        }


        public async Task<ControllerResponse> InsertAsync(Parent student)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
            }
            defaultResponse.ClearAndAddError("Az adatok mentése nem lehetséges!");
            return defaultResponse;
        }

    }
}
