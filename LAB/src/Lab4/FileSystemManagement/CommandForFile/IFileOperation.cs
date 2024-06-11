namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public interface IFileOperation
{
    void Execute(string source, string? destination);
}