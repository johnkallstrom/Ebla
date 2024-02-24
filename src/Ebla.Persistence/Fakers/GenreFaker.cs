namespace Ebla.Persistence.Fakers
{
	public class GenreFaker : Faker<Genre>
	{
        private int _id = 1;

        public GenreFaker()
        {
            RuleFor(g => g.Id, f => _id++);
            RuleFor(g => g.Name, f => f.Random.Word());
        }
    }
}
