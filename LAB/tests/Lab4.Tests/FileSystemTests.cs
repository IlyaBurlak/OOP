using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.SystemCommandReader;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemTests
{
    [Fact]
    public void ProcessCommandsInvalidCommandEmptyCommandLogged()
    {
        // Arrange
        var commandReaderMock = new Mock<ICommandReader>();
        commandReaderMock.Setup(cr => cr.ReadCommand()).Returns("connect /Users/ilaburlak/Deskto/test.rtf -m local");

        var loggerMock = new Mock<ILogger>();

        var fileSystem = new FileSystemFakeForTest(commandReaderMock.Object, loggerMock.Object, null);

        // Act
        fileSystem.ProcessCommands();

        // Assert
        loggerMock.Verify(l => l.Log("Файл не найден по адресу /Users/ilaburlak/Deskto/test.rtf."), Times.Once);
    }

    [Fact]
    public void ProcessCommandsCommandEmptyCommandLoggedFailid()
    {
        // Arrange
        var commandReaderMock = new Mock<ICommandReader>();
        commandReaderMock.Setup(cr => cr.ReadCommand()).Returns("list /Users/ilaburlak/Desktop");

        var loggerMock = new Mock<ILogger>();

        var fileSystem = new FileSystemFakeForTest(commandReaderMock.Object, loggerMock.Object, null);

        // Act
        fileSystem.ProcessCommands();

        // Assert
        loggerMock.Verify(l => l.Log("must be convertible to an integer."), Times.Once);
    }

    [Fact]
    public void ProcessCommandsFailedCommandDisconnectEmptyCommandLogged()
    {
        // Arrange
        var commandReaderMock = new Mock<ICommandReader>();
        commandReaderMock.Setup(cr => cr.ReadCommand()).Returns("disconnect");

        var loggerMock = new Mock<ILogger>();

        var fileSystem = new FileSystemFakeForTest(commandReaderMock.Object, loggerMock.Object, null);

        // Act
        fileSystem.ProcessCommands();

        // Assert
        loggerMock.Verify(l => l.Log("No connected file to disconnect."), Times.Once);
    }
}