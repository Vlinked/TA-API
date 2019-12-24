using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TA_API.EntityModels;
using TA_API.IRepositoryService;

namespace TA_API.RepositoryService
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private VlinkdbContext _context = null;
        private IUnitOfWork _unitOfWork = null;
        private DbSet<T> table = null;
        private IDbContextTransaction _transaction = null;

        public GenericRepository(VlinkdbContext _context, IUnitOfWork unitOfWork)
        {
            this._context = _context;
            this._unitOfWork = unitOfWork;
            //_transaction = _context.Database.BeginTransaction();
            table = _context.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {
            var TList = table.ToList();
            _unitOfWork.Dispose();
            return TList;
        }

        public T GetById(object id)
        {
            var GetByIdlist = table.Find(id);
            return GetByIdlist;
        }

        public void Insert(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }
            table.Add(obj);
        }

        public void Update(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
                //_transaction = _context.Database.BeginTransaction();
                // _transaction.Commit();
                _unitOfWork.Dispose();
            }
            catch (Exception ex)
            {
                // _transaction.Rollback();
                throw ex;
            }
            finally
            {
                //_transaction.Dispose();

            }
        }

        public void Delete(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }
            table.Remove(obj);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var FindByresult = this._context.Set<T>().Where(expression);
            //_unitOfWork.Dispose();
            return FindByresult;
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = this._context.Set<T>().Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }



    }
}
