using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompassSurveyTestApp.Models
{
    public interface ICompassDBContext: IDisposable
    {
        IEnumerable<Survey> GetAllItems();
        Task AddAsync(Survey newItem);
        Task<List<Survey>> ListAsync();
        Task<Survey> GetSurveyAsync(int id);
        Task UpdateSurveyAsync(int surveyId, Survey survey);
    }
}
