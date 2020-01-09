using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{
  public class CodeBuilder
  {
    private List<Field> Fields = new List<Field>();
    private string Name = string.Empty;
    private StringBuilder SB = new StringBuilder();
    public const string Indent = "  "; // 2 spaces
    public const char NewLine = '\n';

    public CodeBuilder()
    {

    }

    public CodeBuilder(string className)
    {
      Name = className;
    }

    public CodeBuilder AddField(string name, string typeName)
    {
      Fields.Add(new Field(name, typeName));
      return this;
    }

    public string Build()
    {
      return this.ToString();
    }

    public override string ToString()
    {
      SB.Append($"public class {this.Name}{NewLine}");
      SB.Append($"{{{NewLine}");
      foreach (var field in Fields)
      {
        SB.Append(Indent);
        SB.Append($"public {field.Type} {field.Name};{NewLine}");
      }
      SB.Append($"}}{NewLine}");

      return SB.ToString();
    }
  }

  internal class Field
  {
    public string Name { get; set; }
    public string Type { get; set; }

    public Field() { }

    public Field(string name, string type)
    {
      Name = name;
      Type = type;
    }
  }
}