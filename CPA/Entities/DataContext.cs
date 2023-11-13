namespace CPA.Entities
{
    public class DataContext
    {
        public  List<Customer> CustomersList { get; set; }
        public  int CustomerCnt { get; set; }
        public  int CPACnt { get; set; }
        public List<cpa> CPAList { get; set; }
        public  int MeetingCnt { get; set; }
        public  List<Meet> MeetsList { get; set; }
        public DataContext()
        {
            MeetingCnt = 2;
            MeetsList = new List<Meet> { new Meet { MeetingDuration = 0.5, MeetingDate = DateTime.Now, MeetingId = 1, MeetingHour = 14 } };
            CPACnt = 2;
            CPAList = new List<cpa> { new cpa { CPAName = "AvitalIsakov", SeniorityYears = 20, CPAId = 1 } };
            CustomerCnt = 2;
            CustomersList = new List<Customer> { new Customer { CustomerId = 1, CustomerName = "Avital", CustomerCaseNumber = "1254887" } };
        }
    }
}
