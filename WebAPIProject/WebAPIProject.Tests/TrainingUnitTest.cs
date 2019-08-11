using Microsoft.AspNetCore.Mvc;
using System;
using WebAPIProject.Controllers;
using WebAPIProject.Models;
using Xunit;

namespace WebAPIProject.Tests
{
    public class TrainingUnitTes
    {
        private TrainingData SetupValidData()
        {
            return new TrainingData { TrainingName = "Test training 1", StartDate = new DateTime(2019, 08, 10), EndDate = new DateTime(2019, 08, 19) };
        }

        private TrainingData SetupInValidEndDateData()
        {
            return new TrainingData { TrainingName = "Test training 1", StartDate = new DateTime(2019, 08, 10), EndDate = new DateTime(2019, 08, 08) };
        }

        private TrainingData SetupInValidDateData()
        {
            return new TrainingData { TrainingName = "Test training 1", StartDate = DateTime.MinValue, EndDate = DateTime.MinValue };
        }

        [Fact]
        public void Save_Training_Success()
        {
            //Arrange
            var training = SetupValidData();

           
            //Act
            var trainingController = new TrainingController();

            var actionResult =  trainingController.Post(training);

            //Assert
            var viewResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            Assert.IsAssignableFrom<int>(viewResult.StatusCode.GetValueOrDefault());
            Assert.Equal<int>(200, viewResult.StatusCode.GetValueOrDefault());
        }
        [Fact]
        public void Save_Training_InValid_EndDate()
        {
            //Arrange
            var training = SetupInValidDateData();


            //Act
            var trainingController = new TrainingController();

            var actionResult = trainingController.Post(training);

            //Assert
            var viewResult = Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult.Result);
            Assert.IsAssignableFrom<int>(viewResult.StatusCode.GetValueOrDefault());
            Assert.Equal<int>(400, viewResult.StatusCode.GetValueOrDefault());
        }

        [Fact]
        public void Save_Training_Invalid_Dates()
        {
            //Arrange
            var training = SetupInValidDateData();


            //Act
            var trainingController = new TrainingController();

            var actionResult = trainingController.Post(training);

            //Assert
            var viewResult = Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult.Result);
            Assert.IsAssignableFrom<int>(viewResult.StatusCode.GetValueOrDefault());
            Assert.Equal<int>(400, viewResult.StatusCode.GetValueOrDefault());
        }
    }
}
