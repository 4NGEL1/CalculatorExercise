// <summary>
// <copyright file="CalculatorService.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Services.Calculator.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Axity.Calculator.DataAccess.DAO.Calculator;
    using Axity.Calculator.Dtos.Calculator;
    using Axity.Calculator.Entities.Model;

    /// <summary>
    /// Class Calculator Service.
    /// </summary>
    public class CalculatorService : ICalculatorService
    {
        private readonly IMapper mapper;

        private readonly ICalculatorDao modelDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorService"/> class.
        /// </summary>
        /// <param name="mapper">Object to mapper.</param>
        /// <param name="modelDao">Object to modelDao.</param>
        public CalculatorService(IMapper mapper, ICalculatorDao modelDao)
        {
            this.mapper = mapper;
            this.modelDao = modelDao ?? throw new ArgumentNullException(nameof(modelDao));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CalculatorDto>> GetAllCalculatorAsync()
        {
            return this.mapper.Map<List<CalculatorDto>>(await this.modelDao.GetAllCalculatorAsync());
        }

        /// <inheritdoc/>
        public async Task<CalculatorDto> GetCalculatorAsync(int id)
        {
            return this.mapper.Map<CalculatorDto>(await this.modelDao.GetCalculatorAsync(id));
        }

        /// <inheritdoc/>
        public async Task<bool> InsertCalculator(CalculatorDto model)
        {
            return await this.modelDao.InsertCalculator(this.mapper.Map<CalculatorModel>(model));
        }
        /// <inheritdoc/>
        public float Suma(float a, float b, bool S){
            b = (S == false)? -b :b;
            float resultado = a+b;
            if (resultado<1.5E-38 || resultado>3.4E+38 ) throw new OverflowException();
            return checked(resultado);
        }
        /// <inheritdoc/>
        public float Multiplication(float a, float b, bool S){
            if( b == 0 && S == false ) throw new DivideByZeroException();
            b = (S == false)? 1/b : b;
            return checked(a*b);
        }
    }
}
