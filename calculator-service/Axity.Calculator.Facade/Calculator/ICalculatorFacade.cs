// <summary>
// <copyright file="ICalculatorFacade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Facade.Calculator
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Calculator.Dtos.Calculator;

    /// <summary>
    /// Interface User Facade.
    /// </summary>
    public interface ICalculatorFacade
    {
        /// <summary>
        /// Method for get all list of Users.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<CalculatorDto>> GetListCalculatorActive();

        /// <summary>
        /// Method for get User by id.
        /// </summary>
        /// <param name="id">Id User.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<CalculatorDto> GetListCalculatorActive(int id);

        /// <summary>
        /// Method to add user to DB.
        /// </summary>
        /// <param name="model">User Model.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> InsertCalculator(CalculatorDto model);

        float Suma(float a, float b, bool S);
        float Multiplication(float a, float b, bool S);
    }
}