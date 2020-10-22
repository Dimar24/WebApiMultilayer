using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.BLL.Services;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;
using WebApiMultilayer.WEB.Controllers;

namespace WebApiMultilayer.Tests
{
    [TestFixture]
    public class MarkTest
    {
        private IService<MarkDTO> _markService;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IRepository<Mark>> _markRepository;

        private MarkDTO mark { get; set; }

        public MarkTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _markRepository = new Mock<IRepository<Mark>>();
            _unitOfWork.Setup(u => u.Marks).Returns(_markRepository.Object);
        }

        [SetUp]
        public void SetUp()
        {
            _markService = new MarkService(_unitOfWork.Object);
        }

        [TestCase(-1, false)]
        [TestCase(1, true)]
        [TestCase(7, false)]
        public void GetMark(int id, bool isExist)
        {
            var test = GetTestMarks();
            // Arrange
            _markRepository.Setup(u => u.Get(id)).Returns(GetTestMarks().FirstOrDefault(u => u.Id == id));

            // Act
            var result = _markService.Get(id);

            // Assert
            bool isTrue = (!(result is null) && (result.Name == GetTestMarks().FirstOrDefault(m => m.Id == id).Name)) == isExist;
            Assert.IsTrue(isTrue);
        }






        private List<Mark> GetTestMarks()
        {
            var marks = new List<Mark>
            {
                new Mark { Id=1, Name="Kek"},
                new Mark { Id=2, Name="Lol"},
                new Mark { Id=3, Name="Chebyrek"},
                new Mark { Id=4, Name="Cat"}
            };
            return marks;
        }


        [TearDown]
        public void postconditions()
        {

        }
    }
}
