namespace QLTS.Tool_Khao_Sat.BL
{
    public class Script
    {
        public static string ScriptDeleteUser = "DELETE a\r\nFROM sc_user_role a\r\nINNER JOIN user b ON a.user_id = b.user_id\r\nWHERE b.user_name = 'misaqlts';\r\n\r\nDELETE FROM user WHERE user_name = 'misaqlts';\r\nDELETE FROM activity_diary WHERE user_name LIKE '%misaqlts%';";
        public static string ScriptDeleteUser_Authen = "DELETE FROM user WHERE user_name = 'misaqlts' and tenant_id = '{0}';";
        public static string ScriptStartTrace = "TRUNCATE TABLE mysql.general_log;\nSET GLOBAL log_output = 'TABLE';\nSET GLOBAL general_log = 1;";
        public static string ScriptStopTrace = "SET GLOBAL log_output = 'TABLE';\r\nSET GLOBAL general_log = 0;";
        public static string ScriptGetResultTrace = "SELECT CAST(argument AS char)  AS Data\r\nFROM mysql.general_log\r\nWHERE  argument LIKE 'CALL%'\r\nORDER BY event_time DESC\r\nLIMIT 0, 1000;";
    }
}
