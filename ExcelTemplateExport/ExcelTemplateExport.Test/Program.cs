﻿using System.Diagnostics;
using System.Reflection;
using ExcelTemplateExport;
using ExcelTemplateExport.Internal;
using ExcelTemplateExport.Models;

var person = new Person { Name = "John", Age = 30, Amount = 1000 };
var persons = new List<Person>();

for (var i= 0; i< 100000; i++)
{
    persons.Add(new Person { Name = $"Person {i}", Age = 30 + i, Amount = 1000 + i });
}

var config = ExportConfiguration.CreateBuilder()
    .WithTemplatePath("./template.xlsx")
    .WithOutputPath("./output.xlsx")
    .SetAutoFitRows(true)
    .SetAutoFitColumns(true)
    .AddDataSet("Person", person)
    .AddDataSet("Persons", persons)
    .Build();

var stopwatch = new Stopwatch();
stopwatch.Start();  
var export = new TemplateExportExcel();
export.Export(config);
stopwatch.Stop();
Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

public class Person
{
    public string Name { get; set; }

    public int Age { get; set; }

    public double Amount { get; set; }
    
    public double AmountPerYear => Amount / Age;
}