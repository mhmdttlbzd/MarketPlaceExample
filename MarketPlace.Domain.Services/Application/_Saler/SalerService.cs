﻿using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Saler
{
    public class SalerService : ISalerService
    {
        private readonly ISalerRepo _salerRepo;

        public SalerService(ISalerRepo salerRepo)
        {
            _salerRepo = salerRepo;
        }

        public async Task<int> CreateAsync(SalerInputDto input, CancellationToken cancellationToken)
            => await _salerRepo.CreateAsync(input, cancellationToken);

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
            =>await _salerRepo.DeleteAsync(id, cancellationToken);

        public async Task<List<SalerOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => await _salerRepo.GetAllAsync(cancellationToken);

        public async Task<SalerOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _salerRepo.GetByIdAsync(id, cancellationToken);

        public async Task UpdateAsync(SalerInputDto input, int id, CancellationToken cancellationToken)
            =>await _salerRepo.UpdateAsync(input, id, cancellationToken);

        public int AllSalersCount() => _salerRepo.AllSalersCount();
        public async Task<List<GeneralSalerDto>> GetGeneralSalers(CancellationToken cancellationToken)
            => await _salerRepo.GetGeneralSalers(cancellationToken);
    }
}
