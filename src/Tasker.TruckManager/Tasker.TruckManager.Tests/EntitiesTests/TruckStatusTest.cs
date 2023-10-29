using Tasker.TruckManager.Domain.Entities;
using Tasker.TruckManager.Domain.Enums;

namespace Tasker.TruckManager.Tests.EntitiesTests
{

    public class TruckStatusTest
    {
        [Fact]
        public void ShoudlHaveOutOfServiceStatus()
        {
            var truck = new Truck() { Name = "Test", Description = "truck" };

            truck.SetOutOfService();

            Assert.Equal(StatusEnum.OutOfService, truck.Status);
        }
        [Fact]
        public void ShoudlHaveAtJobStatus()
        {
            var truck = new Truck() { Name = "Test", Description = "truck" };

            Assert.True(truck.SetAtJob());

            Assert.Equal(StatusEnum.AtJob, truck.Status);
        }
        [Fact]
        public void ShouldNotAllowToChangeStatusToAtJob()
        {
            var truck = new Truck() { Name = "Test", Description = "truck" };

            truck.SetReturning();

            Assert.False(truck.SetAtJob());
            Assert.Equal(StatusEnum.Returning, truck.Status);
        }
        [Fact]
        public void ShoudlHaveLoadingStatus()
        {
            var truck = new Truck() { Name = "Test" };

            Assert.True(truck.SetLoading());

            Assert.Equal(StatusEnum.Loading, truck.Status);
        }
        [Fact]
        public void ShouldNotAllowToChangeStatusToLoading()
        {
            var truck = new Truck() { Name = "Test" };

            truck.SetReturning();

            Assert.False(truck.SetLoading());
            Assert.Equal(StatusEnum.Returning, truck.Status);
        }
        [Fact]
        public void ShoudlHaveToJobStatus()
        {
            var truck = new Truck() { Name = "Test" };

            Assert.True(truck.SetToJob());

            Assert.Equal(StatusEnum.ToJob, truck.Status);
        }
        [Fact]
        public void ShouldNotAllowToChangeStatusToToJob()
        {
            var truck = new Truck() { Name = "Test" };

            truck.SetReturning();

            Assert.False(truck.SetToJob());
            Assert.Equal(StatusEnum.Returning, truck.Status);
        }
        [Fact]
        public void ShoudlHaveReturningStatus()
        {
            var truck = new Truck() { Name = "Test" };

            Assert.True(truck.SetReturning());
            Assert.Equal(StatusEnum.Returning, truck.Status);
        }
        [Fact]
        public void ShouldNotAllowToChangeStatusToReturning()
        {
            var truck = new Truck() { Name = "Test" };

            truck.SetToJob();

            Assert.False(truck.SetReturning());
            Assert.Equal(StatusEnum.ToJob, truck.Status);
        }
        [Fact]
        public void ShoudlHaveReturnedStatus()
        {
            var truck = new Truck() { Name = "Test" };

            Assert.True(truck.SetReturned());
            Assert.Equal(StatusEnum.Returned, truck.Status);
        }
        [Fact]
        public void ShouldNotAllowToChangeStatusReturned()
        {
            var truck = new Truck() { Name = "Test" };

            truck.SetToJob();

            Assert.False(truck.SetReturned());
            Assert.Equal(StatusEnum.ToJob, truck.Status);
        }
    }
}
