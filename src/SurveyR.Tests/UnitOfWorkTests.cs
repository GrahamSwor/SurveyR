using System;
using System.Reflection;
using Moq;
using NHibernate;
using NUnit.Framework;
using Should;

namespace SurveyR.Tests
{
    [TestFixture]
    public class UnitOfWorkTests
    {

        private Mock<IUnitOfWorkFactory> _mockFactory = new Mock<IUnitOfWorkFactory>();
        private Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
        private Mock<ISession> _mockSession = new Mock<ISession>();
        private IUnitOfWorkFactory _factory;
        private IUnitOfWork _unitOfWork;
        private ISession _session;

        [SetUp]
        public void SetUp()
        {
            _factory = _mockFactory.Object;
            _unitOfWork = _mockUnitOfWork.Object;
            _session = _mockSession.Object;

            var fieldInfo = typeof(UnitOfWork).GetField("_factory", BindingFlags.Static | BindingFlags.NonPublic);
            fieldInfo.SetValue(null, _factory);

            _mockFactory.Setup(x => x.Create()).Returns(_unitOfWork);
            _mockFactory.Setup(x => x.CurrentSession).Returns(_session);
        }

        [TearDown]
        public void TearDown()
        {
            var fieldInfo = typeof(UnitOfWork).GetField("_innerUnitOfWork", BindingFlags.Static | BindingFlags.NonPublic);
            fieldInfo.SetValue(null, null);
        }

        [Test]
        public void should_start_unit_of_work()
        {
            IUnitOfWork uow = UnitOfWork.Start();
            uow.ShouldEqual(_unitOfWork);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void should_throw_if_starting_UnitOfWork_if_already_started()
        {
            UnitOfWork.Start();
            UnitOfWork.Start();
        }

        [Test]
        public void should_be_able_to_access_Current_UnitOfWwork()
        {
            var uow = UnitOfWork.Start();
            var current = UnitOfWork.Current;
            current.ShouldEqual(uow);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void should_throw_if_Current_accessed_before_Start()
        {
            var current = UnitOfWork.Current;
        }

        [Test]
        public void should_tell_if_IsStarted()
        {
            UnitOfWork.IsStarted.ShouldEqual(false);
            UnitOfWork.Start();
            UnitOfWork.IsStarted.ShouldEqual(true);
        }

        [Test]
        public void should_get_current_ISession_if_started()
        {
            using(UnitOfWork.Start())
            {
                ISession session = UnitOfWork.CurrentSession;
                session.ShouldNotBeNull();
            }
        }
    }
}