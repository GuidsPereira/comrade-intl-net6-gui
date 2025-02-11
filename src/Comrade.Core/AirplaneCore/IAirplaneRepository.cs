﻿using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Models;

namespace Comrade.Core.AirplaneCore;

public interface IAirplaneRepository : IRepository<Airplane>
{
    Task<ISingleResult<Airplane>> ValidateSameCode(Guid id, string code);
}