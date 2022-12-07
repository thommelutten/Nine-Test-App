using AutoMapper;
using Moq;
using NineTestApp.Application.Colors.Queries.GetColors;
using NineTestApp.Application.Common.Interfaces;
using NineTestApp.Application.Common.Mappings;
using NineTestApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineTestApp.Application.Test.Colors.Queries.GetColors
{
    public class GetColorsQueryTest
    {
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        [Test]
        public async Task TestHandle()
        {
            var mockColorRepository = new Mock<IColorRepository>();

            mockColorRepository.Setup(_ => _.GetColors())
                .Returns(Task.FromResult(new List<Color>()
                {
                    new Color()
                    {
                        Name = "Purple",
                        HexCode = "#800080",
                        RGB = "128, 0, 128"
                    }
                }));

            var handler = new GetColorsQueryHandler(mockColorRepository.Object, _mapper);

            var query = new GetColorsQuery();
            var result = await handler.Handle(query, CancellationToken.None);

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Name, Is.EqualTo("Purple"));
                Assert.That(result[0].HexCode, Is.EqualTo("#800080"));
                Assert.That(result[0].RGB, Is.EqualTo("128, 0, 128"));
            });
        }
    }
}
