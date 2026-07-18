using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using EmployeeManagementSystem.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public static class GenericServices
    {
        public static void HandleOperation<T>(int operationChoice, GenericRepository<T> repo, Func<T> add)
           where T : BaseClass
        {
            switch (operationChoice)
            {
                case 1: // Add
                    var toAdd = add();
                    repo.Add(toAdd);
                    Console.WriteLine($"{typeof(T).Name} added successfully.");
                    break;

                case 2: // Update
                    try
                    {
                        repo.Update(add());
                        Console.WriteLine($"{typeof(T).Name} updated successfully.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 3: // Remove
                    int removeId = SystemFlow.ReadInt("Enter Id to remove: ");
                    var toRemove = repo.GetById(removeId);
                    if (toRemove == null)
                    {
                        Console.WriteLine($"No {typeof(T).Name} found with that Id.");
                        break;
                    }
                    repo.Delete(toRemove);
                    Console.WriteLine("Removed successfully.");
                    break;

                case 4: // Searching
                     int option = SystemMenus.SearchMenu();
                    if (option == 5) break; // Back option
                    var results = SearchSystem.Searching(option, repo);
                    if (results.Count == 0) Console.WriteLine("Nothing Found");
                    else
                    {
                        foreach (var result in results)
                        {
                            Console.WriteLine(result);
                        }
                    }
                    break;

                case 5: // Get All
                    var all = repo.GetAll().ToList();
                    if (all.Count == 0)
                    {
                        Console.WriteLine($"No {typeof(T).Name}s available.");
                        break;
                    }
                    foreach (var asset in all)
                        Console.WriteLine(asset);
                    break;
            }

        }
    }
}
