using ETicket.Data.Enums;
using ETicket.Models;

namespace ETicket.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Cinema
                if (!context.Parties.Any())
                {
                    context.Parties.AddRange(new List<Parties>()
                    {
                        new Parties()
                        {
                            Name = "Party1 (6:00PM - 9:00PM)"
                        },
                        new Parties()
                        {
                            Name = "Party2 (9:00PM - 12:00AM)"
                        },
                        new Parties()
                        {
                            Name = "Party3 (12:00AM - 3:00AM)"
                        },
                    });
                    context.SaveChanges();
                }

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Location = "The Location Of Cinema 1",
                            PhoneNumber ="01100000000",
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Location = "The Location Of Cinema 2",
                            PhoneNumber ="01200000000",
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Location = "The Location Of Cinema 3",
                            PhoneNumber ="01300000000",
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Location = "The Location Of Cinema 4",
                            PhoneNumber ="01400000000",
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Location = "The Location Of Cinema 5",
                            PhoneNumber ="01500000000",
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            ProducerId = 3,
                            moviecategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            ProducerId = 1,
                            moviecategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            ProducerId = 4,
                            moviecategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            ProducerId = 2,
                            moviecategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            ProducerId = 3,
                            moviecategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            ProducerId = 5,
                            moviecategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
                //Cinemas_Movies
                if (!context.Cinemas_Movies.Any())
                {
                    context.Cinemas_Movies.AddRange(new List<Cinemas_Movies>()
                    {
                        new Cinemas_Movies()
                        {
                            CinemaId = 1,
                            MovieId = 1
                        },
                        new Cinemas_Movies()
                        {
                            CinemaId = 2,
                            MovieId = 1
                        },

                         new Cinemas_Movies()
                        {
                            CinemaId = 3,
                            MovieId = 1
                        },
                         new Cinemas_Movies()
                        {
                            CinemaId = 2,
                            MovieId = 2
                        },

                        new Cinemas_Movies()
                        {
                            CinemaId = 4,
                            MovieId = 3
                        },
                        new Cinemas_Movies()
                        {
                            CinemaId = 2,
                            MovieId = 3
                        },
                        new Cinemas_Movies()
                        {
                            CinemaId = 5,
                            MovieId = 4
                        },


                        new Cinemas_Movies()
                        {
                            CinemaId = 2,
                            MovieId = 4
                        },
                        new Cinemas_Movies()
                        {
                            CinemaId = 1,
                            MovieId = 5
                        },
                        new Cinemas_Movies()
                        {
                            CinemaId = 4,
                            MovieId = 5
                        },


                        new Cinemas_Movies()
                        {
                            CinemaId = 5,
                            MovieId = 6
                        },
                        new Cinemas_Movies()
                        {
                            CinemaId = 3,
                            MovieId = 6
                        },
                        new Cinemas_Movies()
                        {
                            CinemaId = 4,
                            MovieId = 4
                        },
                    });
                    context.SaveChanges();
                }


                //Parties_Movies
                if (!context.Parties_Movies.Any())
                {
                    context.Parties_Movies.AddRange(new List<Parties_Movies>()
                    {
                        new Parties_Movies()
                        {
                            PartyId = 1,
                            MovieId = 1
                        },
                        new Parties_Movies()
                        {
                            PartyId = 2,
                            MovieId = 1
                        },
                        new Parties_Movies()
                        {
                            PartyId = 3,
                            MovieId = 1
                        },

                        new Parties_Movies()
                        {
                            PartyId = 1,
                            MovieId = 2
                        },
                        new Parties_Movies()
                        {
                            PartyId = 2,
                            MovieId = 2
                        },
                        new Parties_Movies()
                        {
                            PartyId = 3,
                            MovieId = 2
                        },

                        new Parties_Movies()
                        {
                            PartyId = 1,
                            MovieId = 3
                        },
                        new Parties_Movies()
                        {
                            PartyId = 2,
                            MovieId = 3
                        },
                        new Parties_Movies()
                        {
                            PartyId = 3,
                            MovieId = 3
                        },

                        new Parties_Movies()
                        {
                            PartyId = 1,
                            MovieId = 4
                        },
                        new Parties_Movies()
                        {
                            PartyId = 2,
                            MovieId = 4
                        },
                        new Parties_Movies()
                        {
                            PartyId = 3,
                            MovieId = 4
                        },

                        new Parties_Movies()
                        {
                            PartyId = 1,
                            MovieId = 5
                        },
                        new Parties_Movies()
                        {
                            PartyId = 2,
                            MovieId = 5
                        },
                        new Parties_Movies()
                        {
                            PartyId = 3,
                            MovieId = 5
                        },

                        new Parties_Movies()
                        {
                            PartyId = 1,
                            MovieId = 6
                        },
                        new Parties_Movies()
                        {
                            PartyId = 2,
                            MovieId = 6
                        },
                        new Parties_Movies()
                        {
                            PartyId = 3,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
