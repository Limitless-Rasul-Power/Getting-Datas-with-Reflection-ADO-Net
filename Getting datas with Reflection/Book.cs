namespace Getting_datas_with_Reflection
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public int PageCount { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Title}, {Author}, {Publisher}, {Genre}, {Price}, {PageCount}";
        }

    }
}