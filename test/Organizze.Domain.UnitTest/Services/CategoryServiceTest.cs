using FluentAssertions;
using Moq;
using Organizze.Domain.Entities.Categories;
using Organizze.Domain.Repositories.Categories;
using Organizze.Domain.Services;
using Xunit;

namespace Organizze.Domain.UnitTest.Services;

public class CategoryServiceTest
{
    private readonly CategoryService _service;
    private readonly Mock<ICategoryRepository> _repositoryMock;

    public CategoryServiceTest()
    {
        _repositoryMock = new Mock<ICategoryRepository>();
        _service = new CategoryService(_repositoryMock.Object);
    }

    [Fact]
    public async Task Given_valid_input_should_create_category()
    {
        // Arrange
        const string name = "Valid name";

        // Act
        var category = await _service.Create(name);

        // Assert
        category.Should().NotBeNull();
        _repositoryMock.Verify(repository => repository.GetByName(It.IsAny<string>()), Times.Once);
        _repositoryMock.Verify(repository => repository.Insert(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public async Task When_category_already_exist_should_throw_exception()
    {
        // Arrange
        const string name = "Any name";
        var existingCategory = Category.New(name);

        _repositoryMock.Setup(repository => repository.GetByName(name)).ReturnsAsync(existingCategory);

        // Act
        var exception = await Record.ExceptionAsync(async () => await _service.Create(name));

        // Assert
        exception.Should().NotBeNull();
    }

    // Uma exception no Insert
    [Fact]
    public async Task When_exception_category_insertion_should_throw_exception()
    {
        // Arrange
        const string name = "Any name";

        _repositoryMock.Setup(repository => repository.Insert(It.IsAny<Category>()))
            .ThrowsAsync(new Exception("Erro de conexão com o banco de dados."));

        // Act
        var exception = await Record.ExceptionAsync(async () => await _service.Create(name));

        // Assert
        exception.Should().NotBeNull();
        exception.Message.Should().Be("Falha ao inserir a categoria.");
    }

    [Fact]
    public async void Given_registered_categories_should_return_all_categories()
    {
        // Arrange
        var category = Category.New("any");
        var categories = new List<Category>() { category };

        _repositoryMock.Setup(repository => repository.GetAllCategories()).ReturnsAsync(categories);
        
        // Act
        var allCategories = await _service.GetAllCategories();

        // Assert
        allCategories.Should().NotBeNull();
        allCategories.Should().Contain(category);
    }
}