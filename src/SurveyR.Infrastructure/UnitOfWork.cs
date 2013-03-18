using System;
using NHibernate;
using SurveyR.Core;
using SurveyR.Core.Contracts.Infrastructure;

namespace SurveyR.Infrastructure
{
    public class UnitOfWork
    {
        private static readonly IUnitOfWorkFactory _factory = new UnitOfWorkFactory();
        private static IUnitOfWork _innerUnitOfWork;

        public static IUnitOfWork Start()
        {
            if(_innerUnitOfWork != null)
            {
                throw new InvalidOperationException("Unit of work already started");
            }

            _innerUnitOfWork = _factory.Create();
            
            return _innerUnitOfWork;
        }

        public static IUnitOfWork Current
        {
            get
            {
                if(_innerUnitOfWork == null)
                {
                    throw new InvalidOperationException("Unit of work has not been started");
                }

                return _innerUnitOfWork;
            } 
            private set { _innerUnitOfWork = value; }
        }

        public static bool IsStarted
        {
            get
            {
                return _innerUnitOfWork != null;
            }
        }

        public static ISession CurrentSession
        {
            get { return _factory.CurrentSession; }
            internal set { _factory.CurrentSession = value; }
        }
    }
}