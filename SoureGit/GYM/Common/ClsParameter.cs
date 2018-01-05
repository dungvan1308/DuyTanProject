using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GYM.Common
{
    public class ClsParameter
    {
        public const string SQL_BACKUP_PATH = @"C:\Backup\";
        public const string SYSTEM_DATE_FORMAT = "dd/MM/yyyy";
        public const string DATE_FORMAT_DD_MM_YYYY_HH_MM_SS = "dd/MM/yyyy HH:mm:ss tt";
        public const string SQL_SET_DATE_FORMAT = " SET DATEFORMAT DMY ";
        public const string OBJECT_EXIST_CODE = "99999";
        public const string OBJECT_DELETE_SUCCESSFUL = "11111";
        public const string OBJECT_DELETE_IN_USE = "00000";
        public const string MSG_DATEEFFECT_EMPTY = "Chưa chọn ngày hiệu lực";
        public const string FONT_FAMILY_NAME = "Times New Roman";
        public const int REPORT_COMPANY_INFO_WIDTH = 500;
        public const int REPORT_COMPANY_INFO_HEIGHT = 100;
        public const string STATUS_VALUE_OPEN = "O";
        public const string STATUS_VALUE_CLOSE = "C";
        public const string STATUS_VALUE_ALL = "A";
        public const string STATUS_TEXT_ALL = "Tất cả";

        public const string MODE_VIEW = "VIEW";
        public const string MODULE = "MODULE";
        public const string MODULE_REPORT = "RPT";
        public const string MODE_ADD = "ADD";
        public const string MODE_UPDATE = "UPDATE";
        public const string MSG_DATA_ERROR = "Lỗi dữ liệu";
        public const string MSG_UPDATE_SUCCESSFULL = "Cập nhập thành công";
        public const string MSG_ADD_SUCCESSFULL = "Thêm mới thành công";
        public const string MSG_TRANSACTION_SUCCESSFULL = "Giao dịch thành công";
        public const string MSG_TRANSACTION_FAIL = "Giao dịch không thành công";
        public const string MSG_ADD_FAIL = "Thêm mới không thành công";
        public const string MSG_UPDATE_FAIL = "Cập nhập không thành công";
        public const string MSG_OBJECT_IN_USE = "Sản phẩm đang sử dụng";
        public const string MSG_USERS_EXIST = "Người dùng tồn tại ";
        public const string MSG_USERS_NOT_EXIST = "Người dùng không tồn tại";
        public const string MSG_USERS_NOT_SELECTED = "Chưa chọn người dùng";
        public const string MSG_OBJ_NOT_SELECTED = "Chưa chọn đối tượng";
        public const string MSG_DATA_BLANK = "Dữ liệu để trống";
        public const string MSG_LOGIN_SUCESS = "Đăng nhập thành công";
        public const string MSG_LOGIN_FAIL = "Đăng nhập thất bại";
        public const string MSG_DELETE_OR_NOT = "Có xóa hay không ?";
        public const string MSG_DELTE_SUCESSFULL = "Xóa thành công ";
        public const string MSG_LOCK_USER_SUCESSFULL = " Khóa người dùng thành công ";
        public const string MSG_UNLOCK_SUCESSFULL = " Mở khóa người dùng thành công ";
        public const string MSG_YESNO_LOCK = " Bạn muốn khóa người dùng ? ";
        public const string MSG_YESNO_UNLOCK = " Bạn muốn mở khóa người dùng ? ";
        public const string MSG_DELETE_FAIL = "Xóa không thành công ";
        public const string MSG_YESNO_DELETE = "Bạn có muốn xóa không ?";
        public const string MSG_QUESTION_SAVE = "Bạn có lưu không ? ";
        public const string MSG_QUESTION_TRAN = "Bạn có muốn thực hiện giao dịch ? ";
        public const string MSG_QUESTION_BACKUP = "Bạn muốn sao lưu dữ liệu ? ";
        public const string MSG_QUESTION_RESTORE = "Bạn muốn khôi phục dữ liệu ? ";
        public const string MSG_BACKUP_SUCCESS = "Sao lưu dữ liệu thành công ";
        public const string MSG_RESTORE_SUCCESS = "Khôi phục dữ liệu thành công ";
        public const string MSG_BACKUP_FAIL = "Sao lưu dữ liệu không thành công ";
        public const string MSG_RESTORE_FAIL = "Khôi phục dữ liệu không thành công ";
        public const string MSG_FILENAME_EMTY = "Chưa chọn file dữ liệu ";
        public const string FILED_TODATE = "TODATE";
        public const string FILED_OLD_TODATE = "OLD_DATE";

        #region Hanh trinh Xe
        public const string MODULE_JOURNEY = "JOURNEY";
        public const string MODULE_PLACE ="PLACE";
        public const string MODULE_TRUST = "TRUST";
        #endregion 

        #region Group User
        public const string MODULE_GROUPUSER = "GROUPUSER";
        public const string TITLE_GROUPUSER = "Nhóm người dùng";
        public const string MSG_GROUPNAME_EMPTY = "Tên nhóm người dùng bỏ trống";
        public const string MSG_GROUP_USER_ISUSE = " Nhóm người dùng đã sử dụng ";
        public const string MSG_GROUP_USER_NAME_EXIST = "Tên nhóm người dùng tồn tại";
        #endregion 

        #region User
        public const string MODULE_USER = "USERS";
        public const string TITLE_USER = "Người dùng";
        public const string MSG_USERS_USERNAME_EMPTY = "Tên người dùng bỏ trống.";
        public const string MSG_USERS_FULLNAME_EMPTY = "Họ tên người dùng bỏ trống.";
        public const string MSG_USERS_PASS_NOT_SAME = "Mật khẩu nhập lại không đúng";
        public const string MSG_USERS_PASS_OLD_INVALID = "Mật khẩu cũ không đúng.";
        public const string MSG_USERS_PASS_EMPTY = "Mật khẩu trống.";
        public const string MSG_USERS_NEW_PASS_EMPTY = "Mật khẩu mới trống.";
        public const string MSG_USERS_RESET_PASS_SUCCESS = "Thiết lập mật khẩu thành công.";
        public const string MSG_USERS_RESET_PASS_FAIL = "Thiết lập mật khẩu không thành công.";
        public const string MSG_USER_CHANGE_PASS_FAIL = " Đổi mật khẩu không thành công. ";
        public const string MSG_USER_CHANGE_PASS_SUCESSS = " Đổi mật khẩu thành công. ";
        public const string MSG_LOCK_USER_FAIL = " Khóa người dùng không thành công. ";
        public const string MSG_UNLOCK_USER_SUCESSFULL = " Mở khóa người dùng thành công. ";
        public const string MSG_UNLOCK_USER_FAIL = " Mở khóa người dùng không thành công. ";
        public const string MSG_USER_ISUSE = "Người dùng đã sử dụng. ";
        public const string MSG_USERS_GROUP_USER_EMPTY = "Nhóm người dùng bỏ trống.";
        public const string MSG_USERS_UNLOCK_EXIST = "Người dùng đã mở khóa rồi.";
        public const string MSG_USERS_LOCK_EXIST = "Người dùng đã khóa rồi.";


        #endregion
        #region Employee
        public const string MODULE_EMP = "EMPLOYEE";
        public const string TITLE_EMP = "Nhân viên";

        public const string MSG_EMPLOYEE_IN_USE = "Nhân viên đã sử dụng.";
        public const string MSG_EMPLOYEE_ID_EMPTY = "Mã nhân viên bỏ trống.";
        public const string MSG_EMPLOYEE_NAME_EMPTY = "Tên nhân viên bỏ trống.";
        public const string MSG_EMPLOYEE_BIRTH_DAY_EMPTY = "Ngày sinh bỏ trống.";
        public const string MSG_EMPLOYEE_BIRTH_DAY_INVALID = "Ngày sinh phải nhỏ hơn ngày hiện tại.";
        public const string MSG_EMPLOYEE_ID_CARD_DAY_NOW_INVALID = "Ngày cấp phải nhỏ hơn ngày hiện tại.";
        public const string MSG_EMPLOYEE_ID_CARD_DAY_INVALID = "Ngày cấp CMND phải lớn hơn ngày sinh.";
        public const string MSG_EMPLOYEE_CONTRACT_START_END_DATE_INVALID = "Ngày bắt đầu HĐ lớn hơn ngày kết thúc HĐ.";
        public const string MSG_EMPLOYEE_CONTRACT_DAY_INVALID = "Ngày hợp đồng không đúng.";
        public const string MSG_EMPLOYEE_NAME_EXIST = "Nhân viên tồn tại. ";
        public const string MSG_EMPLOYEE_NOT_SELECTED = " Chưa chọn nhân viên.";
        public const string MSG_AMOUNT_NOT_INPUT = " Chưa nhập số tiền. ";
        public const string MSG_SALARY_MONTH_NOT_INPUT = "Chưa nhập kì trả lương. ";
        public const string MSG_REPORT_NOT_SELECTED = "Chưa chọn báo cáo. ";

        public const string EDUCATION_VALUE_PHD = "01";
        public const string EDUCATION_VALUE_MASTER = "02";
        public const string EDUCATION_VALUE_BACHELOR = "03";
        public const string EDUCATION_VALUE_COLLEGE = "04";
        public const string EDUCATION_VALUE_JUNIOR = "05";

        public const string MATERIAL_VALUE_MARRIED = "02";
        public const string MATERIAL_VALUE_SINGLE = "01";
        public const string GENDER_VALUE_MAN = "M";
        public const string GENDER_VALUE_WOMAN = "F";

        public const string MSG_EMPLOYEE_CANNOT_SELECT_IMAGE = "Không chọn được hình ảnh !";

        #endregion
        #region Customer
        public const string MODULE_CUST = "CUSTOMER";
        public const string TITLE_CUST = "Khách hàng";
        public const string TITLE_PROVIDER = "Nhà cung cấp";
        public const string MSG_CUST_ISUSE = "Khách hàng đã sử dụng ";
        public const string MSG_PROGRAM_ISUSE = "Chương trình đã sử dụng";
        public const string MSG_CUST_NOT_SELECT = "Chưa chọn khách hàng";
        public const string MSG_PROVIDER_NOT_SELECT = "Chưa chọn nhà cung cấp";
        public const string MSG_CUST_NAME_EMPTY = "Tên khách hàng bỏ trống";
        public const string MSG_CUST_NOT_HAVE = "Chưa có khách hàng";

        #endregion
        #region Contract
        public const string MODULE_CONTRACT = "CONTRACT";
        public const string TITLE_CONTRACT = "Hợp đồng";

        public const string MSG_CONTRACT_FROM_DATE = "Ngày hiệu lực phải lớn hơn bằng ngày hợp đồng.";
        public const string MSG_CONTRACT_TO_DATE = "Đến ngày hiệu lực phải lớn hơn ngày hiệu lực hợp đồng.";
        public const string MSG_CONTRACT_NAME_EMPTY = "Tên hợp động để trống.";
        public const string MSG_CONTRACT_FROMDATE_EMPTY = "Ngày hiệu lực không được để trống.";
        public const string MSG_CONTRACT_TODATE_EMPTY = "Ngày đến hạn không được để trống.";
        public const string MSG_CONTRACT_PRODUCT_EMPTY = "Gói sản phẩm không để trống.";
        public const string MSG_CONTRACT_CUS_EMPTY ="Khách hàng không để trống.";
        public const string MSG_CONTRACT_EMPTY = "Chưa chọn hợp đồng.";

        #endregion

        #region Program 
        public const string MODULE_PROGRAME = "PROGRAME";
        public const string TITLE_PROGRAME = "Chương trình";
        #endregion 

        #region FingerPrint
        public const string MODULE_FINGERPRINT = "FINGERPRINT";
        public const string TITLE_FINGERPRINT = "FINGERPRINT";
        #endregion
        #region commonform
        public const string LIST_COLUMN_NO = "STT";
        public const string LIST_COLUMN_TXNUM = "Số giao dịch";
        public const string LIST_COLUMN_TXDATE = "Ngày giao dịch";
        public const string LIST_COLUMN_PAYDATE = "Ngày thanh toán ";
        public const string LIST_COLUMN_TIMES = "Lần giao dịch";
        public const string LIST_COLUMN_TXDESC = "Tên giao dịch";
        public const string LIST_COLUMN_DESC = "Diễn giải";
        public const string LIST_COLUMN_AMOUNT = "Số tiền";
        public const string LIST_COLUMN_PAY_AMOUNT = "Số tiền thanh toán";
        public const string LIST_COLUMN_PAYMETHOD = "Phương thức thanh toán";
        public const string LIST_COLUMN_TRAN_KIND = "Loại giao dịch";
        public const string LIST_COLUMN_PRODUCT = "Sản phẩm";
        public const string LIST_REPORT_NAME = "Tên báo cáo";
        public const string LIST_DESC = "Diễn giải";

        public const string LIST_COLUMN_ID = "Mã";
        public const string LIST_COLUMN_BILL_NAME = "Tên hóa đơn";
        public const string LIST_COLUMN_QUALITY = "Số lượng";
        public const string LIST_COLUMN_OUTPUT = "Số lượng xuất";
        public const string LIST_COLUMN_STATUS = "Trạng thái";
        public const string LIST_COLUMN_COST = "Chi phí";
        public const string LIST_COLUMN_INCOME = "Thu nhập";
        public const string LIST_COLUMN_PROVIDER = "Nhà cung cấp";
        public const string LIST_COLUMN_ALERT_MIN = "SL Tối thiểu";
        public const string LIST_COLUMN_ALERT_CONTENT = "Cảnh báo";
        public const string LIST_COLUMN_CORRUPT = "SL Hư";

        public const string LIST_COLUMN_CREATED_BY = "Người tạo";
        public const string LIST_COLUMN_CREATED_DATE = "Ngày tạo";
        public const string LIST_COLUMN_MODIFIED_BY = "Người chỉnh sửa";
        public const string LIST_COLUMN_MODIFIED_DATE = "Ngày chỉnh sửa";

        public const string LIST_COLUMN_FRDATE = "Từ ngày ";
        public const string LIST_COLUMN_TODATE = "Đến ngày ";
        public const string LIST_COLUMN_ADVERTISENAME = "Chương trình khuyến mãi";
        public const string LIST_COLUMN_CUST_NAME = "Khách hàng";
        public const string LIST_COLUMN_ORDERDATE = "Ngày nhận đơn hàng";
        public const string LIST_COLUMN_OUTDATE = "Ngày giao hàng";
        public const string LIST_COLUMN_RECIPIENT = "Người nhận";
        public const string LIST_COLUMN_WAREHOUSENAME = "Nơi xuất kho";


        public const string LIST_COLUMN_EMPLOYEE_NAME = "Nhân viên";
        public const string LIST_COLUMN_EMPLOYEE_BIRTHDAY = "Ngày sinh";
        public const string LIST_COLUMN_EMPLOYEE_BIRTHPLACE = "Nơi sinh";
        public const string LIST_COLUMN_EMPLOYEE_IDENTITY_ID = "CMND";
        public const string LIST_COLUMN_EMPLOYEE_IDENTITY_ISSUE_DATE = "Ngày cấp";
        public const string LIST_COLUMN_EMPLOYEE_IDENTITY_ISSUE_PLACE = "Nơi cấp";
        public const string LIST_COLUMN_EMPLOYEE_GENDER = "Giới tính";
        public const string LIST_COLUMN_EMPLOYEE_MATERIAL_STATUS = "Tình trạng hôn nhân";
        public const string LIST_COLUMN_EMPLOYEE_ADDRESS = "Địa chỉ";
        public const string LIST_COLUMN_EMPLOYEE_CITY = "Thành phố";
        public const string LIST_COLUMN_EMPLOYEE_PHONE = "Số điện thoại";
        public const string LIST_COLUMN_EMPLOYEE_MOBILE = "Số di động";
        public const string LIST_COLUMN_EMPLOYEE_YAHOO = "Yahoo";
        public const string LIST_COLUMN_EMPLOYEE_SKYPE = "Skype";
        public const string LIST_COLUMN_EMPLOYEE_EMAIL = "Email";

        public const string LIST_COLUMN_EMPLOYEE_EDUCATION = "Trình độ học vấn";
        public const string LIST_COLUMN_EMPLOYEE_SPECIALIZE = "Chuyên ngành";

        public const string LIST_COLUMN_EMPLOYEE_CONTRACT = "Hợp đồng";
        public const string LIST_COLUMN_EMPLOYEE_CONTRACT_TYPE = "Loại Hợp đồng";
        public const string LIST_COLUMN_EMPLOYEE_CONTRACT_START_DATE = "Ngày bắt đầu";
        public const string LIST_COLUMN_EMPLOYEE_CONTRACT_END_DATE = "Ngày kết thúc";
        public const string LIST_COLUMN_EMPLOYEE_STATUS = "Tình trạng";
        public const string MSG_DATEFORMAT_ERR = "Sai định dạng ngày ";

        public const string MSG_GROUP_CUST_INVALID_PHONE_NUMBER = "Số điện thoại không đúng";
        public const string PARA_CUSTID = "@CUSTID";
        public const string PARA_EMPLOYEEID = "@EMPLOYEEID";

        public const string FIELD_CONTRACTID = "CONTRACTID";
        public const string FIELD_CONTRACTNAME = "CONTRACTNAME";
        public const string FIELD_CUSTID = "CUSTID";
        public const string FIELD_EMPLOYEEID = "EMPLOYEEID";
        public const string FIELD_CUSTNAME = "CUSTNAME";
        public const string FIELD_ADDRESS = "ADDRESS";
        public const string FIELD_PAID = "PAID";    // Số tiền thanh toán
        public const string TYPE_NUMBER = "NUMBER";
        public const string MAIN_KEY = "1";

        #endregion

        public struct STRUCTINFO
        {
            public string NAME;
            public string VALUE;
            public string KEY;

        }

        public struct STRUCT_INFOLOGIN
        {
            //De khi login lay duoc thong tin dang nhap 
            public static string UserId;
            public static string UserName;
            public static string FullName;
            public static string GroupId;

            //Thong tin doanh nghiep 
            public static string CompanyName;
            public static string Address;
            public static string Tax;
            public static string Tel;
            public static string Fax;

        }
    }
}
