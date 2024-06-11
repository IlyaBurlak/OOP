using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Handler;

public interface IFileOperationHandler
{
    IFileOperationHandler SetNext(IFileOperationHandler handler);
    void Handle(string command, string? argument, string? secondArgument, FileStream? connectedFileStream);
}