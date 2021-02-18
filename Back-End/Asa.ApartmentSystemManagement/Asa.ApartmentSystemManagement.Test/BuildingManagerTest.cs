using NUnit.Framework;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Managers;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System.Threading.Tasks;
using System;
using Moq;

namespace Asa.ApartmentSystemManagement.Test
{
    public class BuildingManagerTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void AddBuildingAsync_EmptyName_ThrowsException()
        {
            int myId = 10;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            mock_IBuildingTableGateway.Setup(x => x.InsertBuildingAsync(It.IsAny<BuildingDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);

            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            BuildingDTO building = new BuildingDTO { Id = 0, Name = string.Empty, NumberOfUnits = 30 };

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => buildingManager.AddBuilding(building));
            Assert.That(ex.ParamName, Is.EqualTo("Building Cannot be empty!"));
        }

        [Test]
        public void AddBuilding_EmptyNameAndLessThan2Units_ThrowsNameException()
        {
            int myId = 10;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            mock_IBuildingTableGateway.Setup(x => x.InsertBuildingAsync(It.IsAny<BuildingDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);

            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            BuildingDTO building = new BuildingDTO { Id = 20, Name = string.Empty, NumberOfUnits = 0 };

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => buildingManager.AddBuilding(building));
            Assert.That(ex.ParamName, Is.EqualTo("Building Cannot be empty!"));
        }

        [Test]
        public void AddBuilding_LessThan2Units_ThrowsException()
        {
            int myId = 10;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            mock_IBuildingTableGateway.Setup(x => x.InsertBuildingAsync(It.IsAny<BuildingDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);
            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            BuildingDTO building = new BuildingDTO { Id = 20, Name = "buildingname", NumberOfUnits = 1 };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => buildingManager.AddBuilding(building));
            Assert.That(ex.ParamName, Is.EqualTo("Building cannot have less than two units!"));
        }

        [Test]
        public async Task AddBuilding_AddedSuccessfully_ReturnsSameId()
        {
            int myId = 10;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            mock_IBuildingTableGateway.Setup(x => x.InsertBuildingAsync(It.IsAny<BuildingDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);

            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            BuildingDTO building = new BuildingDTO { Id = 20, Name = "A", NumberOfUnits = 2 };

            await buildingManager.AddBuilding(building);

            Assert.AreEqual(building.Id, myId);
        }

    }
}