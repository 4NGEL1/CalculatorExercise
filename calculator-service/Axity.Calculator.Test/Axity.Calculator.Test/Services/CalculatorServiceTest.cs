// <summary>
// <copyright file="CalculatorServiceTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Test.Services.Calculator
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Axity.Calculator.DataAccess.DAO.Calculator;
    using Axity.Calculator.Entities.Context;
    using Axity.Calculator.Services.Mapping;
    using Axity.Calculator.Services.Calculator;
    using Axity.Calculator.Services.Calculator.Impl;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using Axity.LeadToCash.Resources.Db;
    /// <summary>
    /// Class CalculatorServiceTest.
    /// </summary>
    [TestFixture]
    public class CalculatorServiceTest : BaseTest
    {
        private ICalculatorService modelServices;

        private IMapper mapper;

        private ICalculatorDao modelDao;

        /// <summary>
        /// Init configuration.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            this.mapper = mapperConfiguration.CreateMapper();

            Users.ListUsers = this.GetAllCalculators().ToList();

            this.modelDao = new CalculatorDao();
            this.modelServices = new CalculatorService(this.mapper, this.modelDao);
        }

        /// <summary>
        /// Method to verify Get All Calculators.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateGetAllCalculators()
        {
            var result = await this.modelServices.GetAllCalculatorAsync();

            Assert.True(result != null);
            Assert.True(result.Any());
        }

        /// <summary>
        /// Method to validate get model by id.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateSpecificCalculators()
        {
            var result = await this.modelServices.GetCalculatorAsync(2);

            Assert.True(result != null);
            Assert.True(result.FirstName == "Jorge");
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task InsertCalculator()
        {
            // Arrange
            var model = this.GetCalculatorDto();

            // Act
            var result = await this.modelServices.InsertCalculator(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
        //TDD Suma
        [Test]
        public void ReturnThreedotThreeWhenNumberaIsTwodotTwoAndNumberbIsOnedotOne(){
            var response = this.modelServices.Suma(2.2f,1.1f,true);
            Assert.AreEqual(3.3,response);
        }
        [Test]
        [ExpectedException(typeof(OverflowException(),"Desbordamiento")]
        public void ExceptionOverFlow(){
            var response = this.modelServices.Multiplication(3.4E+38f,1,false);
        }
        //TDD Resta
        [Test]
        public void ReturnNegativeNumberWhenTheSecondNumberIsGreatherThanFirst(){
            var response = this.modelServices.Suma(1,2,false);
            Assert.AreEqual(-1,response);
        }
        [Test]
        public void ReturnZeroWhenBothNumbersAreEquals(){
            var response = this.modelServices.Suma(2,2,false);
            Assert.AreEqual(0,response);
        }
        //TDD Multiplicacion
        [Test]
        public void ReturnZeroWhenAnyNumberIsZero(){
            var response = this.modelServices.Multiplication(0,1.1f,true);
            Assert.AreEqual(0,response);
        }
        

        //TDD Division
        [Test]
        public void ReturnZeroWhenFirstNumberIsZero(){
            var response = this.modelServices.Multiplication(0,1.1f,false);
            Assert.AreEqual(0,response);
        }
        [Test]
        public void ReturnOneWhenBothNumbersAreSame(){
            var response = this.modelServices.Multiplication(9,9,false);
            Assert.AreEqual(1,response);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException(),"Division por cero")]
        public void DividedByZeroWhenBIsZero(){
            var response = this.modelServices.Multiplication(0,0,false);
        }
       
    }
}
