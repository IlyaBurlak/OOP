using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public class FileConnector : IFileOperation
{
    private readonly ILogger _logger;

    public FileConnector(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public FileStream? ConnectedFileStream { get; private set; }
    public bool IsSuccess { get; private set; }

    public void Execute(string source, string? destination)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        IsSuccess = false;

        if (source != "connect")
        {
            _logger.Log("Неподдерживаемый формат команды.");
            return;
        }

        if (destination == null)
        {
            _logger.Log("Аргументы не указаны.");
            return;
        }

        string[] argsParts = destination.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string file = argsParts[0];

        if (!File.Exists(file))
        {
            _logger.Log($"Файл не найден по адресу {file}.");
            return;
        }

        try
        {
            using (FileStream connectedFileStream = File.Open(file, FileMode.Open))
            {
                ConnectedFileStream = connectedFileStream;

                _logger.Log($"Файл {file} успешно подключен.");
                IsSuccess = true;
            }
        }
        catch (FileNotFoundException ex)
        {
            _logger.Log($"Файл не найден: {ex.Message}.");
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.Log($"Ошибка доступа: {ex.Message}.");
        }
        catch (IOException ex)
        {
            _logger.Log($"Ошибка ввода/вывода: {ex.Message}.");
        }
        catch (Exception ex)
        {
            _logger.Log($"Неизвестная ошибка: {ex.Message}.");
            throw;
        }
    }
}