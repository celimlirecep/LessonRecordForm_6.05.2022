﻿using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class BaseRule<T>:IBaseRule<T> where T:class,new()
    {
        
    }
}