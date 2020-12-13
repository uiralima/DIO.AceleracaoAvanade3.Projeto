﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Services.Abstracts.Converter
{
    public interface IModelByteConverter
    {
        string CotentType { get; }
        byte[] ToBytes(Models.IModel model);
        T FromBytes<T>(byte[] data) where T : Models.IModel;
    }
}
