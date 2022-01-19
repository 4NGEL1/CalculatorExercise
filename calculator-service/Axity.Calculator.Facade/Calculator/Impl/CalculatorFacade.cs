// <summary>
// <copyright file="CalculatorFacade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Facade.Calculator.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Calculator.Dtos.Calculator;
    using Axity.Calculator.Services.Calculator;

    /// <summary>
    /// Class Calculator Facade.
    /// </summary>
    public class CalculatorFacade : ICalculatorFacade
    {
        private readonly ICalculatorService modelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorFacade"/> class.
        /// </summary>
        /// <param name="modelService">Interface Calculator Service.</param>
        public CalculatorFacade(ICalculatorService modelService)
        {
            this.modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CalculatorDto>> GetListCalculatorActive()
        {
            return await this.modelService.GetAllCalculatorAsync();
        }

        /// <inheritdoc/>
        public async Task<CalculatorDto> GetListCalculatorActive(int id)
        {
            return await this.modelService.GetCalculatorAsync(id);
        }

        /// <inheritdoc/>
        public async Task<bool> InsertCalculator(CalculatorDto model)
        {
            return await this.modelService.InsertCalculator(model);
        }

        /// <inheritdoc/>
        public float Suma(float a, float b, bool S){
            return this.modelService.Suma(a,b,S);
        }
        public float Multiplication(float a, float b, bool S){
            return this.modelService.Multiplication(a,b,S);
        }
    }
}
