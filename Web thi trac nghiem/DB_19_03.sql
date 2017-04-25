USE master
GO
DROP DATABASE EXON_SYSTEM
GO
-------------------------------- Update 19/03 --------------------------------
GO
CREATE DATABASE EXON_SYSTEM
GO
USE EXON_SYSTEM
GO
-------------------------------- G --------------------------------
GO
CREATE TABLE DEPARTMENTS -- Phòng, Ban, Bộ môn
(
	DepartmentID int PRIMARY KEY IDENTITY,
	DepartmentCode nvarchar(10) NOT NULL, -- Mã phòng, ban
	DepartmentName nvarchar(MAX) NOT NULL, -- Tên phòng, ban
	[Level] int NOT NULL DEFAULT 1, -- Cấp độ
	[Status] int NOT NULL DEFAULT 1, -- Trạng thái
	
	CONSTRAINT UNIQUE_DepartmentCode UNIQUE (DepartmentCode),
	CONSTRAINT CHECK_DepartmentCode CHECK (LEN(DepartmentCode) > 0),
	CONSTRAINT CHECK_DepartmentName CHECK (LEN(DepartmentName) > 0),

	DepartmentIDParent int,
	CONSTRAINT FK_DEPARTMENTS_DEPARTMENT FOREIGN KEY(DepartmentIDParent) REFERENCES DEPARTMENTS(DepartmentID)
)
GO
CREATE TABLE POSITIONS -- Chức vụ / quyền truy cập
(
	PositionID int PRIMARY KEY IDENTITY,
	PositionCode nvarchar(10) NOT NULL, -- Mã chức vụ
	PositionName nvarchar(MAX) NOT NULL, -- Tên chức vụ
	[Permission] int NOT NULL DEFAULT 1, -- Quyền hạn, ex: 0: Chủ nhiệm khoa, 1: Chủ nhiệm bộ môn, ...
	[Status] int NOT NULL DEFAULT 1,

	CONSTRAINT UNIQUE_PositionCode UNIQUE (PositionCode),
	CONSTRAINT CHECK_PositionCode CHECK (LEN(PositionCode) > 0),
	CONSTRAINT CHECK_PositionName CHECK (LEN(PositionName) > 0)
)
GO
CREATE TABLE STAFFS -- Thông tin giảng viên / cán bộ học viện
(
	StaffID int PRIMARY KEY IDENTITY,
	Username varchar(20) NOT NULL, -- Tên đăng nhập
	[Password] varchar(20) NOT NULL, -- Mật khẩu
	Fullname nvarchar(MAX) NOT NULL, -- Tên cán bộ
	Birthday int NOT NULL, -- Ngày sinh
	Sex int NOT NULL, -- Giới tính
	IdentityCardNumber varchar(12) NOT NULL, -- Số CMND
	AcademicRank nvarchar(MAX), -- Học hàm
	Degree nvarchar(MAX), -- Học vị
	CurrentAddress nvarchar(MAX), -- Địa chỉ hiện tại
	[Status] int NOT NULL DEFAULT 1,

	CONSTRAINT UNIQUE_StaffIdentification UNIQUE (Username),
	CONSTRAINT CHECK_StaffIdentification CHECK (LEN(Username) > 0),
	CONSTRAINT CHECK_Password CHECK (LEN([Password]) > 0),
	CONSTRAINT CHECK_Fullname CHECK (LEN(Fullname) > 0),

	PositionID int NOT NULL, -- Chức vụ
	CONSTRAINT FK_STAFFS_POSITION FOREIGN KEY(PositionID) REFERENCES POSITIONS(PositionID),
	DepartmentID int NOT NULL, -- Phòng, Ban, Khoa, Bộ môn
	CONSTRAINT FK_STAFFS_DEPARTMENT FOREIGN KEY(DepartmentID) REFERENCES DEPARTMENTS(DepartmentID),
)
GO
CREATE TABLE SUBJECTS -- Môn thi
(
	SubjectID int PRIMARY KEY IDENTITY,
	SubjectCode nvarchar(10) NOT NULL, -- Mã môn
	SubjectName nvarchar(MAX) NOT NULL, -- Tên môn
	[Status] int NOT NULL DEFAULT 1,

	CONSTRAINT UNIQUE_SubjectCode UNIQUE (SubjectCode),
	CONSTRAINT CHECK_SubjectCode CHECK (LEN(SubjectCode) > 0),
	CONSTRAINT CHECK_SubjectName CHECK (LEN(SubjectName) > 0),

	DepartmentID int NOT NULL,
	CONSTRAINT FK_SUBJECTS_DEPARTMENT FOREIGN KEY(DepartmentID) REFERENCES DEPARTMENTS(DepartmentID)
)
GO
CREATE TABLE MODULES -- Lớp học phần
(
	ModuleID int PRIMARY KEY IDENTITY,
	ModuleCode nvarchar(10) NOT NULL, -- Mã lớp học phần
	SchoolYear int NOT NULL DEFAULT 2017, -- Năm học
	[Description] nvarchar(MAX),
	[Status] int NOT NULL DEFAULT 1,

	SubjectID int NOT NULL,
	CONSTRAINT FK_MODULES_SUBJECT FOREIGN KEY(SubjectID) REFERENCES SUBJECTS(SubjectID)
)
GO
CREATE TABLE TOPICS -- Chủ đề
(
	TopicID int PRIMARY KEY IDENTITY,
	TopicName nvarchar(100),
	[Description] nvarchar(MAX),
	[Status] int NOT NULL DEFAULT 1,

	SubjectID int NOT NULL,
	CONSTRAINT FK_TOPICS_SUBJECT FOREIGN KEY(SubjectID) REFERENCES SUBJECTS(SubjectID)
)
GO
CREATE TABLE TOPICS_STAFFS -- Phân công giáo viên ra câu hỏi
(
	TopicStaffID int PRIMARY KEY IDENTITY,
	BeginDate int, -- Ngày bắt đầu
	EndDate int, -- Ngày kết thúc
	[Description] nvarchar(MAX),
	[Status] int NOT NULL DEFAULT 1,

	TopicID int NOT NULL,
	CONSTRAINT FK_STAFFS_TOPIC FOREIGN KEY(TopicID) REFERENCES TOPICS(TopicID),
	StaffID1 int, -- Người phân công
	CONSTRAINT FK_TOPICS_STAFF1 FOREIGN KEY(StaffID1) REFERENCES STAFFS(StaffID),
	StaffID2 int, -- Người được phân công
	CONSTRAINT FK_TOPICS_STAFF2 FOREIGN KEY(StaffID2) REFERENCES STAFFS(StaffID)
)
GO
-------------------------------- Kiên --------------------------------
GO
CREATE TABLE QUESTION_TYPES -- Loại câu hỏi
(
	QuestionTypeID int PRIMARY KEY IDENTITY,
	QuestionTypeName nvarchar(20) NOT NULL, -- Tên ngắn gọn
	[Description] nvarchar(200) NOT NULL, -- Mô tả loại câu hỏi
	IsQuiz bit NOT NULL DEFAULT 1, -- Trắc nghiệm /0: Tự luận
	IsSingleChoice bit NOT NULL DEFAULT 1, -- Đáp án duy nhất /0: Đa đáp án
	IsParagraph bit NOT NULL DEFAULT 1, -- Có đoạn văn /0: Không có đoạn văn
	IsQuestionContent bit NOT NULL DEFAULT 1, -- Có nội dung câu hỏi /0: Không có nội dung câu hỏi
	IsMixSubQuestion bit NOT NULL DEFAULT 1, -- Đảo câu hỏi con /0: Không đảo câu hỏi con
	-- IsMixAnswer bit NOT NULL DEFAULT 1, -- Đảo câu trả lời /0: Không đảo câu trả lời
	NumberSubQuestion int NOT NULL DEFAULT 2, -- Số câu hỏi con
	NumberAnswer int NOT NULL DEFAULT 4, -- Số câu trả lời/cho mỗi câu hỏi con
	[Status] int NOT NULL DEFAULT 1, -- Trạng thái
)
GO
CREATE TABLE QUESTIONS -- Câu hỏi (Đoạn văn)
(
	QuestionID int PRIMARY KEY IDENTITY,
	QuestionContent nvarchar(MAX), -- Nội dung đoạn văn
	[Level] int DEFAULT 1, -- Độ khó 1-4
	[Status] int NOT NULL DEFAULT 1, -- Trạng thái 1: new; 2: đã xét; 3: làm lại
	[CreatedDate] int, -- Ngày tạo
	[UpdateDate] int, -- Ngày sửa
	[AcceptedDate] int, -- Ngày duyệt

	QuestionTypeID int, -- Loại câu hỏi
	CONSTRAINT FK_QUESTIONS_QUESTIONTYPE FOREIGN KEY(QuestionTypeID) REFERENCES QUESTION_TYPES(QuestionTypeID),
	TopicID int, -- Chủ đề
	CONSTRAINT FK_QUESTIONS_TOPIC FOREIGN KEY(TopicID) REFERENCES TOPICS(TopicID),
	StaffID1 int, -- Người tạo
	CONSTRAINT FK_QUESTIONS_STAFF1 FOREIGN KEY(StaffID1) REFERENCES STAFFS(StaffID),
	StaffID2 int, -- Người duyệt
	CONSTRAINT FK_QUESTIONS_STAFF2 FOREIGN KEY(StaffID2) REFERENCES STAFFS(StaffID)
)
GO
CREATE TABLE SUBQUESTIONS -- Câu hỏi con
(
	SubQuestionID int PRIMARY KEY IDENTITY,
	SubQuestionContent nvarchar(MAX), -- Nội dung câu hỏi con
	FixedPosition int DEFAULT 0, -- Vị trí cố định
	Score float NOT NULL DEFAULT 0, -- Điểm cho câu hỏi

	QuestionID int,
	CONSTRAINT FK_SUBQUESTIONS_QUESTION FOREIGN KEY(QuestionID) REFERENCES QUESTIONS(QuestionID)
)
GO
CREATE TABLE ANSWERS -- Câu trả lời
(
	AnswerID int PRIMARY KEY IDENTITY,
	AnswerContent nvarchar(MAX), -- Nội dung câu trả lời
	-- FixedPosition int DEFAULT 0, -- Vị trí cố định
	IsCorrect bit NOT NULL DEFAULT 0, -- Đáp án đúng

	SubQuestionID int,
	CONSTRAINT FK_ANSWERS_SUBQUESTION FOREIGN KEY(SubQuestionID) REFERENCES SUBQUESTIONS(SubQuestionID)
)
GO
-------------------------------- Linh --------------------------------
GO
CREATE TABLE CONTEST_TYPES -- Hình thức thi
(
	ContestTypeID int PRIMARY KEY IDENTITY,
	ContestTypeName nvarchar(50), -- Tự luận, trác nghiệm
	[Status] int NOT NULL DEFAULT 1
)
GO
CREATE TABLE CONTESTS -- Kỳ thi
(
	ContestID int PRIMARY KEY IDENTITY,
	ContestName nvarchar(100),
	[Description] nvarchar(MAX),
	CreateDate int, -- Ngày tạo
	AcceptDate int, -- Ngày duyệt
	BeginRegisiter int, -- Ngày bắt đầu đk
	EndRegister int, -- Ngày kết thúc đk
	QuestionStartDate int, -- Ngày tạo câu hỏi
	QuestionEndDate int, -- Ngày kết thúc tạo câu hỏi
	SchoolYear int,
	[Status] int NOT NULL DEFAULT 1,

	StaffID1 int, -- Người tạo
	CONSTRAINT FK_CONTESTS_STAFF1 FOREIGN KEY(StaffID1) REFERENCES STAFFS(StaffID),
	StaffID2 int, -- Người duyệt
	CONSTRAINT FK_CONTESTS_STAFF2 FOREIGN KEY(StaffID2) REFERENCES STAFFS(StaffID)
)
GO
CREATE TABLE SCHEDULES -- Lịch thi / Chi tiết kỳ thi
(
	ScheduleID int PRIMARY KEY IDENTITY,
	StartDate int, -- Ngày bắt đầu
	EndDate int, -- Ngày kết thúc
	TimeOfTest int NOT NULL, -- Thời gian thi (theo phút)
	[Status] int NOT NULL DEFAULT 1,

	ContestID int, -- Kỳ thi
	CONSTRAINT FK_SCHEDULES_CONTEST FOREIGN KEY(ContestID) REFERENCES CONTESTS(ContestID),
	SubjectID int, -- Môn thi
	CONSTRAINT FK_SCHEDULES_SUBJECT FOREIGN KEY(SubjectID) REFERENCES SUBJECTS(SubjectID),
	ContestTypeID int, -- Hình thức thi
	CONSTRAINT FK_SCHEDULES_CONTESTTYPE FOREIGN KEY(ContestTypeID) REFERENCES CONTEST_TYPES(ContestTypeID)
)
GO
-------------------------------- Kiên --------------------------------
GO
CREATE TABLE STRUCTURES -- Cấu trúc đề thi
(
	StructureID int PRIMARY KEY IDENTITY,
	CreateDate int, -- Ngày tạo
	[Status] int NOT NULL DEFAULT 1,

	ScheduleID int, -- Chi tiết kỳ thi
	CONSTRAINT FK_STRUCTURES_SCHEDULE FOREIGN KEY(ScheduleID) REFERENCES SCHEDULES(ScheduleID),
	StaffID int, -- Người tạo
	CONSTRAINT FK_STRUCTURES_STAFF FOREIGN KEY(StaffID) REFERENCES STAFFS(StaffID)
)
GO
CREATE TABLE STRUCTURE_DETAIL -- Cấu trúc đề thi chi tiết
(
	StructureDetailID int PRIMARY KEY IDENTITY,
	NumberQuestions int, -- Số câu trong chủ đề
	[Level] int, -- Độ khó

	StructureID int, -- Cấu trúc
	CONSTRAINT FK_STRUCTUREDETAIL_STRUCTURE FOREIGN KEY(StructureID) REFERENCES STRUCTURES(StructureID),
	TopicID int, -- Chủ đề
	CONSTRAINT FK_STRUCTUREDETAIL_TOPIC FOREIGN KEY(TopicID) REFERENCES TOPICS(TopicID),
	QuestionTypeID int, -- Loại câu hỏi
	CONSTRAINT FK_STRUCTUREDETAIL_QUESTIONTYPE FOREIGN KEY(QuestionTypeID) REFERENCES QUESTION_TYPES(QuestionTypeID)
)
GO
-------------------------------- Hương - Bắt đầu đăng ký --------------------------------
GO
CREATE TABLE CONTESTANT_TYPES -- Loại thí sinh
(
	ContestantTypeID int PRIMARY KEY IDENTITY,
	ContestantTypeName nvarchar(50),
	[Status] int NOT NULL DEFAULT 1
)
GO
CREATE TABLE REGISTERS -- Đăng ký
(
	RegisterID int PRIMARY KEY IDENTITY,
	FullName nvarchar(50), -- Họ tên
	Birthday int, -- Ngày sinh
	Ethnic nvarchar(100), -- Dân tộc
	PlaceOfBirth nvarchar(MAX), -- Nơi sinh
	HighSchool nvarchar(MAX), -- Trường trung học
	Sex int, -- Giới tính
	IdentityCardNumber varchar(12), -- Số CMND
	Unit nvarchar(100), -- Đơn vị (lớp)
	CurrentAddress nvarchar(MAX), -- Địa chỉ hiện tại
	RegisterDate int, -- Ngày đăng ký
	RegisterType bit, -- Hình thức đk 1: ONLINE 0: OFFLINE
	[Status] int NOT NULL DEFAULT 1, -- Trạng thái
	
	ContestID int, -- Mã kỳ thi
	CONSTRAINT FK_REGISTERS_CONTEST FOREIGN KEY(ContestID) REFERENCES CONTESTS(ContestID),
	ContestantTypeID int,
	CONSTRAINT FK_REGISTERS_CONTESTANTTYPE FOREIGN KEY(ContestantTypeID) REFERENCES CONTESTANT_TYPES(ContestantTypeID)
)
GO
CREATE TABLE REGISTERS_SUBJECTS -- Đăng ký - Môn thi
(
	RegisterSubjectID int PRIMARY KEY IDENTITY,
	[Status] int NOT NULL DEFAULT 1,

	SubjectID int,
	CONSTRAINT FK_SUBJECTS_REGISTER FOREIGN KEY(SubjectID) REFERENCES SUBJECTS(SubjectID),
	RegisterID int,
	CONSTRAINT FK_REGISTERS_SUBJECT FOREIGN KEY(RegisterID) REFERENCES REGISTERS(RegisterID)
)
GO
CREATE TABLE RECEIPTS -- Phiếu thu
(
	ReceiptID int PRIMARY KEY IDENTITY,
	Cost float,
	ReceivedDate int,
	RegisterDate int,
	ReceiptType bit, -- Hình thức thu 1: ONLINE 0: OFFLINE
	[Status] int NOT NULL DEFAULT 1,

	StaffID int, -- Người thu tiền
	CONSTRAINT FK_RECEIPTS_STAFF FOREIGN KEY(StaffID) REFERENCES STAFFS(StaffID),
	RegisterID int,
	CONSTRAINT FK_RECEIPTS_REGISTER FOREIGN KEY(RegisterID) REFERENCES REGISTERS(RegisterID)
)
GO
-------------------------------- Hương - Hết hạn đăng ký --------------------------------
GO
CREATE TABLE CONTESTANTS -- Danh sách thí sinh + tài khoản
(
	ContestantID int PRIMARY KEY IDENTITY,
	ContestantCode varchar(20), -- Mã thí sinh dự thi (Được ch/tr tự động tạo sau khi đk hoàn tất)
	[Status] int NOT NULL DEFAULT 1,
	
	FullName nvarchar(50), -- Họ tên
	Birthday int, -- Ngày sinh
	Ethnic nvarchar(100), -- Dân tộc
	PlaceOfBirth nvarchar(MAX), -- Nơi sinh
	HighSchool nvarchar(MAX), -- Trường trung học
	Sex int, -- Giới tính
	IdentityCardNumber varchar(12), -- Số CMND
	Unit nvarchar(100), -- Đơn vị (lớp)
	CurrentAddress nvarchar(MAX), -- Địa chỉ hiện tại

 	ContestID int,
	CONSTRAINT UNIQUE_ContestantCode_ContestID UNIQUE (ContestID, ContestantCode),
	CONSTRAINT FK_CONTESTANTS_CONTEST FOREIGN KEY(ContestID) REFERENCES CONTESTS(ContestID)
)
GO
CREATE TABLE CONTESTANTS_SUBJECTS -- Thí sinh - Môn thi
(
	ContestantSubjectID int PRIMARY KEY IDENTITY,
	[Status] int NOT NULL DEFAULT 1,

	SubjectID int,
	CONSTRAINT FK_CONTESTANTS_SUBJECT FOREIGN KEY(SubjectID) REFERENCES SUBJECTS(SubjectID),
	ContestantID int,
	CONSTRAINT FK_SUBJECTS_CONTESTANT FOREIGN KEY(ContestantID) REFERENCES CONTESTANTS(ContestantID)
)
GO
CREATE TABLE FINGERPRINTS -- Vân tay : Hương + Luyến
(
	FingerprintID int PRIMARY KEY IDENTITY,
	FingerprintImage nvarchar(MAX), -- Nội dung ảnh
	FilePath nvarchar(MAX), -- Đường dẫn file ảnh
	DateSaveFingerprint int,
	TimeSaveFingerprint int,
	[Status] int NOT NULL DEFAULT 1,

	ContestantID int,
	CONSTRAINT FK_FINGERPRINTS_CONTESTANT FOREIGN KEY(ContestantID) REFERENCES CONTESTANTS(ContestantID)
)
GO
-------------------------------- Linh --------------------------------
GO
CREATE TABLE LOCATIONS -- Địa điểm thi
(
	LocationID int PRIMARY KEY IDENTITY,
	LocationName nvarchar(MAX),
	[Status] int NOT NULL DEFAULT 1,
	
	ContestID int,
	CONSTRAINT FK_LOCATIONS_CONTEST FOREIGN KEY(ContestID) REFERENCES CONTESTS(ContestID)
)
GO
CREATE TABLE ROOMTESTS -- Phòng thi
(
	RoomTestID int PRIMARY KEY IDENTITY,
	RoomTestName nvarchar(100),
	MaxSeatMount int, -- Số lượng chỗ ngồi tối đa
	MaxSupervisor int, -- Số lượng giám sát
	[Status] int NOT NULL DEFAULT 1,

	LocationID int,
	CONSTRAINT FK_ROOMTESTS_LOCATION FOREIGN KEY(LocationID) REFERENCES LOCATIONS(LocationID)
)
GO
CREATE TABLE SHIFTS -- Ca thi (chi tiết lịch thi)
(
	ShiftID int PRIMARY KEY IDENTITY,
	ShiftDate int, -- Ngày thi
	StartTime int, -- Thời gian bắt đầu
	EndTime int, -- Thời gian kết thúc

	ScheduleID int,
	CONSTRAINT FK_SHIFTS_SCHEDULE FOREIGN KEY(ScheduleID) REFERENCES SCHEDULES(ScheduleID)
)
GO
CREATE TABLE SHIFTS_STAFFS -- Bảng phân theo ca: giám thị, phòng thi
(
	DivisionShiftID int PRIMARY KEY IDENTITY,
	[Status] int NOT NULL DEFAULT 1,

	ShiftID int, -- Ca thi
	CONSTRAINT FK_STAFFS_SHIFT FOREIGN KEY(ShiftID) REFERENCES SHIFTS(ShiftID),
	StaffID int, -- Giám thị
	CONSTRAINT FK_SHIFTS_STAFF FOREIGN KEY(StaffID) REFERENCES STAFFS(StaffID),
	RoomTestID int, -- Phòng thi
	CONSTRAINT FK_SHIFTS_ROOMTEST FOREIGN KEY(RoomTestID) REFERENCES ROOMTESTS(RoomTestID)
)
GO
CREATE TABLE ROOMDIAGRAMS -- Sơ đồ phòng thi
(
	RoomDiagramID int PRIMARY KEY IDENTITY,
	ComputerCode varchar(50),
	ComputerName varchar(50),
	[Description] nvarchar(MAX),
	[Status] int NOT NULL DEFAULT 1,
	
	RoomTestID int,
	CONSTRAINT FK_ROOMDIAGRAMS_ROOMTEST FOREIGN KEY(RoomTestID) REFERENCES ROOMTESTS(RoomTestID)
)
GO
CREATE TABLE CONTESTANTS_SHIFTS -- Danh sách thi (theo ca)
(
	ContestantShiftID int PRIMARY KEY IDENTITY,
	ClientIP varchar(25), -- Địa chỉ IP
	[Status] int NOT NULL DEFAULT 1, -- Tình trạng đăng nhập: 1: chưa thi, 2: Đã đăng nhập, 3: Đang thi, 4: Đã thi xong ...
	ContestantPass varchar(20), -- Mật khẩu

	ShiftID int, -- Ca thi
	CONSTRAINT FK_CONTESTANTS_SHIFT FOREIGN KEY(ShiftID) REFERENCES SHIFTS(ShiftID),
	ContestantID int, -- Thí sinh
	CONSTRAINT FK_SHIFTS_CONTESTANT FOREIGN KEY(ContestantID) REFERENCES CONTESTANTS(ContestantID),
	RoomDiagramID int,
	CONSTRAINT FK_CONTESTANTS_ROOMDIAGRAM FOREIGN KEY(RoomDiagramID) REFERENCES ROOMDIAGRAMS(RoomDiagramID)
)
GO
-------------------------------- Kiên --------------------------------
GO
CREATE TABLE BAGOFTESTS -- Túi đề thi
(
	BagOfTestID int PRIMARY KEY IDENTITY,
	NumberOfTest int,

	ShiftID int,
	CONSTRAINT FK_BAGOFTESTS_SHIFT FOREIGN KEY(ShiftID) REFERENCES SHIFTS(ShiftID)
)
GO
CREATE TABLE TESTS -- Đề thi
(
	TestID int PRIMARY KEY IDENTITY,
	TestDate int,
	[Status] int NOT NULL DEFAULT 1,

	BagOfTestID int,
	CONSTRAINT FK_TESTS_BAGOFTEST FOREIGN KEY(BagOfTestID) REFERENCES BAGOFTESTS(BagOfTestID),
	StructureID int,
	CONSTRAINT FK_TESTS_STRUCTURE FOREIGN KEY(StructureID) REFERENCES STRUCTURES(StructureID)
)
GO
CREATE TABLE TEST_DETAIL -- Chi tiết đề thi
(
	TestDetailID int PRIMARY KEY IDENTITY,
	RandomAnswer varchar(200), -- Chuỗi đảo đáp án, ex: 'AnswerID1,AnswerID2,AnswerID3,...'
	NumberIndex int, -- Thứ tự câu hỏi: 1, 2, 3, 4, ...

	TestID int,
	CONSTRAINT FK_TESTDETAIL_TEST FOREIGN KEY(TestID) REFERENCES TESTS(TestID),
	QuestionID int,
	CONSTRAINT FK_TESTDETAIL_QUESTION FOREIGN KEY(QuestionID) REFERENCES QUESTIONS(QuestionID)
)
GO
CREATE TABLE CONTESTANTS_TESTS -- Mã đề của thí sinh (khởi tạo ngay trước khi bắt đầu thi)
(
	ContestantTestID int PRIMARY KEY IDENTITY,

	ContestantID int,
	CONSTRAINT FK_CONTESTANTS_TEST FOREIGN KEY(ContestantID) REFERENCES CONTESTANTS(ContestantID),
	TestID int,
	CONSTRAINT FK_TESTS_CONTESTANT FOREIGN KEY(TestID) REFERENCES TESTS(TestID)
)
GO
CREATE TABLE ANSWERSHEETS -- Bài thi
(
	AnswerSheetID int PRIMARY KEY IDENTITY,
	AnswerContent varchar(MAX), -- Chuỗi câu hỏi, trả lời, ex: '1,A.2,B.3,D.'
	TestScores float, -- Điểm trắc nghiệm
	EssayPoints float, -- Điểm tự luận
	[Status] int NOT NULL DEFAULT 1,
	
	ContestantID int,
	CONSTRAINT FK_ANSWERSHEETS_CONTESTANT FOREIGN KEY(ContestantID) REFERENCES CONTESTANTS(ContestantID),
	TestID int, -- Đề thi
	CONSTRAINT FK_ANSWERSHEETS_TEST FOREIGN KEY(TestID) REFERENCES TESTS(TestID),
	StaffID int, -- Người chấm
	CONSTRAINT FK_ANSWERSHEETS_STAFF FOREIGN KEY(StaffID) REFERENCES STAFFS(StaffID)
)
GO
CREATE TABLE ANSWERSHEET_DETAIL -- Chi tiết bài thi
(
	AnswerSheetDetailID int PRIMARY KEY IDENTITY,
	AnswerSheetDetailContent varchar(MAX),
	LastTime int, -- Thời gian cuối cùng chọn đáp án (tính theo giây)

	AnswerSheetID int,
	CONSTRAINT FK_ANSWERSHEETDETAIL_ANSWERSHEET FOREIGN KEY(AnswerSheetID) REFERENCES ANSWERSHEETS(AnswerSheetID),
	TestDetailID int,
	CONSTRAINT FK_ANSWERSHEETDETAIL_TESTDETAIL FOREIGN KEY(TestDetailID) REFERENCES TEST_DETAIL(TestDetailID)
)
GO
-------------------------------- Luyến --------------------------------
GO
CREATE TABLE VIOLATION_TYPES -- Loại vi phạm
(
	ViolationTypeID int PRIMARY KEY IDENTITY,
	ViolationName nvarchar(100),
	[Description] nvarchar(MAX),
	[Level] int,
	[Status] int NOT NULL DEFAULT 1
)
GO
CREATE TABLE VIOLATIONS_CONTESTANTS -- Thí sinh vi phạm
(
	ViolationDetailID int PRIMARY KEY IDENTITY,
	[Status] int NOT NULL DEFAULT 1,

	ViolationTypeID int,
	CONSTRAINT FK_VIOLATIONS_VIOLATIONTYPE FOREIGN KEY (ViolationTypeID) REFERENCES VIOLATION_TYPES(ViolationTypeID),
	ContestantShiftID int,
	CONSTRAINT FK_VIOLATIONS_CONTESTTANT FOREIGN KEY (ContestantShiftID) REFERENCES CONTESTANTS_SHIFTS(ContestantShiftID)
)
GO
-------------------------------- INSERT --------------------------------
GO
INSERT INTO DEPARTMENTS(DepartmentCode, DepartmentName, [Level], [Status]) VALUES
	(N'ROOT', N'ROOT', 1, 1)
