namespace BookStoreAPI.DTO
{
    public class VnpayRequest
    {
        public long vnp_TxnRef {get; set;}
        public long vnp_Amount {get; set;}
        public long vnp_TransactionNo {get; set;}
        public string vnp_ResponseCode {get; set;}
        public string vnp_TransactionStatus {get; set;}
        public string vnp_SecureHash {get; set;}
    }
}