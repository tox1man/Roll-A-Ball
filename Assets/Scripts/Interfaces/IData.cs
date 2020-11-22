﻿using System;

namespace RollABall
{
    interface IData<T>
    {
        void Save(T data, string path);
        T Load(T savedData, string path);
    }
}
 