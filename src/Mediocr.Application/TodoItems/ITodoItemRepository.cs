﻿using Mediocr.Application.Infrastructure;
using Raven.Client;

namespace Mediocr.Application.TodoItems
{
    public interface IRepository<T>
    {
        T Load(object id);
        void Add(T state);
    }

    public class EntityRepository<T> : IRepository<T>
    {
        private readonly IManageUnitOfWork _uow;
        private readonly IDocumentSession _session;

        public EntityRepository(IManageUnitOfWork uow, IDocumentSession session)
        {
            _uow = uow;
            _session = session;
        }

        public T Load(object id)
        {
            var state = _session.Load<T>(id.ToString());
            _uow.Put(state);
            return state;
        }

        public void Add(T state)
        {
            _uow.Put(state);
            _session.Store(state);
        }
    }
}