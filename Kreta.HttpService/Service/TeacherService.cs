using Kreta.Shared.Dtos;
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
    public class TeacherService : ITeacherService
    {
        private readonly HttpClient? _httpClient;

        public TeacherService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("KretaApi");
            }
        }

        public async Task<List<Teacher>> SelectAllTeacher()
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<TeacherDto>? resultDto = await _httpClient.GetFromJsonAsync<List<TeacherDto>>("api/Teacher");
                    if (resultDto is not null)
                    {
                        List<Teacher> result = resultDto.Select(studentDto => studentDto.ToTeacher()).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Teacher>();
        }

        public async Task<ControllerResponse> UpdateAsync(Teacher student)
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



        public async Task<ControllerResponse> InsertAsync(Teacher student)
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
