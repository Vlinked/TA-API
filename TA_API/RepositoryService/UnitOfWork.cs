using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TA_API.EntityModels;
using TA_API.IRepositoryService;

namespace TA_API.RepositoryService
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The _context
        /// </summary>
        private readonly VlinkdbContext _context;


        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public UnitOfWork(VlinkdbContext context)
        {

            _context = context;
        }
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            return _context.SaveChanges();
        }
        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();

                }
            }
        }
    }
}
