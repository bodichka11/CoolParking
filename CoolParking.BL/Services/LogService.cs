// TODO: implement the LogService class from the ILogService interface.
//       One explicit requirement - for the read method, if the file is not found, an InvalidOperationException should be thrown
//       Other implementation details are up to you, they just have to match the interface requirements
//       and tests, for example, in LogServiceTests you can find the necessary constructor format.
using CoolParking.BL.Interfaces;
using System.Reflection.Metadata.Ecma335;


public class LogService : ILogService
{
    public string LogPath  { get; }
    public void Write(string logInfo)
    {
        
    }
    public string Read()
    {
        return LogPath;
    }
    public LogService(string logPath)
    {
        LogPath = logPath;
    }
}