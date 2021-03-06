﻿using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IFilmService : IEntityService<Film>
    {
        Film GetFilmByIdMovie(Guid IdMovie);

        IList<Film> GetAllFilmInSeriesTV(Guid IdMovie);

        ICollection<Film> GetFilmsByMovieId(Guid id);
    }
}
