﻿using Microsoft.EntityFrameworkCore;
using World.Api.Data;
using World.Api.Model;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class CountryRepository: ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Country entity) { 
            await _dbContext.Countries.AddAsync(entity);
            await Save();
        }

        public async Task Update(Country entity) {
            _dbContext.Countries.Update(entity);
            await Save();
        }

        public async Task Delete(Country entity) {
            _dbContext.Countries.Remove(entity);
            await Save();

        }

        public async Task<List<Country>> GetAll() {
            List<Country> countries = await _dbContext.Countries.ToListAsync();
            return countries;
        }

        public async Task<Country> GetById(int id) {
            Country country = await _dbContext.Countries.FindAsync(id);
            return country;

        }


        public bool IsCountryExists(string name)
        {
            var result = _dbContext.Countries.AsQueryable().Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result; 
        }

        public async Task Save() {

            await _dbContext.SaveChangesAsync();

        }
    }
}
