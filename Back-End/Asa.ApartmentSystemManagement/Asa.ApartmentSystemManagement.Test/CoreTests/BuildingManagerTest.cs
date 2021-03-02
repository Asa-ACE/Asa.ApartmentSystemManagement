using NUnit.Framework;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Managers;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System.Threading.Tasks;
using System;
using Moq;

namespace Asa.ApartmentSystemManagement.Test.CoreTests
{
    public class BuildingManagerTest
    {
        [SetUp]
        public void Setup() { }
        private bool AreEqualBuildingDto(BuildingDTO expected , BuildingDTO actual)
        {
            return expected.Id == actual.Id 
                & expected.Name == actual.Name 
                & expected.NumberOfUnits == actual.NumberOfUnits 
                & expected.Address == actual.Address;
        }
        
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

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => buildingManager.AddBuildingAsync(building));
            Assert.That(ex.ParamName, Is.EqualTo("Building Cannot be empty!"));
        }

        [Test]
        public void AddBuildingAsync_EmptyNameAndLessThan2Units_ThrowsNameException()
        {
            int myId = 10;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            mock_IBuildingTableGateway.Setup(x => x.InsertBuildingAsync(It.IsAny<BuildingDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);

            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            BuildingDTO building = new BuildingDTO { Id = 20, Name = string.Empty, NumberOfUnits = 0 };

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => buildingManager.AddBuildingAsync(building));
            Assert.That(ex.ParamName, Is.EqualTo("Building Cannot be empty!"));
        }

        [Test]
        public void AddBuildingAsync_LessThan2Units_ThrowsException()
        {
            int myId = 10;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            mock_IBuildingTableGateway.Setup(x => x.InsertBuildingAsync(It.IsAny<BuildingDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);
            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            BuildingDTO building = new BuildingDTO { Id = 20, Name = "buildingname", NumberOfUnits = 1 };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => buildingManager.AddBuildingAsync(building));
            Assert.That(ex.ParamName, Is.EqualTo("Building cannot have less than two units!"));
        }

        [Test]
        public async Task AddBuildingAsync_AddedSuccessfully_ReturnsSameId()
        {
            int myId = 10;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            mock_IBuildingTableGateway.Setup(x => x.InsertBuildingAsync(It.IsAny<BuildingDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);

            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            BuildingDTO building = new BuildingDTO { Id = 20, Name = "A", NumberOfUnits = 2 };

            await buildingManager.AddBuildingAsync(building);

            Assert.AreEqual(building.Id, myId);
        }
        [Test]
        public async Task GetBuildingByIdAsync_GotSuccessfully_ReturnedBuildingDTO()
        {
            int id = 2;
            var testDTO = new BuildingDTO
            {
                Id = 2,
                Name = "building_1",
                Address = "somewhere",
                NumberOfUnits = 2
            };
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            mock_IBuildingTableGateway.Setup(x => x.GetBuildingByIdAsync(It.IsAny<int>())).ReturnsAsync(testDTO);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);
            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            var result = await buildingManager.GetBuildingByIdAsync(id);
            Assert.IsTrue(AreEqualBuildingDto(testDTO,result));
        }
        [Test]
        public async Task AddUnitAsync_AddedSuccessfully_PassValidate()
        {
            int myId = 1;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IUnitTableGateway> mock_IUnitTableGateway = new Mock<IUnitTableGateway>();
            mock_IUnitTableGateway.Setup(x => x.InsertUnitAsync(It.IsAny<UnitDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateUnitTableGateway()).Returns(mock_IUnitTableGateway.Object);
            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            var testDTO = new UnitDTO
            {
                BuildingId = 1,
                Area = 20,
                Description = "hello" ,
                UnitNumber = 1 ,
            };

            await buildingManager.AddUnitAsync(testDTO);
            Assert.AreEqual(testDTO.Id, myId);
        }

        [Test]
        public void AddUnitAsync_LessThan20Area_ValidateException()
        {
            int myId = 1;
            Mock<ITableGatewayFactory> mock_ITableGatwayFactory = new Mock<ITableGatewayFactory>();
            Mock<IUnitTableGateway> mock_IUnitTableGateway = new Mock<IUnitTableGateway>();
            mock_IUnitTableGateway.Setup(x => x.InsertUnitAsync(It.IsAny<UnitDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateUnitTableGateway()).Returns(mock_IUnitTableGateway.Object);
            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            var testDTO = new UnitDTO
            {
                BuildingId = 1,
                Area = 19,
                Description = "hello",
                UnitNumber = 1,
            };
            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => buildingManager.AddUnitAsync(testDTO));
            Assert.That(ex.ParamName, Is.EqualTo("Unit area cannot be less than 20!"));
        }
    }
}