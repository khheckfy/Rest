﻿using Npgsql;
using RestaurantChain.Infrastructure.Repositories;
using RestaurantChain.Repository;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure
{
    internal sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NpgsqlConnection _connection;

        private IApplicationsForDistributionRepository _applicationsForDistributionRepository;
        private IAvailibilityInRestaurantRepository _availibilityInRestaurantRepository;
        private IBanksRepository _banksRepository;
        private IDishesRepository _dishesRepository;
        private IGroupsOfDishesRepository _groupsOfDishesRepository;
        private IMenuRepository _menuRepository;
        private INomenclatureRepository _nomenclatureRepository;
        private IProductsRepository _productsRepository;
        private IRestaurantsRepository _restaurantsRepository;
        private ISalesRepository _salesRepository;
        private IStreetsRepository _streetsRepository;
        private ISuppliersRepository _suppliersRepository;
        private ISuppliesRepository _suppliesRepository;
        private IUnitsRepository _unitsRepository;
        private IUserRightsRepository _userRightsRepository;
        private IUsersRepository _usersRepository;

        public UnitOfWork (string connectionString)
        {
            _connection = new NpgsqlConnection (connectionString);
            _connection.Open();
        }

        public IApplicationsForDistributionRepository ApplicationsForDistributionRepository =>
            _applicationsForDistributionRepository ??= new ApplicationsForDistribuitonRepository(_connection);
        public IAvailibilityInRestaurantRepository AvailibilityInRestaurantRepository => 
            _availibilityInRestaurantRepository ??= new AvailibilityInRestaurantRepository(_connection);
        public IBanksRepository BanksRepository => _banksRepository ??= new BanksRepository(_connection);
        public IDishesRepository DishesRepository => _dishesRepository ??= new DishesRepository(_connection);
        public IGroupsOfDishesRepository GroupsOfDishesRepository => _groupsOfDishesRepository ??= new GroupsOfDishesRepository(_connection);
        public IMenuRepository MenuRepository => _menuRepository ??= new MenuRepository(_connection);
        public INomenclatureRepository NomenclatureRepository => _nomenclatureRepository ??= new NomenclatureRepository(_connection);
        public IProductsRepository ProductsRepository => _productsRepository ??= new ProductsRepository(_connection);
        public IRestaurantsRepository RestaurantsRepository => _restaurantsRepository ??= new RestaurantsRepository(_connection);
        public ISalesRepository SalesRepository => _salesRepository ??= new SalesRepository(_connection);
        public IStreetsRepository StreetsRepository => _streetsRepository ??= new StreetsRepository(_connection);
        public ISuppliersRepository SuppliersRepository => _suppliersRepository ??= new SuppliersRepository(_connection);
        public ISuppliesRepository SuppliesRepository => _suppliesRepository ??= new SuppliesRepository(_connection);
        public IUnitsRepository UnitsRepository => _unitsRepository ??= new UnitsRepository(_connection);
        public IUserRightsRepository UserRightsRepository => _userRightsRepository ??= new UserRightsRepository(_connection);
        public IUsersRepository UsersRepository => _usersRepository ??= new UsersRepository(_connection);

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
            
        }
    }
}
