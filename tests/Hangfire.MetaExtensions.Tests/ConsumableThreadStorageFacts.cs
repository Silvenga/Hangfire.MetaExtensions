using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Hangfire.MetaExtensions.Tests
{
    public class ConsumableThreadStorageFacts
    {
        private static readonly Fixture AutoFixture = new Fixture();

        [Fact]
        public void On_Add_items_should_exist()
        {
            var str = AutoFixture.Create<string>();

            // Act
            ConsumableThreadStorage<string>.Add(str);

            // Assert
            ConsumableThreadStorage<string>.GetAllAndClear().Should().OnlyContain(x => x == str);
        }

        [Fact]
        public void GetAllAndClear_should_clear_all_values()
        {
            var str = AutoFixture.Create<string>();

            // Act
            ConsumableThreadStorage<string>.Add(str);
            ConsumableThreadStorage<string>.GetAllAndClear();

            // Assert
            ConsumableThreadStorage<string>.GetAllAndClear().Should().BeEmpty();
        }

        [Fact]
        public void ConsumableThreadStorage_should_act_as_thread_static()
        {
            var str = AutoFixture.Create<string>();

            // Act
            Task.Run(() => ConsumableThreadStorage<string>.Add(str));

            // Assert
            ConsumableThreadStorage<string>.GetAllAndClear().Should().BeEmpty();
        }
    }
}