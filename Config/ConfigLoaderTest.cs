using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConfigUnitTest
{
    [TestClass]
    public class ConfigLoaderTest
    {
        [TestMethod]
        public void TestConfigLoader()
        {
            // Arrange
            string tempDir = Path.GetTempPath();
            string configFilePath = Path.Combine(tempDir, "TestConfig");
            Directory.CreateDirectory(configFilePath);

            // Create a sample config file
            string configFileContent = @"
                TraceLevel: Information
                LogLevel: Debug";
            File.WriteAllText(Path.Combine(configFilePath, "config.yaml"), configFileContent);

            // Act
            var configLoader = new Config.Services.ConfigLoader(configFilePath);

            // Assert
            Assert.AreEqual("Information", Environment.GetEnvironmentVariable("TRACE_LEVEL"));
            Assert.AreEqual("Debug", Environment.GetEnvironmentVariable("LOG_LEVEL"));

            // Clean up
            Directory.Delete(configFilePath, true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestConfigLoader_InvalidFilePath()
        {
            // Arrange
            string invalidPath = "InvalidPath";

            // Act
            var configLoader = new Config.Services.ConfigLoader(invalidPath);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestConfigLoader_MissingConfigFile()
        {
            // Arrange
            string tempDir = Path.GetTempPath();
            string configFilePath = Path.Combine(tempDir, "TestConfig");

            // Act
            var configLoader = new Config.Services.ConfigLoader(configFilePath);
        }
    }
}
