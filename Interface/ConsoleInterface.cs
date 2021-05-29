using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Exceptions;
using GraphDomain;
using Interface.Commands;

namespace ConsoleApp1.Interface
{
    public class ConsoleInterface
    {
        private readonly List<ICommand> commands;
        private Graph graph;

        public ConsoleInterface(Graph graph)
        {
            commands = new List<ICommand>();
            this.graph = graph;
        }

        private void Execute(string[] command)
        {
            if(command != null && command.Length > 0 && int.TryParse(command[0],out int num))
                commands.FirstOrDefault(c=>c.CommandNumber == num)?.Execute(ref graph,command.Skip(1).ToArray());
        }

        public void Register(ICommand command)
        {
            commands.Add(command);
            command.CommandNumber = commands.Count;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Введите номер команды и необходимые аргументы");
                commands.ForEach(c=>Console.WriteLine($"[{c.CommandNumber}] {c.Name}"));
                Console.WriteLine("[0] Выход");
                Console.Write(">");
                var command = Console.ReadLine()?.Split(' ');
                Console.Clear();
                if (command != null && command.Length == 1 && command[0] == "0")
                    break;
                try
                {
                    Execute(command);
                }
                catch (VertexAlreadyExistsException)
                {
                    Console.WriteLine("ОШИБКА! Такая вершина уже есть");
                }
                catch (EdgeAlreadyExistsException)
                {
                    Console.WriteLine("ОШИБКА! Такое ребро уже есть");
                }
                catch (VertexDoesNotExistException)
                {
                    Console.WriteLine("ОШИБКА! Такой вершины не существует");
                }
                catch (EdgeDoesNotExistException)
                {
                    Console.WriteLine("ОШИБКА! Такого ребра не существует");
                }
                catch (NotPositiveVertexCountException)
                {
                    Console.WriteLine("ОШИБКА! В графе должна быть хотя бы одна вершина");
                }
                catch (IncorrectCommandException)
                {
                    Console.WriteLine("ОШИБКА! Неверные аргументы или номер команды");
                }
                catch (NegativeDataException)
                {
                    Console.WriteLine("ОШИБКА! Веса рёбер должны быть неотрицательными");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("ОШИБКА! Файл не найден");
                }
                catch (NotDualGraphException)
                {
                    Console.WriteLine("ОШИБКА! Граф не двудольный");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("ОШИБКА! Необходимо создать или загрузить граф");
                }
                catch
                {
                    Console.WriteLine("ОШИБКА! Неизвестная ошибка, возможно нарушен формат ввода в файл");
                }
            }
        }
    }
}