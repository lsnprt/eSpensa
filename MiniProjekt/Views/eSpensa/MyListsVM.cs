namespace MiniProjekt.Views.eSpensa
{
    public class MyListsVM
    {
        public ListVM[] ListOfLists { get; set; }

        public class ListVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ItemCount { get; set; }
        }
    }
}
