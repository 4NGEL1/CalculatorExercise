// <summary>
// <copyright file="CalculatorDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.DataAccess.DAO.Calculator
{
    using Axity.Calculator.Entities.Context;
    using Axity.Calculator.Entities.Model;
    using Axity.LeadToCash.Resources.Db;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Class Calculator Dao
    /// </summary>
    public class CalculatorDao : ICalculatorDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorDao"/> class.
        /// </summary>
        public CalculatorDao()
        {
            Users.ListUsers = new List<CalculatorModel>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CalculatorModel>> GetAllCalculatorAsync()
        {
            return Users.ListUsers;
        }

        /// <inheritdoc/>
        public async Task<CalculatorModel> GetCalculatorAsync(int id)
        {
            return Users.ListUsers.FirstOrDefault(p => p.Id.Equals(id));
        }

        /// <inheritdoc/>
        public async Task<bool> InsertCalculator(CalculatorModel model)
        {
            Users.ListUsers.Add(model);
            return true;
        }
    }
}
