using System;

namespace QLTS.Tool_Khao_Sat.Model
{
    public class Tenant
    {
        public Guid tenant_id { get; set; }
        public string tenant_code { get; set; }
        public string tenant_name { get; set; }
        public bool survey_success { get; set; } = false;
        public string error { get; set; }
    }
}
