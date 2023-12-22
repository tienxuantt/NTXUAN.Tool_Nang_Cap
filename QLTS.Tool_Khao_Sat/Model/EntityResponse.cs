using System.Collections.Generic;

namespace QLTS.Tool_Khao_Sat.Model
{
    public class TenantResponse
    {
        public int Status { get; set; }
        public List<Tenant> Data { get; set; }
    }

    public class TotalEnity
    {
        public int Total { get; set; }
    }

    public class TotalResponse
    {
        public int Status { get; set; }
        public List<TotalEnity> Data { get; set; }
    }

    public class ExecuteResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Code { get; set; }
    }

    public class SubjectJson
    {
        public List<Subject> Data { get; set; }
    }
}
