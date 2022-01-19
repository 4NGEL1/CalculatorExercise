// <summary>
// <copyright file="FacadeTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Test.Facade
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using Axity.Calculator.Dtos.Calculator;
    using Axity.Calculator.Facade.Calculator.Impl;
    using Axity.Calculator.Services.Calculator;

    /// <summary>
    /// Class CalculatorServiceTest.
    /// </summary>
    [TestFixture]
    public class FacadeTest : BaseTest
    {
        private CalculatorFacade modelFacade;

        /// <summary>
        /// The init.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mockServices = new Mock<ICalculatorService>();
            var model = this.GetCalculatorDto();
            IEnumerable<CalculatorDto> listCalculator = new List<CalculatorDto> { model };

            mockServices
                .Setup(m => m.GetAllCalculatorAsync())
                .Returns(Task.FromResult(listCalculator));

            mockServices
                .Setup(m => m.GetCalculatorAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(model));

            mockServices
                .Setup(m => m.InsertCalculator(It.IsAny<CalculatorDto>()))
                .Returns(Task.FromResult(true));

            this.modelFacade = new CalculatorFacade(mockServices.Object);
        }

        /// <summary>
        /// Test for selecting all models.
        /// </summary>
        /// <returns>nothing.</returns>
        [Test]
        public async Task GetAllCalculatorAsyncTest()
        {
            // arrange

            // Act
            var response = await this.modelFacade.GetListCalculatorActive();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// gets the model.
        /// </summary>
        /// <returns>the model with the correct id.</returns>
        [Test]
        public async Task GetListCalculatorActive()
        {
            // arrange
            var id = 10;

            // Act
            var response = await this.modelFacade.GetListCalculatorActive(id);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(id, response.Id);
        }

        /// <summary>
        /// Test for inseting models.
        /// </summary>
        /// <returns>the bool if it was inserted.</returns>
        [Test]
        public async Task InsertCalculator()
        {
            // Arrange
            var model = new CalculatorDto();

            // Act
            var response = await this.modelFacade.InsertCalculator(model);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response);
        }
    }
}
