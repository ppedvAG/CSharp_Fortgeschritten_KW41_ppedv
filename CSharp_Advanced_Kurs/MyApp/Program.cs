using GenericRepository;
using GenericRepository.EF;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EFRepositoryBase<Song, int > repository = new GenericRepository.EF.EFRepositoryBase<Song, int>();

            IReadonlyRepository<Song, int> readonlyReposity = GenericRepository.EF.EFRepositoryBase<Song, int>();
            
            IRepository<Song, int> repostory = GenericRepository.EF.EFRepositoryBase<Song, int>();

            repostory.
        }
    }

    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}