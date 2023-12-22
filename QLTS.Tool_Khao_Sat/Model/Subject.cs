using System.Collections.Generic;

namespace QLTS.Tool_Khao_Sat.Model
{
    public class Subject
    {
        public string SubjectName { get; set; }
        public string ScriptSurvey { get; set; }
        public string ScriptExecute { get; set; }
        public int TotalProvince { get; set; } = 0;
        public int TotalError { get; set; } = 0;
        public List<Tenant> TeantsError { get; set; } = new List<Tenant>();
        public List<Tenant> TeantsSurvey { get; set; } = new List<Tenant>();
        public bool SurveySuccess { get; set; } = false;
    }
}
