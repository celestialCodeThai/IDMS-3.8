using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMS.DataManage
{
    public class DataAccess
    {
        public static string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static string path = (System.IO.Path.GetDirectoryName(executable));

        public List<hnData> GetHn(string hnid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(dbhelper.CnnVal("db")))
            {
                var output = connection.Query<hnData>($"select * from patientdata where hn = '{hnid}'").ToList();
                return output;

            }


        }

        public void InsertData(string hn, string firstName, string lastName, string sex, string prefix, string age, string birth, string nation, string pt)
        {
            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                List<hnData> data = new List<hnData>();

                data.Add(new hnData { hnid = hn, FirstName = firstName, LastName = lastName, Sex = sex, Prefix = prefix, Age = age, Birthdate = birth, Nationality = nation, ptype = pt });
                connection.Execute("INSERT INTO patientdata(hn,name,surname,sex,prefix,age,birthdate,nationality,type)VALUES (@hnid,@FirstName,@LastName,@Sex,@Prefix,@Age,@Birthdate,@Nationality,@ptype)", data);
            }
        }

        public void AddNewCase(string caseid, string name, string hn, string pro, string pr, string indi, string itm, string d1, string d2, string d3, string d4,
            string date, string day, string doc1, string doc2, string sn, string cn, string an, string sts, string financeValue)
        {
            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                List<hnCase> data = new List<hnCase>();
                data.Add(new hnCase
                {
                    caseID = caseid,
                    pname = name,
                    hnid = hn,
                    procedure = pro,
                    ProcedureRoom = pr,
                    indication = indi,
                    Intruments = itm,
                    preDX1 = d1,
                    preDX2 = d2,
                    preDX3 = d3,
                    preDX4 = d4,
                    regisDate = date,
                    Day = day,
                    docName = doc1,
                    docName2 = doc2,
                    sNurse = sn,
                    cNurse = cn,
                    Anesthesist = an,
                    caseStatus = sts,
                    finance = financeValue,
                });
                connection.Execute("INSERT INTO patientcase(`caseid`,`Patient Name`,`hn`,`Procedure`,`Procedure Room`,`Indication`,`Instruments`,`PreDX1`,`PreDX2`,`PreDX3`,`PreDX4`,`Date`,`Day`,`Doctor`,`Doctor 2`,`Scrub Nurse`,`Circulating Nurse`,`Anesthesist`,`status`,`finance`)VALUES (@caseID,@pname,@hnid,@procedure,@ProcedureRoom,@indication,@Intruments,@preDX1,@preDX2,@preDX3,@preDX4,@regisDate,@Day,@docName,@docName2,@sNurse,@cNurse,@Anesthesist,@caseStatus,@finance)", data);
            }
        }

        public void EditCase(string caseid, string name, string hn, string pro, string pr, string indi, string itm, string d1, string d2, string d3, string d4,
                   string date, string day, string doc1, string doc2, string sn, string cn, string an, string sts)
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                List<hnCase> data = new List<hnCase>();
                data.Add(new hnCase
                {
                    caseID = caseid,
                    pname = name,
                    hnid = hn,
                    procedure = pro,
                    ProcedureRoom = pr,
                    indication = indi,
                    Intruments = itm
                                    ,
                    preDX1 = d1,
                    preDX2 = d2,
                    preDX3 = d3,
                    preDX4 = d4,
                    regisDate = date,
                    Day = day,
                    docName = doc1,
                    docName2 = doc2,
                    sNurse = sn,
                    cNurse = cn,
                    Anesthesist = an,
                    caseStatus = sts
                });
                //connection.Execute("INSERT INTO patientcase(caseid,hn,Procedure,Procedure Room,Instruments,PreDX1,PreDX2,PreDX3,PreDX4,Date,Doctor,Doctor 2,Scrub Nurse,Circulating Nurse,Anesthesist,status)VALUES (@caseID,@hnid,@Procedure,@ProcedureRoom,@Intruments,@preDX1,@preDX2,@preDX3,@preDX4,@regisDate,@docName,@docName2,@sNurse,@cNurse,@Anesthesist,@caseStatus)", data);
                connection.Execute("UPDATE `patientcase` SET (`Patient Name`,`hn`,`Procedure`,`Procedure Room`,`Indication`,`Instruments`,`PreDX1`,`PreDX2`,`PreDX3`,`PreDX4`,`Date`,`Day`,`Doctor`,`Doctor 2`,`Scrub Nurse`,`Circulating Nurse`,`Anesthesist`,`status`)VALUES (@pname,@hnid,@procedure,@ProcedureRoom,@indication,@Intruments,@preDX1,@preDX2,@preDX3,@preDX4,@regisDate,@Day,@docName,@docName2,@sNurse,@cNurse,@Anesthesist,@caseStatus)", data);
            }

        }

        public void EditData(string caseid, string field, string newdata)
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("UPDATE `patientcase` SET `" + field + "` = '" + newdata + "' WHERE `patientcase`.`caseid` = '" + caseid + "'");

            }

        }

        public List<hnData> GetHnCase(string hnid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(dbhelper.CnnVal("db")))
            {
                var output = connection.Query<hnData>($"select * from patientcase where hn = '{hnid}'").ToList();
                return output;

            }


        }
        public void DeleteRow(string caseid)
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("DELETE FROM `patientcase` WHERE `patientcase`.`caseid` = '" + caseid + "'");

            }

        }
        public void updateMultiPro(string caseid, string pro)
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("UPDATE `patientcase` SET `Procedure` = '" + pro + "' WHERE `patientcase`.`caseid` = '" + caseid + "'");

            }

        }
        public void updatePendingStatus(string caseid, string time)
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("UPDATE `patientcase` SET `status` = 'Pending', `Duration` = '" + time + "' WHERE `patientcase`.`caseid` = '" + caseid + "'");

            }

        }


        public void updateDoneStatus(string caseid)
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("UPDATE `patientcase` SET `status` = 'Done' WHERE `patientcase`.`caseid` = '" + caseid + "'");

            }

        }

        public void addDoctor(string name)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("INSERT INTO `doctor` (`docname`)VALUES('" + name + "')");
            //   INSERT INTO `patientdata` (`hn`) VALUES('

            connection.Close();
            connection.Dispose();
        }
        public void addnurse(string name)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("INSERT INTO `nurse` (`nursename`)VALUES('" + name + "')");

            connection.Close();
            connection.Dispose();
        }
        public void addSnurse(string name)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("INSERT INTO `snurse` (`snursename`)VALUES('" + name + "')");

            connection.Close();
            connection.Dispose();
        }

        public void addCnurse(string name)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("INSERT INTO `cnurse` (`cnursename`)VALUES('" + name + "')");

            connection.Close();
            connection.Dispose();
        }

        public void addAnesthesist(string name)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("INSERT INTO `anesthesist` (`anesname`)VALUES('" + name + "')");

            connection.Close();
            connection.Dispose();
        }
        public void removeDoctor(string pk)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("DELETE FROM  `doctor` WHERE `doctor`.`docid` = '" + pk + "'");
            //   INSERT INTO `patientdata` (`hn`) VALUES('

            connection.Close();
            connection.Dispose();
        }
        public void removeSnurse(string pk)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("DELETE FROM  `nurse` WHERE `nurse`.`nurseid` = '" + pk + "'");
            //   INSERT INTO `patientdata` (`hn`) VALUES('

            connection.Close();
            connection.Dispose();
        }
        public void removeCnurse(string pk)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("DELETE FROM  `nurse` WHERE `nurse`.`nurseid` = '" + pk + "'");
            //   INSERT INTO `patientdata` (`hn`) VALUES('

            connection.Close();
            connection.Dispose();
        }
        public void removeAnesthesist(string pk)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("DELETE FROM  `anesthesist` WHERE `anesthesist`.`anesid` = '" + pk + "'");
            //   INSERT INTO `patientdata` (`hn`) VALUES('

            connection.Close();
            connection.Dispose();
        }
        //for SQLLITE

        public bool checkRowExistz(string caseid)
        {
            bool RowExist = false;


            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();

            string query = "select * from `report` where caseid='" + caseid + "'";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows == true)
                {
                    RowExist = true;
                }
            }
            reader.Close();
            connection.Close();
            connection.Dispose();

            return RowExist;



        }

        public bool checkRowExist(string caseid, string table)
        {
            bool RowExist = false;


            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            connection.Open();

            string query = "select * from `" + table + "` where caseid='" + caseid + "'";
            MySqlCommand sql_cmd = new MySqlCommand(query, connection);

            MySqlDataReader reader = sql_cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows == true)
                {
                    RowExist = true;
                }
            }
            reader.Close();
            connection.Close();
            connection.Dispose();

            return RowExist;



        }

        //for SQLLITE
        public void addReportKeyz(string data, string field)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();
            connection.Execute("INSERT INTO `report` (`" + field + "`)VALUES('" + data + "')");

            connection.Close();
            connection.Dispose();
        }
        public void addReportKey(string data, string field, string table)
        {



            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            connection.Open();
            connection.Execute("INSERT INTO `" + table + "` (`" + field + "`)VALUES('" + data + "')");

            connection.Close();
            connection.Dispose();
        }
        //for SQLLITE
        public void addReportFieldz(string caseid, string data, string field)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();
            connection.Execute("UPDATE `report` SET `" + field + "` = '" + data + "' WHERE `report`.`caseid` = '" + caseid + "'");

            connection.Close();
            connection.Dispose();
        }
        public void addReportField(string caseid, string data, string field)
        {


            // System.Windows.Forms.MessageBox.Show("UPDATE `report` SET `" + field + "` = '" + data + "' WHERE `report`.`caseid` = '" + caseid + "'");

            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            connection.Open();
            connection.Execute("UPDATE `report` SET `" + field + "` = '" + data + "' WHERE `report`.`caseid` = '" + caseid + "'");

            connection.Close();
            connection.Dispose();
        }
        public void addReportFieldnew(string caseid, string[] data, string[] field)
        {
            string cmd = "UPDATE `report` SET `";
            for (int i = 0; i < field.Length - 1; i++)
            {
                cmd += field[i] + "` = '" + data[i] + "',`";

            }
            cmd += field[field.Length - 1] + "` = '" + data[field.Length - 1] + "'" +
                "WHERE `report`.`caseid` = '" + caseid + "'";
            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));


            connection.Open();
            connection.Execute(cmd);
            connection.Close();
            connection.Dispose();
        }

        public void addReportFieldnewBRONCO(string caseid, string[] data, string[] field)
        {


            string cmd = "UPDATE `broncoreport` SET `";
            for (int i = 0; i < field.Length - 1; i++)
            {
                cmd += field[i] + "` = '" + data[i] + "',`";

            }
            cmd += field[field.Length - 1] + "` = '" + data[field.Length - 1] + "'" +
                "WHERE `broncoreport`.`caseid` = '" + caseid + "'";
            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));


            connection.Open();
            connection.Execute(cmd);
            connection.Close();
            connection.Dispose();
        }
        public void addbroncoReportField(string caseid, string data, string field)
        {


            // System.Windows.Forms.MessageBox.Show("UPDATE `report` SET `" + field + "` = '" + data + "' WHERE `report`.`caseid` = '" + caseid + "'");

            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            connection.Open();
            connection.Execute("UPDATE `broncoreport` SET `" + field + "` = '" + data + "' WHERE `broncoreport`.`caseid` = '" + caseid + "'");

            connection.Close();
            connection.Dispose();
        }
        //for SQLLITE remove 'z' for use
        public string getValuez(string caseid, string field)
        {
            // SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("db"));

            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();

            string query = "select `" + field + "` from `report` where caseid='" + caseid + "'";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            string x = "";
            while (reader.Read())
            {
                x = reader[field].ToString();

            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            return x;



        }

        public string getValue(string caseid, string field)
        {
            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                string oString = "select `" + field + "` from `report` where caseid='" + caseid + "'";
                MySqlCommand oCmd = new MySqlCommand(oString, connection);

                connection.Open();
                string x = "";

                using (MySqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        x = oReader[field].ToString();
                    }

                    connection.Close();
                }

                return x;
            }
        }

        public string getValueWithTableName(string caseid, string tablename, string field)
        {
            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                string oString = "select `" + field + "` from `" + tablename + "` where caseid='" + caseid + "'";
                MySqlCommand oCmd = new MySqlCommand(oString, connection);

                connection.Open();
                string x = "";
                using (MySqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        x = oReader[field].ToString();
                    }
                    connection.Close();
                }
                return x;
            }
        }

        public string getValueBRONCO(string caseid, string field)
        {
            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                string oString = "select `" + field + "` from `broncoreport` where caseid='" + caseid + "'";
                MySqlCommand oCmd = new MySqlCommand(oString, connection);


                connection.Open();
                string x = "";
                using (MySqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        x = oReader[field].ToString();
                    }

                    connection.Close();
                }
                return x;
            }
        }
        public void DeleteAll()
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("TRUNCATE TABLE patientcase");
            }

        }
        public void DeleteReportAll()
        {

            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();

            string query = "TRUNCATE TABLE report";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            connection.Close();
            connection.Dispose();
        }

        public void updatePatientdata(string caseid, string field, string txt)
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("UPDATE `patientcase` SET `" + field + "` = '" + txt + "' WHERE `patientcase`.`caseid` = '" + caseid + "'");
            }

        }

        public void updatePatientCase(string caseid, string field, string txt)
        {

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("UPDATE `patientcase` SET `" + field + "` = '" + txt + "' WHERE `patientcase`.`caseid` = '" + caseid + "'");
            }

        }

        public void settingHeaderImage(string Logo_id, string data, string field)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();
            connection.Execute("UPDATE `setting` SET `" + field + "` = '" + data + "' WHERE `setting`.`Logoid` = '" + Logo_id + "'");

            connection.Close();
            connection.Dispose();
        }
        public void settingHeader(string Logo_id, string data, string field)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();
            connection.Execute("UPDATE `header` SET `" + field + "` = '" + data + "' WHERE `header`.`hid` = '" + Logo_id + "'");

            connection.Close();
            connection.Dispose();
        }

        public void settingUSB(string usb_id, string data, string field)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("UPDATE `USB` SET `" + field + "` = '" + data + "' WHERE `USB`.`hid` = '" + usb_id + "'");

            connection.Close();
            connection.Dispose();
        }

        public void settingHeaderz(string Logo_id, string data, string field)
        {

            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            connection.Open();
            connection.Execute("UPDATE `header` SET `" + field + "` = '" + data + "' WHERE `header`.`hid` = '" + Logo_id + "'");

            connection.Close();
            connection.Dispose();
        }
        public string getsettingtext(string logoid, string field)
        {
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();

            string query = "select `" + field + "` from `header` where hid='" + logoid + "'";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            string x = "";
            while (reader.Read())
            {
                x = reader[field].ToString();

            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            return x;
        }

        public string getusbtext(string logoid, string field)
        {


            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();

            string query = "select `" + field + "` from `USB` where hid='" + logoid + "'";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            string x = "";
            while (reader.Read())
            {
                x = reader[field].ToString();

            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            return x;
        }

        //Start top function ============================================================================================================================================

        public string getOption(string column, string key)
        {
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();

            string query = "select `" + column + "` from `option` where option_key='" + key + "'";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            string option_value = "";
            while (reader.Read())
            {
                option_value = reader[column].ToString();
            }

            reader.Close();
            connection.Close();
            connection.Dispose();

            return option_value;
        }

        public void updateOption(string column, string key, string value)
        {
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("UPDATE `option` SET `" + column + "` = '" + value + "' WHERE `option`.`option_key` = '" + key + "'");

            connection.Close();
            connection.Dispose();
        }

        public void imagePointInsertOrUpdate(string caseId, string[] data, string[] field)
        {
            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                string CASE_ID = caseId;
                string fieldList = "`caseId`";
                string valueList = "";
                string updateQuery = "";

                for (int i = 1; i <= field.Length; i++)
                {
                    fieldList += ",`point_" + i + "`";
                    valueList += ",'" + data[i - 1] + "'";
                    if (i == 1)
                    {
                        updateQuery += "point_" + i + " = VALUES(point_" + i + ")";
                    }
                    else
                    {
                        updateQuery += ",point_" + i + " = VALUES(point_" + i + ")";
                    }
                }

                string query = "INSERT INTO image_point(" + fieldList + ") VALUES ('" + CASE_ID + "'" + valueList + ") ON DUPLICATE KEY UPDATE ";

                connection.Execute(query + " " + updateQuery);
            }
        }

        //End top ================================================================================================================================================

        public void AddMac(string data)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));




            connection.Open();

            connection.Execute("INSERT INTO USB(USB_PATH,hid) VALUES('" + data + "', 0) ON CONFLICT(hid) DO UPDATE SET USB_PATH = '" + data + "' WHERE hid = 0 ");


            connection.Close();
            connection.Dispose();
        }
        public void AddDrive(string data)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));




            connection.Open();

            connection.Execute("INSERT INTO USB(USB_PATH,hid) VALUES('" + data + "', 2) ON CONFLICT(hid) DO UPDATE SET USB_PATH = '" + data + "' WHERE hid = 2 ");


            connection.Close();
            connection.Dispose();
        }
        public void AddSwitch(string data)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));




            connection.Open();

            connection.Execute("INSERT INTO USB(USB_PATH,hid) VALUES('" + data + "', 3) ON CONFLICT(hid) DO UPDATE SET USB_PATH = '" + data + "' WHERE hid = 3 ");


            connection.Close();
            connection.Dispose();
        }
        public string getsettingValue(string logoid, string field)
        {


            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            connection.Open();

            string query = "select `" + field + "` from `setting` where Logoid='" + logoid + "'";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            string x = "";
            while (reader.Read())
            {
                x = reader[field].ToString();
            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            return x;



        }

        public void addcamera(string BRAND, string SN, string MODEL, string NICKNAME)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();

            connection.Execute("INSERT INTO `camera` (`brand`,`sn`,`model`,`nickname`)VALUES('" + BRAND + "','" + SN + "','" + MODEL + "','" + NICKNAME + "')");

            connection.Close();
            connection.Dispose();
        }

        public void addProcedureRoom(string roomValue)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();

            connection.Execute("INSERT INTO `procedure_room` (`name`) VALUES('" + roomValue + "')");

            connection.Close();
            connection.Dispose();
        }

        public void removeCamera(string pk)
        {


            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();
            connection.Execute("DELETE FROM  `camera` WHERE `camera`.`cameraid` = '" + pk + "'");
            //   INSERT INTO `patientdata` (`hn`) VALUES('

            connection.Close();
            connection.Dispose();
        }

        public void removeProcedureRoom(string id)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("setting"));
            connection.Open();

            connection.Execute("DELETE FROM  `procedure_room` WHERE `procedure_room`.`id` = '" + id + "'");

            connection.Close();
            connection.Dispose();
        }

        public bool checkRowExist2(string caseid)
        {
            bool RowExist = false;


            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl2"));
            connection.Open();

            string query = "select * from `report` where caseid='" + caseid + "'";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows == true)
                {
                    RowExist = true;
                }
            }
            reader.Close();
            connection.Close();
            connection.Dispose();

            return RowExist;



        }

        public void addReportKey2(string data, string field)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl2"));
            connection.Open();
            connection.Execute("INSERT INTO `report` (`" + field + "`)VALUES('" + data + "')");

            connection.Close();
            connection.Dispose();
        }
        public void addReportField2(string caseid, string data, string field)
        {



            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl2"));
            connection.Open();
            connection.Execute("UPDATE `report` SET `" + field + "` = '" + data + "' WHERE `report`.`caseid` = '" + caseid + "'");

            connection.Close();
            connection.Dispose();
        }

        public string getValue2(string caseid, string field)
        {


            SQLiteConnection connection = new SQLiteConnection(dbhelper.CnnVal("dbl2"));
            connection.Open();

            string query = "select `" + field + "` from `report` where caseid='" + caseid + "'";
            SQLiteCommand sql_cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            string x = "";
            while (reader.Read())
            {
                x = reader[field].ToString();

            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            return x;



        }

        public string getCaseCount(bool isTotal, string procedure)
        {
            string query = "SELECT COUNT(caseid) FROM `patientcase`";

            if (!isTotal)
            {
                query = "SELECT COUNT(caseid) FROM `patientcase` WHERE `Procedure` LIKE '%" + procedure + "%'";
            }

            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            MySqlCommand sql_cmd = new MySqlCommand(query, connection);

            connection.Open();

            int countTotal = Convert.ToInt32(sql_cmd.ExecuteScalar());

            connection.Close();
            connection.Dispose();

            return countTotal.ToString();

        }

        public string getPatientCount(string key)
        {
            string query = "SELECT COUNT(hn) FROM `patientdata`";
            if (key != "total")
            {
                query = "SELECT COUNT(hn) FROM `patientdata` WHERE sex = '" + key + "'";
            }
            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            MySqlCommand sql_cmd = new MySqlCommand(query, connection);

            connection.Open();

            int countTotal = Convert.ToInt32(sql_cmd.ExecuteScalar());

            connection.Close();
            connection.Dispose();

            return countTotal.ToString();
        }

        public string getPatientAge(string key)
        {
            string query = "SELECT COUNT(hn) FROM `patientdata` WHERE age BETWEEN '70' AND '200'";
            if (key != "70")
            {
                switch (key)
                {
                    case "15":
                        query = "SELECT COUNT(hn) FROM `patientdata` WHERE age BETWEEN '15' AND '29'";
                        break;
                    case "30":
                        query = "SELECT COUNT(hn) FROM `patientdata` WHERE age BETWEEN '30' AND '39'";
                        break;
                    case "40":
                        query = "SELECT COUNT(hn) FROM `patientdata` WHERE age BETWEEN '40' AND '49'";
                        break;
                    case "50":
                        query = "SELECT COUNT(hn) FROM `patientdata` WHERE age BETWEEN '50' AND '59'";
                        break;
                    case "60":
                        query = "SELECT COUNT(hn) FROM `patientdata` WHERE age BETWEEN '60' AND '69'";
                        break;
                    default:
                        query = "SELECT COUNT(hn) FROM `patientdata` WHERE age BETWEEN '201' AND '202'";
                        break;

                }
            }
            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            MySqlCommand sql_cmd = new MySqlCommand(query, connection);

            connection.Open();

            int countTotal = Convert.ToInt32(sql_cmd.ExecuteScalar());

            connection.Close();
            connection.Dispose();

            return countTotal.ToString();
        }

        public int getProcedureCase(string name, string procedure, string column)
        {
            string query = "SELECT COUNT(caseid) FROM `patientcase` WHERE `Procedure` LIKE '%" + procedure + "%' AND `" + column + "` = '" + name + "'";

            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            MySqlCommand sql_cmd = new MySqlCommand(query, connection);

            connection.Open();

            int countTotal = Convert.ToInt32(sql_cmd.ExecuteScalar());

            connection.Close();
            connection.Dispose();

            return countTotal;
        }

        public int getInstrumentCase(string name)
        {
            string query = "SELECT COUNT(caseid) FROM `patientcase` WHERE `Instruments` = '" + name + "'";

            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
            MySqlCommand sql_cmd = new MySqlCommand(query, connection);

            connection.Open();

            int countTotal = Convert.ToInt32(sql_cmd.ExecuteScalar());

            connection.Close();
            connection.Dispose();

            return countTotal;
        }





    }
}
