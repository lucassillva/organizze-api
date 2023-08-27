using FluentAssertions;
using Organizze.Domain.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Organizze.Domain.UnitTest.Entities
{
    public class TagTest
    {
        [Fact]
        public void Given_valid_name_should_creaty_tag()
        {
            // Arrange
            const string name = "Any";

            // Act
            var tag = Tag.New(name);

            // Assert
            tag.Should().NotBeNull();
            tag.Name.Should().Be(name);
            tag.Id.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData("hjsdkfgajshkdfgjkgajkshfgajkhsfgjkhasfgjkh")]
        public void Given_invalid_name_should_not_create_tag(string name)
        {
            //Arrange
            var exception = Record.Exception(() => Tag.New(name));

            //Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ArgumentException>();
        }
    }
}
