using NineTestApp.Application.Common.Interfaces;
using NineTestApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineTestApp.Infrastructure.Repositories
{
    public class ColorRepository : IColorRepository
    {
        public Task<List<Color>> GetColors()
        {
            return Task.FromResult(new List<Color>()
            {
                new Color()
                {
                    Name = "Red",
                    HexCode = "#FF0000",
                    RGB = "255, 0, 0"
                },
                new Color()
                {
                    Name = "Blue",
                    HexCode = "#0000FF",
                    RGB = "0, 0, 255"
                },
                new Color()
                {
                    Name = "Green",
                    HexCode = "#008000",
                    RGB = "0, 255, 0"
                }
            });
        }
    }
}
