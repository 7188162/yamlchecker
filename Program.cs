// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

class YamlChecker
{
    static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: yaml_checker [yaml file path]");
            return 1;
        }

        string yamlFilePath = args[0];

        if (!File.Exists(yamlFilePath))
        {
            Console.WriteLine($"File does not exist: {yamlFilePath}");
            return -16;
        }

        try
        {
            var input = File.ReadAllText(yamlFilePath);
            var deserializer = new DeserializerBuilder()
                .IgnoreUnmatchedProperties()
                .Build();
            var yamlObject = deserializer.Deserialize<object>(input);

            Console.WriteLine("Valid YAML file.");
            return 0;
        }
        catch (SyntaxErrorException ex)
        {
            Console.WriteLine($"Invalid YAML file at line {ex.Start.Line}, column {ex.Start.Column}: {ex.Message}");
            return -32;
        }
        catch (SemanticErrorException ex){
            Console.WriteLine($"Invalid YAML file at line {ex.Start.Line}, column {ex.Start.Column}: {ex.Message}");
            return -48;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            return -127;
        }
    }
}

