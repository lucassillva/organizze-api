using FluentAssertions;
using Moq;
using Organizze.Domain.Entities.Tags;
using Organizze.Domain.Repositories.Tags;
using Organizze.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Organizze.Domain.UnitTest.Services
{
    public class TagServiceTest
    {
        private readonly TagService _service;
        private readonly Mock<ITagRepository> _repositoryMock;

        public TagServiceTest()
        {
            _repositoryMock = new Mock<ITagRepository>();
            _service = new TagService(_repositoryMock.Object);
        }

        [Fact]
        public async Task Given_valid_input_should_create_tag()
        {
            //Arrange
            const string name = "Any name";

            //Act
            var tag = await _service.Create(name);

            //Assert
            tag.Should().NotBeNull();
            _repositoryMock.Verify(repository => repository.GetByName(It.IsAny<string>()), Times.Once);
            _repositoryMock.Verify(repository => repository.Insert(It.IsAny<Tag>()), Times.Once);
        }

        [Fact]
        public async Task When_tag_already_exist_should_throw_exception()
        {
            //Arrange
            const string name = "Any name";
            var existingTag = Tag.New(name);

            _repositoryMock.Setup(repository => repository.GetByName(name)).ReturnsAsync(existingTag);

            //Act
            var exception = await Record.ExceptionAsync(async () => await _service.Create(name));

            //Assert
            exception.Should().NotBeNull();

        }

        [Fact]
        public async void Given_insertion_error_should_throw_exception()
        {
            //Arrange
            const string name = "Any name";

            _repositoryMock.Setup(repository => repository.Insert(It.IsAny<Tag>())).
                ThrowsAsync(new Exception("Erro na conexão com o banco de dados"));

            //Act
            var exception = await Record.ExceptionAsync(async () => await _service.Create(name));

            //Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be("Falha ao inserir a tag.");
        }
    }
}
