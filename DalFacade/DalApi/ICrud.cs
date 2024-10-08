﻿using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

public interface ICrud<T> where T : class
{
    int Create(T item); //Creates new entity object in DAL
    T? Read(int id); //Reads entity object by its ID 
    T? Read(Func<T, bool> filter); // Read an object by other properties
    IEnumerable<T?> ReadAll(Func<T, bool>? filter = null);//Reads all entity objects
    void Update(T item); //Updates entity object
    void Reset();//Reset the list
}
