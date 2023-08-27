using FluentAssertions;
using Organizze.Domain.Entities.Categories;
using Xunit;

namespace Organizze.Domain.UnitTest.Entities;

public class CategoryTest
{
    [Fact]
    public void Given_valid_name_should_create_category()
    {
        // Arrange
        const string name = "Any";

        // Act
        var category = Category.New(name);

        // Assert
        category.Should().NotBeNull();
        category.Name.Should().Be(name);
        category.Id.Should().NotBeEmpty();
    }

    [Theory]
    [InlineData("")]
    [InlineData("asdfasdfasdfasdfasdfasdfasdfasdf")]
    public void Given_invalid_name_should_not_create_category(string name)
    {
        // Arrange & Act
        var exception = Record.Exception(() => Category.New(name));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<ArgumentException>();
    }
}