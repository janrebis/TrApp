using AutoFixture;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;
using TrApp.Identity;
using TrApp.Models;
using TrApp.Repository;
using TrApp.Services;
using EntityFrameworkCoreMock;
using TrApp.RepositoryContracts;
using System.Linq.Expressions;

namespace Tests
{
    //public class DatabaseTestBase<TRepository, TService, TEntity, TDbContext>
    //    where TRepository : class
    //    where TService : class
    //    where TEntity : class
    //    where TDbContext : DbContext
    //{
    //    protected readonly IFixture Fixture;
    //    protected readonly TRepository Repository;
    //    protected readonly TService Service;
    //    protected readonly List<TEntity> TestData;
    //    protected readonly Mock<TDbContext> DbContextMock;
    //    protected readonly TDbContext DbContext;

    //    protected DatabaseTestBase()
    //    {
    //        Fixture = new Fixture();
    //        TestData = new List<TEntity>();

    //        var options = new DbContextOptionsBuilder<TDbContext>().Options;
    //        DbContextMock = new Mock<TDbContext>(options) { CallBase = true };
    //        DbContext = DbContextMock.Object;

    //        Repository = CreateRepository(DbContext);
    //        Service = CreateService(Repository);

            
    //    }

    //    private TService CreateService(TRepository repository)
    //    {
    //        return Activator.CreateInstance(typeof(TService), repository) as TService;
    //    }

    //    private TRepository CreateRepository(TDbContext dbContext)
    //    {
    //        return Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository;
    //    }

    //    public static void SetupDbSetMock<T, TEntity>(
    //         this DbContextMock<T> dbContextMock,
    //         Expression<Func<T, DbSet<TEntity>>> dbSetSelector,
    //         List<TEntity> initialData)
    //         where T : DbContext
    //         where TEntity : class
    //            {
    //        dbContextMock.CreateDbSetMock(dbSetSelector, initialData);
    //    }


    //}
}