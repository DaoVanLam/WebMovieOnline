﻿using Common.GenericRepository;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Tag> SearchTagByName(string nameTag)
        {
            return _dbContext.Tags.Where(t => t.NameTag.Contains(nameTag)).ToList();
        }
    }
}
