﻿using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IFavoriteMovieService : IEntityService<FavoriteMovie>
    {
        bool ExistObject(Guid idMovie, string idUser);

        ICollection<FavoriteMovie> GetFavoriteMoviesByUserId(string idUser);

        FavoriteMovie Find(Guid idMovie, string idUser);
    }
}
