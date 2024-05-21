using Catalog.Domain.Entities;
using LF.GenericRepository.EntityFrameworkCore.Repository;

namespace Catalog.Domain.Interfaces;

public interface ICategoriesRepository : IGenericRepository<Category> { }