﻿using SharpYaml.Serialization;
using YamlDocument = SharpYaml.Serialization.YamlDocument;
using YamlNode = SharpYaml.Serialization.YamlNode;

namespace FlutterSync.Extensions
{
    internal static class SharpYamlExtensions
    {
        public static string GetScalarValue(this YamlDocument doc, string[] keys)
        {
            // ROOT DOCUMENT
            var root = (YamlMappingNode)doc.RootNode;
            // Find the nested value
            var scalarNode = GetScalarNode(root, keys);
            return scalarNode?.Value ?? string.Empty;
        }

        public static YamlScalarNode GetScalarNode(this YamlDocument doc, string[] keys)
        {
            // ROOT DOCUMENT
            var root = (YamlMappingNode)doc.RootNode;
            return root.GetScalarNode(keys);
        }

        public static YamlScalarNode GetScalarNode(this YamlMappingNode node, string[] keys, int index = 0)
        {
            if (index >= keys.Length)
                return null;

            var currentKey = new YamlScalarNode(keys[index]);

            // Node NOT found
            if (node.Children.ContainsKey(currentKey) == false || node.Children[currentKey] == null)
                return null;

            var nestedNode = node.Children[currentKey];

            // Node FOUND
            if (nestedNode is YamlScalarNode scalarNode && index == keys.Length - 1)
            {
                return scalarNode;
            }

            // Retry by going deeper
            if (nestedNode is YamlMappingNode mappingNode)
            {
                return GetScalarNode(mappingNode, keys, ++index);
            }

            // Not found
            return null;
        }

        public static YamlMappingNode GetMappingNode(this YamlDocument doc, string[] keys, int index = 0)
        {
            // ROOT DOCUMENT
            var root = (YamlMappingNode)doc.RootNode;
            return root.GetMappingNode(keys);
        }

        static YamlMappingNode GetMappingNode(this YamlMappingNode node, string[] keys, int index = 0)
        {
            if (index >= keys.Length)
                return null;

            var currentKey = new YamlScalarNode(keys[index]);

            // Node NOT found
            if (node.Children.ContainsKey(currentKey) == false || node.Children[currentKey] == null)
                return null;

            var nestedNode = node.Children[currentKey];

            if (nestedNode is YamlMappingNode == false)
            {
                return null;
            }

            var nestedMappingNode = (YamlMappingNode) nestedNode;

            // Last key: found
            if (index == keys.Length - 1)
            {
                return nestedMappingNode;
            }

            return GetMappingNode(nestedMappingNode, keys, ++index);
        }
    }
}
