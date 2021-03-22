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
        Survey Add(Survey newItem);
        Survey GetById(Guid id);
        void Remove(Guid id);
    }
}
