create table Amenities(
   AmenityId int primary key identity(1,1),
   AmenityName varchar(100),
   AmenityDescription varchar(100),
   AmenityCategory varchar(100)
)

INSERT INTO amenities (AmenityName, AmenityDescription, AmenityCategory)
VALUES
    ('Swimming Pool', 'Enjoy a refreshing swim in our luxurious pool.', 'Leisure'),
    ('Spa', 'Indulge in rejuvenating spa treatments to relax and unwind.', 'Wellness'),
    ('Fine Dining Restaurant', 'Experience exquisite dining with our gourmet cuisine.', 'Dining'),
    ('Sport Courts', 'Play different kinds of sports on our well-maintained courts with beautiful views.', 'Leisure'),
    ('Concierge Service', 'Our dedicated concierge team is available to assist with all your needs.', 'Services'),
    ('Deluxe Room', 'Experience luxury and comfort in our deluxe accommodation.', 'Accommodation'),
    ('Suite with Ocean View', 'Enjoy breathtaking ocean views from our spacious suites.', 'Accommodation'),
    ('Private Villa', 'Indulge in privacy and luxury with our exclusive private villa.', 'Accommodation');

select * from Amenities

CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY identity(1,1),
    RoomName VARCHAR(100),
    RoomDescription VARCHAR(100), 
    Price DECIMAL(10, 2),
    Available BIT
);

INSERT INTO Rooms(RoomName, RoomDescription, Price, Available) 
VALUES 
    ('Deluxe Room', 'Experience luxury and comfort in our deluxe accommodation.', 10000, 1),
    ('Suite with Ocean View', 'Enjoy breathtaking ocean views from our spacious suites.', 15000, 1),
    ('Private Villa', 'Indulge in privacy and luxury with our exclusive private villa.', 20000, 0);

SELECT * FROM Rooms;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY identity(1,1),
    CustomerName VARCHAR(100),
    CustomerPhoneNumber bigint, 
    CustomerCheckIn varchar(100),
    CustomerCheckOut varchar(100)
);
insert into Customers(CustomerName,CustomerPhoneNumber,CustomerCheckIn,CustomerCheckOut)
values('Ashi',9654873289,'2024-06-01','2024-06-03')
create table LoginView(
    Id int primary key identity(1,1),
    Username varchar(100),
	Password varchar(100),
	Role varchar(100)
)
select * from LoginView
insert into LoginView(Username,Password,Role)
values('admin','admin123','admin')
drop table LoginView

create table Employee(
   EmployeeId int primary key identity(1,1),
   EmployeeName varchar(100),
   EmployeePhoneNumber bigint,
   EmployeeDesignation varchar(100)
)

