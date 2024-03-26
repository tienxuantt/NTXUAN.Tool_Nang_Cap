using QLTS.Tool_Khao_Sat.Model;
using System.Collections.Generic;

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

    public class TableBackup
    {
        public static List<TableInfo> listTable = new List<TableInfo>
        {
            new TableInfo("convert_circular", "SELECT * FROM {0};"),
            new TableInfo("dic_organization", "SELECT * FROM {0} WHERE organization_id = '{1}';"),
            new TableInfo("fixed_asset", "SELECT * FROM {0} WHERE organization_id = '{1}';"),
            new TableInfo("fixed_asset_ledger", "SELECT * FROM {0} WHERE organization_id = '{1}';"),
            new TableInfo("fixed_asset_change_category", "SELECT * FROM {0} WHERE organization_id = '{1}';"),
            new TableInfo("fa_ledger_inventory", "SELECT * FROM {0} WHERE organization_id = '{1}';"),
            new TableInfo("convert_circular_history", "SELECT * FROM {0} WHERE organization_id = '{1}';"),
            new TableInfo("dic_fixed_asset_category", "SELECT * FROM {0} WHERE organization_id is null OR organization_id = '{1}';"),
            new TableInfo("db_option", "SELECT * FROM {0} WHERE organization_id is null OR organization_id = '{1}';"),
            new TableInfo("dic_fixed_asset_category_master", "SELECT cch.* FROM {0} cch inner JOIN dic_fixed_asset_category dfac ON dfac.fixed_asset_category_master_id = dfac.fixed_asset_category_master_id WHERE dfac.organization_id is NULL OR dfac.organization_id = '{1}';")
        };
    }
}
