namespace QL_DT.Models
{
    public class Detail_Receipt
    {
        public int ID {get; set;}
        public int Receipt_ID {get; set;}
        public int Product_ID {get; set;}
        public int Quantity {get; set;}
        public int State_Product {get; set;}
        

        // Nhung thuoc tinh co lien toi bang khac
        public Receipt_Note Receipt_Note {get; set;}
    }
}