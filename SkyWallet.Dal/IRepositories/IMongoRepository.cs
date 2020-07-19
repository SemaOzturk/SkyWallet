using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SkyWallet.Dal.IRepositories
{
    public interface IMongoRepository<TDocument> where TDocument :IDocument
    {
        IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);

        TDocument GetByKey(string id);
        void Insert(TDocument document);
        void InsertMany(ICollection<TDocument> documents);
        IQueryable<TDocument> GetAll();
        void Update(TDocument document);
        void Delete(string id);


    }
}
