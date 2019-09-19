using Models;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICrud<T>
    {

        List<T> GetObjects();
        void AddEntity(T Entity);
        void UpdateEntity(int EntityId);
        void DeleteEntity(int EntityId);
        void AddEntity(Board board);

    }
}
