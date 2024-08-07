﻿using Domain.Entities;

namespace Domain.Interface;

public interface ICinemaRepository : IGeneralRepository
{
    Task<IEnumerable<Cinema>> GetCinemasAsync();
    Task<Cinema?> GetCinemaByIdAsync(int? id);
}
