using Logging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibUnitTest.LogTrace
{
    [TestClass]
    public class LoggingTest
    {
        private readonly string logDirectory = "C:\\Logs\\"; // Change this to your desired log directory

        [TestMethod]
        public void TestYamlFileLogger()
        {
            // Arrange
            var logger = YamlFileLogger.GetInstance(logDirectory);
            string message = "Test message";

            // Act
            logger.LogInformation(message);
            string logFilePath = Path.Combine(logDirectory, "Information.yaml");
            bool fileExists = File.Exists(logFilePath);

            // Assert
            Assert.IsTrue(fileExists);
            // Clean up
            File.Delete(logFilePath);
        }

        [TestMethod]
        public void TestTraceLogger()
        {
            // Arrange
            var logger = TraceLogger.GetInstance(logDirectory);
            string message = "Test message";

            // Act
            logger.LogInformation(message);
            string logFilePath = Path.Combine(logDirectory, "TraceLog.yaml");
            bool fileExists = File.Exists(logFilePath);

            // Assert
            Assert.IsTrue(fileExists);
            // Clean up
            File.Delete(logFilePath);
        }

        [TestMethod]
        public void TestCombinedLogger()
        {
            // Arrange
            var logger = new CombinedLogger(logDirectory);
            string message = "Test message";

            // Act
            logger.LogInformation(message);
            string logFilePath1 = Path.Combine(logDirectory, "Information.yaml");
            string logFilePath2 = Path.Combine(logDirectory, "TraceLog.yaml");
            bool fileExists1 = File.Exists(logFilePath1);
            bool fileExists2 = File.Exists(logFilePath2);

            // Assert
            Assert.IsTrue(fileExists1 || fileExists2);
            // Clean up
            if (fileExists1) File.Delete(logFilePath1);
            if (fileExists2) File.Delete(logFilePath2);
        }
    }
}