GO
INSERT INTO POSITIONS(PositionCode, PositionName, Permission, [Status]) VALUES
	(N'ADMIN', N'ADMIN', 1, 1)
GO
INSERT INTO STAFFS(Username, [Password], Fullname, Birthday, Sex, IdentityCardNumber, PositionID, DepartmentID) VALUES
	('ADMIN', '123456', N'Cán bộ', 1000, 1, '123456789', 1, 1)
GO
INSERT INTO SUBJECTS(SubjectCode, SubjectName, DepartmentID) VALUES
	('12121212', N'Môn Toán', 1),
	('12121213', N'Môn Lý', 1),
	('12121214', N'Môn Hóa', 1)
GO
INSERT INTO CONTEST_TYPES(ContestTypeName) VALUES
	(N'Trắc nghiệm'),
	(N'Tự luận')
GO
INSERT INTO TOPICS(TopicName, [Description], SubjectID) VALUES
	(N'Chủ đề 1', N'Toán cao cấp', 1),
	(N'Chủ đề 2', N'Toán trung cấp', 1),
	(N'Chủ đề 3', N'Toán sơ cấp', 1)
GO
INSERT INTO TOPICS(TopicName, [Description], SubjectID) VALUES
	(N'Chủ đề 1', N'Lý cao cấp', 2),
	(N'Chủ đề 2', N'Lý trung cấp', 2),
	(N'Chủ đề 3', N'Lý sơ cấp', 2)
GO
INSERT INTO TOPICS(TopicName, [Description], SubjectID) VALUES
	(N'Chủ đề 1', N'Hóa cao cấp', 3),
	(N'Chủ đề 2', N'Hóa trung cấp', 3),
	(N'Chủ đề 3', N'Hóa sơ cấp', 3)
GO