using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;


namespace IDMS.World
{
    public static class Current
    {
        private static string _inputVideo = "";
        public static string InputVideo
        {
            get { return _inputVideo; }
            set { _inputVideo = value; }
        }

        private static string _outputVideo = "";
        public static string OuputVideo
        {
            get { return _outputVideo; }
            set { _outputVideo = value; }
        }

        private static string _startup = Application.StartupPath;
        public static string startupPath
        {
            get { return _startup; }
            set { _startup = value; }
        }
        private static string _Date2 = "";
        public static string Date2
        {
            get { return _Date2; }
            set { _Date2 = value; }
        }

        private static string _Date3 = "";
        public static string Date3
        {
            get { return _Date3; }
            set { _Date3 = value; }
        }

        private static bool _Fire = false;
        public static bool Fire
        {
            get { return _Fire; }
            set { _Fire = value; }
        }

        private static bool _Rec = false;
        public static bool Rec
        {
            get { return _Rec; }
            set { _Rec = value; }
        }

        private static int _sCount = 0;
        public static int sCount
        {
            get { return _sCount; }
            set { _sCount = value; }
        }

        private static string _PatientID = "";
        public static string PatientID
        {
            get { return _PatientID; }
            set { _PatientID = value; }
        }

        private static string _HN = "";
        public static string HN
        {
            get { return _HN; }
            set { _HN = value; }
        }

        private static string _firstname = "";
        public static string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private static string _lastname = "";
        public static string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private static string _age = "";
        public static string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private static string _gender = "";
        public static string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private static string _date;
        public static string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private static string _rdate;
        public static string rDate
        {
            get { return _rdate; }
            set { _rdate = value; }
        }

        private static string _endoscopist;
        public static string Endoscopist
        {
            get { return _endoscopist; }
            set { _endoscopist = value; }
        }

        private static string _modelseries;
        public static string Modelseries
        {
            get { return _modelseries; }
            set { _modelseries = value; }
        }

        private static string _modelseries2;
        public static string Modelseries2
        {
            get { return _modelseries2; }
            set { _modelseries2 = value; }
        }

        private static string _modelseries3;
        public static string Modelseries3
        {
            get { return _modelseries3; }
            set { _modelseries3 = value; }

        }
        private static string _nurse;
        public static string Nurse
        {
            get { return _nurse; }
            set { _nurse = value; }
        }

        private static string _nurse2;
        public static string Nurse_2
        {
            get { return _nurse2; }
            set { _nurse2 = value; }

        }

        private static string _nurse3;
        public static string Nurse_3
        {
            get { return _nurse3; }
            set { _nurse3 = value; }

        }

        private static string _pro;
        public static string Pro
        {
            get { return _pro; }
            set { _pro = value; }
        }

        private static bool _gastroChkBox;
        public static bool GastroChkBox
        {
            get { return _gastroChkBox; }
            set { _gastroChkBox = value; }
        }

        private static bool _colonChkBox;
        public static bool ColonChkBox
        {
            get { return _colonChkBox; }
            set { _colonChkBox = value; }
        }

        private static bool _ercpChkBox;
        public static bool ERCPChkBox
        {
            get { return _ercpChkBox; }
            set { _ercpChkBox = value; }
        }

        private static bool _broncoBox;
        public static bool BroncoBox
        {
            get { return _broncoBox; }
            set { _broncoBox = value; }
        }

        private static bool _plureoBox;
        public static bool PlueroBox
        {
            get { return _plureoBox; }
            set { _plureoBox = value; }
        }

        private static bool _urologyChkBox;
        public static bool UrologyChkBox
        {
            get { return _urologyChkBox; }
            set { _urologyChkBox = value; }

        }

        private static bool _entChkBox;
        public static bool ENTChkBox
        {
            get { return _entChkBox; }
            set { _entChkBox = value; }
        }

        public static string Report_ID;

    }
    public static class PrintQueue
    {
        private static string _FirstName = "";
        public static string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private static string _LastName = "";
        public static string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private static string _HN = "";
        public static string HN
        {
            get { return _HN; }
            set { _HN = value; }
        }
        private static string _Age = "";
        public static string Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        private static string _Sex = "";
        public static string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        private static string _Date = "";
        public static string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private static string _Pro = "";
        public static string Pro
        {
            get { return _Pro; }
            set { _Pro = value; }
        }

        private static string _Anes = "";
        public static string Anes
        {
            get { return _Anes; }
            set { _Anes = value; }
        }

        private static string _Consultant = "";
        public static string Consultant
        {
            get { return _Consultant; }
            set { _Consultant = value; }
        }
        private static string _Endos = "";
        public static string Endos
        {
            get { return _Endos; }
            set { _Endos = value; }
        }
        private static string _Indication = "";
        public static string Indication
        {
            get { return _Indication; }
            set { _Indication = value; }
        }
        private static string _Sedation = "";
        public static string Sedation
        {
            get { return _Sedation; }
            set { _Sedation = value; }
        }

        private static string _hPylori = "";
        public static string hPylori
        {
            get { return _hPylori; }
            set { _hPylori = value; }
        }
        private static string _hPyloriResult = "";
        public static string hPyloriResult
        {
            get { return _hPyloriResult; }
            set { _hPyloriResult = value; }
        }
        private static string _Patho = "";
        public static string Patho
        {
            get { return _Patho; }
            set { _Patho = value; }
        }
        private static string _PathoResult = "";
        public static string PathoResult
        {
            get { return _PathoResult; }
            set { _PathoResult = value; }
        }

        private static string _Bronchial = "";
        public static string Bronchial
        {
            get { return _Bronchial; }
            set { _Bronchial = value; }
        }

        private static string _BAL = "";
        public static string BAL
        {
            get { return _BAL; }
            set { _BAL = value; }
        }

        private static string _TBNA = "";
        public static string TBNA
        {
            get { return _TBNA; }
            set { _TBNA = value; }
        }

        private static string _Comments = "";
        public static string Commentss
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        private static string _Diagnosis = "";
        public static string Diagnosis
        {
            get { return _Diagnosis; }
            set { _Diagnosis = value; }
        }

        private static string _imgDirectory = "";
        public static string imgDirectory
        {
            get { return _imgDirectory; }
            set { _imgDirectory = value; }
        }

        private static string _imgDirectoryRoot = "";

        public static string imgDirectoryRoot
        {
            get { return _imgDirectoryRoot; }
            set { _imgDirectoryRoot = value; }
        }

        private static string _nextApp = "";
        public static string nextApp
        {
            get { return _nextApp; }
            set { _nextApp = value; }
        }
    }

}
