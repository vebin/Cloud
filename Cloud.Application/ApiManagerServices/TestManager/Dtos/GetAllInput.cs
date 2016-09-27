namespace Cloud.ApiManagerServices.TestManager.Dtos
{
    public class GetAllInput 
    {
        public string Id { get; set; }

        public bool State { get; set; }

        public int PageSize { get; set; } = 20;
    }
}