// <summary>
// <copyright file="ICalculatorDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.DataAccess.DAO.Calculator
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Calculator.Entities.Model;

    /// <summary>
    /// Interface IUserDao
    /// </summary>
    public interface  ICalculatorDao
    {
        /// <summary>
        /// Method for get all users from db.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<CalculatorModel>> GetAllCalculatorAsync();

        /// <summary>
        /// Method for get user by id from db.
        /// </summary>
        /// <param name="id">Calculator Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<CalculatorModel> GetCalculatorAsync(int id);

        /// <summary>
        /// Method for add Calculator to DB.
        /// </summary>
        /// <param name="model">Calculator Dto.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> InsertCalculator(CalculatorModel model);
    }
}
