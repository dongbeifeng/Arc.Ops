using NHibernate;
using NSubstitute;
using Xunit;
using static NSubstitute.Substitute;

namespace Arc.Ops.Tests
{
    public class OpHelperTests
    {
        [Fact()]
        public async Task SaveOpAsyncTestAsync()
        {
            ISession session = For<ISession>();
            OpHelper sut = new OpHelper(session);
            var op = await sut.SaveOpAsync("A", "B", "C", "{0} {1}", "D", "E");
            
            Assert.Equal("A", op.OperationType);
            Assert.Equal("B", op.Url);
            Assert.Equal("C", op.IPAddress);
            Assert.Equal("D E", op.Comment);
            await session.Received().SaveAsync(op);
        }
    }
}