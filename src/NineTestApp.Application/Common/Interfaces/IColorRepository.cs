using NineTestApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineTestApp.Application.Common.Interfaces
{
    public interface IColorRepository
    {
        Task<List<Color>> GetColors();
    }
}
