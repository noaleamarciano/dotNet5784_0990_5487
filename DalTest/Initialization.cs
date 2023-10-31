
namespace DalTest;
using DalApi;
using DO;
using System.Runtime.CompilerServices;

public static class Initialization
{
    private static IDependence? s_dalDependence;
    private static ITask? s_dalTask;
    private static IEngineer? s_dalEngineer;
    private static readonly Random s_rand = new();
}