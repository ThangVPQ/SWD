namespace invoice_xlsm_exporter_v3.Dto
{
    public class ResponseEntity
    {
        public object Data { get;private set; }
        public bool Status { get;private set; }
        public ResponseEntity(object data, bool status)
        {
            Data = data;
            Status = status;
        }
    }
}
