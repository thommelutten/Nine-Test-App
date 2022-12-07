using AutoMapper;
using NineTestApp.Application.Common.Mappings;
using NineTestApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineTestApp.Application.Colors.Queries.GetColors
{
    public class ColorDto : IMapFrom<Color>
    {
        public string? Name { get; set; }
        public string? HexCode { get; set; }
        public string? RGB { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Color, ColorDto>();
        }
    }
}
