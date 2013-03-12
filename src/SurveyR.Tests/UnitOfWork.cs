using System;

namespace SurveyR.Tests
{
    public class UnitOfWork
    {
        private static IUnitOfWorkFactory _factory = new UnitOfWorkFactory();
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
    }
}