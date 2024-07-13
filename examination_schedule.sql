CREATE DATABASE SWD392_ClinicSchedule;

USE SWD392_ClinicSchedule;

CREATE TABLE [User](
	username VARCHAR(100) PRIMARY KEY,
	[password] VARCHAR(50),
	firstName NVARCHAR(100),
	lastName NVARCHAR(100),
	email VARCHAR(100),
	gender BIT,
	dob DATE,
	phoneNumber VARCHAR(10),
	[role] VARCHAR(50)
);

CREATE TABLE TimeSlot (
    id INT PRIMARY KEY,
    startTime TIME,
    endTime TIME
);

CREATE TABLE Department (
    deptId INT PRIMARY KEY,
    deptName NVARCHAR(255)
);

CREATE TABLE Room (
    roomId INT PRIMARY KEY,
    roomName NVARCHAR(255),
    description NVARCHAR(255)
);

CREATE TABLE Patient(
	username VARCHAR(100) FOREIGN KEY REFERENCES [User](username),
	patientId VARCHAR(50) PRIMARY KEY ,
	medicalRecord VARCHAR(500)
);

CREATE TABLE Doctor(
	username VARCHAR(100) FOREIGN KEY REFERENCES [User](username),
	doctorId VARCHAR(50) PRIMARY KEY,
	license VARCHAR(500),
	deptId INT FOREIGN KEY REFERENCES Department(deptId)
);

CREATE TABLE Staff(
	username VARCHAR(100) FOREIGN KEY REFERENCES [User](username),
	staffId VARCHAR(50) PRIMARY KEY
);

CREATE TABLE [Event](
	eventId INT PRIMARY KEY IDENTITY(1, 1),
	doctorId VARCHAR(50) NULL FOREIGN KEY REFERENCES Doctor(doctorId),
	patientId VARCHAR(50) NULL FOREIGN KEY REFERENCES Patient(patientId),
	staffId VARCHAR(50) NULL FOREIGN KEY REFERENCES Staff(staffId),
	roomId INT NULL FOREIGN KEY REFERENCES Room(roomId),
	timeSlotId INT NOT NULL FOREIGN KEY REFERENCES TimeSlot(id),
	[date] DATE NOT NULL,
	eventType VARCHAR(50) NULL,
	[status] VARCHAR(50) NULL,
	[description] NVARCHAR(500) NULL
);

/*
DROP TABLE [Event];
DROP TABLE Patient;
DROP TABLE Doctor;
DROP TABLE Staff;
DROP TABLE TimeSlot;
DROP TABLE Room;
DROP TABLE Department;
DROP TABLE [User];
*/


------------------------------- Insert -------------------------------

-- TimeSlot
INSERT INTO TimeSlot (id, startTime, endTime)
VALUES (1, '08:00:00', '09:00:00');
INSERT INTO TimeSlot (id, startTime, endTime)
VALUES (2, '09:00:00', '10:00:00');
INSERT INTO TimeSlot (id, startTime, endTime)
VALUES (3, '10:00:00', '11:00:00');
INSERT INTO TimeSlot (id, startTime, endTime)
VALUES (4, '11:00:00', '12:00:00');
INSERT INTO TimeSlot (id, startTime, endTime)
VALUES (5, '13:00:00', '14:00:00');
INSERT INTO TimeSlot (id, startTime, endTime)
VALUES (6, '14:00:00', '15:00:00');
INSERT INTO TimeSlot (id, startTime, endTime)
VALUES (7, '15:00:00', '16:00:00');
INSERT INTO TimeSlot (id, startTime, endTime)
VALUES (8, '16:00:00', '17:00:00');

-- Department
INSERT INTO Department (deptID, deptName)
VALUES (1, N'Khoa Ngoại');
INSERT INTO Department (deptID, deptName)
VALUES (2, N'Khoa Nhi');
INSERT INTO Department (deptID, deptName)
VALUES (3, N'Khoa Phẫu thuật');
INSERT INTO Department (deptID, deptName)
VALUES (4, N'Khoa Sản');
INSERT INTO Department (deptID, deptName)
VALUES (5, N'Khoa Tim mạch');

