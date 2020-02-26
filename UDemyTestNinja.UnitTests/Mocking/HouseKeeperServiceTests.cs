using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace UDemyTestNinja.UnitTests.Mocking
{
    [TestFixture]
    class HouseKeeperServiceTests
    {
        private HouseKeeperService _service;

        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;

        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _houseKeeper;
        private string _statementFilename;

        [SetUp]
        public void SetUp()
        {
            _houseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _houseKeeper
            }.AsQueryable());

            _statementFilename = "fileName";
            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator
                .Setup(sg =>
                sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns(() => _statementFilename);

            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            _service = new HouseKeeperService(
                _unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => sg.SaveStatement(
                _houseKeeper.Oid,
                _houseKeeper.FullName,
                _statementDate));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HouseKeeperIsNullOrEmptyOrWhitespace_ShouldNotGenerateStatements(string errorEmail)
        {
            _houseKeeper.Email = errorEmail;

            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => sg.SaveStatement(
                _houseKeeper.Oid,
                _houseKeeper.FullName,
                _statementDate),
                Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _service.SendStatementEmails(_statementDate);

            VerifyEmailSent();
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_StatementFilenameIsNullOrEmptyOrWhitespace_ShouldNotEmailStatement(string errorstatementFilename)
        {
            _statementFilename = errorstatementFilename;

            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [Test]

        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            _emailSender.Setup(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                )).Throws<Exception>();

            _service.SendStatementEmails(_statementDate);

            VerifyMessageBoxDisplay();
        }

        private void VerifyMessageBoxDisplay()
        {
            _messageBox.Verify(mb => mb.Show(
                It.IsAny<string>(),
                It.IsAny<string>(),
                MessageBoxButtons.OK
                ));
        }

        private void VerifyEmailNotSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }

        private void VerifyEmailSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                _houseKeeper.Email,
                _houseKeeper.StatementEmailBody,
                _statementFilename,
                It.IsAny<string>()));
        }
    }
}
