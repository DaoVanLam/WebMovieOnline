﻿using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IProducerRepository: IGenericRepository<Producer>
    {
        ICollection<Producer> SearchProducerByName(string producerName);

    }
}
