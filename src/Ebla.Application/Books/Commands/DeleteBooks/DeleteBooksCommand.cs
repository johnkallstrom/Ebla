namespace Ebla.Application.Books.Commands
{
    public class DeleteBooksCommand : IRequest<Result>
    {
        public int[] Ids { get; set; }

        public override string ToString()
        {
            string str = "";
            Ids.ToList().ForEach(x =>
            {
                if (Ids.Last().Equals(x)) str += $"{x}";
                else str += $"{x}, ";
            });

            return str;
        }
    }
}