-- Room
INSERT INTO Room (roomID, roomName, description)
VALUES (101, N'Phòng khám chính', N'Phòng khám cho bác sĩ chẩn đoán ban đầu');
INSERT INTO Room (roomID, roomName, description)
VALUES (102, N'Phòng Xét nghiệm', N'Phòng thực hiện các xét nghiệm và kiểm tra sàng lọc');
INSERT INTO Room (roomID, roomName, description)
VALUES (103, N'Phòng Mổ', N'Phòng tiến hành các ca phẫu thuật');
INSERT INTO Room (roomID, roomName, description)
VALUES (104, N'Phòng Hồi sức', N'Phòng chăm sóc và theo dõi bệnh nhân sau phẫu thuật hoặc suy tim');
INSERT INTO Room (roomID, roomName, description)
VALUES (105, N'Phòng Điều trị', N'Phòng cung cấp điều trị y tế và dược phẩm');
INSERT INTO Room (roomID, roomName, description)
VALUES (106, N'Phòng Cảm mạo', N'Phòng triển khai các chương trình cảm mạo và tiêm vắc xin');
INSERT INTO Room (roomID, roomName, description)
VALUES (107, N'Phòng X-quang', N'Phòng thực hiện chụp X-quang và các loại hình chụp hình khác');
INSERT INTO Room (roomID, roomName, description)
VALUES (108, N'Phòng Tư vấn', N'Phòng cung cấp dịch vụ tư vấn và hướng dẫn cho bệnh nhân');
INSERT INTO Room (roomID, roomName, description)
VALUES (109, N'Phòng Điều dưỡng', N'Phòng chăm sóc và theo dõi bệnh nhân hàng ngày');
INSERT INTO Room (roomID, roomName, description)
VALUES (110, N'Phòng Chờ', N'Phòng chờ đợi và tiếp đón bệnh nhân nhập viện và đặt lịch hẹn');

-- User
	-- Doctors
insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('johnsmith', '123456', 'John', 'Smith', 'johnsmith@gmail.com', 0, '1980-01-15', '0123456789', 'Doctor');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('janedoe', '123456', 'Jane', 'Doe', 'janedoe@gmail.com', 1, '1985-05-23', '0123456789', 'Doctor');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('paulwhite', '123456', 'Paul', 'White', 'paulwhite@gmail.com', 0, '1979-03-12', '0123456789', 'Doctor');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('saramiller', '123456', 'Sara', 'Miller', 'saramiller@gmail.com', 1, '1990-11-30', '0123456789', 'Doctor');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('davidjohnson', '123456', 'David', 'Johnson', 'davidjohnson@gmail.com', 0, '1982-08-21', '0123456789', 'Doctor');

	-- Staff
insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('alicebrown', '123456', 'Alice', 'Brown', 'alicebrown@gmail.com', 1, '1991-02-18', '0123456789', 'Staff');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('bobmartin', '123456', 'Bob', 'Martin', 'bobmartin@gmail.com', 0, '1987-07-10', '0123456789', 'Staff');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('caroldavis', '123456', 'Carol', 'Davis', 'caroldavis@gmail.com', 1, '1993-04-05', '0123456789', 'Staff');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('danielwilson', '123456', 'Daniel', 'Wilson', 'danielwilson@gmail.com', 0, '1989-06-25', '0123456789', 'Staff');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('evamartinez', '123456', 'Eva', 'Martinez', 'evamartinez@gmail.com', 1, '1994-09-15', '0123456789', 'Staff');

	-- Patients
insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('michaelbrown', '123456', 'Michael', 'Brown', 'michaelbrown@gmail.com', 0, '1996-01-10', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('lucyjones', '123456', 'Lucy', 'Jones', 'lucyjones@gmail.com', 1, '1998-03-22', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('jameswilliams', '123456', 'James', 'Williams', 'jameswilliams@gmail.com', 0, '1995-05-14', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('emilydavis', '123456', 'Emily', 'Davis', 'emilydavis@gmail.com', 1, '1994-08-27', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('michaelsmith', '123456', 'Michael', 'Smith', 'michaelsmith@gmail.com', 0, '1990-12-01', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('sophiewilson', '123456', 'Sophie', 'Wilson', 'sophiewilson@gmail.com', 1, '1997-06-18', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('davidmartinez', '123456', 'David', 'Martinez', 'davidmartinez@gmail.com', 0, '1993-04-05', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('oliviajohnson', '123456', 'Olivia', 'Johnson', 'oliviajohnson@gmail.com', 1, '1999-09-12', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('williamrodriguez', '123456', 'William', 'Rodriguez', 'williamrodriguez@gmail.com', 0, '1992-07-24', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('isabellagarcia', '123456', 'Isabella', 'Garcia', 'isabellagarcia@gmail.com', 1, '1991-11-08', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('madageca', '123456', 'Madace', 'Geca', 'madageca@gmail.com', 1, '1991-11-08', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('whoAmi', '123456', 'whoAmi', 'whoAmi', 'whoAmi@gmail.com', 1, '1991-11-08', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('alexandermiller', '123456', 'Alexander', 'Miller', 'alexandermiller@gmail.com', 0, '1994-02-15', '0123456789', 'Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('markhenry', '123456', 'Mark', 'Henry', 'markhenry@gmail.com', 0, '1996-12-03','0123456789','Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('hellinda', '123456', 'Heli', 'Linda', 'helinda@gmail.com', 1, '1993-12-03','0123456789','Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('peterLand', '123456', 'Land', 'Peter', 'landPeter@gmail.com', 0, '1992-12-03','0123456789','Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('weimake', '123456', 'Wei', 'Make', 'weiMake@gmail.com', 0, '1992-12-03','0123456789','Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('poPio', '123456', 'Pop', 'Boy', 'popPio@gmail.com', 1, '1992-12-03','0123456789','Patient');

insert into [User](username, [password], firstName, lastName, email, gender, dob, phoneNumber, [role])
values ('arianDe', '123456', 'Arian', 'De', 'arianDe@gmail.com', 1, '1992-12-03','0123456789','Patient');

-- Patient
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('williamrodriguez', 'P001', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('whoAmi', 'P002', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('weimake', 'P003', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('sophiewilson', 'P004', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('poPio', 'P005', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('peterLand', 'P006', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('oliviajohnson', 'P007', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('michaelsmith', 'P008', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('michaelbrown', 'P009', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('markhenry', 'P0010', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('madageca', 'P0011', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('lucyjones', 'P0012', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('jameswilliams', 'P0013', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('isabellagarcia', 'P0014', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('hellinda', 'P0015', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('emilydavis', 'P0016', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('davidmartinez', 'P0017', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('arianDe', 'P0018', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');
INSERT INTO Patient(username, patientId, medicalRecord) VALUES ('alexandermiller', 'P0019', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d');

-- Doctor
INSERT INTO Doctor(username, doctorId, license, deptId) VALUES ('davidjohnson', 'D001', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d', 1);
INSERT INTO Doctor(username, doctorId, license, deptId) VALUES ('janedoe', 'D002', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d', 2);
INSERT INTO Doctor(username, doctorId, license, deptId) VALUES ('johnsmith', 'D003', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d', 3);
INSERT INTO Doctor(username, doctorId, license, deptId) VALUES ('paulwhite', 'D004', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d', 4);
INSERT INTO Doctor(username, doctorId, license, deptId) VALUES ('saramiller', 'D005', 'https://drive.google.com/drive/folders/1yg3XlnCT2r83s0fmv9A2G2NLEOsRI28d', 5);

-- Staff
INSERT INTO Staff(username, staffId) VALUES ('alicebrown', 'S001');
INSERT INTO Staff(username, staffId) VALUES ('bobmartin', 'S002');
INSERT INTO Staff(username, staffId) VALUES ('caroldavis', 'S003');
INSERT INTO Staff(username, staffId) VALUES ('danielwilson', 'S004');
INSERT INTO Staff(username, staffId) VALUES ('evamartinez', 'S005');

-- Event
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D001', 'P001', 'S001', 101, 1, '2024-07-17', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], [status], eventType, description) VALUES
('D001', 'P002', 'S001', 101, 2, '2024-07-18', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D001', 'P003', 'S001', 101, 3, '2024-07-16', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D005', 'P004', 'S001', 101, 4, '2024-07-19', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D005', 'P005', 'S002', 101, 5, '2024-07-21', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D005', 'P006', 'S002', 101, 6, '2024-07-15', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D005', 'P007', 'S002', 101, 7, '2024-07-17', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D004', 'P008', 'S002', 101, 8, '2024-07-18', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D004', 'P009', 'S003', 101, 1, '2024-07-19', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D004', 'P0010', 'S003', 101, 2, '2024-07-20', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D004', 'P0011', 'S003', 101, 3, '2024-07-21', 'Appointment', 'Approved', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D004', 'P0012', 'S003', 101, 4, '2024-07-20', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D002', 'P0013', 'S004', 101, 5, '2024-07-18', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D002', 'P0014', 'S004', 101, 6, '2024-07-19', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D002', 'P0015', 'S004', 101, 7, '2024-07-17', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D002', 'P0016', 'S004', 101, 8, '2024-07-21', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D002', 'P0017', 'S005', 101, 1, '2024-07-18', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D003', 'P0018', 'S005', 101, 2, '2024-07-19', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D003', 'P0019', 'S005', 101, 3, '2024-07-20', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D003', 'P002', 'S005', 101, 4, '2024-07-21', 'Appointment', 'Pending', null);
INSERT INTO [Event](doctorId, patientId, staffId, roomId, timeSlotId, [date], eventType, [status], description) VALUES
('D003', 'P003', 'S005', 101, 5, '2024-07-19', 'Appointment', 'Pending', null);

-- SELECT 
/*
SELECT * FROM [Event];
SELECT * FROM Patient;
SELECT * FROM Doctor;
SELECT * FROM Staff;
SELECT * FROM TimeSlot;
SELECT * FROM Room;
SELECT * FROM Department;
SELECT * FROM [User];
*/

select * from [Event] where [date] between '2024-07-12' and '2024-07-19'
and [status] = 'Pending'