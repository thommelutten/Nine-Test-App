using AutoMapper;
using MediatR;
using NineTestApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineTestApp.Application.Colors.Queries.GetColors
{
    public class GetColorsQuery : IRequest<List<ColorDto>>
    {
    }

    public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, List<ColorDto>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetColorsQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<List<ColorDto>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
        {
            var colors = await _colorRepository.GetColors();

            return _mapper.Map<List<ColorDto>>(colors);
        }
    }
}
