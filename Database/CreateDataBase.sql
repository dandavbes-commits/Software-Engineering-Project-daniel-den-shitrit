-- GymTime - מערכת הזמנת שיעורים לחדר כושר
-- סקריפט יצירת מסד הנתונים

IF DB_ID('GymTimeDB') IS NOT NULL
BEGIN
    ALTER DATABASE GymTimeDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE GymTimeDB;
END
GO

CREATE DATABASE GymTimeDB;
GO

USE GymTimeDB;
GO


-- סוגי השיעורים שהמכון מציע
CREATE TABLE ClassTypes
(
    TypeID          INT             NOT NULL IDENTITY(1,1),
    TypeName        NVARCHAR(50)    NOT NULL,
    TypeDescription NVARCHAR(200)   NULL,
    DurationMinutes INT             NOT NULL,

    CONSTRAINT PK_ClassTypes PRIMARY KEY (TypeID),
    CONSTRAINT UQ_ClassTypes_Name UNIQUE (TypeName),
    CONSTRAINT CK_ClassTypes_Duration CHECK (DurationMinutes BETWEEN 15 AND 120)
);
GO


-- כל המשתמשים. IsManager קובע אם זה מנהל או לקוח
CREATE TABLE Clients
(
    ClientID     INT            NOT NULL IDENTITY(1,1),
    FullName     NVARCHAR(60)   NOT NULL,
    Phone        NVARCHAR(15)   NOT NULL,
    Email        NVARCHAR(80)   NULL,
    UserName     NVARCHAR(30)   NOT NULL,
    UserPassword NVARCHAR(64)   NOT NULL,   -- SHA256 ולא טקסט גלוי
    IsManager    BIT            NOT NULL,
    JoinDate     DATE           NOT NULL,

    CONSTRAINT PK_Clients PRIMARY KEY (ClientID),
    CONSTRAINT UQ_Clients_UserName UNIQUE (UserName)
);
GO


-- כל שורה היא שיעור אחד בתאריך ובשעה מסוימים
CREATE TABLE Classes
(
    ClassID         INT            NOT NULL IDENTITY(1,1),
    TypeID          INT            NOT NULL,
    TrainerName     NVARCHAR(60)   NOT NULL,
    ClassDate       DATE           NOT NULL,
    StartTime       TIME(0)        NOT NULL,
    MaxParticipants INT            NOT NULL,
    RoomName        NVARCHAR(30)   NOT NULL,
    IsCancelled     BIT            NOT NULL,

    CONSTRAINT PK_Classes PRIMARY KEY (ClassID),
    CONSTRAINT FK_Classes_ClassTypes FOREIGN KEY (TypeID)
        REFERENCES ClassTypes(TypeID),
    CONSTRAINT CK_Classes_Max CHECK (MaxParticipants BETWEEN 1 AND 60),
    -- שני שיעורים לא יכולים להיות באותו אולם באותו זמן
    CONSTRAINT UQ_Classes_Room UNIQUE (ClassDate, StartTime, RoomName)
);
GO


-- טבלת הקישור. הקשר בין לקוחות לשיעורים הוא רבים לרבים
CREATE TABLE Bookings
(
    BookingID   INT           NOT NULL IDENTITY(1,1),
    ClientID    INT           NOT NULL,
    ClassID     INT           NOT NULL,
    BookingDate DATETIME      NOT NULL,
    Status      NVARCHAR(10)  NOT NULL,

    CONSTRAINT PK_Bookings PRIMARY KEY (BookingID),
    CONSTRAINT FK_Bookings_Clients FOREIGN KEY (ClientID)
        REFERENCES Clients(ClientID),
    CONSTRAINT FK_Bookings_Classes FOREIGN KEY (ClassID)
        REFERENCES Classes(ClassID),
    CONSTRAINT CK_Bookings_Status CHECK (Status IN (N'ממתין', N'אושר', N'בוטל')),
    -- מונע רישום כפול של אותו לקוח לאותו שיעור
    CONSTRAINT UQ_Bookings_ClientClass UNIQUE (ClientID, ClassID)
);
GO


CREATE INDEX IX_Classes_Date ON Classes(ClassDate);
CREATE INDEX IX_Bookings_ClassID ON Bookings(ClassID);
GO


-- ================= נתוני התחלה =================

INSERT INTO ClassTypes (TypeName, TypeDescription, DurationMinutes) VALUES
(N'ספינינג',   N'אימון אופניים קבוצתי בעצימות גבוהה',      45),
(N'יוגה',      N'מתיחות, נשימות ואיזון',                    60),
(N'TRX',       N'אימון כוח עם רצועות נגד משקל הגוף',        45),
(N'זומבה',     N'אימון אירובי לצלילי מוזיקה לטינית',        50),
(N'פילאטיס',   N'חיזוק שרירי הליבה ושיפור היציבה',          60);
GO

-- הסיסמאות הן SHA256 של מה שכתוב בהערה
INSERT INTO Clients (FullName, Phone, Email, UserName, UserPassword, IsManager, JoinDate) VALUES
-- Aa123456
(N'דניאל בן שטרית', N'050-1112222', N'daniel@gymtime.co.il', N'admin',
 N'C4318372F98F4C46ED3A32C16EE4D7A76C832886D887631C0294B3314F34EDF1', 1, '2025-09-01'),
-- 123456
(N'דנה כהן',        N'052-3334444', N'dana@gmail.com',        N'dana',
 N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 0, '2025-09-10'),
(N'ליאור בן שטרית', N'054-5556666', N'lior@gmail.com',        N'lior',
 N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 0, '2025-10-02'),
(N'אראל בן שטרית',  N'053-7778888', N'erel@gmail.com',        N'erel',
 N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 0, '2025-11-15'),
(N'אופיר בן שטרית', N'058-9990000', N'ofir@gmail.com',        N'ofir',
 N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 0, '2026-01-20');
GO

INSERT INTO Classes (TypeID, TrainerName, ClassDate, StartTime, MaxParticipants, RoomName, IsCancelled) VALUES
(1, N'אור כהן',     '2026-08-16', '18:00', 12, N'אולם אופניים', 0),
(2, N'עידן אזולאי', '2026-08-16', '20:00', 15, N'אולם ראשי',    0),
(3, N'אבי לוי',     '2026-08-17', '17:30',  8, N'אולם ראשי',    0),
(4, N'יעל שמעוני',  '2026-08-17', '19:00', 20, N'אולם ראשי',    0),
(1, N'רון מזרחי',   '2026-08-18', '18:00', 12, N'אולם אופניים', 0),
(5, N'נועה פרץ',    '2026-08-18', '09:00', 10, N'אולם קטן',     0);
GO

INSERT INTO Bookings (ClientID, ClassID, BookingDate, Status) VALUES
(2, 1, '2026-08-12 10:15', N'אושר'),
(3, 1, '2026-08-12 11:40', N'אושר'),
(4, 2, '2026-08-12 12:05', N'ממתין'),
(5, 2, '2026-08-12 12:30', N'אושר'),
(2, 3, '2026-08-12 13:20', N'ממתין'),
(3, 4, '2026-08-12 14:00', N'בוטל'),
(5, 1, '2026-08-12 15:10', N'ממתין');
GO

PRINT N'מסד הנתונים GymTimeDB נוצר בהצלחה';
GO
